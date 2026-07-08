using System.Drawing;
using System.Windows.Forms;
using WindowsFormsAero.TaskDialog;

namespace OnTopReplica {
    partial class MainForm {

        /// <summary>
        /// Opens the context menu.
        /// </summary>
        /// <param name="position">Optional position of the mouse, relative to which the menu is shown.</param>
        public void OpenContextMenu(Point? position) {
            Point menuPosition = MousePosition;
            if (position.HasValue)
                menuPosition = position.Value;

            if (FullscreenManager.IsFullscreen) {
                menuFullscreenContext.Show(menuPosition);
            }
            else {
                menuContext.Show(menuPosition);
            }
        }

        /// <summary>
        /// Gets the window's vertical chrome size.
        /// </summary>
        public int ChromeBorderVertical {
            get {
                if (IsChromeVisible)
                    return SystemInformation.FrameBorderSize.Height;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets the window's horizontal chrome size.
        /// </summary>
        public int ChromeBorderHorizontal {
            get {
                if (IsChromeVisible)
                    return SystemInformation.FrameBorderSize.Width;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Displays an error task dialog.
        /// </summary>
        /// <param name="mainInstruction">Main instruction of the error dialog.</param>
        /// <param name="explanation">Detailed informations about the error.</param>
        /// <param name="errorMessage">Expanded error codes/messages.</param>
        private void ShowErrorDialog(string mainInstruction, string explanation, string errorMessage) {
            TaskDialog dlg = new TaskDialog(mainInstruction, Strings.ErrorGenericTitle, explanation) {
                CommonIcon = CommonIcon.Stop,
                IsExpanded = false
            };

            if (!string.IsNullOrEmpty(errorMessage)) {
                dlg.ExpandedInformation = Strings.ErrorGenericInfoText + errorMessage;
                dlg.ExpandedControlText = Strings.ErrorGenericInfoButton;
            }

            dlg.Show(this);
        }

        /// <summary>
        /// Ensures that the main form is visible (either closing the fullscreen mode or reactivating from task icon).
        /// </summary>
        public void EnsureMainFormVisible() {
            //Reset special modes
            FullscreenManager.SwitchBack();

            //Restore all panels in a platform-dependent method
            RestoreAllPanels();
        }

    }
}
