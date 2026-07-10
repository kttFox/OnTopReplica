namespace OnTopReplica.SidePanels {
    partial class OptionsPanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.btnClose = new System.Windows.Forms.Button();
			this.panelMain = new System.Windows.Forms.Panel();
			this.groupHotkeys = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblHotKeyShowHide = new System.Windows.Forms.Label();
			this.txtHotKeyShowHide = new OnTopReplica.HotKeyTextBox();
			this.lblHotKeyClone = new System.Windows.Forms.Label();
			this.txtHotKeyClone = new OnTopReplica.HotKeyTextBox();
			this.groupLanguage = new System.Windows.Forms.GroupBox();
			this.comboLanguage = new OnTopReplica.ImageComboBox();
			this.lblLanguage = new System.Windows.Forms.Label();
			this.groupIndicator = new System.Windows.Forms.GroupBox();
			this.checkIndicator = new System.Windows.Forms.CheckBox();
			this.lblIndicatorSize = new System.Windows.Forms.Label();
			this.numIndicatorSize = new System.Windows.Forms.NumericUpDown();
			this.lblIndicatorRunColor = new System.Windows.Forms.Label();
			this.panelIndicatorRunColor = new System.Windows.Forms.Panel();
			this.lblIndicatorPauseColor = new System.Windows.Forms.Label();
			this.panelIndicatorPauseColor = new System.Windows.Forms.Panel();
			this.groupAutoHide = new System.Windows.Forms.GroupBox();
			this.checkAutoHide = new System.Windows.Forms.CheckBox();
			this.panelMain.SuspendLayout();
			this.groupHotkeys.SuspendLayout();
			this.groupLanguage.SuspendLayout();
			this.groupIndicator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numIndicatorSize)).BeginInit();
			this.groupAutoHide.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(220, 464);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(87, 27);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = global::OnTopReplica.Strings.MenuClose;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.Close_click);
			// 
			// panelMain
			// 
			this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelMain.AutoScroll = true;
			this.panelMain.Controls.Add(this.groupHotkeys);
			this.panelMain.Controls.Add(this.groupLanguage);
			this.panelMain.Controls.Add(this.groupIndicator);
			this.panelMain.Controls.Add(this.groupAutoHide);
			this.panelMain.Location = new System.Drawing.Point(7, 7);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(301, 451);
			this.panelMain.TabIndex = 1;
			// 
			// groupHotkeys
			// 
			this.groupHotkeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupHotkeys.Controls.Add(this.label1);
			this.groupHotkeys.Controls.Add(this.lblHotKeyShowHide);
			this.groupHotkeys.Controls.Add(this.txtHotKeyShowHide);
			this.groupHotkeys.Controls.Add(this.lblHotKeyClone);
			this.groupHotkeys.Controls.Add(this.txtHotKeyClone);
			this.groupHotkeys.Location = new System.Drawing.Point(3, 89);
			this.groupHotkeys.Name = "groupHotkeys";
			this.groupHotkeys.Size = new System.Drawing.Size(294, 130);
			this.groupHotkeys.TabIndex = 1;
			this.groupHotkeys.TabStop = false;
			this.groupHotkeys.Text = "Hot keys:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(7, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(182, 50);
			this.label1.TabIndex = 4;
			this.label1.Text = "These system-wide shortcuts can also be used when OnTopReplica is not in focus.";
			// 
			// lblHotKeyShowHide
			// 
			this.lblHotKeyShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblHotKeyShowHide.BackColor = System.Drawing.Color.Transparent;
			this.lblHotKeyShowHide.Location = new System.Drawing.Point(196, 25);
			this.lblHotKeyShowHide.Name = "lblHotKeyShowHide";
			this.lblHotKeyShowHide.Size = new System.Drawing.Size(91, 20);
			this.lblHotKeyShowHide.TabIndex = 3;
			this.lblHotKeyShowHide.Text = "Show/Hide";
			// 
			// txtHotKeyShowHide
			// 
			this.txtHotKeyShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHotKeyShowHide.Location = new System.Drawing.Point(7, 22);
			this.txtHotKeyShowHide.Name = "txtHotKeyShowHide";
			this.txtHotKeyShowHide.ReadOnly = true;
			this.txtHotKeyShowHide.Size = new System.Drawing.Size(181, 23);
			this.txtHotKeyShowHide.TabIndex = 2;
			// 
			// lblHotKeyClone
			// 
			this.lblHotKeyClone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblHotKeyClone.BackColor = System.Drawing.Color.Transparent;
			this.lblHotKeyClone.Location = new System.Drawing.Point(196, 55);
			this.lblHotKeyClone.Name = "lblHotKeyClone";
			this.lblHotKeyClone.Size = new System.Drawing.Size(91, 33);
			this.lblHotKeyClone.TabIndex = 1;
			this.lblHotKeyClone.Text = "Clone current window";
			// 
			// txtHotKeyClone
			// 
			this.txtHotKeyClone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHotKeyClone.Location = new System.Drawing.Point(7, 52);
			this.txtHotKeyClone.Name = "txtHotKeyClone";
			this.txtHotKeyClone.ReadOnly = true;
			this.txtHotKeyClone.Size = new System.Drawing.Size(181, 23);
			this.txtHotKeyClone.TabIndex = 0;
			// 
			// groupLanguage
			// 
			this.groupLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupLanguage.Controls.Add(this.comboLanguage);
			this.groupLanguage.Controls.Add(this.lblLanguage);
			this.groupLanguage.Location = new System.Drawing.Point(3, 3);
			this.groupLanguage.Name = "groupLanguage";
			this.groupLanguage.Size = new System.Drawing.Size(294, 78);
			this.groupLanguage.TabIndex = 0;
			this.groupLanguage.TabStop = false;
			this.groupLanguage.Text = "Language:";
			// 
			// comboLanguage
			// 
			this.comboLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboLanguage.FormattingEnabled = true;
			this.comboLanguage.IconList = null;
			this.comboLanguage.Location = new System.Drawing.Point(10, 22);
			this.comboLanguage.Name = "comboLanguage";
			this.comboLanguage.Size = new System.Drawing.Size(276, 24);
			this.comboLanguage.TabIndex = 2;
			this.comboLanguage.SelectedIndexChanged += new System.EventHandler(this.LanguageBox_IndexChange);
			// 
			// lblLanguage
			// 
			this.lblLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLanguage.Location = new System.Drawing.Point(7, 50);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Size = new System.Drawing.Size(280, 25);
			this.lblLanguage.TabIndex = 1;
			this.lblLanguage.Text = "Requires a restart.";
			// 
			// groupIndicator
			// 
			this.groupIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupIndicator.Controls.Add(this.checkIndicator);
			this.groupIndicator.Controls.Add(this.lblIndicatorSize);
			this.groupIndicator.Controls.Add(this.numIndicatorSize);
			this.groupIndicator.Controls.Add(this.lblIndicatorRunColor);
			this.groupIndicator.Controls.Add(this.panelIndicatorRunColor);
			this.groupIndicator.Controls.Add(this.lblIndicatorPauseColor);
			this.groupIndicator.Controls.Add(this.panelIndicatorPauseColor);
			this.groupIndicator.Location = new System.Drawing.Point(3, 225);
			this.groupIndicator.Name = "groupIndicator";
			this.groupIndicator.Size = new System.Drawing.Size(294, 145);
			this.groupIndicator.TabIndex = 2;
			this.groupIndicator.TabStop = false;
			this.groupIndicator.Text = "Color alert indicator:";
			// 
			// checkIndicator
			// 
			this.checkIndicator.Location = new System.Drawing.Point(10, 22);
			this.checkIndicator.Name = "checkIndicator";
			this.checkIndicator.Size = new System.Drawing.Size(276, 20);
			this.checkIndicator.TabIndex = 0;
			this.checkIndicator.Text = "Show indicator dot";
			this.checkIndicator.UseVisualStyleBackColor = true;
			this.checkIndicator.CheckedChanged += new System.EventHandler(this.Indicator_SettingChanged);
			// 
			// lblIndicatorSize
			// 
			this.lblIndicatorSize.Location = new System.Drawing.Point(10, 52);
			this.lblIndicatorSize.Name = "lblIndicatorSize";
			this.lblIndicatorSize.Size = new System.Drawing.Size(180, 20);
			this.lblIndicatorSize.TabIndex = 1;
			this.lblIndicatorSize.Text = "Dot size (px):";
			this.lblIndicatorSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numIndicatorSize
			// 
			this.numIndicatorSize.Location = new System.Drawing.Point(196, 50);
			this.numIndicatorSize.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
			this.numIndicatorSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numIndicatorSize.Name = "numIndicatorSize";
			this.numIndicatorSize.Size = new System.Drawing.Size(60, 23);
			this.numIndicatorSize.TabIndex = 2;
			this.numIndicatorSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
			this.numIndicatorSize.ValueChanged += new System.EventHandler(this.Indicator_SettingChanged);
			// 
			// lblIndicatorRunColor
			// 
			this.lblIndicatorRunColor.Location = new System.Drawing.Point(10, 82);
			this.lblIndicatorRunColor.Name = "lblIndicatorRunColor";
			this.lblIndicatorRunColor.Size = new System.Drawing.Size(180, 20);
			this.lblIndicatorRunColor.TabIndex = 3;
			this.lblIndicatorRunColor.Text = "Running color:";
			this.lblIndicatorRunColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelIndicatorRunColor
			// 
			this.panelIndicatorRunColor.BackColor = System.Drawing.Color.Red;
			this.panelIndicatorRunColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelIndicatorRunColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelIndicatorRunColor.Location = new System.Drawing.Point(196, 82);
			this.panelIndicatorRunColor.Name = "panelIndicatorRunColor";
			this.panelIndicatorRunColor.Size = new System.Drawing.Size(60, 20);
			this.panelIndicatorRunColor.TabIndex = 4;
			this.panelIndicatorRunColor.Click += new System.EventHandler(this.PanelIndicatorRunColor_Click);
			// 
			// lblIndicatorPauseColor
			// 
			this.lblIndicatorPauseColor.Location = new System.Drawing.Point(10, 112);
			this.lblIndicatorPauseColor.Name = "lblIndicatorPauseColor";
			this.lblIndicatorPauseColor.Size = new System.Drawing.Size(180, 20);
			this.lblIndicatorPauseColor.TabIndex = 5;
			this.lblIndicatorPauseColor.Text = "Paused color:";
			this.lblIndicatorPauseColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelIndicatorPauseColor
			// 
			this.panelIndicatorPauseColor.BackColor = System.Drawing.Color.LimeGreen;
			this.panelIndicatorPauseColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelIndicatorPauseColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelIndicatorPauseColor.Location = new System.Drawing.Point(196, 112);
			this.panelIndicatorPauseColor.Name = "panelIndicatorPauseColor";
			this.panelIndicatorPauseColor.Size = new System.Drawing.Size(60, 20);
			this.panelIndicatorPauseColor.TabIndex = 6;
			this.panelIndicatorPauseColor.Click += new System.EventHandler(this.PanelIndicatorPauseColor_Click);
			// 
			// groupAutoHide
			// 
			this.groupAutoHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupAutoHide.Controls.Add(this.checkAutoHide);
			this.groupAutoHide.Location = new System.Drawing.Point(3, 376);
			this.groupAutoHide.Name = "groupAutoHide";
			this.groupAutoHide.Size = new System.Drawing.Size(294, 70);
			this.groupAutoHide.TabIndex = 3;
			this.groupAutoHide.TabStop = false;
			this.groupAutoHide.Text = "Auto hide:";
			// 
			// checkAutoHide
			// 
			this.checkAutoHide.Location = new System.Drawing.Point(10, 22);
			this.checkAutoHide.Name = "checkAutoHide";
			this.checkAutoHide.Size = new System.Drawing.Size(276, 40);
			this.checkAutoHide.TabIndex = 0;
			this.checkAutoHide.Text = "Hide panels when the cloned window is inactive";
			this.checkAutoHide.UseVisualStyleBackColor = true;
			this.checkAutoHide.CheckedChanged += new System.EventHandler(this.AutoHide_CheckedChanged);
			// 
			// OptionsPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.btnClose);
			this.MinimumSize = new System.Drawing.Size(315, 422);
			this.Name = "OptionsPanel";
			this.Padding = new System.Windows.Forms.Padding(7);
			this.Size = new System.Drawing.Size(315, 498);
			this.panelMain.ResumeLayout(false);
			this.groupHotkeys.ResumeLayout(false);
			this.groupHotkeys.PerformLayout();
			this.groupLanguage.ResumeLayout(false);
			this.groupIndicator.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numIndicatorSize)).EndInit();
			this.groupAutoHide.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private ImageComboBox comboLanguage;
        private System.Windows.Forms.GroupBox groupHotkeys;
        private HotKeyTextBox txtHotKeyClone;
        private System.Windows.Forms.Label lblHotKeyShowHide;
        private HotKeyTextBox txtHotKeyShowHide;
        private System.Windows.Forms.Label lblHotKeyClone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupIndicator;
        private System.Windows.Forms.CheckBox checkIndicator;
        private System.Windows.Forms.Label lblIndicatorSize;
        private System.Windows.Forms.NumericUpDown numIndicatorSize;
        private System.Windows.Forms.Label lblIndicatorRunColor;
        private System.Windows.Forms.Panel panelIndicatorRunColor;
        private System.Windows.Forms.Label lblIndicatorPauseColor;
        private System.Windows.Forms.Panel panelIndicatorPauseColor;
        private System.Windows.Forms.GroupBox groupAutoHide;
        private System.Windows.Forms.CheckBox checkAutoHide;
    }
}
