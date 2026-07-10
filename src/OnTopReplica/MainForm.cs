using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using OnTopReplica.Native;
using OnTopReplica.Properties;
using OnTopReplica.StartupOptions;
using OnTopReplica.WindowSeekers;
using WindowsFormsAero.Dwm;
using WindowsFormsAero.TaskDialog;

namespace OnTopReplica {

    partial class MainForm : AspectRatioForm {

        //GUI elements
        ThumbnailPanel _thumbnailPanel;

        //Multi-panel support: secondary panels always clone the primary's source window
        MainForm _primaryPanel; //null on the primary panel itself
        readonly List<MainForm> _childPanels = new List<MainForm>();
        //True while restoring or shutting down (primary only). Starts true so that
        //startup option side effects (e.g. chrome changes) cannot overwrite the
        //layout file before it has been restored; cleared at the end of OnShown.
        bool _suppressLayoutSave = true;
        internal static bool ApplicationExiting; //set when "Exit program" terminates all panels

        //Registry of all open panel windows. Do NOT use Application.OpenForms for
        //lifetime tracking: forms silently disappear from it when their handle is
        //recreated (e.g. on ShowInTaskbar changes during primary promotion).
        static readonly List<MainForm> _openPanels = new List<MainForm>();

        /// <summary>
        /// Saves the panel layout immediately. Call whenever a layout-relevant
        /// setting changes (panels added/removed/moved, region, source window,
        /// color alert settings). No-op while restoring or shutting down.
        /// </summary>
        public void NotifyPanelLayoutChanged() {
            var primary = _primaryPanel ?? this;
            if (primary._suppressLayoutSave || primary.IsDisposed)
                return;
            PanelLayoutManager.Save(primary, primary._childPanels);
        }

        /// <summary>
        /// Gets whether this window is a secondary panel added via "Add panel".
        /// Secondary panels follow the primary panel's cloned window.
        /// </summary>
        public bool IsSecondaryPanel {
            get { return _primaryPanel != null; }
        }

        /// <summary>
        /// Gets the secondary panels bound to this (primary) panel.
        /// </summary>
        internal IEnumerable<MainForm> ChildPanels {
            get { return _childPanels; }
        }

        /// <summary>
        /// Gets the primary panel of this window's panel set (itself if primary).
        /// </summary>
        internal MainForm PrimaryPanel {
            get { return _primaryPanel ?? this; }
        }

        /// <summary>
        /// Gets the current primary panel, resolving promotions. Null when no
        /// panel is open (i.e. during shutdown).
        /// </summary>
        internal static MainForm CurrentPrimary {
            get {
                foreach (var panel in _openPanels) {
                    if (!panel.IsDisposed && !panel.IsSecondaryPanel)
                        return panel;
                }
                return null;
            }
        }

        /// <summary>
        /// Enables click forwarding on the whole panel set.
        /// </summary>
        public void EnableClickForwardingAllPanels() {
            var primary = _primaryPanel ?? this;

            //Confirm (at most) once for the whole panel set, instead of once per panel
            if (!primary.ConfirmFirstTimeClickForwarding())
                return;

            primary.ClickForwardingEnabled = true;
            foreach (var child in primary._childPanels) {
                if (!child.IsDisposed) {
                    child.ClickForwardingEnabled = true;
                }
            }
        }

        /// <summary>
        /// Disables click forwarding on the whole panel set.
        /// </summary>
        public void DisableClickForwardingAllPanels() {
            var primary = _primaryPanel ?? this;
            primary.ClickForwardingEnabled = false;
            foreach (var child in primary._childPanels) {
                if (!child.IsDisposed) {
                    child.ClickForwardingEnabled = false;
                }
            }
        }

        /// <summary>
        /// Enables click-through mode on the whole panel set.
        /// </summary>
        public void EnableClickThroughAllPanels() {
            var primary = _primaryPanel ?? this;

            //Confirm (at most) once for the whole panel set, instead of once per panel
            if (!primary.ConfirmFirstTimeClickThrough())
                return;

            primary.ClickThroughEnabled = true;
            foreach (var child in primary._childPanels) {
                if (!child.IsDisposed) {
                    child.ClickThroughEnabled = true;
                }
            }
        }

