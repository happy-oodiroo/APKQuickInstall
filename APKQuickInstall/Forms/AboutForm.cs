using APKQuickInstall.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static APKQuickInstall.Localization.LocalizationHelper;

namespace APKQuickInstall
{
    public partial class AboutForm : Form
    {
        private ControlPositionManager positionManager = new ControlPositionManager();
        public AboutForm()
        {
            InitializeComponent();
            ReloadLocalization();
            LoadAppInfo();
        }

        public void ReloadLocalization()
        {
            this.Text = T("About.Title");
            lblTitle.Text = T("AppTitle");
            lblVersionLabel.Text = T("About.Version");
            lblAuthorLabel.Text = T("About.Author");
            lblAuthor.Text = T("About.AuthorName");
            lblDescriptionLabel.Text = T("About.Description");
            lblDescription.Text = T("About.DescriptionText");
            grpTechnologies.Text = T("About.Technologies");
            btnClose.Text = T("Common.Close");
            linkGitHub.Text = T("About.GitHubRepo");
            lblCopyright.Text = T("About.Copyright");

            if (LocalizationManager.Instance.CurrentLanguage == "ar")
            {
                this.RightToLeft = RightToLeft.Yes;
                positionManager.MirrorPositions(this, true);
            }
            else
            {
                this.RightToLeft = RightToLeft.No;
                positionManager.RestoreOriginalPositions(this);
            }
        }

        private void LoadAppInfo()
        {
            // Obtenir la version de l'assembly
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = $"{version?.Major}.{version?.Minor}.{version?.Build}";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Ouvrir le lien GitHub dans le navigateur
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/happy-oodiroo/APKQuickInstall",
                    UseShellExecute = true
                });
            }
            catch
            {
                ShowMessage("About.ErrorOpenLink",
                    "Common.Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
