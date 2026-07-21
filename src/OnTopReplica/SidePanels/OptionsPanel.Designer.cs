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
			this.groupLanguage = new System.Windows.Forms.Label();
			this.comboLanguage = new OnTopReplica.ImageComboBox();
			this.lblLanguage = new System.Windows.Forms.Label();
			this.groupHotkeys = new System.Windows.Forms.Label();
			this.txtHotKeyShowHide = new OnTopReplica.HotKeyTextBox();
			this.lblHotKeyShowHide = new System.Windows.Forms.Label();
			this.txtHotKeyClone = new OnTopReplica.HotKeyTextBox();
			this.lblHotKeyClone = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupIndicator = new System.Windows.Forms.Label();
			this.checkIndicator = new System.Windows.Forms.CheckBox();
			this.lblIndicatorSize = new System.Windows.Forms.Label();
			this.numIndicatorSize = new System.Windows.Forms.NumericUpDown();
			this.lblIndicatorRunColor = new System.Windows.Forms.Label();
			this.panelIndicatorRunColor = new System.Windows.Forms.Panel();
			this.lblIndicatorPauseColor = new System.Windows.Forms.Label();
			this.panelIndicatorPauseColor = new System.Windows.Forms.Panel();
			this.checkPauseColorAlertOnLoss = new System.Windows.Forms.CheckBox();
			this.groupAutoHide = new System.Windows.Forms.Label();
			this.checkAutoHide = new System.Windows.Forms.CheckBox();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numIndicatorSize)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(220, 460);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(87, 27);
			this.btnClose.TabIndex = 20;
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
			this.panelMain.Controls.Add(this.groupLanguage);
			this.panelMain.Controls.Add(this.comboLanguage);
			this.panelMain.Controls.Add(this.lblLanguage);
			this.panelMain.Controls.Add(this.groupHotkeys);
			this.panelMain.Controls.Add(this.txtHotKeyShowHide);
			this.panelMain.Controls.Add(this.lblHotKeyShowHide);
			this.panelMain.Controls.Add(this.txtHotKeyClone);
			this.panelMain.Controls.Add(this.lblHotKeyClone);
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.groupIndicator);
			this.panelMain.Controls.Add(this.checkIndicator);
			this.panelMain.Controls.Add(this.lblIndicatorSize);
			this.panelMain.Controls.Add(this.numIndicatorSize);
			this.panelMain.Controls.Add(this.lblIndicatorRunColor);
			this.panelMain.Controls.Add(this.panelIndicatorRunColor);
			this.panelMain.Controls.Add(this.lblIndicatorPauseColor);
			this.panelMain.Controls.Add(this.panelIndicatorPauseColor);
			this.panelMain.Controls.Add(this.checkPauseColorAlertOnLoss);
			this.panelMain.Controls.Add(this.groupAutoHide);
			this.panelMain.Controls.Add(this.checkAutoHide);
			this.panelMain.Location = new System.Drawing.Point(7, 7);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(301, 447);
			this.panelMain.TabIndex = 1;
			// 
			// groupLanguage
			// 
			this.groupLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupLanguage.AutoSize = true;
			this.groupLanguage.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupLanguage.Location = new System.Drawing.Point(3, 5);
			this.groupLanguage.Name = "groupLanguage";
			this.groupLanguage.Size = new System.Drawing.Size(62, 15);
			this.groupLanguage.TabIndex = 0;
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
			this.comboLanguage.Location = new System.Drawing.Point(16, 26);
			this.comboLanguage.Name = "comboLanguage";
			this.comboLanguage.Size = new System.Drawing.Size(268, 24);
			this.comboLanguage.TabIndex = 1;
			this.comboLanguage.SelectedIndexChanged += new System.EventHandler(this.LanguageBox_IndexChange);
			// 
			// lblLanguage
			// 
			this.lblLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLanguage.Location = new System.Drawing.Point(16, 53);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Size = new System.Drawing.Size(268, 22);
			this.lblLanguage.TabIndex = 2;
			this.lblLanguage.Text = "Requires a restart.";
			// 
			// groupHotkeys
			// 
			this.groupHotkeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupHotkeys.AutoSize = true;
			this.groupHotkeys.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupHotkeys.Location = new System.Drawing.Point(3, 85);
			this.groupHotkeys.Name = "groupHotkeys";
			this.groupHotkeys.Size = new System.Drawing.Size(56, 15);
			this.groupHotkeys.TabIndex = 3;
			this.groupHotkeys.Text = "Hot keys:";
			// 
			// txtHotKeyShowHide
			// 
			this.txtHotKeyShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHotKeyShowHide.Location = new System.Drawing.Point(16, 106);
			this.txtHotKeyShowHide.Name = "txtHotKeyShowHide";
			this.txtHotKeyShowHide.ReadOnly = true;
			this.txtHotKeyShowHide.Size = new System.Drawing.Size(165, 23);
			this.txtHotKeyShowHide.TabIndex = 4;
			// 
			// lblHotKeyShowHide
			// 
			this.lblHotKeyShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblHotKeyShowHide.BackColor = System.Drawing.Color.Transparent;
			this.lblHotKeyShowHide.Location = new System.Drawing.Point(191, 109);
			this.lblHotKeyShowHide.Name = "lblHotKeyShowHide";
			this.lblHotKeyShowHide.Size = new System.Drawing.Size(93, 20);
			this.lblHotKeyShowHide.TabIndex = 5;
			this.lblHotKeyShowHide.Text = "Show/Hide";
			// 
			// txtHotKeyClone
			// 
			this.txtHotKeyClone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHotKeyClone.Location = new System.Drawing.Point(16, 136);
			this.txtHotKeyClone.Name = "txtHotKeyClone";
			this.txtHotKeyClone.ReadOnly = true;
			this.txtHotKeyClone.Size = new System.Drawing.Size(165, 23);
			this.txtHotKeyClone.TabIndex = 6;
			// 
			// lblHotKeyClone
			// 
			this.lblHotKeyClone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblHotKeyClone.BackColor = System.Drawing.Color.Transparent;
			this.lblHotKeyClone.Location = new System.Drawing.Point(191, 139);
			this.lblHotKeyClone.Name = "lblHotKeyClone";
			this.lblHotKeyClone.Size = new System.Drawing.Size(93, 33);
			this.lblHotKeyClone.TabIndex = 7;
			this.lblHotKeyClone.Text = "Clone current window";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(16, 175);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(268, 45);
			this.label1.TabIndex = 8;
			this.label1.Text = "These system-wide shortcuts can also be used when OnTopReplica is not in focus.";
			// 
			// groupIndicator
			// 
			this.groupIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupIndicator.AutoSize = true;
			this.groupIndicator.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupIndicator.Location = new System.Drawing.Point(3, 228);
			this.groupIndicator.Name = "groupIndicator";
			this.groupIndicator.Size = new System.Drawing.Size(65, 15);
			this.groupIndicator.TabIndex = 9;
			this.groupIndicator.Text = "Color alert:";
			// 
			// checkIndicator
			// 
			this.checkIndicator.AutoSize = true;
			this.checkIndicator.Checked = true;
			this.checkIndicator.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkIndicator.Location = new System.Drawing.Point(16, 252);
			this.checkIndicator.Name = "checkIndicator";
			this.checkIndicator.Size = new System.Drawing.Size(126, 19);
			this.checkIndicator.TabIndex = 10;
			this.checkIndicator.Text = "Show indicator dot";
			this.checkIndicator.UseVisualStyleBackColor = true;
			this.checkIndicator.CheckedChanged += new System.EventHandler(this.Indicator_SettingChanged);
			// 
			// lblIndicatorSize
			// 
			this.lblIndicatorSize.AutoSize = true;
			this.lblIndicatorSize.Location = new System.Drawing.Point(23, 279);
			this.lblIndicatorSize.Name = "lblIndicatorSize";
			this.lblIndicatorSize.Size = new System.Drawing.Size(75, 15);
			this.lblIndicatorSize.TabIndex = 11;
			this.lblIndicatorSize.Text = "Dot size (px):";
			this.lblIndicatorSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numIndicatorSize
			// 
			this.numIndicatorSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numIndicatorSize.Location = new System.Drawing.Point(224, 277);
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
			this.numIndicatorSize.TabIndex = 12;
			this.numIndicatorSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
			this.numIndicatorSize.ValueChanged += new System.EventHandler(this.Indicator_SettingChanged);
			// 
			// lblIndicatorRunColor
			// 
			this.lblIndicatorRunColor.AutoSize = true;
			this.lblIndicatorRunColor.Location = new System.Drawing.Point(23, 309);
			this.lblIndicatorRunColor.Name = "lblIndicatorRunColor";
			this.lblIndicatorRunColor.Size = new System.Drawing.Size(85, 15);
			this.lblIndicatorRunColor.TabIndex = 13;
			this.lblIndicatorRunColor.Text = "Running color:";
			this.lblIndicatorRunColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelIndicatorRunColor
			// 
			this.panelIndicatorRunColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panelIndicatorRunColor.BackColor = System.Drawing.Color.Red;
			this.panelIndicatorRunColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelIndicatorRunColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelIndicatorRunColor.Location = new System.Drawing.Point(224, 309);
			this.panelIndicatorRunColor.Name = "panelIndicatorRunColor";
			this.panelIndicatorRunColor.Size = new System.Drawing.Size(60, 20);
			this.panelIndicatorRunColor.TabIndex = 14;
			this.panelIndicatorRunColor.Click += new System.EventHandler(this.PanelIndicatorRunColor_Click);
			// 
			// lblIndicatorPauseColor
			// 
			this.lblIndicatorPauseColor.AutoSize = true;
			this.lblIndicatorPauseColor.Location = new System.Drawing.Point(23, 339);
			this.lblIndicatorPauseColor.Name = "lblIndicatorPauseColor";
			this.lblIndicatorPauseColor.Size = new System.Drawing.Size(78, 15);
			this.lblIndicatorPauseColor.TabIndex = 15;
			this.lblIndicatorPauseColor.Text = "Stopped color:";
			this.lblIndicatorPauseColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelIndicatorPauseColor
			// 
			this.panelIndicatorPauseColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panelIndicatorPauseColor.BackColor = System.Drawing.Color.LimeGreen;
			this.panelIndicatorPauseColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelIndicatorPauseColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelIndicatorPauseColor.Location = new System.Drawing.Point(224, 339);
			this.panelIndicatorPauseColor.Name = "panelIndicatorPauseColor";
			this.panelIndicatorPauseColor.Size = new System.Drawing.Size(60, 20);
			this.panelIndicatorPauseColor.TabIndex = 16;
			this.panelIndicatorPauseColor.Click += new System.EventHandler(this.PanelIndicatorPauseColor_Click);
			// 
			// checkPauseColorAlertOnLoss
			// 
			this.checkPauseColorAlertOnLoss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkPauseColorAlertOnLoss.AutoSize = true;
			this.checkPauseColorAlertOnLoss.Location = new System.Drawing.Point(16, 368);
			this.checkPauseColorAlertOnLoss.Name = "checkPauseColorAlertOnLoss";
			this.checkPauseColorAlertOnLoss.Size = new System.Drawing.Size(248, 19);
			this.checkPauseColorAlertOnLoss.TabIndex = 17;
			this.checkPauseColorAlertOnLoss.Text = "Stop color alerts when the window is lost";
			this.checkPauseColorAlertOnLoss.UseVisualStyleBackColor = true;
			this.checkPauseColorAlertOnLoss.CheckedChanged += new System.EventHandler(this.PauseColorAlertOnLoss_CheckedChanged);
			// 
			// groupAutoHide
			// 
			this.groupAutoHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupAutoHide.AutoSize = true;
			this.groupAutoHide.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.groupAutoHide.Location = new System.Drawing.Point(3, 398);
			this.groupAutoHide.Name = "groupAutoHide";
			this.groupAutoHide.Size = new System.Drawing.Size(62, 15);
			this.groupAutoHide.TabIndex = 18;
			this.groupAutoHide.Text = "Auto hide:";
			// 
			// checkAutoHide
			// 
			this.checkAutoHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkAutoHide.AutoSize = true;
			this.checkAutoHide.Location = new System.Drawing.Point(16, 419);
			this.checkAutoHide.Name = "checkAutoHide";
			this.checkAutoHide.Size = new System.Drawing.Size(253, 19);
			this.checkAutoHide.TabIndex = 19;
			this.checkAutoHide.Text = "Show/hide in sync with the cloned window";
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
			this.Size = new System.Drawing.Size(315, 494);
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numIndicatorSize)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label groupLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private ImageComboBox comboLanguage;
        private System.Windows.Forms.Label groupHotkeys;
        private HotKeyTextBox txtHotKeyClone;
        private System.Windows.Forms.Label lblHotKeyShowHide;
        private HotKeyTextBox txtHotKeyShowHide;
        private System.Windows.Forms.Label lblHotKeyClone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label groupIndicator;
        private System.Windows.Forms.CheckBox checkIndicator;
        private System.Windows.Forms.Label lblIndicatorSize;
        private System.Windows.Forms.NumericUpDown numIndicatorSize;
        private System.Windows.Forms.Label lblIndicatorRunColor;
        private System.Windows.Forms.Panel panelIndicatorRunColor;
        private System.Windows.Forms.Label lblIndicatorPauseColor;
        private System.Windows.Forms.Panel panelIndicatorPauseColor;
        private System.Windows.Forms.Label groupAutoHide;
        private System.Windows.Forms.CheckBox checkAutoHide;
        private System.Windows.Forms.CheckBox checkPauseColorAlertOnLoss;
    }
}