        /// <summary>
        /// Disables click-through mode on the whole panel set.
        /// </summary>
        public void DisableClickThroughAllPanels() {
            var primary = _primaryPanel ?? this;
            primary.ClickThroughEnabled = false;
            foreach (var child in primary._childPanels) {
                if (!child.IsDisposed) {
                    child.ClickThroughEnabled = false;
                }
            }
        }

        /// <summary>
        /// Pauses or resumes color alert detection on the whole panel set.
        /// The Enabled setting of each panel is preserved.
        /// </summary>
        public void SetColorAlertPausedAllPanels(bool paused) {
            var primary = _primaryPanel ?? this;
            SetColorAlertPaused(primary, paused);
            foreach (var child in primary._childPanels) {
                if (!child.IsDisposed) {
                    SetColorAlertPaused(child, paused);
                }
            }
        }

        /// <summary>
        /// Gets whether color alert detection is currently paused for the panel set
        /// (the primary panel's state is used as representative).
        /// </summary>
        public bool IsColorAlertPausedAllPanels {
            get {
                var primary = _primaryPanel ?? this;
                try {
                    return primary.MessagePumpManager.Get<MessagePumpProcessors.ColorDetectionProcessor>().Paused;
                }
                catch {
                    return false;
                }
            }
        }

        static void SetColorAlertPaused(MainForm panel, bool paused) {
            try {
                var proc = panel.MessagePumpManager.Get<MessagePumpProcessors.ColorDetectionProcessor>();
                proc.Paused = paused;
            }
            catch { }
            panel.UpdateColorAlertIndicator();
        }

        ColorAlertIndicatorWindow _colorAlertIndicator;

        /// <summary>
        /// 開いている全パネルの●インジケーターを更新する。
        /// 設定パネルでインジケーター関連の設定が変更されたときに呼び出す。
        /// </summary>
        public static void UpdateAllColorAlertIndicators() {
            foreach (var panel in _openPanels) {
                if (!panel.IsDisposed) panel.UpdateColorAlertIndicator();
            }
        }

        /// <summary>
        /// カラーアラートの実行状態に応じて、パネル右上の●インジケーターの
        /// 表示/非表示と位置を更新する。UI スレッドから呼び出すこと。
        /// </summary>
        public void UpdateColorAlertIndicator() {
            if (IsDisposed || !IsHandleCreated) return;
            if (!_managersInitialized) return; //ハンドル作成前の OnLocationChanged 等に備えるガード

            bool show;
            bool paused = false;
            try {
                var proc = MessagePumpManager.Get<MessagePumpProcessors.ColorDetectionProcessor>();
                show = proc.Enabled;
                paused = proc.Paused;
            }
            catch {
                show = false;
            }
            show &= Properties.Settings.Default.ColorAlertIndicatorEnabled;
            show &= Visible && WindowState != FormWindowState.Minimized;

            if (show) {
                if (_colorAlertIndicator == null || _colorAlertIndicator.IsDisposed) {
                    _colorAlertIndicator = new ColorAlertIndicatorWindow {
                        Owner = this //オーナー付きにすることで TopMost なしで常にこのパネルの直上に保たれる
                    };
                }
                //実行中/一時停止中の色とサイズは設定から反映する
                _colorAlertIndicator.DotSize = Properties.Settings.Default.ColorAlertIndicatorSize;
                _colorAlertIndicator.DotColor = paused
                    ? Properties.Settings.Default.ColorAlertIndicatorPausedColor
                    : Properties.Settings.Default.ColorAlertIndicatorRunningColor;
                _colorAlertIndicator.UpdatePosition(this);
                if (!_colorAlertIndicator.Visible) {
                    _colorAlertIndicator.Show();
                }
                //オーナー(このパネル)が TopMost の場合、オーナー付きウィンドウが
                //TopMost バンドに入らず下に潜ることがあるため、常に状態を同期して
                //パネルの直上に保つ。
                if (_colorAlertIndicator.TopMost != TopMost) {
                    _colorAlertIndicator.TopMost = TopMost;
                }
                _colorAlertIndicator.EnsureAbove(this);
            }
            else if (_colorAlertIndicator != null && !_colorAlertIndicator.IsDisposed && _colorAlertIndicator.Visible) {
                _colorAlertIndicator.Hide();
            }
        }

