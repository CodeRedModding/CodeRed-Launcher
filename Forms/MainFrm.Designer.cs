
namespace CodeRedLauncher
{
    partial class MainFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            TabCtrl = new System.Windows.Forms.TabControl();
            AboutTab = new System.Windows.Forms.TabPage();
            AboutArtOne = new System.Windows.Forms.PictureBox();
            EasterEggImg = new System.Windows.Forms.PictureBox();
            PlatformInfoCtrl = new CodeRedLauncher.Controls.CRAboutInfo();
            BuildInfoCtrl = new CodeRedLauncher.Controls.CRAboutInfo();
            PsyonixInfoCtrl = new CodeRedLauncher.Controls.CRAboutInfo();
            ModuleInfoCtrl = new CodeRedLauncher.Controls.CRAboutInfo();
            LauncherInfoCtrl = new CodeRedLauncher.Controls.CRAboutInfo();
            WebsiteInfoCtrl = new CodeRedLauncher.Controls.CRAboutInfo();
            DiscordInfoCtrl = new CodeRedLauncher.Controls.CRAboutInfo();
            DonateInfoCtrl = new CodeRedLauncher.Controls.CRAboutInfo();
            RemixInfoCtrl = new CodeRedLauncher.Controls.CRAboutInfo();
            CheckUpdatesBtn = new CodeRedLauncher.Controls.CRButton();
            CreditsLbl = new System.Windows.Forms.Label();
            DashboardTab = new System.Windows.Forms.TabPage();
            VersionCtrl = new CodeRedLauncher.Controls.CRVersionStatus();
            ChangelogCtrl = new CodeRedLauncher.Controls.CRChangelog();
            DashboardArtTwo = new System.Windows.Forms.PictureBox();
            ProcessCtrl = new CodeRedLauncher.Controls.CRProcessStatus();
            DashboardArtOne = new System.Windows.Forms.PictureBox();
            ManualInjectBtn = new CodeRedLauncher.Controls.CRButton();
            NewsTab = new System.Windows.Forms.TabPage();
            NewsCtrl = new CodeRedLauncher.Controls.CRNews();
            NewsArtOne = new System.Windows.Forms.PictureBox();
            NewsArtTwo = new System.Windows.Forms.PictureBox();
            SettingsTab = new System.Windows.Forms.TabPage();
            AutoInstallBx = new CodeRedLauncher.Controls.CRCheckbox();
            SettingsArtTwo = new System.Windows.Forms.PictureBox();
            SettingsArtOne = new System.Windows.Forms.PictureBox();
            HideWhenMinimizedBx = new CodeRedLauncher.Controls.CRCheckbox();
            InstallPathLbl = new CodeRedLauncher.Controls.CRIconLabel();
            LightModeBx = new CodeRedLauncher.Controls.CRCheckbox();
            ManualInjectBx = new CodeRedLauncher.Controls.CRCheckbox();
            InstallPathBx = new CodeRedLauncher.Controls.CRTextbox();
            OpenFolderBtn = new CodeRedLauncher.Controls.CRButton();
            ExportLogsBtn = new CodeRedLauncher.Controls.CRButton();
            InjectAllInstancesBx = new CodeRedLauncher.Controls.CRCheckbox();
            MinimizeOnStartupBx = new CodeRedLauncher.Controls.CRCheckbox();
            RunOnStartupBx = new CodeRedLauncher.Controls.CRCheckbox();
            PreventInjectionBx = new CodeRedLauncher.Controls.CRCheckbox();
            AutoCheckUpdatesBx = new CodeRedLauncher.Controls.CRCheckbox();
            InjectionTimeoutBx = new CodeRedLauncher.Controls.CRNumberbox();
            InjectionTimeoutLbl = new CodeRedLauncher.Controls.CRIconLabel();
            InstallPathBtn = new CodeRedLauncher.Controls.CRButton();
            BackgroundPnl = new System.Windows.Forms.Panel();
            TabPnl = new System.Windows.Forms.Panel();
            AboutTabBtn = new CodeRedLauncher.Controls.CRTab();
            SettingsTabBtn = new CodeRedLauncher.Controls.CRTab();
            ExitTabBtn = new CodeRedLauncher.Controls.CRTab();
            NewsTabBtn = new CodeRedLauncher.Controls.CRTab();
            DashboardTabBtn = new CodeRedLauncher.Controls.CRTab();
            OfflinePopup = new CodeRedLauncher.Controls.CROfflinePopup();
            DuplicatePopup = new CodeRedLauncher.Controls.CRDupePopup();
            PathPopup = new CodeRedLauncher.Controls.CRPathPopup();
            InstallPopup = new CodeRedLauncher.Controls.CRInstallPopup();
            UpdatePopup = new CodeRedLauncher.Controls.CRUpdatePopup();
            TitleBar = new CodeRedLauncher.Controls.CRTitleBar();
            ProcessTmr = new System.Windows.Forms.Timer(components);
            InjectTmr = new System.Windows.Forms.Timer(components);
            TrayIcon = new System.Windows.Forms.NotifyIcon(components);
            UpdateTmr = new System.Windows.Forms.Timer(components);
            TabCtrl.SuspendLayout();
            AboutTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AboutArtOne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EasterEggImg).BeginInit();
            DashboardTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DashboardArtTwo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DashboardArtOne).BeginInit();
            NewsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NewsArtOne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NewsArtTwo).BeginInit();
            SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SettingsArtTwo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsArtOne).BeginInit();
            BackgroundPnl.SuspendLayout();
            TabPnl.SuspendLayout();
            SuspendLayout();
            // 
            // TabCtrl
            // 
            TabCtrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TabCtrl.Controls.Add(AboutTab);
            TabCtrl.Controls.Add(DashboardTab);
            TabCtrl.Controls.Add(NewsTab);
            TabCtrl.Controls.Add(SettingsTab);
            TabCtrl.Location = new System.Drawing.Point(56, 6);
            TabCtrl.Name = "TabCtrl";
            TabCtrl.SelectedIndex = 0;
            TabCtrl.Size = new System.Drawing.Size(918, 628);
            TabCtrl.TabIndex = 3;
            // 
            // AboutTab
            // 
            AboutTab.BackColor = System.Drawing.Color.FromArgb(30, 31, 34);
            AboutTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            AboutTab.Controls.Add(AboutArtOne);
            AboutTab.Controls.Add(EasterEggImg);
            AboutTab.Controls.Add(PlatformInfoCtrl);
            AboutTab.Controls.Add(BuildInfoCtrl);
            AboutTab.Controls.Add(PsyonixInfoCtrl);
            AboutTab.Controls.Add(ModuleInfoCtrl);
            AboutTab.Controls.Add(LauncherInfoCtrl);
            AboutTab.Controls.Add(WebsiteInfoCtrl);
            AboutTab.Controls.Add(DiscordInfoCtrl);
            AboutTab.Controls.Add(DonateInfoCtrl);
            AboutTab.Controls.Add(RemixInfoCtrl);
            AboutTab.Controls.Add(CheckUpdatesBtn);
            AboutTab.Controls.Add(CreditsLbl);
            AboutTab.Location = new System.Drawing.Point(4, 24);
            AboutTab.Name = "AboutTab";
            AboutTab.Size = new System.Drawing.Size(910, 600);
            AboutTab.TabIndex = 5;
            AboutTab.Text = "About";
            // 
            // AboutArtOne
            // 
            AboutArtOne.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AboutArtOne.BackColor = System.Drawing.Color.Transparent;
            AboutArtOne.BackgroundImage = Properties.Resources.TR4_Dark;
            AboutArtOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            AboutArtOne.Location = new System.Drawing.Point(713, 0);
            AboutArtOne.Name = "AboutArtOne";
            AboutArtOne.Size = new System.Drawing.Size(197, 140);
            AboutArtOne.TabIndex = 78;
            AboutArtOne.TabStop = false;
            // 
            // EasterEggImg
            // 
            EasterEggImg.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            EasterEggImg.BackColor = System.Drawing.Color.Transparent;
            EasterEggImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            EasterEggImg.Cursor = System.Windows.Forms.Cursors.Hand;
            EasterEggImg.Location = new System.Drawing.Point(675, 475);
            EasterEggImg.Name = "EasterEggImg";
            EasterEggImg.Size = new System.Drawing.Size(35, 35);
            EasterEggImg.TabIndex = 75;
            EasterEggImg.TabStop = false;
            EasterEggImg.Click += EasterEggImg_Click;
            // 
            // PlatformInfoCtrl
            // 
            PlatformInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            PlatformInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            PlatformInfoCtrl.DescriptionText = "Loading...";
            PlatformInfoCtrl.Hyperlink = false;
            PlatformInfoCtrl.IconDark = Properties.Resources.Rocket_Red;
            PlatformInfoCtrl.IconLight = Properties.Resources.Rocket_Purple;
            PlatformInfoCtrl.Location = new System.Drawing.Point(35, 215);
            PlatformInfoCtrl.Name = "PlatformInfoCtrl";
            PlatformInfoCtrl.Size = new System.Drawing.Size(435, 35);
            PlatformInfoCtrl.TabIndex = 41;
            PlatformInfoCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            PlatformInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            PlatformInfoCtrl.TitleText = "Platform";
            // 
            // BuildInfoCtrl
            // 
            BuildInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            BuildInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            BuildInfoCtrl.DescriptionText = "Loading...";
            BuildInfoCtrl.Hyperlink = false;
            BuildInfoCtrl.IconDark = Properties.Resources.Drive_Red;
            BuildInfoCtrl.IconLight = Properties.Resources.Drive_Purple;
            BuildInfoCtrl.Location = new System.Drawing.Point(35, 170);
            BuildInfoCtrl.Name = "BuildInfoCtrl";
            BuildInfoCtrl.Size = new System.Drawing.Size(435, 35);
            BuildInfoCtrl.TabIndex = 40;
            BuildInfoCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            BuildInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            BuildInfoCtrl.TitleText = "Build version";
            // 
            // PsyonixInfoCtrl
            // 
            PsyonixInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            PsyonixInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            PsyonixInfoCtrl.DescriptionText = "Loading...";
            PsyonixInfoCtrl.Hyperlink = false;
            PsyonixInfoCtrl.IconDark = Properties.Resources.Server_Red;
            PsyonixInfoCtrl.IconLight = Properties.Resources.Server_Purple;
            PsyonixInfoCtrl.Location = new System.Drawing.Point(35, 125);
            PsyonixInfoCtrl.Name = "PsyonixInfoCtrl";
            PsyonixInfoCtrl.Size = new System.Drawing.Size(435, 35);
            PsyonixInfoCtrl.TabIndex = 39;
            PsyonixInfoCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            PsyonixInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            PsyonixInfoCtrl.TitleText = "Psyonix version";
            // 
            // ModuleInfoCtrl
            // 
            ModuleInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            ModuleInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            ModuleInfoCtrl.DescriptionText = "Loading...";
            ModuleInfoCtrl.Hyperlink = false;
            ModuleInfoCtrl.IconDark = Properties.Resources.Database_Red;
            ModuleInfoCtrl.IconLight = Properties.Resources.Database_Purple;
            ModuleInfoCtrl.Location = new System.Drawing.Point(35, 80);
            ModuleInfoCtrl.Name = "ModuleInfoCtrl";
            ModuleInfoCtrl.Size = new System.Drawing.Size(435, 35);
            ModuleInfoCtrl.TabIndex = 38;
            ModuleInfoCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            ModuleInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ModuleInfoCtrl.TitleText = "Module version";
            // 
            // LauncherInfoCtrl
            // 
            LauncherInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            LauncherInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            LauncherInfoCtrl.DescriptionText = "Loading...";
            LauncherInfoCtrl.Hyperlink = false;
            LauncherInfoCtrl.IconDark = Properties.Resources.Box_Red;
            LauncherInfoCtrl.IconLight = Properties.Resources.Box_Purple;
            LauncherInfoCtrl.Location = new System.Drawing.Point(35, 35);
            LauncherInfoCtrl.Name = "LauncherInfoCtrl";
            LauncherInfoCtrl.Size = new System.Drawing.Size(435, 35);
            LauncherInfoCtrl.TabIndex = 37;
            LauncherInfoCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            LauncherInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            LauncherInfoCtrl.TitleText = "Launcher version";
            // 
            // WebsiteInfoCtrl
            // 
            WebsiteInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            WebsiteInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            WebsiteInfoCtrl.DescriptionText = "https://coderedmodding.github.io/";
            WebsiteInfoCtrl.Hyperlink = true;
            WebsiteInfoCtrl.IconDark = Properties.Resources.Website_Red;
            WebsiteInfoCtrl.IconLight = Properties.Resources.Website_Purple;
            WebsiteInfoCtrl.Location = new System.Drawing.Point(35, 260);
            WebsiteInfoCtrl.Name = "WebsiteInfoCtrl";
            WebsiteInfoCtrl.Size = new System.Drawing.Size(435, 35);
            WebsiteInfoCtrl.TabIndex = 36;
            WebsiteInfoCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            WebsiteInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            WebsiteInfoCtrl.TitleText = "Website";
            // 
            // DiscordInfoCtrl
            // 
            DiscordInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            DiscordInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            DiscordInfoCtrl.DescriptionText = "https://discord.gg/";
            DiscordInfoCtrl.Hyperlink = true;
            DiscordInfoCtrl.IconDark = Properties.Resources.Discord_Red;
            DiscordInfoCtrl.IconLight = Properties.Resources.Discord_Purple;
            DiscordInfoCtrl.Location = new System.Drawing.Point(35, 305);
            DiscordInfoCtrl.Name = "DiscordInfoCtrl";
            DiscordInfoCtrl.Size = new System.Drawing.Size(435, 35);
            DiscordInfoCtrl.TabIndex = 34;
            DiscordInfoCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            DiscordInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            DiscordInfoCtrl.TitleText = "Discord";
            // 
            // DonateInfoCtrl
            // 
            DonateInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            DonateInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            DonateInfoCtrl.DescriptionText = "https://ko-fi.com/coderedmodding/";
            DonateInfoCtrl.Hyperlink = true;
            DonateInfoCtrl.IconDark = Properties.Resources.Coffee_Red;
            DonateInfoCtrl.IconLight = Properties.Resources.Coffee_Purple;
            DonateInfoCtrl.Location = new System.Drawing.Point(35, 350);
            DonateInfoCtrl.Name = "DonateInfoCtrl";
            DonateInfoCtrl.Size = new System.Drawing.Size(435, 35);
            DonateInfoCtrl.TabIndex = 33;
            DonateInfoCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            DonateInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            DonateInfoCtrl.TitleText = "Donate";
            // 
            // RemixInfoCtrl
            // 
            RemixInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            RemixInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            RemixInfoCtrl.DescriptionText = "https://remixicon.com/";
            RemixInfoCtrl.Hyperlink = true;
            RemixInfoCtrl.IconDark = Properties.Resources.Remix_Red;
            RemixInfoCtrl.IconLight = Properties.Resources.Remix_Purple;
            RemixInfoCtrl.Location = new System.Drawing.Point(35, 395);
            RemixInfoCtrl.Name = "RemixInfoCtrl";
            RemixInfoCtrl.Size = new System.Drawing.Size(435, 35);
            RemixInfoCtrl.TabIndex = 32;
            RemixInfoCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            RemixInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            RemixInfoCtrl.TitleText = "Icons";
            // 
            // CheckUpdatesBtn
            // 
            CheckUpdatesBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            CheckUpdatesBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            CheckUpdatesBtn.ButtonEnabled = true;
            CheckUpdatesBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            CheckUpdatesBtn.DisplayText = "Check for Updates";
            CheckUpdatesBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            CheckUpdatesBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            CheckUpdatesBtn.IconDark = Properties.Resources.Refresh_White;
            CheckUpdatesBtn.IconLight = Properties.Resources.Refresh_White;
            CheckUpdatesBtn.Location = new System.Drawing.Point(240, 475);
            CheckUpdatesBtn.Name = "CheckUpdatesBtn";
            CheckUpdatesBtn.Size = new System.Drawing.Size(426, 35);
            CheckUpdatesBtn.TabIndex = 31;
            CheckUpdatesBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            CheckUpdatesBtn.OnButtonClick += CheckUpdatesBtn_OnButtonClick;
            // 
            // CreditsLbl
            // 
            CreditsLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CreditsLbl.BackColor = System.Drawing.Color.Transparent;
            CreditsLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            CreditsLbl.ForeColor = System.Drawing.Color.FromArgb(128, 132, 142);
            CreditsLbl.Location = new System.Drawing.Point(35, 535);
            CreditsLbl.Name = "CreditsLbl";
            CreditsLbl.Size = new System.Drawing.Size(840, 60);
            CreditsLbl.TabIndex = 21;
            CreditsLbl.Text = "CodeRed was created by ItsBrank, but its creation would not have been possible without the inspiration of the following people: ";
            CreditsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashboardTab
            // 
            DashboardTab.BackColor = System.Drawing.Color.FromArgb(30, 31, 34);
            DashboardTab.Controls.Add(VersionCtrl);
            DashboardTab.Controls.Add(ChangelogCtrl);
            DashboardTab.Controls.Add(DashboardArtTwo);
            DashboardTab.Controls.Add(ProcessCtrl);
            DashboardTab.Controls.Add(DashboardArtOne);
            DashboardTab.Controls.Add(ManualInjectBtn);
            DashboardTab.Location = new System.Drawing.Point(4, 24);
            DashboardTab.Name = "DashboardTab";
            DashboardTab.Padding = new System.Windows.Forms.Padding(3);
            DashboardTab.Size = new System.Drawing.Size(910, 600);
            DashboardTab.TabIndex = 0;
            DashboardTab.Text = "Dashboard";
            // 
            // VersionCtrl
            // 
            VersionCtrl.BackColor = System.Drawing.Color.FromArgb(40, 42, 45);
            VersionCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            VersionCtrl.DescriptionText = "Loading...";
            VersionCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            VersionCtrl.IconDescDark = Properties.Resources.Note_Red;
            VersionCtrl.IconDescLight = Properties.Resources.Note_Purple;
            VersionCtrl.IconTitleDark = Properties.Resources.Shield_Red;
            VersionCtrl.IconTitleLight = Properties.Resources.Shield_Purple;
            VersionCtrl.IconWarnDark = Properties.Resources.Warning_Red;
            VersionCtrl.IconWarnLight = Properties.Resources.Warning_Purple;
            VersionCtrl.Location = new System.Drawing.Point(535, 25);
            VersionCtrl.Name = "VersionCtrl";
            VersionCtrl.Size = new System.Drawing.Size(350, 130);
            VersionCtrl.TabIndex = 39;
            VersionCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            VersionCtrl.TitleFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            VersionCtrl.TitleText = "Loading...";
            VersionCtrl.View = CodeRedLauncher.Controls.VersionViews.Loading;
            // 
            // ChangelogCtrl
            // 
            ChangelogCtrl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ChangelogCtrl.BackColor = System.Drawing.Color.FromArgb(40, 42, 45);
            ChangelogCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ChangelogCtrl.IconLauncherDark = Properties.Resources.Changelog_Red;
            ChangelogCtrl.IconLauncherLight = Properties.Resources.Changelog_Purple;
            ChangelogCtrl.IconModuleDark = Properties.Resources.Changelog_Red;
            ChangelogCtrl.IconModuleLight = Properties.Resources.Changelog_Purple;
            ChangelogCtrl.LauncherText = "Loading...";
            ChangelogCtrl.Location = new System.Drawing.Point(25, 180);
            ChangelogCtrl.ModuleText = "Loading...";
            ChangelogCtrl.Name = "ChangelogCtrl";
            ChangelogCtrl.Size = new System.Drawing.Size(860, 315);
            ChangelogCtrl.TabIndex = 33;
            ChangelogCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            ChangelogCtrl.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            ChangelogCtrl.View = CodeRedLauncher.Controls.ChangelogViews.Module;
            // 
            // DashboardArtTwo
            // 
            DashboardArtTwo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DashboardArtTwo.BackColor = System.Drawing.Color.Transparent;
            DashboardArtTwo.BackgroundImage = Properties.Resources.BR0_Red;
            DashboardArtTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            DashboardArtTwo.Location = new System.Drawing.Point(774, 497);
            DashboardArtTwo.Name = "DashboardArtTwo";
            DashboardArtTwo.Size = new System.Drawing.Size(136, 103);
            DashboardArtTwo.TabIndex = 37;
            DashboardArtTwo.TabStop = false;
            // 
            // ProcessCtrl
            // 
            ProcessCtrl.BackColor = System.Drawing.Color.FromArgb(40, 42, 45);
            ProcessCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ProcessCtrl.DescriptionText = "Loading...";
            ProcessCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            ProcessCtrl.IconDescDark = Properties.Resources.Message_Red;
            ProcessCtrl.IconDescLight = Properties.Resources.Message_Purple;
            ProcessCtrl.IconTitleDark = Properties.Resources.Rocket_Red;
            ProcessCtrl.IconTitleLight = Properties.Resources.Rocket_Purple;
            ProcessCtrl.IconWarnDark = Properties.Resources.Warning_Red;
            ProcessCtrl.IconWarnLight = Properties.Resources.Warning_Purple;
            ProcessCtrl.Location = new System.Drawing.Point(25, 25);
            ProcessCtrl.Name = "ProcessCtrl";
            ProcessCtrl.Result = InjectionResults.None;
            ProcessCtrl.Size = new System.Drawing.Size(480, 130);
            ProcessCtrl.TabIndex = 35;
            ProcessCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            ProcessCtrl.TitleFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            ProcessCtrl.TitleText = "Loading...";
            ProcessCtrl.View = CodeRedLauncher.Controls.ProcessViews.Loading;
            // 
            // DashboardArtOne
            // 
            DashboardArtOne.BackColor = System.Drawing.Color.Transparent;
            DashboardArtOne.BackgroundImage = Properties.Resources.TL0_Red;
            DashboardArtOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            DashboardArtOne.Location = new System.Drawing.Point(0, 0);
            DashboardArtOne.Name = "DashboardArtOne";
            DashboardArtOne.Size = new System.Drawing.Size(93, 122);
            DashboardArtOne.TabIndex = 38;
            DashboardArtOne.TabStop = false;
            // 
            // ManualInjectBtn
            // 
            ManualInjectBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            ManualInjectBtn.ButtonEnabled = true;
            ManualInjectBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ManualInjectBtn.DisplayText = "Manually Inject";
            ManualInjectBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ManualInjectBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            ManualInjectBtn.IconDark = Properties.Resources.Mouse_White;
            ManualInjectBtn.IconLight = Properties.Resources.Mouse_White;
            ManualInjectBtn.Location = new System.Drawing.Point(288, 530);
            ManualInjectBtn.Name = "ManualInjectBtn";
            ManualInjectBtn.Size = new System.Drawing.Size(320, 35);
            ManualInjectBtn.TabIndex = 34;
            ManualInjectBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            ManualInjectBtn.Visible = false;
            ManualInjectBtn.OnButtonClick += ManualInjectBtn_OnButtonClick;
            // 
            // NewsTab
            // 
            NewsTab.BackColor = System.Drawing.Color.FromArgb(30, 31, 34);
            NewsTab.Controls.Add(NewsCtrl);
            NewsTab.Controls.Add(NewsArtOne);
            NewsTab.Controls.Add(NewsArtTwo);
            NewsTab.Location = new System.Drawing.Point(4, 24);
            NewsTab.Name = "NewsTab";
            NewsTab.Padding = new System.Windows.Forms.Padding(3);
            NewsTab.Size = new System.Drawing.Size(910, 600);
            NewsTab.TabIndex = 1;
            NewsTab.Text = "News";
            // 
            // NewsCtrl
            // 
            NewsCtrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            NewsCtrl.BackColor = System.Drawing.Color.FromArgb(50, 50, 55);
            NewsCtrl.Location = new System.Drawing.Point(23, 25);
            NewsCtrl.Name = "NewsCtrl";
            NewsCtrl.NewsAuthor = "Loading...";
            NewsCtrl.NewsCategory = "Loading...";
            NewsCtrl.NewsDate = "Loading...";
            NewsCtrl.NewsThumbnail = null;
            NewsCtrl.NewsTitle = "Loading...";
            NewsCtrl.NextDark = Properties.Resources.Right_Red;
            NewsCtrl.NextLight = Properties.Resources.Right_Purple;
            NewsCtrl.PrevDark = Properties.Resources.Left_Red;
            NewsCtrl.PrevLight = Properties.Resources.Left_Purple;
            NewsCtrl.Size = new System.Drawing.Size(865, 550);
            NewsCtrl.TabIndex = 0;
            NewsCtrl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            // 
            // NewsArtOne
            // 
            NewsArtOne.BackColor = System.Drawing.Color.Transparent;
            NewsArtOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            NewsArtOne.Location = new System.Drawing.Point(0, 0);
            NewsArtOne.Name = "NewsArtOne";
            NewsArtOne.Size = new System.Drawing.Size(163, 157);
            NewsArtOne.TabIndex = 1;
            NewsArtOne.TabStop = false;
            // 
            // NewsArtTwo
            // 
            NewsArtTwo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            NewsArtTwo.BackColor = System.Drawing.Color.Transparent;
            NewsArtTwo.BackgroundImage = Properties.Resources.TR0_Red;
            NewsArtTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            NewsArtTwo.Location = new System.Drawing.Point(778, 0);
            NewsArtTwo.Name = "NewsArtTwo";
            NewsArtTwo.Size = new System.Drawing.Size(131, 79);
            NewsArtTwo.TabIndex = 2;
            NewsArtTwo.TabStop = false;
            // 
            // SettingsTab
            // 
            SettingsTab.BackColor = System.Drawing.Color.FromArgb(30, 31, 34);
            SettingsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            SettingsTab.Controls.Add(AutoInstallBx);
            SettingsTab.Controls.Add(SettingsArtTwo);
            SettingsTab.Controls.Add(SettingsArtOne);
            SettingsTab.Controls.Add(HideWhenMinimizedBx);
            SettingsTab.Controls.Add(InstallPathLbl);
            SettingsTab.Controls.Add(LightModeBx);
            SettingsTab.Controls.Add(ManualInjectBx);
            SettingsTab.Controls.Add(InstallPathBx);
            SettingsTab.Controls.Add(OpenFolderBtn);
            SettingsTab.Controls.Add(ExportLogsBtn);
            SettingsTab.Controls.Add(InjectAllInstancesBx);
            SettingsTab.Controls.Add(MinimizeOnStartupBx);
            SettingsTab.Controls.Add(RunOnStartupBx);
            SettingsTab.Controls.Add(PreventInjectionBx);
            SettingsTab.Controls.Add(AutoCheckUpdatesBx);
            SettingsTab.Controls.Add(InjectionTimeoutBx);
            SettingsTab.Controls.Add(InjectionTimeoutLbl);
            SettingsTab.Controls.Add(InstallPathBtn);
            SettingsTab.Location = new System.Drawing.Point(4, 24);
            SettingsTab.Name = "SettingsTab";
            SettingsTab.Size = new System.Drawing.Size(910, 600);
            SettingsTab.TabIndex = 4;
            SettingsTab.Text = "Settings";
            // 
            // AutoInstallBx
            // 
            AutoInstallBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AutoInstallBx.BackColor = System.Drawing.Color.Transparent;
            AutoInstallBx.BoxChecked = false;
            AutoInstallBx.BoxEnabled = true;
            AutoInstallBx.CheckedDark = Properties.Resources.Checkbox_White;
            AutoInstallBx.CheckedLight = Properties.Resources.Checkbox_Black;
            AutoInstallBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            AutoInstallBx.DisplayText = "Automatically install updates";
            AutoInstallBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            AutoInstallBx.IconDark = Properties.Resources.Install_Red;
            AutoInstallBx.IconLight = Properties.Resources.Install_Purple;
            AutoInstallBx.Location = new System.Drawing.Point(35, 80);
            AutoInstallBx.Name = "AutoInstallBx";
            AutoInstallBx.Size = new System.Drawing.Size(365, 35);
            AutoInstallBx.TabIndex = 77;
            AutoInstallBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            AutoInstallBx.UncheckedDark = Properties.Resources.CheckboxEmpy_White;
            AutoInstallBx.UncheckedLight = Properties.Resources.CheckboxEmpy_Black;
            AutoInstallBx.OnCheckChanged += AutoInstallBx_OnCheckChanged;
            // 
            // SettingsArtTwo
            // 
            SettingsArtTwo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            SettingsArtTwo.BackColor = System.Drawing.Color.Transparent;
            SettingsArtTwo.BackgroundImage = Properties.Resources.BR3_Dark;
            SettingsArtTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            SettingsArtTwo.Location = new System.Drawing.Point(812, 466);
            SettingsArtTwo.Name = "SettingsArtTwo";
            SettingsArtTwo.Size = new System.Drawing.Size(98, 134);
            SettingsArtTwo.TabIndex = 76;
            SettingsArtTwo.TabStop = false;
            // 
            // SettingsArtOne
            // 
            SettingsArtOne.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            SettingsArtOne.BackColor = System.Drawing.Color.Transparent;
            SettingsArtOne.BackgroundImage = Properties.Resources.TR3_Dark;
            SettingsArtOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            SettingsArtOne.Location = new System.Drawing.Point(709, 0);
            SettingsArtOne.Name = "SettingsArtOne";
            SettingsArtOne.Size = new System.Drawing.Size(201, 221);
            SettingsArtOne.TabIndex = 75;
            SettingsArtOne.TabStop = false;
            // 
            // HideWhenMinimizedBx
            // 
            HideWhenMinimizedBx.BackColor = System.Drawing.Color.Transparent;
            HideWhenMinimizedBx.BoxChecked = false;
            HideWhenMinimizedBx.BoxEnabled = true;
            HideWhenMinimizedBx.CheckedDark = Properties.Resources.Checkbox_White;
            HideWhenMinimizedBx.CheckedLight = Properties.Resources.Checkbox_Black;
            HideWhenMinimizedBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            HideWhenMinimizedBx.DisplayText = "Hide when minimized";
            HideWhenMinimizedBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            HideWhenMinimizedBx.IconDark = Properties.Resources.Spy_Red;
            HideWhenMinimizedBx.IconLight = Properties.Resources.Spy_Purple;
            HideWhenMinimizedBx.Location = new System.Drawing.Point(35, 260);
            HideWhenMinimizedBx.Name = "HideWhenMinimizedBx";
            HideWhenMinimizedBx.Size = new System.Drawing.Size(365, 35);
            HideWhenMinimizedBx.TabIndex = 74;
            HideWhenMinimizedBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            HideWhenMinimizedBx.UncheckedDark = Properties.Resources.CheckboxEmpy_White;
            HideWhenMinimizedBx.UncheckedLight = Properties.Resources.CheckboxEmpy_Black;
            HideWhenMinimizedBx.OnCheckChanged += HideWhenMinimizedBx_OnCheckChanged;
            // 
            // InstallPathLbl
            // 
            InstallPathLbl.BackColor = System.Drawing.Color.Transparent;
            InstallPathLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InstallPathLbl.DisplayText = "Install path";
            InstallPathLbl.IconDark = Properties.Resources.Folder_Red;
            InstallPathLbl.IconLight = Properties.Resources.Folder_Purple;
            InstallPathLbl.IconSize = CodeRedLauncher.Controls.IconSizes.Medium;
            InstallPathLbl.Location = new System.Drawing.Point(35, 490);
            InstallPathLbl.Name = "InstallPathLbl";
            InstallPathLbl.Size = new System.Drawing.Size(150, 35);
            InstallPathLbl.TabIndex = 72;
            InstallPathLbl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            // 
            // LightModeBx
            // 
            LightModeBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            LightModeBx.BackColor = System.Drawing.Color.Transparent;
            LightModeBx.BoxChecked = false;
            LightModeBx.BoxEnabled = true;
            LightModeBx.CheckedDark = Properties.Resources.Checkbox_White;
            LightModeBx.CheckedLight = Properties.Resources.Checkbox_Black;
            LightModeBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            LightModeBx.DisplayText = "Blind me with the power of the sun";
            LightModeBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            LightModeBx.IconDark = Properties.Resources.Sun_Red;
            LightModeBx.IconLight = Properties.Resources.Sun_Purple;
            LightModeBx.Location = new System.Drawing.Point(35, 395);
            LightModeBx.Name = "LightModeBx";
            LightModeBx.Size = new System.Drawing.Size(365, 35);
            LightModeBx.TabIndex = 70;
            LightModeBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            LightModeBx.UncheckedDark = Properties.Resources.CheckboxEmpy_White;
            LightModeBx.UncheckedLight = Properties.Resources.CheckboxEmpy_Black;
            LightModeBx.OnCheckChanged += LightModeBx_OnCheckChanged;
            // 
            // ManualInjectBx
            // 
            ManualInjectBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ManualInjectBx.BackColor = System.Drawing.Color.Transparent;
            ManualInjectBx.BoxChecked = false;
            ManualInjectBx.BoxEnabled = true;
            ManualInjectBx.CheckedDark = Properties.Resources.Checkbox_White;
            ManualInjectBx.CheckedLight = Properties.Resources.Checkbox_Black;
            ManualInjectBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ManualInjectBx.DisplayText = "Manually inject instead of delay";
            ManualInjectBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            ManualInjectBx.IconDark = Properties.Resources.Mouse_Red;
            ManualInjectBx.IconLight = Properties.Resources.Mouse_Purple;
            ManualInjectBx.Location = new System.Drawing.Point(35, 350);
            ManualInjectBx.Name = "ManualInjectBx";
            ManualInjectBx.Size = new System.Drawing.Size(365, 35);
            ManualInjectBx.TabIndex = 69;
            ManualInjectBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            ManualInjectBx.UncheckedDark = Properties.Resources.CheckboxEmpy_White;
            ManualInjectBx.UncheckedLight = Properties.Resources.CheckboxEmpy_Black;
            ManualInjectBx.OnCheckChanged += ManualInjectBx_OnCheckChanged;
            // 
            // InstallPathBx
            // 
            InstallPathBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InstallPathBx.BackColor = System.Drawing.Color.FromArgb(128, 128, 130);
            InstallPathBx.BoxEnabled = true;
            InstallPathBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            InstallPathBx.DisplayText = "Loading...";
            InstallPathBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InstallPathBx.Location = new System.Drawing.Point(192, 490);
            InstallPathBx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            InstallPathBx.Name = "InstallPathBx";
            InstallPathBx.ReadOnly = true;
            InstallPathBx.Size = new System.Drawing.Size(263, 35);
            InstallPathBx.TabIndex = 67;
            InstallPathBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            // 
            // OpenFolderBtn
            // 
            OpenFolderBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            OpenFolderBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            OpenFolderBtn.ButtonEnabled = true;
            OpenFolderBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            OpenFolderBtn.DisplayText = "Open Install Path";
            OpenFolderBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            OpenFolderBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            OpenFolderBtn.IconDark = Properties.Resources.Open_White;
            OpenFolderBtn.IconLight = Properties.Resources.Open_White;
            OpenFolderBtn.Location = new System.Drawing.Point(135, 540);
            OpenFolderBtn.Name = "OpenFolderBtn";
            OpenFolderBtn.Size = new System.Drawing.Size(320, 35);
            OpenFolderBtn.TabIndex = 63;
            OpenFolderBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            OpenFolderBtn.OnButtonClick += OpenFolderBtn_OnButtonClick;
            // 
            // ExportLogsBtn
            // 
            ExportLogsBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            ExportLogsBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            ExportLogsBtn.ButtonEnabled = true;
            ExportLogsBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ExportLogsBtn.DisplayText = "Export Crash Logs";
            ExportLogsBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ExportLogsBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            ExportLogsBtn.IconDark = Properties.Resources.Zip_White;
            ExportLogsBtn.IconLight = Properties.Resources.Zip_White;
            ExportLogsBtn.Location = new System.Drawing.Point(467, 540);
            ExportLogsBtn.Name = "ExportLogsBtn";
            ExportLogsBtn.Size = new System.Drawing.Size(320, 35);
            ExportLogsBtn.TabIndex = 62;
            ExportLogsBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            ExportLogsBtn.OnButtonClick += ExportLogsBtn_OnButtonClick;
            // 
            // InjectAllInstancesBx
            // 
            InjectAllInstancesBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InjectAllInstancesBx.BackColor = System.Drawing.Color.Transparent;
            InjectAllInstancesBx.BoxChecked = false;
            InjectAllInstancesBx.BoxEnabled = true;
            InjectAllInstancesBx.CheckedDark = Properties.Resources.Checkbox_White;
            InjectAllInstancesBx.CheckedLight = Properties.Resources.Checkbox_Black;
            InjectAllInstancesBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InjectAllInstancesBx.DisplayText = "Inject into all game instances";
            InjectAllInstancesBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            InjectAllInstancesBx.IconDark = Properties.Resources.Stack_Red;
            InjectAllInstancesBx.IconLight = Properties.Resources.Stack_Purple;
            InjectAllInstancesBx.Location = new System.Drawing.Point(35, 305);
            InjectAllInstancesBx.Name = "InjectAllInstancesBx";
            InjectAllInstancesBx.Size = new System.Drawing.Size(365, 35);
            InjectAllInstancesBx.TabIndex = 60;
            InjectAllInstancesBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            InjectAllInstancesBx.UncheckedDark = Properties.Resources.CheckboxEmpy_White;
            InjectAllInstancesBx.UncheckedLight = Properties.Resources.CheckboxEmpy_Black;
            InjectAllInstancesBx.OnCheckChanged += InjectAllInstancesBx_OnCheckChanged;
            // 
            // MinimizeOnStartupBx
            // 
            MinimizeOnStartupBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            MinimizeOnStartupBx.BackColor = System.Drawing.Color.Transparent;
            MinimizeOnStartupBx.BoxChecked = false;
            MinimizeOnStartupBx.BoxEnabled = true;
            MinimizeOnStartupBx.CheckedDark = Properties.Resources.Checkbox_White;
            MinimizeOnStartupBx.CheckedLight = Properties.Resources.Checkbox_Black;
            MinimizeOnStartupBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            MinimizeOnStartupBx.DisplayText = "Minimize on startup";
            MinimizeOnStartupBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            MinimizeOnStartupBx.IconDark = Properties.Resources.Eye_Red;
            MinimizeOnStartupBx.IconLight = Properties.Resources.Eye_Purple;
            MinimizeOnStartupBx.Location = new System.Drawing.Point(35, 215);
            MinimizeOnStartupBx.Name = "MinimizeOnStartupBx";
            MinimizeOnStartupBx.Size = new System.Drawing.Size(365, 35);
            MinimizeOnStartupBx.TabIndex = 58;
            MinimizeOnStartupBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            MinimizeOnStartupBx.UncheckedDark = Properties.Resources.CheckboxEmpy_White;
            MinimizeOnStartupBx.UncheckedLight = Properties.Resources.CheckboxEmpy_Black;
            MinimizeOnStartupBx.OnCheckChanged += MinimizeOnStartupBx_OnCheckChanged;
            // 
            // RunOnStartupBx
            // 
            RunOnStartupBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            RunOnStartupBx.BackColor = System.Drawing.Color.Transparent;
            RunOnStartupBx.BoxChecked = false;
            RunOnStartupBx.BoxEnabled = true;
            RunOnStartupBx.CheckedDark = Properties.Resources.Checkbox_White;
            RunOnStartupBx.CheckedLight = Properties.Resources.Checkbox_Black;
            RunOnStartupBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            RunOnStartupBx.DisplayText = "Run on windows startup";
            RunOnStartupBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            RunOnStartupBx.IconDark = Properties.Resources.Windows_Red;
            RunOnStartupBx.IconLight = Properties.Resources.Windows_Purple;
            RunOnStartupBx.Location = new System.Drawing.Point(35, 170);
            RunOnStartupBx.Name = "RunOnStartupBx";
            RunOnStartupBx.Size = new System.Drawing.Size(365, 35);
            RunOnStartupBx.TabIndex = 57;
            RunOnStartupBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            RunOnStartupBx.UncheckedDark = Properties.Resources.CheckboxEmpy_White;
            RunOnStartupBx.UncheckedLight = Properties.Resources.CheckboxEmpy_Black;
            RunOnStartupBx.OnCheckChanged += RunOnStartupBx_OnCheckChanged;
            // 
            // PreventInjectionBx
            // 
            PreventInjectionBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PreventInjectionBx.BackColor = System.Drawing.Color.Transparent;
            PreventInjectionBx.BoxChecked = false;
            PreventInjectionBx.BoxEnabled = true;
            PreventInjectionBx.CheckedDark = Properties.Resources.Checkbox_White;
            PreventInjectionBx.CheckedLight = Properties.Resources.Checkbox_Black;
            PreventInjectionBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            PreventInjectionBx.DisplayText = "Prevent injection if easy anti-cheat is detected";
            PreventInjectionBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            PreventInjectionBx.IconDark = Properties.Resources.Lock_Red;
            PreventInjectionBx.IconLight = Properties.Resources.Lock_Purple;
            PreventInjectionBx.Location = new System.Drawing.Point(35, 125);
            PreventInjectionBx.Name = "PreventInjectionBx";
            PreventInjectionBx.Size = new System.Drawing.Size(365, 35);
            PreventInjectionBx.TabIndex = 56;
            PreventInjectionBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            PreventInjectionBx.UncheckedDark = Properties.Resources.CheckboxEmpy_White;
            PreventInjectionBx.UncheckedLight = Properties.Resources.CheckboxEmpy_Black;
            PreventInjectionBx.OnCheckChanged += PreventInjectionBx_OnCheckChanged;
            // 
            // AutoCheckUpdatesBx
            // 
            AutoCheckUpdatesBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AutoCheckUpdatesBx.BackColor = System.Drawing.Color.Transparent;
            AutoCheckUpdatesBx.BoxChecked = false;
            AutoCheckUpdatesBx.BoxEnabled = true;
            AutoCheckUpdatesBx.CheckedDark = Properties.Resources.Checkbox_White;
            AutoCheckUpdatesBx.CheckedLight = Properties.Resources.Checkbox_Black;
            AutoCheckUpdatesBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            AutoCheckUpdatesBx.DisplayText = "Automatically check for updates";
            AutoCheckUpdatesBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            AutoCheckUpdatesBx.IconDark = Properties.Resources.Download_Red;
            AutoCheckUpdatesBx.IconLight = Properties.Resources.Download_Purple;
            AutoCheckUpdatesBx.Location = new System.Drawing.Point(35, 35);
            AutoCheckUpdatesBx.Name = "AutoCheckUpdatesBx";
            AutoCheckUpdatesBx.Size = new System.Drawing.Size(365, 35);
            AutoCheckUpdatesBx.TabIndex = 55;
            AutoCheckUpdatesBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            AutoCheckUpdatesBx.UncheckedDark = Properties.Resources.CheckboxEmpy_White;
            AutoCheckUpdatesBx.UncheckedLight = Properties.Resources.CheckboxEmpy_Black;
            AutoCheckUpdatesBx.OnCheckChanged += AutoCheckUpdatesBx_OnCheckChanged;
            // 
            // InjectionTimeoutBx
            // 
            InjectionTimeoutBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InjectionTimeoutBx.BackColor = System.Drawing.Color.FromArgb(128, 128, 130);
            InjectionTimeoutBx.BoxEnabled = true;
            InjectionTimeoutBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InjectionTimeoutBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            InjectionTimeoutBx.Hexadecimal = false;
            InjectionTimeoutBx.Increment = 1;
            InjectionTimeoutBx.Location = new System.Drawing.Point(192, 440);
            InjectionTimeoutBx.MaximumValue = 300000;
            InjectionTimeoutBx.MinimumValue = 5000;
            InjectionTimeoutBx.Name = "InjectionTimeoutBx";
            InjectionTimeoutBx.ReadOnly = false;
            InjectionTimeoutBx.Size = new System.Drawing.Size(263, 35);
            InjectionTimeoutBx.TabIndex = 64;
            InjectionTimeoutBx.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            InjectionTimeoutBx.Value = 20000;
            InjectionTimeoutBx.OnValueChanged += InjectionTimeoutBx_OnValueChanged;
            // 
            // InjectionTimeoutLbl
            // 
            InjectionTimeoutLbl.BackColor = System.Drawing.Color.Transparent;
            InjectionTimeoutLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InjectionTimeoutLbl.DisplayText = "Injection delay";
            InjectionTimeoutLbl.IconDark = Properties.Resources.Hourglass_Red;
            InjectionTimeoutLbl.IconLight = Properties.Resources.Hourglass_Purple;
            InjectionTimeoutLbl.IconSize = CodeRedLauncher.Controls.IconSizes.Medium;
            InjectionTimeoutLbl.Location = new System.Drawing.Point(35, 440);
            InjectionTimeoutLbl.Name = "InjectionTimeoutLbl";
            InjectionTimeoutLbl.Size = new System.Drawing.Size(150, 35);
            InjectionTimeoutLbl.TabIndex = 71;
            InjectionTimeoutLbl.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            // 
            // InstallPathBtn
            // 
            InstallPathBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InstallPathBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            InstallPathBtn.ButtonEnabled = true;
            InstallPathBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InstallPathBtn.DisplayText = "Change";
            InstallPathBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InstallPathBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            InstallPathBtn.IconDark = Properties.Resources.Folders_White;
            InstallPathBtn.IconLight = Properties.Resources.Folders_White;
            InstallPathBtn.Location = new System.Drawing.Point(467, 490);
            InstallPathBtn.Name = "InstallPathBtn";
            InstallPathBtn.Size = new System.Drawing.Size(165, 35);
            InstallPathBtn.TabIndex = 68;
            InstallPathBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            InstallPathBtn.OnButtonClick += InstallPathBtn_OnButtonClick;
            // 
            // BackgroundPnl
            // 
            BackgroundPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            BackgroundPnl.Controls.Add(TabPnl);
            BackgroundPnl.Controls.Add(TabCtrl);
            BackgroundPnl.Controls.Add(OfflinePopup);
            BackgroundPnl.Controls.Add(DuplicatePopup);
            BackgroundPnl.Controls.Add(PathPopup);
            BackgroundPnl.Controls.Add(InstallPopup);
            BackgroundPnl.Controls.Add(UpdatePopup);
            BackgroundPnl.Controls.Add(TitleBar);
            BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            BackgroundPnl.Name = "BackgroundPnl";
            BackgroundPnl.Size = new System.Drawing.Size(970, 630);
            BackgroundPnl.TabIndex = 4;
            // 
            // TabPnl
            // 
            TabPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            TabPnl.BackColor = System.Drawing.Color.FromArgb(42, 45, 49);
            TabPnl.Controls.Add(AboutTabBtn);
            TabPnl.Controls.Add(SettingsTabBtn);
            TabPnl.Controls.Add(ExitTabBtn);
            TabPnl.Controls.Add(NewsTabBtn);
            TabPnl.Controls.Add(DashboardTabBtn);
            TabPnl.Location = new System.Drawing.Point(0, 30);
            TabPnl.Name = "TabPnl";
            TabPnl.Size = new System.Drawing.Size(60, 600);
            TabPnl.TabIndex = 2;
            // 
            // AboutTabBtn
            // 
            AboutTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AboutTabBtn.BackColor = System.Drawing.Color.Transparent;
            AboutTabBtn.IconDark = Properties.Resources.About_White;
            AboutTabBtn.IconDarkSelected = Properties.Resources.About_Red;
            AboutTabBtn.IconLight = Properties.Resources.About_Black;
            AboutTabBtn.IconLightSelected = Properties.Resources.About_Purple;
            AboutTabBtn.Location = new System.Drawing.Point(0, 500);
            AboutTabBtn.Name = "AboutTabBtn";
            AboutTabBtn.Size = new System.Drawing.Size(60, 50);
            AboutTabBtn.TabActive = false;
            AboutTabBtn.TabEnabled = true;
            AboutTabBtn.TabIndex = 7;
            AboutTabBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            AboutTabBtn.OnTabClick += AboutTabBtn_OnTabClick;
            // 
            // SettingsTabBtn
            // 
            SettingsTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SettingsTabBtn.BackColor = System.Drawing.Color.Transparent;
            SettingsTabBtn.IconDark = Properties.Resources.Settings_White;
            SettingsTabBtn.IconDarkSelected = Properties.Resources.Settings_Red;
            SettingsTabBtn.IconLight = Properties.Resources.Settings_Black;
            SettingsTabBtn.IconLightSelected = Properties.Resources.Settings_Purple;
            SettingsTabBtn.Location = new System.Drawing.Point(0, 450);
            SettingsTabBtn.Name = "SettingsTabBtn";
            SettingsTabBtn.Size = new System.Drawing.Size(60, 50);
            SettingsTabBtn.TabActive = false;
            SettingsTabBtn.TabEnabled = true;
            SettingsTabBtn.TabIndex = 6;
            SettingsTabBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            SettingsTabBtn.OnTabClick += SettingsTabBtn_OnTabClick;
            // 
            // ExitTabBtn
            // 
            ExitTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ExitTabBtn.BackColor = System.Drawing.Color.Transparent;
            ExitTabBtn.IconDark = Properties.Resources.Exit_White;
            ExitTabBtn.IconDarkSelected = Properties.Resources.Exit_Red;
            ExitTabBtn.IconLight = Properties.Resources.Exit_Black;
            ExitTabBtn.IconLightSelected = Properties.Resources.Exit_Purple;
            ExitTabBtn.Location = new System.Drawing.Point(0, 550);
            ExitTabBtn.Name = "ExitTabBtn";
            ExitTabBtn.Size = new System.Drawing.Size(60, 50);
            ExitTabBtn.TabActive = false;
            ExitTabBtn.TabEnabled = true;
            ExitTabBtn.TabIndex = 5;
            ExitTabBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            ExitTabBtn.OnTabClick += ExitTabBtn_OnTabClick;
            // 
            // NewsTabBtn
            // 
            NewsTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            NewsTabBtn.BackColor = System.Drawing.Color.Transparent;
            NewsTabBtn.IconDark = Properties.Resources.News_White;
            NewsTabBtn.IconDarkSelected = Properties.Resources.News_Red;
            NewsTabBtn.IconLight = Properties.Resources.News_Black;
            NewsTabBtn.IconLightSelected = Properties.Resources.News_Purple;
            NewsTabBtn.Location = new System.Drawing.Point(0, 50);
            NewsTabBtn.Name = "NewsTabBtn";
            NewsTabBtn.Size = new System.Drawing.Size(60, 50);
            NewsTabBtn.TabActive = false;
            NewsTabBtn.TabEnabled = true;
            NewsTabBtn.TabIndex = 1;
            NewsTabBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            NewsTabBtn.OnTabClick += NewsTabBtn_OnTabClick;
            // 
            // DashboardTabBtn
            // 
            DashboardTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DashboardTabBtn.BackColor = System.Drawing.Color.FromArgb(10, 255, 50, 37);
            DashboardTabBtn.IconDark = Properties.Resources.Dashboard_White;
            DashboardTabBtn.IconDarkSelected = Properties.Resources.Dashboard_Red;
            DashboardTabBtn.IconLight = Properties.Resources.Dashboard_Black;
            DashboardTabBtn.IconLightSelected = Properties.Resources.Dashboard_Purple;
            DashboardTabBtn.Location = new System.Drawing.Point(0, 0);
            DashboardTabBtn.Name = "DashboardTabBtn";
            DashboardTabBtn.Size = new System.Drawing.Size(60, 50);
            DashboardTabBtn.TabActive = true;
            DashboardTabBtn.TabEnabled = true;
            DashboardTabBtn.TabIndex = 0;
            DashboardTabBtn.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            DashboardTabBtn.OnTabClick += DashboardTabBtn_OnTabClick;
            // 
            // OfflinePopup
            // 
            OfflinePopup.AcceptDark = Properties.Resources.Offline_White;
            OfflinePopup.AcceptLight = Properties.Resources.Offline_White;
            OfflinePopup.AltDark = Properties.Resources.Yes_White;
            OfflinePopup.AltLight = Properties.Resources.Yes_White;
            OfflinePopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            OfflinePopup.BoundForm = null;
            OfflinePopup.BoundTitle = null;
            OfflinePopup.DenyDark = Properties.Resources.No_White;
            OfflinePopup.DenyLight = Properties.Resources.No_White;
            OfflinePopup.Location = new System.Drawing.Point(0, 0);
            OfflinePopup.Name = "OfflinePopup";
            OfflinePopup.Size = new System.Drawing.Size(970, 630);
            OfflinePopup.TabIndex = 8;
            OfflinePopup.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            OfflinePopup.View = CodeRedLauncher.Controls.OfflineViews.Default;
            OfflinePopup.Visible = false;
            OfflinePopup.ButtonClickAccept += OfflinePopup_ButtonClickAccept;
            OfflinePopup.ButtonClickDeny += OfflinePopup_ButtonClickDeny;
            OfflinePopup.ButtonClickAlt += OfflinePopup_ButtonClickAlt;
            // 
            // DuplicatePopup
            // 
            DuplicatePopup.AcceptDark = Properties.Resources.Yes_White;
            DuplicatePopup.AcceptLight = Properties.Resources.Yes_White;
            DuplicatePopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            DuplicatePopup.BoundForm = null;
            DuplicatePopup.BoundTitle = null;
            DuplicatePopup.DenyDark = Properties.Resources.No_White;
            DuplicatePopup.DenyLight = Properties.Resources.No_White;
            DuplicatePopup.Location = new System.Drawing.Point(0, 0);
            DuplicatePopup.Name = "DuplicatePopup";
            DuplicatePopup.Size = new System.Drawing.Size(970, 630);
            DuplicatePopup.TabIndex = 8;
            DuplicatePopup.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            DuplicatePopup.Visible = false;
            DuplicatePopup.ButtonClickAccept += DuplicatePopup_ButtonClickAccept;
            DuplicatePopup.ButtonClickDeny += DuplicatePopup_ButtonClickDeny;
            // 
            // PathPopup
            // 
            PathPopup.AltDark = Properties.Resources.Yes_White;
            PathPopup.AltLight = Properties.Resources.Yes_White;
            PathPopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            PathPopup.BoundForm = null;
            PathPopup.BoundTitle = null;
            PathPopup.Location = new System.Drawing.Point(0, 0);
            PathPopup.Name = "PathPopup";
            PathPopup.Size = new System.Drawing.Size(970, 630);
            PathPopup.TabIndex = 8;
            PathPopup.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            PathPopup.Visible = false;
            // 
            // InstallPopup
            // 
            InstallPopup.AcceptDark = Properties.Resources.Install_White;
            InstallPopup.AcceptLight = Properties.Resources.Install_White;
            InstallPopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            InstallPopup.BoundForm = null;
            InstallPopup.BoundTitle = null;
            InstallPopup.ButtonsEnabled = true;
            InstallPopup.DenyDark = Properties.Resources.Folder_White;
            InstallPopup.DenyLight = Properties.Resources.Folder_White;
            InstallPopup.Location = new System.Drawing.Point(0, 0);
            InstallPopup.Name = "InstallPopup";
            InstallPopup.Size = new System.Drawing.Size(970, 630);
            InstallPopup.TabIndex = 8;
            InstallPopup.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            InstallPopup.View = CodeRedLauncher.Controls.InstallViews.None;
            InstallPopup.Visible = false;
            InstallPopup.ButtonClickAccept += InstallPopup_ButtonClickAccept;
            InstallPopup.ButtonClickDeny += InstallPopup_ButtonClickDeny;
            // 
            // UpdatePopup
            // 
            UpdatePopup.AcceptDark = Properties.Resources.Yes_White;
            UpdatePopup.AcceptLight = Properties.Resources.Yes_White;
            UpdatePopup.AltDark = Properties.Resources.Yes_White;
            UpdatePopup.AltLight = Properties.Resources.Yes_White;
            UpdatePopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            UpdatePopup.BoundForm = null;
            UpdatePopup.BoundTitle = null;
            UpdatePopup.ButtonsEnabled = true;
            UpdatePopup.DenyDark = Properties.Resources.No_White;
            UpdatePopup.DenyLight = Properties.Resources.No_White;
            UpdatePopup.Location = new System.Drawing.Point(0, 0);
            UpdatePopup.Name = "UpdatePopup";
            UpdatePopup.Size = new System.Drawing.Size(970, 630);
            UpdatePopup.TabIndex = 8;
            UpdatePopup.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            UpdatePopup.View = CodeRedLauncher.Controls.UpdateViews.Module;
            UpdatePopup.Visible = false;
            UpdatePopup.ButtonClickAccept += UpdatePopup_ButtonClickAccept;
            UpdatePopup.ButtonClickDeny += UpdatePopup_ButtonClickDeny;
            // 
            // TitleBar
            // 
            TitleBar.BackColor = System.Drawing.Color.FromArgb(50, 50, 55);
            TitleBar.BoundForm = null;
            TitleBar.DisplayText = "CODERED LAUNCHER";
            TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            TitleBar.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            TitleBar.Location = new System.Drawing.Point(0, 0);
            TitleBar.MinimizeButton = true;
            TitleBar.Name = "TitleBar";
            TitleBar.Size = new System.Drawing.Size(970, 30);
            TitleBar.TabIndex = 2;
            TitleBar.Theme = CodeRedLauncher.Controls.ControlTheme.Dark;
            TitleBar.OnMinimized += TitleBar_OnMinimized;
            TitleBar.OnExit += TitleBar_OnExit;
            // 
            // ProcessTmr
            // 
            ProcessTmr.Interval = 250;
            ProcessTmr.Tick += ProcessTmr_Tick;
            // 
            // InjectTmr
            // 
            InjectTmr.Interval = 5000;
            InjectTmr.Tick += InjectTmr_Tick;
            // 
            // TrayIcon
            // 
            TrayIcon.Icon = (System.Drawing.Icon)resources.GetObject("TrayIcon.Icon");
            TrayIcon.Text = "CodeRed Launcher";
            TrayIcon.Visible = true;
            TrayIcon.Click += TrayIcon_Click;
            // 
            // UpdateTmr
            // 
            UpdateTmr.Interval = 150000;
            UpdateTmr.Tick += UpdateTmr_Tick;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(50, 51, 56);
            ClientSize = new System.Drawing.Size(972, 632);
            Controls.Add(BackgroundPnl);
            DoubleBuffered = true;
            ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainFrm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += MainFrm_Load;
            Resize += MainFrm_Resize;
            TabCtrl.ResumeLayout(false);
            AboutTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AboutArtOne).EndInit();
            ((System.ComponentModel.ISupportInitialize)EasterEggImg).EndInit();
            DashboardTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DashboardArtTwo).EndInit();
            ((System.ComponentModel.ISupportInitialize)DashboardArtOne).EndInit();
            NewsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NewsArtOne).EndInit();
            ((System.ComponentModel.ISupportInitialize)NewsArtTwo).EndInit();
            SettingsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SettingsArtTwo).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsArtOne).EndInit();
            BackgroundPnl.ResumeLayout(false);
            TabPnl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl TabCtrl;
        private System.Windows.Forms.TabPage NewsTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.TabPage AboutTab;
        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.Label CreditsLbl;
        private System.Windows.Forms.TabPage DashboardTab;
        private System.Windows.Forms.Timer ProcessTmr;
        private System.Windows.Forms.Timer InjectTmr;
        private Controls.CRTitleBar TitleBar;
        private System.Windows.Forms.Panel TabPnl;
        private Controls.CRButton CheckUpdatesBtn;
        private Controls.CRCheckbox AutoCheckUpdatesBx;
        private Controls.CRCheckbox PreventInjectionBx;
        private Controls.CRCheckbox RunOnStartupBx;
        private Controls.CRCheckbox MinimizeOnStartupBx;
        private Controls.CRCheckbox InjectAllInstancesBx;
        private Controls.CRTab DashboardTabBtn;
        private Controls.CRTab NewsTabBtn;
        private Controls.CRTab ExitTabBtn;
        private Controls.CRTab AboutTabBtn;
        private Controls.CRTab SettingsTabBtn;
        private Controls.CRChangelog ChangelogCtrl;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private Controls.CRButton ManualInjectBtn;
        private Controls.CRNews NewsCtrl;
        private Controls.CRButton OpenFolderBtn;
        private Controls.CRButton ExportLogsBtn;
        private Controls.CRNumberbox InjectionTimeoutBx;
        private System.Windows.Forms.Timer UpdateTmr;
        private Controls.CRTextbox InstallPathBx;
        private Controls.CRButton InstallPathBtn;
        private Controls.CRAboutInfo RemixInfoCtrl;
        private Controls.CRAboutInfo DonateInfoCtrl;
        private Controls.CRAboutInfo LauncherInfoCtrl;
        private Controls.CRAboutInfo WebsiteInfoCtrl;
        private Controls.CRAboutInfo DiscordInfoCtrl;
        private Controls.CRAboutInfo PlatformInfoCtrl;
        private Controls.CRAboutInfo BuildInfoCtrl;
        private Controls.CRAboutInfo PsyonixInfoCtrl;
        private Controls.CRAboutInfo ModuleInfoCtrl;
        private Controls.CRCheckbox ManualInjectBx;
        private Controls.CRIconLabel InjectionTimeoutLbl;
        private Controls.CRIconLabel InstallPathLbl;
        private Controls.CRCheckbox LightModeBx;
        private Controls.CRProcessStatus ProcessCtrl;
        private System.Windows.Forms.PictureBox EasterEggImg;
        private Controls.CROfflinePopup OfflinePopup;
        private Controls.CRUpdatePopup UpdatePopup;
        private Controls.CRInstallPopup InstallPopup;
        private Controls.CRCheckbox HideWhenMinimizedBx;
        private System.Windows.Forms.PictureBox DashboardArtTwo;
        private System.Windows.Forms.PictureBox DashboardArtOne;
        private System.Windows.Forms.PictureBox NewsArtOne;
        private System.Windows.Forms.PictureBox NewsArtTwo;
        private System.Windows.Forms.PictureBox SettingsArtOne;
        private System.Windows.Forms.PictureBox AboutArtOne;
        private System.Windows.Forms.PictureBox SettingsArtTwo;
        private Controls.CRDupePopup DuplicatePopup;
        private Controls.CRCheckbox AutoInstallBx;
        private Controls.CRPathPopup PathPopup;
        private Controls.CRVersionStatus VersionCtrl;
    }
}