namespace APKQuickInstall
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpDevice;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Button btnRefreshDevices;
        private System.Windows.Forms.Button btnNetworkDevice;

        private System.Windows.Forms.GroupBox grpApk;
        private System.Windows.Forms.Label lblApkPath;
        private System.Windows.Forms.TextBox txtApkPath;
        private System.Windows.Forms.Button btnBrowseApk;
        private System.Windows.Forms.Label lblApkName;
        private System.Windows.Forms.Label lblApkSize;

        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkReinstall;
        private System.Windows.Forms.CheckBox chkGrantPermissions;

        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;

        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuLangEnglish;
        private System.Windows.Forms.ToolStripMenuItem menuLangFrench;
        private System.Windows.Forms.ToolStripMenuItem menuLangArabic;



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            grpDevice = new GroupBox();
            lblDevice = new Label();
            cmbDevices = new ComboBox();
            btnRefreshDevices = new Button();
            btnNetworkDevice = new Button();
            grpApk = new GroupBox();
            lblApkPath = new Label();
            txtApkPath = new TextBox();
            btnBrowseApk = new Button();
            lblApkName = new Label();
            lblApkSize = new Label();
            grpOptions = new GroupBox();
            chkReinstall = new CheckBox();
            chkGrantPermissions = new CheckBox();
            btnInstall = new Button();
            btnUninstall = new Button();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            grpLog = new GroupBox();
            txtLog = new TextBox();
            btnClearLog = new Button();
            btnClose = new Button();
            menuStrip = new MenuStrip();
            menuLanguage = new ToolStripMenuItem();
            menuLangEnglish = new ToolStripMenuItem();
            menuLangFrench = new ToolStripMenuItem();
            menuLangArabic = new ToolStripMenuItem();
            menuConfigurationADB = new ToolStripMenuItem();
            menuAbout = new ToolStripMenuItem();
            grpDevice.SuspendLayout();
            grpApk.SuspendLayout();
            grpOptions.SuspendLayout();
            grpLog.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // grpDevice
            // 
            grpDevice.BackColor = Color.Transparent;
            grpDevice.Controls.Add(lblDevice);
            grpDevice.Controls.Add(cmbDevices);
            grpDevice.Controls.Add(btnRefreshDevices);
            grpDevice.Controls.Add(btnNetworkDevice);
            grpDevice.Location = new Point(14, 38);
            grpDevice.Margin = new Padding(3, 4, 3, 4);
            grpDevice.Name = "grpDevice";
            grpDevice.Padding = new Padding(3, 4, 3, 4);
            grpDevice.Size = new Size(869, 93);
            grpDevice.TabIndex = 0;
            grpDevice.TabStop = false;
            grpDevice.Text = "Appareil Android";
            // 
            // lblDevice
            // 
            lblDevice.AutoSize = true;
            lblDevice.Location = new Point(17, 40);
            lblDevice.Name = "lblDevice";
            lblDevice.Size = new Size(73, 20);
            lblDevice.TabIndex = 0;
            lblDevice.Text = "Appareil :";
            // 
            // cmbDevices
            // 
            cmbDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDevices.FormattingEnabled = true;
            cmbDevices.Location = new Point(97, 36);
            cmbDevices.Margin = new Padding(3, 4, 3, 4);
            cmbDevices.Name = "cmbDevices";
            cmbDevices.Size = new Size(464, 28);
            cmbDevices.TabIndex = 1;
            cmbDevices.SelectedIndexChanged += CmbDevices_SelectedIndexChanged;
            // 
            // btnRefreshDevices
            // 
            btnRefreshDevices.Font = new Font("Segoe UI Emoji", 9.07563F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefreshDevices.Location = new Point(567, 32);
            btnRefreshDevices.Margin = new Padding(3, 4, 3, 4);
            btnRefreshDevices.Name = "btnRefreshDevices";
            btnRefreshDevices.Size = new Size(136, 36);
            btnRefreshDevices.TabIndex = 2;
            btnRefreshDevices.Text = "🔄 Actualiser";
            btnRefreshDevices.UseVisualStyleBackColor = true;
            btnRefreshDevices.Click += BtnRefreshDevices_Click;
            // 
            // btnNetworkDevice
            // 
            btnNetworkDevice.Font = new Font("Segoe UI Emoji", 9.07563F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNetworkDevice.Location = new Point(709, 32);
            btnNetworkDevice.Margin = new Padding(3, 4, 3, 4);
            btnNetworkDevice.Name = "btnNetworkDevice";
            btnNetworkDevice.Size = new Size(136, 36);
            btnNetworkDevice.TabIndex = 3;
            btnNetworkDevice.Text = "🌐 Réseau...";
            btnNetworkDevice.UseVisualStyleBackColor = true;
            btnNetworkDevice.Click += BtnNetworkDevice_Click;
            // 
            // grpApk
            // 
            grpApk.BackColor = Color.Transparent;
            grpApk.Controls.Add(lblApkPath);
            grpApk.Controls.Add(txtApkPath);
            grpApk.Controls.Add(btnBrowseApk);
            grpApk.Controls.Add(lblApkName);
            grpApk.Controls.Add(lblApkSize);
            grpApk.Location = new Point(14, 142);
            grpApk.Margin = new Padding(3, 4, 3, 4);
            grpApk.Name = "grpApk";
            grpApk.Padding = new Padding(3, 4, 3, 4);
            grpApk.Size = new Size(869, 133);
            grpApk.TabIndex = 1;
            grpApk.TabStop = false;
            grpApk.Text = "Fichier APK";
            // 
            // lblApkPath
            // 
            lblApkPath.AutoSize = true;
            lblApkPath.Location = new Point(17, 40);
            lblApkPath.Name = "lblApkPath";
            lblApkPath.Size = new Size(59, 20);
            lblApkPath.TabIndex = 0;
            lblApkPath.Text = "Fichier :";
            // 
            // txtApkPath
            // 
            txtApkPath.BackColor = Color.WhiteSmoke;
            txtApkPath.Location = new Point(97, 36);
            txtApkPath.Margin = new Padding(3, 4, 3, 4);
            txtApkPath.Name = "txtApkPath";
            txtApkPath.ReadOnly = true;
            txtApkPath.Size = new Size(594, 27);
            txtApkPath.TabIndex = 1;
            // 
            // btnBrowseApk
            // 
            btnBrowseApk.Font = new Font("Segoe UI Emoji", 9.07563F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowseApk.Location = new Point(709, 33);
            btnBrowseApk.Margin = new Padding(3, 4, 3, 4);
            btnBrowseApk.Name = "btnBrowseApk";
            btnBrowseApk.Size = new Size(137, 36);
            btnBrowseApk.TabIndex = 2;
            btnBrowseApk.Text = "📁 Parcourir...";
            btnBrowseApk.UseVisualStyleBackColor = true;
            btnBrowseApk.Click += BtnBrowseApk_Click;
            // 
            // lblApkName
            // 
            lblApkName.AutoSize = true;
            lblApkName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApkName.Location = new Point(97, 80);
            lblApkName.Name = "lblApkName";
            lblApkName.Size = new Size(185, 20);
            lblApkName.TabIndex = 3;
            lblApkName.Text = "Aucun fichier sélectionné";
            // 
            // lblApkSize
            // 
            lblApkSize.AutoSize = true;
            lblApkSize.ForeColor = Color.Gray;
            lblApkSize.Location = new Point(97, 100);
            lblApkSize.Name = "lblApkSize";
            lblApkSize.Size = new Size(0, 20);
            lblApkSize.TabIndex = 4;
            // 
            // grpOptions
            // 
            grpOptions.BackColor = Color.Transparent;
            grpOptions.Controls.Add(chkReinstall);
            grpOptions.Controls.Add(chkGrantPermissions);
            grpOptions.Location = new Point(14, 286);
            grpOptions.Margin = new Padding(3, 4, 3, 4);
            grpOptions.Name = "grpOptions";
            grpOptions.Padding = new Padding(3, 4, 3, 4);
            grpOptions.Size = new Size(411, 107);
            grpOptions.TabIndex = 2;
            grpOptions.TabStop = false;
            grpOptions.Text = "Options d'installation";
            // 
            // chkReinstall
            // 
            chkReinstall.AutoSize = true;
            chkReinstall.Location = new Point(17, 40);
            chkReinstall.Margin = new Padding(3, 4, 3, 4);
            chkReinstall.Name = "chkReinstall";
            chkReinstall.Size = new Size(284, 24);
            chkReinstall.TabIndex = 0;
            chkReinstall.Text = "Réinstaller (remplacer si déjà installée)";
            chkReinstall.UseVisualStyleBackColor = true;
            // 
            // chkGrantPermissions
            // 
            chkGrantPermissions.AutoSize = true;
            chkGrantPermissions.Location = new Point(17, 69);
            chkGrantPermissions.Margin = new Padding(3, 4, 3, 4);
            chkGrantPermissions.Name = "chkGrantPermissions";
            chkGrantPermissions.Size = new Size(237, 24);
            chkGrantPermissions.TabIndex = 1;
            chkGrantPermissions.Text = "Accorder toutes les permissions";
            chkGrantPermissions.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            btnInstall.BackColor = Color.FromArgb(0, 120, 215);
            btnInstall.Enabled = false;
            btnInstall.FlatStyle = FlatStyle.Flat;
            btnInstall.Font = new Font("Segoe UI Emoji", 10.2857141F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInstall.ForeColor = Color.White;
            btnInstall.Location = new Point(446, 302);
            btnInstall.Margin = new Padding(3, 4, 3, 4);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(206, 60);
            btnInstall.TabIndex = 3;
            btnInstall.Text = "📦 Installer l'APK";
            btnInstall.UseVisualStyleBackColor = false;
            btnInstall.Click += BtnInstall_Click;
            // 
            // btnUninstall
            // 
            btnUninstall.Font = new Font("Segoe UI Emoji", 9.07563F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUninstall.Location = new Point(677, 302);
            btnUninstall.Margin = new Padding(3, 4, 3, 4);
            btnUninstall.Name = "btnUninstall";
            btnUninstall.Size = new Size(206, 60);
            btnUninstall.TabIndex = 4;
            btnUninstall.Text = "🗑️ Désinstaller une app";
            btnUninstall.UseVisualStyleBackColor = true;
            btnUninstall.Click += BtnUninstall_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(14, 409);
            progressBar.Margin = new Padding(3, 4, 3, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(869, 33);
            progressBar.TabIndex = 5;
            progressBar.Visible = false;
            // 
            // lblProgress
            // 
            lblProgress.Location = new Point(14, 427);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(869, 27);
            lblProgress.TabIndex = 6;
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpLog
            // 
            grpLog.BackColor = Color.Transparent;
            grpLog.Controls.Add(txtLog);
            grpLog.Controls.Add(btnClearLog);
            grpLog.Location = new Point(14, 489);
            grpLog.Margin = new Padding(3, 4, 3, 4);
            grpLog.Name = "grpLog";
            grpLog.Padding = new Padding(3, 4, 3, 4);
            grpLog.Size = new Size(869, 267);
            grpLog.TabIndex = 7;
            grpLog.TabStop = false;
            grpLog.Text = "Journal d'activité";
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.Black;
            txtLog.Font = new Font("Consolas", 9F);
            txtLog.ForeColor = Color.Lime;
            txtLog.Location = new Point(17, 33);
            txtLog.Margin = new Padding(3, 4, 3, 4);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(828, 172);
            txtLog.TabIndex = 0;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(17, 216);
            btnClearLog.Margin = new Padding(3, 4, 3, 4);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(114, 33);
            btnClearLog.TabIndex = 1;
            btnClearLog.Text = "Effacer";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += BtnClearLog_Click;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClose.BackColor = Color.DarkRed;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(232, 17, 35);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 9.07563F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(855, 2);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(38, 30);
            btnClose.TabIndex = 2;
            btnClose.Text = "(&X)";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Transparent;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { menuLanguage, menuConfigurationADB, menuAbout });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(896, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // menuLanguage
            // 
            menuLanguage.DropDownItems.AddRange(new ToolStripItem[] { menuLangEnglish, menuLangFrench, menuLangArabic });
            menuLanguage.Name = "menuLanguage";
            menuLanguage.Size = new Size(113, 24);
            menuLanguage.Text = "🌍 Language";
            // 
            // menuLangEnglish
            // 
            menuLangEnglish.Name = "menuLangEnglish";
            menuLangEnglish.Size = new Size(145, 26);
            menuLangEnglish.Text = "English";
            menuLangEnglish.Click += MenuLangEnglish_Click;
            // 
            // menuLangFrench
            // 
            menuLangFrench.Name = "menuLangFrench";
            menuLangFrench.Size = new Size(145, 26);
            menuLangFrench.Text = "Français";
            menuLangFrench.Click += MenuLangFrench_Click;
            // 
            // menuLangArabic
            // 
            menuLangArabic.Name = "menuLangArabic";
            menuLangArabic.Size = new Size(145, 26);
            menuLangArabic.Text = "العربية";
            menuLangArabic.Click += MenuLangArabic_Click;
            // 
            // menuConfigurationADB
            // 
            menuConfigurationADB.Name = "menuConfigurationADB";
            menuConfigurationADB.Size = new Size(169, 24);
            menuConfigurationADB.Text = "⚙️Configuration ADB";
            menuConfigurationADB.Click += menuConfigurationADB_Click;
            // 
            // menuAbout
            // 
            menuAbout.Name = "menuAbout";
            menuAbout.Size = new Size(89, 24);
            menuAbout.Text = "\U0001faa7 About";
            menuAbout.Click += menuAbout_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(896, 770);
            ControlBox = false;
            Controls.Add(btnClose);
            Controls.Add(grpLog);
            Controls.Add(lblProgress);
            Controls.Add(progressBar);
            Controls.Add(btnUninstall);
            Controls.Add(btnInstall);
            Controls.Add(grpOptions);
            Controls.Add(grpApk);
            Controls.Add(grpDevice);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ADB APK Installer - Installation d'applications Android";
            Load += MainForm_Load;
            grpDevice.ResumeLayout(false);
            grpDevice.PerformLayout();
            grpApk.ResumeLayout(false);
            grpApk.PerformLayout();
            grpOptions.ResumeLayout(false);
            grpOptions.PerformLayout();
            grpLog.ResumeLayout(false);
            grpLog.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem menuConfigurationADB;
        private ToolStripMenuItem menuAbout;
        private Button btnClose;
    }
}