        /// <summary>
        /// Closes all panels and terminates the application. Layout saving is
        /// suppressed first, so that panels closing during shutdown do not
        /// overwrite the stored layout with a partial state.
        /// </summary>
        public void ExitApplication() {
            ApplicationExiting = true;
            var primary = _primaryPanel ?? this;
            primary._suppressLayoutSave = true;
            Application.Exit();
        }

        /// <summary>
        /// Gets whether the given window handle belongs to one of the open panels.
        /// </summary>
        internal static bool IsPanelHandle(IntPtr handle) {
            foreach (var panel in _openPanels) {
                if (!panel.IsDisposed && panel.IsHandleCreated && panel.Handle == handle)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Hides all panel windows (primary and secondaries) at once.
        /// </summary>
        public void HideAllPanels() {
            var primary = _primaryPanel ?? this;
            Program.Platform.HideForm(primary);
            foreach (var child in primary._childPanels) {
                Program.Platform.HideForm(child);
            }
            //Deactivate: releases focus so the taskbar button is no longer highlighted
            primary.WindowState = FormWindowState.Minimized;
        }

        bool _restoringAllPanels; //re-entrancy guard (Show() re-triggers OnActivated)

        /// <summary>
        /// Restores all panel windows (primary and secondaries) at once.
        /// </summary>
        public void RestoreAllPanels() {
            var primary = _primaryPanel ?? this;

            //Guard against re-entrancy and shutdown: RestoreForm calls Show(), which
            //raises OnActivated again and would recurse into this method endlessly
            //(stack overflow), especially while forms are being disposed.
            if (primary._restoringAllPanels || ApplicationExiting ||
                primary.IsDisposed || primary.Disposing)
                return;

            primary._restoringAllPanels = true;
            try {
                if (primary.WindowState == FormWindowState.Minimized) {
                    primary.WindowState = FormWindowState.Normal;
                }
                Program.Platform.RestoreForm(primary);
                foreach (var child in primary._childPanels.ToArray()) {
                    if (!child.IsDisposed && !child.Disposing) {
                        Program.Platform.RestoreForm(child);
                    }
                }
            }
            finally {
                primary._restoringAllPanels = false;
            }
        }

        /// <summary>
        /// Creates a secondary panel window bound to this panel's primary.
        /// The new panel clones the same source window as the primary and follows
        /// it when the primary switches to another window.
        /// </summary>
        public MainForm CreateChildPanel() {
            var primary = _primaryPanel ?? this;

            var form = new MainForm(new StartupOptions.Options());
            form._primaryPanel = primary;
            primary._childPanels.Add(form);
            form.FormClosed += (s, args) => {
                //Resolve the primary at close time: it may have changed if the
                //original primary was closed and a child was promoted.
                var p = form._primaryPanel;
                if (p != null) {
                    p._childPanels.Remove(form);
                    p.NotifyPanelLayoutChanged();
                }
            };

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(Location.X + 40, Location.Y + 40);
            form.ShowInTaskbar = false; //only the primary panel appears in the taskbar
            form.Show();

            if (primary.CurrentThumbnailWindowHandle != null) {
                form.SetThumbnail(primary.CurrentThumbnailWindowHandle, null);
            }

            primary.NotifyPanelLayoutChanged();
            return form;
        }

        //Managers
        readonly MessagePumpManager _msgPumpManager = new MessagePumpManager();
        WindowListMenuManager _windowListManager;
        public FullscreenFormManager FullscreenManager { get; private set; }

        Options _startupOptions;

        public MainForm(Options startupOptions) {
            _startupOptions = startupOptions;

            FullscreenManager = new FullscreenFormManager(this);
            _quickRegionDrawingHandler = new ThumbnailPanel.RegionDrawnHandler(HandleQuickRegionDrawn);
            
            //WinForms init pass
            InitializeComponent();

            //Store default values
            DefaultNonClickTransparencyKey = this.TransparencyKey;
            DefaultBorderStyle = this.FormBorderStyle;

            //Thumbnail panel
            _thumbnailPanel = new ThumbnailPanel {
                Location = Point.Empty,
                Dock = DockStyle.Fill
            };
            _thumbnailPanel.CloneClick += new EventHandler<CloneClickEventArgs>(Thumbnail_CloneClick);
            Controls.Add(_thumbnailPanel);

            //Populate opacity menu (100% down to 10%, in 10% steps)
            for (int pct = 100; pct >= 10; pct -= 10) {
                var item = new ToolStripMenuItem(pct + "%") {
                    Tag = pct / 100.0
                };
                item.Click += new EventHandler(Menu_Opacity_click);
                menuOpacity.Items.Add(item);
            }

            //Set native renderer on context menus
            Asztal.Szótár.NativeToolStripRenderer.SetToolStripRenderer(
                menuContext, menuWindows, menuOpacity, menuResize, menuFullscreenContext
            );

            //Set to Key event preview
            this.KeyPreview = true;

            _openPanels.Add(this);

            Log.Write("Main form constructed");
        }

        #region Event override

        bool _managersInitialized;

        protected override void OnHandleCreated(EventArgs e){
 	        base.OnHandleCreated(e);

            //Window init
            KeepAspectRatio = false;
            GlassMargins = new Padding(-1);

            //Managers: initialize once only. OnHandleCreated fires again when the
            //handle is recreated (e.g. ShowInTaskbar change on primary promotion)
            //and re-registering the processors would duplicate them.
            if (!_managersInitialized) {
                _managersInitialized = true;
                _msgPumpManager.Initialize(this);
                _windowListManager = new WindowListMenuManager(this, menuWindows);
                _windowListManager.ParentMenus = new System.Windows.Forms.ContextMenuStrip[] {
                    menuContext, menuFullscreenContext
                };
            }

            //Platform specific form initialization
            Program.Platform.PostHandleFormInit(this);
        }

        protected override void OnShown(EventArgs e) {
            Log.Write("Main form shown");
            base.OnShown(e);

            //Apply startup options
            _startupOptions.Apply(this);

            //Restore secondary panels from last session (primary only)
            if (!IsSecondaryPanel) {
                _suppressLayoutSave = true;
                try {
                    PanelLayoutManager.Restore(this);
                }
                finally {
                    _suppressLayoutSave = false;
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            Log.Write("Main form closing");
            base.OnClosing(e);

            MainForm promoted = null;
            if (!IsSecondaryPanel) {
                if (!ApplicationExiting && _childPanels.Count > 0) {
                    //The primary is closing but other panels remain: promote a child
                    //to primary so the panel set keeps working (and saving its layout).
                    promoted = PromotePrimaryRole();
                }
                else {
                    //Layout is saved incrementally on every change; suppress further saves so
                    //that child panels closed during shutdown do not erase the stored layout.
                    _suppressLayoutSave = true;
                }
            }

            _msgPumpManager.Dispose();
            Program.Platform.CloseForm(this);

            //Global hotkeys were registered on this (closing) window and were just
            //released by the manager dispose above: re-register on the new primary.
            if (promoted != null && !promoted.IsDisposed) {
                promoted.MessagePumpManager.Get<MessagePumpProcessors.HotKeyManager>().RefreshHotkeys();
            }
        }

        protected override void OnClosed(EventArgs e) {
            Log.Write("Main form closed");
            base.OnClosed(e);

            if (_colorAlertIndicator != null) {
                _colorAlertIndicator.Dispose();
                _colorAlertIndicator = null;
            }

            //Keep the application alive until the last panel window is closed
            _openPanels.Remove(this);
            if (_openPanels.Count > 0)
                return;
            Log.Write("Last panel closed, exiting application loop");
            Application.ExitThread();
        }

        /// <summary>
        /// Transfers the primary role to the first remaining child panel.
        /// Called when the primary closes while other panels are still open.
        /// </summary>
        private MainForm PromotePrimaryRole() {
            var newPrimary = _childPanels[0];
            _childPanels.RemoveAt(0);
            newPrimary._primaryPanel = null;

            //Changing ShowInTaskbar recreates the window handle, which destroys the
            //DWM thumbnail bound to it. Capture the current clone state and restore
            //it right after taking over the taskbar button.
            var cloneHandle = newPrimary.CurrentThumbnailWindowHandle;
            var cloneRegion = newPrimary.SelectedThumbnailRegion;
            newPrimary.ShowInTaskbar = true; //take over the single taskbar button
            if (cloneHandle != null) {
                newPrimary.SetThumbnail(cloneHandle, cloneRegion);
            }

            foreach (var child in _childPanels) {
                child._primaryPanel = newPrimary;
                newPrimary._childPanels.Add(child);
            }
            _childPanels.Clear();

            //This form is closing: stop saving from here, let the new primary take over
            _suppressLayoutSave = true;
            Log.Write("Primary role promoted to another panel");
            PanelLayoutManager.StartWatcher(newPrimary);
            newPrimary.NotifyPanelLayoutChanged();
            return newPrimary;
        }

        FormWindowState _lastWindowState = FormWindowState.Normal;

        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);

            //Minimizing the primary from the taskbar hides all secondary panels;
            //restoring it brings them all back.
            if (WindowState != _lastWindowState) {
                _lastWindowState = WindowState;
                if (!IsSecondaryPanel) {
                    if (WindowState == FormWindowState.Minimized) {
                        foreach (var child in _childPanels) {
                            Program.Platform.HideForm(child);
                        }
                    }
                    else {
                        foreach (var child in _childPanels) {
                            Program.Platform.RestoreForm(child);
                        }
                    }
                }
            }

            UpdateColorAlertIndicator();
        }

        protected override void OnLocationChanged(EventArgs e) {
            base.OnLocationChanged(e);
            UpdateColorAlertIndicator();
        }

        protected override void OnVisibleChanged(EventArgs e) {
            base.OnVisibleChanged(e);
            UpdateColorAlertIndicator();
        }


        protected override void OnResizeEnd(EventArgs e) {
            base.OnResizeEnd(e);

            RefreshScreenLock();

            //Persist layout after a move/resize of any panel
            NotifyPanelLayoutChanged();
        }

        protected override void OnResizing(EventArgs e) {
            //Update aspect ratio from thumbnail while resizing (but do not refresh, resizing does that anyway)
            if (_thumbnailPanel.IsShowingThumbnail) {
                SetAspectRatio(_thumbnailPanel.ThumbnailPixelSize, false);
            }
        }

        protected override void OnActivated(EventArgs e) {
            base.OnActivated(e);

            //Ignore activation while form is being torn down
            if (IsDisposed || Disposing) {
                return;
            }

            //Restoring any panel brings back the whole panel set
            RestoreAllPanels();

            //前面化でインジケーターが下に潜ることがあるため Z オーダーを再同期する
            UpdateColorAlertIndicator();
        }

        protected override void OnDeactivate(EventArgs e) {
            base.OnDeactivate(e);

            //HACK: sometimes, even if TopMost is true, the window loses its "always on top" status.
            //  This is a fix attempt that probably won't work...
            if (!FullscreenManager.IsFullscreen) { //fullscreen mode doesn't use TopMost
                TopMost = false;
                TopMost = true;

                //TopMost の再設定でこのウィンドウが最前面バンドの先頭に上がり、
                //●インジケーターが下に潜るため Z オーダーを再同期する
                UpdateColorAlertIndicator();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);

            if (!FullscreenManager.IsFullscreen) {
                if (_thumbnailPanel.IsShowingThumbnail) {
                    SetAspectRatio(_thumbnailPanel.ThumbnailPixelSize, false);
                }

                int change = (int)(e.Delta / 6.0); //assumes a mouse wheel "tick" is in the 80-120 range
                AdjustSize(change);

                RefreshScreenLock();
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e) {
            base.OnMouseDoubleClick(e);

            //This is handled by the WM_NCLBUTTONDBLCLK msg handler usually (because the GlassForm translates
            //clicks on client to clicks on caption). But if fullscreen mode disables GlassForm dragging, we need
            //this auxiliary handler to switch mode.
            FullscreenManager.Toggle();
        }

        protected override void OnMouseClick(MouseEventArgs e) {
            base.OnMouseClick(e);

            //Same story as above (OnMouseDoubleClick)
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                OpenContextMenu(null);
            }
        }

        private ThumbnailPanel.RegionDrawnHandler _quickRegionDrawingHandler;

        protected override void WndProc(ref Message m) {
            if (_msgPumpManager != null) {
                if (_msgPumpManager.PumpMessage(ref m)) {
                    return;
                }
            }

            switch (m.Msg) {
                case WM.NCRBUTTONUP:
                    //Open context menu if right button clicked on caption (i.e. all of the window area because of glass)
                    if (m.WParam.ToInt32() == HT.CAPTION) {
                        OpenContextMenu(null);

                        m.Result = IntPtr.Zero;
                        return;
                    }
                    break;

                case WM.NCLBUTTONDOWN:
                    if ((ModifierKeys & Keys.Control) == Keys.Control &&
                        ThumbnailPanel.IsShowingThumbnail &&
                        !ThumbnailPanel.DrawMouseRegions) {

                        ThumbnailPanel.EnableMouseRegionsDrawingWithMouseDown();
                        ThumbnailPanel.RegionDrawn += _quickRegionDrawingHandler;

                        m.Result = IntPtr.Zero;
                        return;
                    }
                    break;

                case WM.NCLBUTTONDBLCLK:
                    //Toggle fullscreen mode if double click on caption (whole glass area)
                    if (m.WParam.ToInt32() == HT.CAPTION) {
                        FullscreenManager.Toggle();

                        m.Result = IntPtr.Zero;
                        return;
                    }
                    break;

                case WM.NCHITTEST:
                    //Make transparent to hit-testing if in click through mode
                    if (ClickThroughEnabled) {
                        m.Result = (IntPtr)HT.TRANSPARENT;
                        return;
                    }
                    break;
            }

            base.WndProc(ref m);
        }

        private void HandleQuickRegionDrawn(object sender, ThumbnailRegion region) {
            //Reset region drawing state
            ThumbnailPanel.DrawMouseRegions = false;
            ThumbnailPanel.RegionDrawn -= _quickRegionDrawingHandler;

            SelectedThumbnailRegion = region;
        }

        #endregion

        #region Keyboard event handling

        protected override void OnKeyUp(KeyEventArgs e) {
            base.OnKeyUp(e);

            //ALT
            if (e.Modifiers == Keys.Alt) {
                if (e.KeyCode == Keys.Enter) {
                    e.Handled = true;
                    FullscreenManager.Toggle();
                }

                else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1) {
                    FitToThumbnail(0.25);
                }

                else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2) {
                    FitToThumbnail(0.5);
                }

                else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3 ||
                         e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0) {
                    FitToThumbnail(1.0);
                }

                else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4) {
                    FitToThumbnail(2.0);
                }
            }

            //F11 Fullscreen switch
            else if (e.KeyCode == Keys.F11) {
                e.Handled = true;
                FullscreenManager.Toggle();
            }

            //ESCAPE
            else if (e.KeyCode == Keys.Escape) {
                //Toggle fullscreen
                if (FullscreenManager.IsFullscreen) {
                    FullscreenManager.SwitchBack();
                }
                //Disable click forwarding
                else if (ClickForwardingEnabled) {
                    ClickForwardingEnabled = false;
                }
            }
        }

        #endregion

        #region Thumbnail operation

        /// <summary>
        /// Sets a new thumbnail.
        /// </summary>
        /// <param name="handle">Handle to the window to clone.</param>
        /// <param name="region">Region of the window to clone or null.</param>
        public void SetThumbnail(WindowHandle handle, ThumbnailRegion region) {
            //Never clone one of our own panel windows: DWM throws when a window
            //is registered as a thumbnail source of itself.
            if (handle != null && IsPanelHandle(handle.Handle)) {
                Log.Write("Refusing to clone own panel window HWND {0}", handle.Handle);
                return;
            }

            try {
                Log.Write("Cloning window HWND {0} of class {1}", handle.Handle, handle.Class);

                CurrentThumbnailWindowHandle = handle;
                _thumbnailPanel.SetThumbnailHandle(handle, region);

                //Set aspect ratio (this will resize the form), do not refresh if in fullscreen
                SetAspectRatio(_thumbnailPanel.ThumbnailPixelSize, !FullscreenManager.IsFullscreen);
            }
            catch (Exception ex) {
                Log.WriteException("Unable to set new thumbnail", ex);

                ThumbnailError(ex, false, Strings.ErrorUnableToCreateThumbnail);
                _thumbnailPanel.UnsetThumbnail();
                return;
            }

            //Keep secondary panels on the same source window as the primary
            foreach (var child in _childPanels.ToArray()) {
                if (child.CurrentThumbnailWindowHandle == null ||
                    child.CurrentThumbnailWindowHandle.Handle != handle.Handle) {
                    child.SetThumbnail(handle, null);
                }
            }

            if (!IsSecondaryPanel) {
                NotifyPanelLayoutChanged();
            }
        }

        /// <summary>
        /// Disables the cloned thumbnail.
        /// </summary>
        public void UnsetThumbnail() {
            //Unset handle
            CurrentThumbnailWindowHandle = null;
            _thumbnailPanel.UnsetThumbnail();

            //Disable aspect ratio
            KeepAspectRatio = false;

            //Secondary panels follow the primary
            foreach (var child in _childPanels.ToArray()) {
                child.UnsetThumbnail();
            }

            if (!IsSecondaryPanel) {
                NotifyPanelLayoutChanged();
            }
        }

        /// <summary>
        /// Gets or sets the region displayed of the current thumbnail.
        /// </summary>
        public ThumbnailRegion SelectedThumbnailRegion {
            get {
                if (!_thumbnailPanel.IsShowingThumbnail || !_thumbnailPanel.ConstrainToRegion)
                    return null;

                return _thumbnailPanel.SelectedRegion;
            }
            set {
                if (!_thumbnailPanel.IsShowingThumbnail)
                    return;

                _thumbnailPanel.SelectedRegion = value;

                SetAspectRatio(_thumbnailPanel.ThumbnailPixelSize, true);

                FixPositionAndSize();

                NotifyPanelLayoutChanged();
            }
        }

        const int FixMargin = 10;

        /// <summary>
        /// Fixes the form's position and size, ensuring it is fully displayed in the current screen.
        /// </summary>
        private void FixPositionAndSize() {
            var screen = Screen.FromControl(this);

            if (Width > screen.WorkingArea.Width) {
                Width = screen.WorkingArea.Width - FixMargin;
            }
            if (Height > screen.WorkingArea.Height) {
                Height = screen.WorkingArea.Height - FixMargin;
            }
            if (Location.X + Width > screen.WorkingArea.Right) {
                Location = new Point(screen.WorkingArea.Right - Width - FixMargin, Location.Y);
            }
            if (Location.Y + Height > screen.WorkingArea.Bottom) {
                Location = new Point(Location.X, screen.WorkingArea.Bottom - Height - FixMargin);
            }
        }

        private void ThumbnailError(Exception ex, bool suppress, string title) {
            if (!suppress) {
                ShowErrorDialog(title, Strings.ErrorGenericThumbnailHandleError, ex.Message);
            }

            UnsetThumbnail();
        }

        /// <summary>Automatically sizes the window in order to accomodate the thumbnail p times.</summary>
        /// <param name="p">Scale of the thumbnail to consider.</param>
        private void FitToThumbnail(double p) {
            try {
                Size originalSize = _thumbnailPanel.ThumbnailPixelSize;
                Size fittedSize = new Size((int)(originalSize.Width * p), (int)(originalSize.Height * p));
                ClientSize = fittedSize;
                RefreshScreenLock();
            }
            catch (Exception ex) {
                ThumbnailError(ex, false, Strings.ErrorUnableToFit);
            }
        }

        #endregion

        #region Accessors

        /// <summary>
        /// Gets the form's thumbnail panel.
        /// </summary>
        public ThumbnailPanel ThumbnailPanel {
            get {
                return _thumbnailPanel;
            }
        }

        /// <summary>
        /// Gets the form's message pump manager.
        /// </summary>
        public MessagePumpManager MessagePumpManager {
            get {
                return _msgPumpManager;
            }
        }

        /// <summary>
        /// Gets the form's window list drop down menu.
        /// </summary>
        public ContextMenuStrip MenuWindows {
            get {
                return menuWindows;
            }
        }

        /// <summary>
        /// Retrieves the window handle of the currently cloned thumbnail.
        /// </summary>
        public WindowHandle CurrentThumbnailWindowHandle {
            get;
            private set;
        }

        #endregion

    }
}
