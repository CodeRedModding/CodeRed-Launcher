
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
            TermsBtn = new Controls.CRButton();
            PolicyBtn = new Controls.CRButton();
            EasterEggImg = new System.Windows.Forms.PictureBox();
            PlatformInfoCtrl = new Controls.CRInfo();
            BuildInfoCtrl = new Controls.CRInfo();
            PsyonixInfoCtrl = new Controls.CRInfo();
            ModuleInfoCtrl = new Controls.CRInfo();
            LauncherInfoCtrl = new Controls.CRInfo();
            WebsiteInfoCtrl = new Controls.CRInfo();
            DiscordInfoCtrl = new Controls.CRInfo();
            DonateInfoCtrl = new Controls.CRInfo();
            RemixInfoCtrl = new Controls.CRInfo();
            CheckUpdatesBtn = new Controls.CRButton();
            CreditsLbl = new System.Windows.Forms.Label();
            DashboardTab = new System.Windows.Forms.TabPage();
            UpdateStatusCtrl = new Controls.CRStatus();
            ProcessStatusCtrl = new Controls.CRStatus();
            ChangelogCtrl = new Controls.CRChangelog();
            DashboardArtTwo = new System.Windows.Forms.PictureBox();
            DashboardArtOne = new System.Windows.Forms.PictureBox();
            ManualInjectBtn = new Controls.CRButton();
            LaunchBtn = new Controls.CRButton();
            NewsTab = new System.Windows.Forms.TabPage();
            NewsCtrl = new Controls.CRNews();
            NewsArtOne = new System.Windows.Forms.PictureBox();
            NewsArtTwo = new System.Windows.Forms.PictureBox();
            SettingsTab = new System.Windows.Forms.TabPage();
            AutoInstallBx = new Controls.CRCheckbox();
            SettingsArtTwo = new System.Windows.Forms.PictureBox();
            SettingsArtOne = new System.Windows.Forms.PictureBox();
            HideWhenMinimizedBx = new Controls.CRCheckbox();
            InstallPathLbl = new Controls.CRLabel();
            InjectionTimeoutLbl = new Controls.CRLabel();
            LightModeBx = new Controls.CRCheckbox();
            ManualInjectBx = new Controls.CRCheckbox();
            InstallPathBtn = new Controls.CRButton();
            InstallPathBx = new Controls.CRTextbox();
            OpenFolderBtn = new Controls.CRButton();
            ExportLogsBtn = new Controls.CRButton();
            InjectAllInstancesBx = new Controls.CRCheckbox();
            MinimizeOnStartupBx = new Controls.CRCheckbox();
            RunOnStartupBx = new Controls.CRCheckbox();
            PreventInjectionBx = new Controls.CRCheckbox();
            AutoCheckUpdatesBx = new Controls.CRCheckbox();
            InjectionTimeoutBx = new Controls.CRNumberbox();
            BackgroundPnl = new System.Windows.Forms.Panel();
            TabPnl = new System.Windows.Forms.Panel();
            AboutTabBtn = new Controls.CRTab();
            SettingsTabBtn = new Controls.CRTab();
            ExitTabBtn = new Controls.CRTab();
            NewsTabBtn = new Controls.CRTab();
            DashboardTabBtn = new Controls.CRTab();
            TermsPopup = new Controls.CRPolicy();
            PolicyPopup = new Controls.CRPolicy();
            OfflinePopup = new Controls.CROffline();
            DuplicatePopup = new Controls.CRDuplicate();
            PathPopup = new Controls.CRPathing();
            TitleBar = new Controls.CRTitle();
            InstallPopup = new Controls.CRInstall();
            UpdatePopup = new Controls.CRUpdate();
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
            AboutTab.Controls.Add(TermsBtn);
            AboutTab.Controls.Add(PolicyBtn);
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
            // TermsBtn
            // 
            TermsBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            TermsBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            TermsBtn.ButtonEnabled = true;
            TermsBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            TermsBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            TermsBtn.DisplayText = "Terms of Use";
            TermsBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            TermsBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            TermsBtn.IconBlack = Properties.Resources.List_Black;
            TermsBtn.IconBlue = Properties.Resources.List_Blue;
            TermsBtn.IconPurple = Properties.Resources.List_Purple;
            TermsBtn.IconRed = Properties.Resources.List_Red;
            TermsBtn.IconSync = false;
            TermsBtn.IconType = CodeRedLauncher.Controls.IconTheme.White;
            TermsBtn.IconWhite = Properties.Resources.List_White;
            TermsBtn.Location = new System.Drawing.Point(243, 491);
            TermsBtn.Name = "TermsBtn";
            TermsBtn.Size = new System.Drawing.Size(210, 35);
            TermsBtn.TabIndex = 77;
            TermsBtn.OnButtonClick += TermsBtn_OnButtonClick;
            // 
            // PolicyBtn
            // 
            PolicyBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            PolicyBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            PolicyBtn.ButtonEnabled = true;
            PolicyBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            PolicyBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            PolicyBtn.DisplayText = "Privacy Policy";
            PolicyBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            PolicyBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            PolicyBtn.IconBlack = Properties.Resources.List_Black;
            PolicyBtn.IconBlue = Properties.Resources.List_Blue;
            PolicyBtn.IconPurple = Properties.Resources.List_Purple;
            PolicyBtn.IconRed = Properties.Resources.List_Red;
            PolicyBtn.IconSync = false;
            PolicyBtn.IconType = CodeRedLauncher.Controls.IconTheme.White;
            PolicyBtn.IconWhite = Properties.Resources.List_White;
            PolicyBtn.Location = new System.Drawing.Point(459, 491);
            PolicyBtn.Name = "PolicyBtn";
            PolicyBtn.Size = new System.Drawing.Size(210, 35);
            PolicyBtn.TabIndex = 76;
            PolicyBtn.OnButtonClick += PolicyBtn_OnButtonClick;
            // 
            // EasterEggImg
            // 
            EasterEggImg.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            EasterEggImg.BackColor = System.Drawing.Color.Transparent;
            EasterEggImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            EasterEggImg.Cursor = System.Windows.Forms.Cursors.Hand;
            EasterEggImg.Location = new System.Drawing.Point(675, 450);
            EasterEggImg.Name = "EasterEggImg";
            EasterEggImg.Size = new System.Drawing.Size(75, 75);
            EasterEggImg.TabIndex = 75;
            EasterEggImg.TabStop = false;
            EasterEggImg.Click += EasterEggImg_Click;
            // 
            // PlatformInfoCtrl
            // 
            PlatformInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            PlatformInfoCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            PlatformInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            PlatformInfoCtrl.DisplayDescription = "Loading...";
            PlatformInfoCtrl.DisplayTitle = "Platform";
            PlatformInfoCtrl.Hyperlink = false;
            PlatformInfoCtrl.IconBlack = Properties.Resources.Rocket_Black;
            PlatformInfoCtrl.IconBlue = Properties.Resources.Rocket_Blue;
            PlatformInfoCtrl.IconPurple = Properties.Resources.Rocket_Purple;
            PlatformInfoCtrl.IconRed = Properties.Resources.Rocket_Red;
            PlatformInfoCtrl.IconSync = true;
            PlatformInfoCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            PlatformInfoCtrl.IconWhite = Properties.Resources.Rocket_White;
            PlatformInfoCtrl.Location = new System.Drawing.Point(35, 215);
            PlatformInfoCtrl.Name = "PlatformInfoCtrl";
            PlatformInfoCtrl.Size = new System.Drawing.Size(435, 35);
            PlatformInfoCtrl.TabIndex = 41;
            PlatformInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // BuildInfoCtrl
            // 
            BuildInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            BuildInfoCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            BuildInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            BuildInfoCtrl.DisplayDescription = "Loading...";
            BuildInfoCtrl.DisplayTitle = "Build Version";
            BuildInfoCtrl.Hyperlink = false;
            BuildInfoCtrl.IconBlack = Properties.Resources.Drive_Black;
            BuildInfoCtrl.IconBlue = Properties.Resources.Drive_Blue;
            BuildInfoCtrl.IconPurple = Properties.Resources.Drive_Purple;
            BuildInfoCtrl.IconRed = Properties.Resources.Drive_Red;
            BuildInfoCtrl.IconSync = true;
            BuildInfoCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            BuildInfoCtrl.IconWhite = Properties.Resources.Drive_White;
            BuildInfoCtrl.Location = new System.Drawing.Point(35, 170);
            BuildInfoCtrl.Name = "BuildInfoCtrl";
            BuildInfoCtrl.Size = new System.Drawing.Size(435, 35);
            BuildInfoCtrl.TabIndex = 40;
            BuildInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // PsyonixInfoCtrl
            // 
            PsyonixInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            PsyonixInfoCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            PsyonixInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            PsyonixInfoCtrl.DisplayDescription = "Loading...";
            PsyonixInfoCtrl.DisplayTitle = "Psyonix Version";
            PsyonixInfoCtrl.Hyperlink = false;
            PsyonixInfoCtrl.IconBlack = Properties.Resources.Server_Black;
            PsyonixInfoCtrl.IconBlue = Properties.Resources.Server_Blue;
            PsyonixInfoCtrl.IconPurple = Properties.Resources.Server_Purple;
            PsyonixInfoCtrl.IconRed = Properties.Resources.Server_Red;
            PsyonixInfoCtrl.IconSync = true;
            PsyonixInfoCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            PsyonixInfoCtrl.IconWhite = Properties.Resources.Server_White;
            PsyonixInfoCtrl.Location = new System.Drawing.Point(35, 125);
            PsyonixInfoCtrl.Name = "PsyonixInfoCtrl";
            PsyonixInfoCtrl.Size = new System.Drawing.Size(435, 35);
            PsyonixInfoCtrl.TabIndex = 39;
            PsyonixInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // ModuleInfoCtrl
            // 
            ModuleInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            ModuleInfoCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            ModuleInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            ModuleInfoCtrl.DisplayDescription = "Loading...";
            ModuleInfoCtrl.DisplayTitle = "Module Version";
            ModuleInfoCtrl.Hyperlink = false;
            ModuleInfoCtrl.IconBlack = null;
            ModuleInfoCtrl.IconBlue = Properties.Resources.Database_Blue;
            ModuleInfoCtrl.IconPurple = Properties.Resources.Database_Purple;
            ModuleInfoCtrl.IconRed = Properties.Resources.Database_Red;
            ModuleInfoCtrl.IconSync = true;
            ModuleInfoCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            ModuleInfoCtrl.IconWhite = Properties.Resources.Database_White;
            ModuleInfoCtrl.Location = new System.Drawing.Point(35, 80);
            ModuleInfoCtrl.Name = "ModuleInfoCtrl";
            ModuleInfoCtrl.Size = new System.Drawing.Size(435, 35);
            ModuleInfoCtrl.TabIndex = 38;
            ModuleInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // LauncherInfoCtrl
            // 
            LauncherInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            LauncherInfoCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            LauncherInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            LauncherInfoCtrl.DisplayDescription = "Loading...";
            LauncherInfoCtrl.DisplayTitle = "Launcher Version";
            LauncherInfoCtrl.Hyperlink = false;
            LauncherInfoCtrl.IconBlack = Properties.Resources.Box_Black;
            LauncherInfoCtrl.IconBlue = Properties.Resources.Box_Blue;
            LauncherInfoCtrl.IconPurple = Properties.Resources.Box_Purple;
            LauncherInfoCtrl.IconRed = Properties.Resources.Box_Red;
            LauncherInfoCtrl.IconSync = true;
            LauncherInfoCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            LauncherInfoCtrl.IconWhite = Properties.Resources.Box_White;
            LauncherInfoCtrl.Location = new System.Drawing.Point(35, 35);
            LauncherInfoCtrl.Name = "LauncherInfoCtrl";
            LauncherInfoCtrl.Size = new System.Drawing.Size(435, 35);
            LauncherInfoCtrl.TabIndex = 37;
            LauncherInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // WebsiteInfoCtrl
            // 
            WebsiteInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            WebsiteInfoCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            WebsiteInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            WebsiteInfoCtrl.DisplayDescription = "https://coderedmodding.github.io/";
            WebsiteInfoCtrl.DisplayTitle = "Website";
            WebsiteInfoCtrl.Hyperlink = true;
            WebsiteInfoCtrl.IconBlack = Properties.Resources.Website_Black;
            WebsiteInfoCtrl.IconBlue = Properties.Resources.Website_Blue;
            WebsiteInfoCtrl.IconPurple = Properties.Resources.Website_Purple;
            WebsiteInfoCtrl.IconRed = Properties.Resources.Website_Red;
            WebsiteInfoCtrl.IconSync = true;
            WebsiteInfoCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            WebsiteInfoCtrl.IconWhite = Properties.Resources.Website_White;
            WebsiteInfoCtrl.Location = new System.Drawing.Point(35, 260);
            WebsiteInfoCtrl.Name = "WebsiteInfoCtrl";
            WebsiteInfoCtrl.Size = new System.Drawing.Size(435, 35);
            WebsiteInfoCtrl.TabIndex = 36;
            WebsiteInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // DiscordInfoCtrl
            // 
            DiscordInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            DiscordInfoCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            DiscordInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            DiscordInfoCtrl.DisplayDescription = "https://discord.gg/";
            DiscordInfoCtrl.DisplayTitle = "Discord";
            DiscordInfoCtrl.Hyperlink = true;
            DiscordInfoCtrl.IconBlack = Properties.Resources.Discord_Black;
            DiscordInfoCtrl.IconBlue = Properties.Resources.Discord_Blue;
            DiscordInfoCtrl.IconPurple = Properties.Resources.Discord_Purple;
            DiscordInfoCtrl.IconRed = Properties.Resources.Discord_Red;
            DiscordInfoCtrl.IconSync = true;
            DiscordInfoCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            DiscordInfoCtrl.IconWhite = Properties.Resources.Discord_White;
            DiscordInfoCtrl.Location = new System.Drawing.Point(35, 305);
            DiscordInfoCtrl.Name = "DiscordInfoCtrl";
            DiscordInfoCtrl.Size = new System.Drawing.Size(435, 35);
            DiscordInfoCtrl.TabIndex = 34;
            DiscordInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // DonateInfoCtrl
            // 
            DonateInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            DonateInfoCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            DonateInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            DonateInfoCtrl.DisplayDescription = "https://ko-fi.com/coderedmodding/";
            DonateInfoCtrl.DisplayTitle = "Donate";
            DonateInfoCtrl.Hyperlink = true;
            DonateInfoCtrl.IconBlack = Properties.Resources.Coffee_Black;
            DonateInfoCtrl.IconBlue = Properties.Resources.Coffee_Blue;
            DonateInfoCtrl.IconPurple = Properties.Resources.Coffee_Purple;
            DonateInfoCtrl.IconRed = Properties.Resources.Coffee_Red;
            DonateInfoCtrl.IconSync = true;
            DonateInfoCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            DonateInfoCtrl.IconWhite = Properties.Resources.Coffee_White;
            DonateInfoCtrl.Location = new System.Drawing.Point(35, 350);
            DonateInfoCtrl.Name = "DonateInfoCtrl";
            DonateInfoCtrl.Size = new System.Drawing.Size(435, 35);
            DonateInfoCtrl.TabIndex = 33;
            DonateInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // RemixInfoCtrl
            // 
            RemixInfoCtrl.BackColor = System.Drawing.Color.Transparent;
            RemixInfoCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            RemixInfoCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI", 9.75F);
            RemixInfoCtrl.DisplayDescription = "https://remixicon.com/";
            RemixInfoCtrl.DisplayTitle = "Icons By";
            RemixInfoCtrl.Hyperlink = true;
            RemixInfoCtrl.IconBlack = Properties.Resources.Remix_Black;
            RemixInfoCtrl.IconBlue = Properties.Resources.Remix_Blue;
            RemixInfoCtrl.IconPurple = Properties.Resources.Remix_Purple;
            RemixInfoCtrl.IconRed = Properties.Resources.Remix_Red;
            RemixInfoCtrl.IconSync = true;
            RemixInfoCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            RemixInfoCtrl.IconWhite = Properties.Resources.Remix_White;
            RemixInfoCtrl.Location = new System.Drawing.Point(35, 395);
            RemixInfoCtrl.Name = "RemixInfoCtrl";
            RemixInfoCtrl.Size = new System.Drawing.Size(435, 35);
            RemixInfoCtrl.TabIndex = 32;
            RemixInfoCtrl.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // CheckUpdatesBtn
            // 
            CheckUpdatesBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            CheckUpdatesBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            CheckUpdatesBtn.ButtonEnabled = true;
            CheckUpdatesBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            CheckUpdatesBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            CheckUpdatesBtn.DisplayText = "Check for Updates";
            CheckUpdatesBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            CheckUpdatesBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            CheckUpdatesBtn.IconBlack = Properties.Resources.Refresh_Black;
            CheckUpdatesBtn.IconBlue = Properties.Resources.Refresh_Blue;
            CheckUpdatesBtn.IconPurple = Properties.Resources.Refresh_Purple;
            CheckUpdatesBtn.IconRed = Properties.Resources.Refresh_Red;
            CheckUpdatesBtn.IconSync = false;
            CheckUpdatesBtn.IconType = CodeRedLauncher.Controls.IconTheme.White;
            CheckUpdatesBtn.IconWhite = Properties.Resources.Refresh_White;
            CheckUpdatesBtn.Location = new System.Drawing.Point(243, 450);
            CheckUpdatesBtn.Name = "CheckUpdatesBtn";
            CheckUpdatesBtn.Size = new System.Drawing.Size(426, 35);
            CheckUpdatesBtn.TabIndex = 31;
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
            CreditsLbl.Text = "CodeRed is developed by @ItsBranK, but its creation would not have been possible without the inspiration of the following people: ";
            CreditsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashboardTab
            // 
            DashboardTab.BackColor = System.Drawing.Color.FromArgb(30, 31, 34);
            DashboardTab.Controls.Add(UpdateStatusCtrl);
            DashboardTab.Controls.Add(ProcessStatusCtrl);
            DashboardTab.Controls.Add(ChangelogCtrl);
            DashboardTab.Controls.Add(DashboardArtTwo);
            DashboardTab.Controls.Add(DashboardArtOne);
            DashboardTab.Controls.Add(ManualInjectBtn);
            DashboardTab.Controls.Add(LaunchBtn);
            DashboardTab.Location = new System.Drawing.Point(4, 24);
            DashboardTab.Name = "DashboardTab";
            DashboardTab.Padding = new System.Windows.Forms.Padding(3);
            DashboardTab.Size = new System.Drawing.Size(910, 600);
            DashboardTab.TabIndex = 0;
            DashboardTab.Text = "Dashboard";
            // 
            // UpdateStatusCtrl
            // 
            UpdateStatusCtrl.BackColor = System.Drawing.Color.FromArgb(40, 42, 45);
            UpdateStatusCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            UpdateStatusCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            UpdateStatusCtrl.DisplayType = CodeRedLauncher.Controls.StatusTypes.Version_Idle;
            UpdateStatusCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            UpdateStatusCtrl.IconDescBlack = Properties.Resources.Message_Black;
            UpdateStatusCtrl.IconDescBlue = Properties.Resources.Message_Blue;
            UpdateStatusCtrl.IconDescPurple = Properties.Resources.Message_Purple;
            UpdateStatusCtrl.IconDescRed = Properties.Resources.Message_Red;
            UpdateStatusCtrl.IconDescWhite = Properties.Resources.Message_White;
            UpdateStatusCtrl.IconFirstBlack = Properties.Resources.Cloud_Black;
            UpdateStatusCtrl.IconFirstBlue = Properties.Resources.Cloud_Blue;
            UpdateStatusCtrl.IconFirstPurple = Properties.Resources.Cloud_Purple;
            UpdateStatusCtrl.IconFirstRed = Properties.Resources.Cloud_Red;
            UpdateStatusCtrl.IconFirstWhite = Properties.Resources.Cloud_White;
            UpdateStatusCtrl.IconSecondBlack = Properties.Resources.Shield_Black;
            UpdateStatusCtrl.IconSecondBlue = Properties.Resources.Shield_Blue;
            UpdateStatusCtrl.IconSecondPurple = Properties.Resources.Shield_Purple;
            UpdateStatusCtrl.IconSecondRed = Properties.Resources.Shield_Red;
            UpdateStatusCtrl.IconSecondWhite = Properties.Resources.Shield_White;
            UpdateStatusCtrl.IconThirdBlack = Properties.Resources.Warning_Black;
            UpdateStatusCtrl.IconThirdBlue = Properties.Resources.Warning_Blue;
            UpdateStatusCtrl.IconThirdPurple = Properties.Resources.Warning_Purple;
            UpdateStatusCtrl.IconThirdRed = Properties.Resources.Warning_Red;
            UpdateStatusCtrl.IconThirdWhite = Properties.Resources.Warning_White;
            UpdateStatusCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            UpdateStatusCtrl.Location = new System.Drawing.Point(535, 25);
            UpdateStatusCtrl.Name = "UpdateStatusCtrl";
            UpdateStatusCtrl.ResultType = InjectionResults.None;
            UpdateStatusCtrl.Size = new System.Drawing.Size(350, 130);
            UpdateStatusCtrl.TabIndex = 36;
            UpdateStatusCtrl.TitleFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            UpdateStatusCtrl.ViewType = CodeRedLauncher.Controls.StatusViews.One;
            // 
            // ProcessStatusCtrl
            // 
            ProcessStatusCtrl.BackColor = System.Drawing.Color.FromArgb(40, 42, 45);
            ProcessStatusCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            ProcessStatusCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ProcessStatusCtrl.DisplayType = CodeRedLauncher.Controls.StatusTypes.Process_Idle;
            ProcessStatusCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            ProcessStatusCtrl.IconDescBlack = Properties.Resources.Note_Black;
            ProcessStatusCtrl.IconDescBlue = Properties.Resources.Note_Blue;
            ProcessStatusCtrl.IconDescPurple = Properties.Resources.Note_Purple;
            ProcessStatusCtrl.IconDescRed = Properties.Resources.Note_Red;
            ProcessStatusCtrl.IconDescWhite = Properties.Resources.Note_White;
            ProcessStatusCtrl.IconFirstBlack = Properties.Resources.Rocket_Black;
            ProcessStatusCtrl.IconFirstBlue = Properties.Resources.Rocket_Blue;
            ProcessStatusCtrl.IconFirstPurple = Properties.Resources.Rocket_Purple;
            ProcessStatusCtrl.IconFirstRed = Properties.Resources.Rocket_Red;
            ProcessStatusCtrl.IconFirstWhite = Properties.Resources.Rocket_White;
            ProcessStatusCtrl.IconSecondBlack = null;
            ProcessStatusCtrl.IconSecondBlue = null;
            ProcessStatusCtrl.IconSecondPurple = null;
            ProcessStatusCtrl.IconSecondRed = null;
            ProcessStatusCtrl.IconSecondWhite = null;
            ProcessStatusCtrl.IconThirdBlack = null;
            ProcessStatusCtrl.IconThirdBlue = null;
            ProcessStatusCtrl.IconThirdPurple = null;
            ProcessStatusCtrl.IconThirdRed = null;
            ProcessStatusCtrl.IconThirdWhite = null;
            ProcessStatusCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            ProcessStatusCtrl.Location = new System.Drawing.Point(25, 25);
            ProcessStatusCtrl.Name = "ProcessStatusCtrl";
            ProcessStatusCtrl.ResultType = InjectionResults.None;
            ProcessStatusCtrl.Size = new System.Drawing.Size(480, 130);
            ProcessStatusCtrl.TabIndex = 35;
            ProcessStatusCtrl.TitleFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            ProcessStatusCtrl.ViewType = CodeRedLauncher.Controls.StatusViews.One;
            // 
            // ChangelogCtrl
            // 
            ChangelogCtrl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ChangelogCtrl.BackColor = System.Drawing.Color.FromArgb(40, 42, 45);
            ChangelogCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            ChangelogCtrl.DescriptionFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ChangelogCtrl.DisplayType = CodeRedLauncher.Controls.ChangelogViews.Module;
            ChangelogCtrl.IconBlack = Properties.Resources.Changelog_Black;
            ChangelogCtrl.IconBlue = Properties.Resources.Changelog_Blue;
            ChangelogCtrl.IconPurple = Properties.Resources.Changelog_Purple;
            ChangelogCtrl.IconRed = Properties.Resources.Changelog_Red;
            ChangelogCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            ChangelogCtrl.IconWhite = Properties.Resources.Changelog_White;
            ChangelogCtrl.LauncherText = "Loading...";
            ChangelogCtrl.Location = new System.Drawing.Point(25, 180);
            ChangelogCtrl.ModuleText = "Loading...";
            ChangelogCtrl.Name = "ChangelogCtrl";
            ChangelogCtrl.Size = new System.Drawing.Size(860, 315);
            ChangelogCtrl.TabIndex = 33;
            ChangelogCtrl.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            // 
            // DashboardArtTwo
            // 
            DashboardArtTwo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DashboardArtTwo.BackColor = System.Drawing.Color.Transparent;
            DashboardArtTwo.BackgroundImage = Properties.Resources.BR1_Dark;
            DashboardArtTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            DashboardArtTwo.Location = new System.Drawing.Point(790, 486);
            DashboardArtTwo.Name = "DashboardArtTwo";
            DashboardArtTwo.Size = new System.Drawing.Size(120, 114);
            DashboardArtTwo.TabIndex = 37;
            DashboardArtTwo.TabStop = false;
            // 
            // DashboardArtOne
            // 
            DashboardArtOne.BackColor = System.Drawing.Color.Transparent;
            DashboardArtOne.BackgroundImage = Properties.Resources.TL1_Dark;
            DashboardArtOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            DashboardArtOne.Location = new System.Drawing.Point(0, 0);
            DashboardArtOne.Name = "DashboardArtOne";
            DashboardArtOne.Size = new System.Drawing.Size(126, 122);
            DashboardArtOne.TabIndex = 38;
            DashboardArtOne.TabStop = false;
            // 
            // ManualInjectBtn
            // 
            ManualInjectBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            ManualInjectBtn.ButtonEnabled = true;
            ManualInjectBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            ManualInjectBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ManualInjectBtn.DisplayText = "Manually Inject";
            ManualInjectBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ManualInjectBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            ManualInjectBtn.IconBlack = Properties.Resources.Mouse_Black;
            ManualInjectBtn.IconBlue = Properties.Resources.Mouse_Blue;
            ManualInjectBtn.IconPurple = Properties.Resources.Mouse_Purple;
            ManualInjectBtn.IconRed = Properties.Resources.Mouse_Red;
            ManualInjectBtn.IconSync = false;
            ManualInjectBtn.IconType = CodeRedLauncher.Controls.IconTheme.White;
            ManualInjectBtn.IconWhite = Properties.Resources.Mouse_White;
            ManualInjectBtn.Location = new System.Drawing.Point(288, 530);
            ManualInjectBtn.Name = "ManualInjectBtn";
            ManualInjectBtn.Size = new System.Drawing.Size(320, 35);
            ManualInjectBtn.TabIndex = 34;
            ManualInjectBtn.Visible = false;
            ManualInjectBtn.OnButtonClick += ManualInjectBtn_OnButtonClick;
            // 
            // LaunchBtn
            // 
            LaunchBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            LaunchBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            LaunchBtn.ButtonEnabled = true;
            LaunchBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            LaunchBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            LaunchBtn.DisplayText = "Launch Rocket League";
            LaunchBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            LaunchBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            LaunchBtn.IconBlack = Properties.Resources.Rocket_Black;
            LaunchBtn.IconBlue = Properties.Resources.Rocket_Blue;
            LaunchBtn.IconPurple = Properties.Resources.Rocket_Purple;
            LaunchBtn.IconRed = Properties.Resources.Rocket_Red;
            LaunchBtn.IconSync = false;
            LaunchBtn.IconType = CodeRedLauncher.Controls.IconTheme.White;
            LaunchBtn.IconWhite = Properties.Resources.Rocket_White;
            LaunchBtn.Location = new System.Drawing.Point(288, 530);
            LaunchBtn.Name = "LaunchBtn";
            LaunchBtn.Size = new System.Drawing.Size(320, 35);
            LaunchBtn.TabIndex = 32;
            LaunchBtn.Visible = false;
            LaunchBtn.OnButtonClick += LaunchBtn_OnButtonClick;
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
            NewsCtrl.AuthorBlack = Properties.Resources.Account_Black;
            NewsCtrl.AuthorBlue = Properties.Resources.Account_Blue;
            NewsCtrl.AuthorPurple = Properties.Resources.Account_Purple;
            NewsCtrl.AuthorRed = Properties.Resources.Account_Red;
            NewsCtrl.AuthorWhite = Properties.Resources.Account_White;
            NewsCtrl.BackColor = System.Drawing.Color.Transparent;
            NewsCtrl.CalendarBlack = Properties.Resources.Calendar_Black;
            NewsCtrl.CalendarBlue = Properties.Resources.Calendar_Blue;
            NewsCtrl.CalendarPurple = Properties.Resources.Calendar_Purple;
            NewsCtrl.CalendarRed = Properties.Resources.Calendar_Red;
            NewsCtrl.CalendarWhite = Properties.Resources.Calendar_White;
            NewsCtrl.CategoryBlack = Properties.Resources.Tag_Black;
            NewsCtrl.CategoryBlue = Properties.Resources.Tag_Blue;
            NewsCtrl.CategoryPurple = Properties.Resources.Tag_Purple;
            NewsCtrl.CategoryRed = Properties.Resources.Tag_Red;
            NewsCtrl.CategoryWhite = Properties.Resources.Tag_White;
            NewsCtrl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            NewsCtrl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            NewsCtrl.LeftBlack = Properties.Resources.Left_Black;
            NewsCtrl.LeftBlue = Properties.Resources.Left_Blue;
            NewsCtrl.LeftPurple = Properties.Resources.Left_Purple;
            NewsCtrl.LeftRed = Properties.Resources.Left_Red;
            NewsCtrl.LeftWhite = Properties.Resources.Left_White;
            NewsCtrl.Location = new System.Drawing.Point(23, 25);
            NewsCtrl.Name = "NewsCtrl";
            NewsCtrl.NewsCategory = "Loading...";
            NewsCtrl.PublishAuthor = "Loading...";
            NewsCtrl.PublishDate = "Loading...";
            NewsCtrl.RightBlack = Properties.Resources.Right_Black;
            NewsCtrl.RightBlue = Properties.Resources.Right_Blue;
            NewsCtrl.RightPurple = Properties.Resources.Right_Purple;
            NewsCtrl.RightRed = Properties.Resources.Right_Red;
            NewsCtrl.RightWhite = Properties.Resources.Right_White;
            NewsCtrl.Size = new System.Drawing.Size(865, 550);
            NewsCtrl.TabIndex = 0;
            NewsCtrl.Thumbnail = null;
            NewsCtrl.Title = "Loading...";
            // 
            // NewsArtOne
            // 
            NewsArtOne.BackColor = System.Drawing.Color.Transparent;
            NewsArtOne.BackgroundImage = Properties.Resources.TL2_Dark;
            NewsArtOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            NewsArtOne.Location = new System.Drawing.Point(0, 0);
            NewsArtOne.Name = "NewsArtOne";
            NewsArtOne.Size = new System.Drawing.Size(175, 168);
            NewsArtOne.TabIndex = 1;
            NewsArtOne.TabStop = false;
            // 
            // NewsArtTwo
            // 
            NewsArtTwo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            NewsArtTwo.BackColor = System.Drawing.Color.Transparent;
            NewsArtTwo.BackgroundImage = Properties.Resources.TR2_Dark;
            NewsArtTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            NewsArtTwo.Location = new System.Drawing.Point(801, 0);
            NewsArtTwo.Name = "NewsArtTwo";
            NewsArtTwo.Size = new System.Drawing.Size(109, 106);
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
            SettingsTab.Controls.Add(InjectionTimeoutLbl);
            SettingsTab.Controls.Add(LightModeBx);
            SettingsTab.Controls.Add(ManualInjectBx);
            SettingsTab.Controls.Add(InstallPathBtn);
            SettingsTab.Controls.Add(InstallPathBx);
            SettingsTab.Controls.Add(OpenFolderBtn);
            SettingsTab.Controls.Add(ExportLogsBtn);
            SettingsTab.Controls.Add(InjectAllInstancesBx);
            SettingsTab.Controls.Add(MinimizeOnStartupBx);
            SettingsTab.Controls.Add(RunOnStartupBx);
            SettingsTab.Controls.Add(PreventInjectionBx);
            SettingsTab.Controls.Add(AutoCheckUpdatesBx);
            SettingsTab.Controls.Add(InjectionTimeoutBx);
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
            AutoInstallBx.CheckDark = Properties.Resources.Checkbox_Black;
            AutoInstallBx.CheckWhite = Properties.Resources.Checkbox_White;
            AutoInstallBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            AutoInstallBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            AutoInstallBx.DisplayText = "Automatically install updates";
            AutoInstallBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            AutoInstallBx.IconBlack = Properties.Resources.Install_Black;
            AutoInstallBx.IconBlue = Properties.Resources.Install_Blue;
            AutoInstallBx.IconPurple = Properties.Resources.Install_Purple;
            AutoInstallBx.IconRed = Properties.Resources.Install_Red;
            AutoInstallBx.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            AutoInstallBx.IconWhite = Properties.Resources.Install_White;
            AutoInstallBx.Location = new System.Drawing.Point(35, 80);
            AutoInstallBx.Name = "AutoInstallBx";
            AutoInstallBx.Size = new System.Drawing.Size(315, 35);
            AutoInstallBx.TabIndex = 77;
            AutoInstallBx.UncheckDark = Properties.Resources.CheckboxEmpy_Black;
            AutoInstallBx.UncheckWhite = Properties.Resources.CheckboxEmpy_White;
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
            HideWhenMinimizedBx.CheckDark = Properties.Resources.Checkbox_Black;
            HideWhenMinimizedBx.CheckWhite = Properties.Resources.Checkbox_White;
            HideWhenMinimizedBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            HideWhenMinimizedBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            HideWhenMinimizedBx.DisplayText = "Hide when minimized";
            HideWhenMinimizedBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            HideWhenMinimizedBx.IconBlack = Properties.Resources.Spy_Black;
            HideWhenMinimizedBx.IconBlue = Properties.Resources.Spy_Blue;
            HideWhenMinimizedBx.IconPurple = Properties.Resources.Spy_Purple;
            HideWhenMinimizedBx.IconRed = Properties.Resources.Spy_Red;
            HideWhenMinimizedBx.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            HideWhenMinimizedBx.IconWhite = Properties.Resources.Spy_White;
            HideWhenMinimizedBx.Location = new System.Drawing.Point(35, 260);
            HideWhenMinimizedBx.Name = "HideWhenMinimizedBx";
            HideWhenMinimizedBx.Size = new System.Drawing.Size(315, 35);
            HideWhenMinimizedBx.TabIndex = 74;
            HideWhenMinimizedBx.UncheckDark = Properties.Resources.CheckboxEmpy_Black;
            HideWhenMinimizedBx.UncheckWhite = Properties.Resources.CheckboxEmpy_White;
            HideWhenMinimizedBx.OnCheckChanged += HideWhenMinimizedBx_OnCheckChanged;
            // 
            // InstallPathLbl
            // 
            InstallPathLbl.BackColor = System.Drawing.Color.Transparent;
            InstallPathLbl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            InstallPathLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InstallPathLbl.DisplayText = "Install path";
            InstallPathLbl.IconBlack = Properties.Resources.Folder_Black;
            InstallPathLbl.IconBlue = Properties.Resources.Folder_Blue;
            InstallPathLbl.IconPurple = Properties.Resources.Folder_Purple;
            InstallPathLbl.IconRed = Properties.Resources.Folder_Red;
            InstallPathLbl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            InstallPathLbl.IconWhite = Properties.Resources.Folder_White;
            InstallPathLbl.Location = new System.Drawing.Point(35, 490);
            InstallPathLbl.Name = "InstallPathLbl";
            InstallPathLbl.Size = new System.Drawing.Size(150, 35);
            InstallPathLbl.TabIndex = 72;
            // 
            // InjectionTimeoutLbl
            // 
            InjectionTimeoutLbl.BackColor = System.Drawing.Color.Transparent;
            InjectionTimeoutLbl.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            InjectionTimeoutLbl.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InjectionTimeoutLbl.DisplayText = "Injection delay";
            InjectionTimeoutLbl.IconBlack = Properties.Resources.Hourglass_Black;
            InjectionTimeoutLbl.IconBlue = Properties.Resources.Hourglass_Blue;
            InjectionTimeoutLbl.IconPurple = Properties.Resources.Hourglass_Purple;
            InjectionTimeoutLbl.IconRed = Properties.Resources.Hourglass_Red;
            InjectionTimeoutLbl.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            InjectionTimeoutLbl.IconWhite = Properties.Resources.Hourglass_White;
            InjectionTimeoutLbl.Location = new System.Drawing.Point(35, 440);
            InjectionTimeoutLbl.Name = "InjectionTimeoutLbl";
            InjectionTimeoutLbl.Size = new System.Drawing.Size(150, 35);
            InjectionTimeoutLbl.TabIndex = 71;
            // 
            // LightModeBx
            // 
            LightModeBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            LightModeBx.BackColor = System.Drawing.Color.Transparent;
            LightModeBx.BoxChecked = false;
            LightModeBx.BoxEnabled = true;
            LightModeBx.CheckDark = Properties.Resources.Checkbox_Black;
            LightModeBx.CheckWhite = Properties.Resources.Checkbox_White;
            LightModeBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            LightModeBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            LightModeBx.DisplayText = "Blind me with the power of the sun";
            LightModeBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            LightModeBx.IconBlack = Properties.Resources.Sun_Black;
            LightModeBx.IconBlue = Properties.Resources.Sun_Blue;
            LightModeBx.IconPurple = Properties.Resources.Sun_Purple;
            LightModeBx.IconRed = Properties.Resources.Sun_Red;
            LightModeBx.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            LightModeBx.IconWhite = Properties.Resources.Sun_White;
            LightModeBx.Location = new System.Drawing.Point(35, 395);
            LightModeBx.Name = "LightModeBx";
            LightModeBx.Size = new System.Drawing.Size(315, 35);
            LightModeBx.TabIndex = 70;
            LightModeBx.UncheckDark = Properties.Resources.CheckboxEmpy_Black;
            LightModeBx.UncheckWhite = Properties.Resources.CheckboxEmpy_White;
            LightModeBx.OnCheckChanged += LightModeBx_OnCheckChanged;
            // 
            // ManualInjectBx
            // 
            ManualInjectBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ManualInjectBx.BackColor = System.Drawing.Color.Transparent;
            ManualInjectBx.BoxChecked = false;
            ManualInjectBx.BoxEnabled = true;
            ManualInjectBx.CheckDark = Properties.Resources.Checkbox_Black;
            ManualInjectBx.CheckWhite = Properties.Resources.Checkbox_White;
            ManualInjectBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            ManualInjectBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ManualInjectBx.DisplayText = "Manually inject instead of delay";
            ManualInjectBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            ManualInjectBx.IconBlack = Properties.Resources.Mouse_Black;
            ManualInjectBx.IconBlue = Properties.Resources.Mouse_Blue;
            ManualInjectBx.IconPurple = Properties.Resources.Mouse_Purple;
            ManualInjectBx.IconRed = Properties.Resources.Mouse_Red;
            ManualInjectBx.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            ManualInjectBx.IconWhite = Properties.Resources.Mouse_White;
            ManualInjectBx.Location = new System.Drawing.Point(35, 350);
            ManualInjectBx.Name = "ManualInjectBx";
            ManualInjectBx.Size = new System.Drawing.Size(315, 35);
            ManualInjectBx.TabIndex = 69;
            ManualInjectBx.UncheckDark = Properties.Resources.CheckboxEmpy_Black;
            ManualInjectBx.UncheckWhite = Properties.Resources.CheckboxEmpy_White;
            ManualInjectBx.OnCheckChanged += ManualInjectBx_OnCheckChanged;
            // 
            // InstallPathBtn
            // 
            InstallPathBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InstallPathBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            InstallPathBtn.ButtonEnabled = true;
            InstallPathBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            InstallPathBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InstallPathBtn.DisplayText = "   Change";
            InstallPathBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InstallPathBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            InstallPathBtn.IconBlack = Properties.Resources.Folders_Black;
            InstallPathBtn.IconBlue = Properties.Resources.Folders_Blue;
            InstallPathBtn.IconPurple = Properties.Resources.Folders_Purple;
            InstallPathBtn.IconRed = Properties.Resources.Folders_Red;
            InstallPathBtn.IconSync = false;
            InstallPathBtn.IconType = CodeRedLauncher.Controls.IconTheme.White;
            InstallPathBtn.IconWhite = Properties.Resources.Folders_White;
            InstallPathBtn.Location = new System.Drawing.Point(467, 490);
            InstallPathBtn.Name = "InstallPathBtn";
            InstallPathBtn.Size = new System.Drawing.Size(165, 35);
            InstallPathBtn.TabIndex = 68;
            InstallPathBtn.OnButtonClick += InstallPathBtn_OnButtonClick;
            // 
            // InstallPathBx
            // 
            InstallPathBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InstallPathBx.BackColor = System.Drawing.Color.FromArgb(128, 128, 130);
            InstallPathBx.BoxEnabled = true;
            InstallPathBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            InstallPathBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            InstallPathBx.DisplayText = "Loading...";
            InstallPathBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InstallPathBx.Location = new System.Drawing.Point(192, 490);
            InstallPathBx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            InstallPathBx.Name = "InstallPathBx";
            InstallPathBx.ReadOnly = true;
            InstallPathBx.Size = new System.Drawing.Size(263, 35);
            InstallPathBx.TabIndex = 67;
            // 
            // OpenFolderBtn
            // 
            OpenFolderBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            OpenFolderBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            OpenFolderBtn.ButtonEnabled = true;
            OpenFolderBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            OpenFolderBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            OpenFolderBtn.DisplayText = "Open Install Path";
            OpenFolderBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            OpenFolderBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            OpenFolderBtn.IconBlack = Properties.Resources.Open_Black;
            OpenFolderBtn.IconBlue = Properties.Resources.Open_Blue;
            OpenFolderBtn.IconPurple = Properties.Resources.Open_Purple;
            OpenFolderBtn.IconRed = Properties.Resources.Open_Red;
            OpenFolderBtn.IconSync = false;
            OpenFolderBtn.IconType = CodeRedLauncher.Controls.IconTheme.White;
            OpenFolderBtn.IconWhite = Properties.Resources.Open_White;
            OpenFolderBtn.Location = new System.Drawing.Point(135, 540);
            OpenFolderBtn.Name = "OpenFolderBtn";
            OpenFolderBtn.Size = new System.Drawing.Size(320, 35);
            OpenFolderBtn.TabIndex = 63;
            OpenFolderBtn.OnButtonClick += OpenFolderBtn_OnButtonClick;
            // 
            // ExportLogsBtn
            // 
            ExportLogsBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            ExportLogsBtn.BackColor = System.Drawing.Color.FromArgb(255, 50, 37);
            ExportLogsBtn.ButtonEnabled = true;
            ExportLogsBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            ExportLogsBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ExportLogsBtn.DisplayText = "Export Crash Logs";
            ExportLogsBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            ExportLogsBtn.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            ExportLogsBtn.IconBlack = Properties.Resources.Zip_Black;
            ExportLogsBtn.IconBlue = Properties.Resources.Zip_Blue;
            ExportLogsBtn.IconPurple = Properties.Resources.Zip_Purple;
            ExportLogsBtn.IconRed = Properties.Resources.Zip_Red;
            ExportLogsBtn.IconSync = false;
            ExportLogsBtn.IconType = CodeRedLauncher.Controls.IconTheme.White;
            ExportLogsBtn.IconWhite = Properties.Resources.Zip_White;
            ExportLogsBtn.Location = new System.Drawing.Point(467, 540);
            ExportLogsBtn.Name = "ExportLogsBtn";
            ExportLogsBtn.Size = new System.Drawing.Size(320, 35);
            ExportLogsBtn.TabIndex = 62;
            ExportLogsBtn.OnButtonClick += ExportLogsBtn_OnButtonClick;
            // 
            // InjectAllInstancesBx
            // 
            InjectAllInstancesBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InjectAllInstancesBx.BackColor = System.Drawing.Color.Transparent;
            InjectAllInstancesBx.BoxChecked = false;
            InjectAllInstancesBx.BoxEnabled = true;
            InjectAllInstancesBx.CheckDark = Properties.Resources.Checkbox_Black;
            InjectAllInstancesBx.CheckWhite = Properties.Resources.Checkbox_White;
            InjectAllInstancesBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            InjectAllInstancesBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            InjectAllInstancesBx.DisplayText = "Inject into all game instances";
            InjectAllInstancesBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            InjectAllInstancesBx.IconBlack = Properties.Resources.Stack_Black;
            InjectAllInstancesBx.IconBlue = Properties.Resources.Stack_Blue;
            InjectAllInstancesBx.IconPurple = Properties.Resources.Stack_Purple;
            InjectAllInstancesBx.IconRed = Properties.Resources.Stack_Red;
            InjectAllInstancesBx.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            InjectAllInstancesBx.IconWhite = Properties.Resources.Stack_White;
            InjectAllInstancesBx.Location = new System.Drawing.Point(35, 305);
            InjectAllInstancesBx.Name = "InjectAllInstancesBx";
            InjectAllInstancesBx.Size = new System.Drawing.Size(315, 35);
            InjectAllInstancesBx.TabIndex = 60;
            InjectAllInstancesBx.UncheckDark = Properties.Resources.CheckboxEmpy_Black;
            InjectAllInstancesBx.UncheckWhite = Properties.Resources.CheckboxEmpy_White;
            InjectAllInstancesBx.OnCheckChanged += InjectAllInstancesBx_OnCheckChanged;
            // 
            // MinimizeOnStartupBx
            // 
            MinimizeOnStartupBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            MinimizeOnStartupBx.BackColor = System.Drawing.Color.Transparent;
            MinimizeOnStartupBx.BoxChecked = false;
            MinimizeOnStartupBx.BoxEnabled = true;
            MinimizeOnStartupBx.CheckDark = Properties.Resources.Checkbox_Black;
            MinimizeOnStartupBx.CheckWhite = Properties.Resources.Checkbox_White;
            MinimizeOnStartupBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            MinimizeOnStartupBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            MinimizeOnStartupBx.DisplayText = "Minimize on startup";
            MinimizeOnStartupBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            MinimizeOnStartupBx.IconBlack = Properties.Resources.Eye_Black;
            MinimizeOnStartupBx.IconBlue = Properties.Resources.Eye_Blue;
            MinimizeOnStartupBx.IconPurple = Properties.Resources.Eye_Purple;
            MinimizeOnStartupBx.IconRed = Properties.Resources.Eye_Red;
            MinimizeOnStartupBx.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            MinimizeOnStartupBx.IconWhite = Properties.Resources.Eye_White;
            MinimizeOnStartupBx.Location = new System.Drawing.Point(35, 215);
            MinimizeOnStartupBx.Name = "MinimizeOnStartupBx";
            MinimizeOnStartupBx.Size = new System.Drawing.Size(315, 35);
            MinimizeOnStartupBx.TabIndex = 58;
            MinimizeOnStartupBx.UncheckDark = Properties.Resources.CheckboxEmpy_Black;
            MinimizeOnStartupBx.UncheckWhite = Properties.Resources.CheckboxEmpy_White;
            MinimizeOnStartupBx.OnCheckChanged += MinimizeOnStartupBx_OnCheckChanged;
            // 
            // RunOnStartupBx
            // 
            RunOnStartupBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            RunOnStartupBx.BackColor = System.Drawing.Color.Transparent;
            RunOnStartupBx.BoxChecked = false;
            RunOnStartupBx.BoxEnabled = true;
            RunOnStartupBx.CheckDark = Properties.Resources.Checkbox_Black;
            RunOnStartupBx.CheckWhite = Properties.Resources.Checkbox_White;
            RunOnStartupBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            RunOnStartupBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            RunOnStartupBx.DisplayText = "Run on windows startup";
            RunOnStartupBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            RunOnStartupBx.IconBlack = Properties.Resources.Windows_Black;
            RunOnStartupBx.IconBlue = Properties.Resources.Windows_Blue;
            RunOnStartupBx.IconPurple = Properties.Resources.Windows_Purple;
            RunOnStartupBx.IconRed = Properties.Resources.Windows_Red;
            RunOnStartupBx.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            RunOnStartupBx.IconWhite = Properties.Resources.Windows_White;
            RunOnStartupBx.Location = new System.Drawing.Point(35, 170);
            RunOnStartupBx.Name = "RunOnStartupBx";
            RunOnStartupBx.Size = new System.Drawing.Size(315, 35);
            RunOnStartupBx.TabIndex = 57;
            RunOnStartupBx.UncheckDark = Properties.Resources.CheckboxEmpy_Black;
            RunOnStartupBx.UncheckWhite = Properties.Resources.CheckboxEmpy_White;
            RunOnStartupBx.OnCheckChanged += RunOnStartupBx_OnCheckChanged;
            // 
            // PreventInjectionBx
            // 
            PreventInjectionBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PreventInjectionBx.BackColor = System.Drawing.Color.Transparent;
            PreventInjectionBx.BoxChecked = false;
            PreventInjectionBx.BoxEnabled = true;
            PreventInjectionBx.CheckDark = Properties.Resources.Checkbox_Black;
            PreventInjectionBx.CheckWhite = Properties.Resources.Checkbox_White;
            PreventInjectionBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            PreventInjectionBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            PreventInjectionBx.DisplayText = "Prevent injection when out of date";
            PreventInjectionBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            PreventInjectionBx.IconBlack = Properties.Resources.Lock_Black;
            PreventInjectionBx.IconBlue = Properties.Resources.Lock_Blue;
            PreventInjectionBx.IconPurple = Properties.Resources.Lock_Purple;
            PreventInjectionBx.IconRed = Properties.Resources.Lock_Red;
            PreventInjectionBx.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            PreventInjectionBx.IconWhite = Properties.Resources.Lock_White;
            PreventInjectionBx.Location = new System.Drawing.Point(35, 125);
            PreventInjectionBx.Name = "PreventInjectionBx";
            PreventInjectionBx.Size = new System.Drawing.Size(315, 35);
            PreventInjectionBx.TabIndex = 56;
            PreventInjectionBx.UncheckDark = Properties.Resources.CheckboxEmpy_Black;
            PreventInjectionBx.UncheckWhite = Properties.Resources.CheckboxEmpy_White;
            PreventInjectionBx.OnCheckChanged += PreventInjectionBx_OnCheckChanged;
            // 
            // AutoCheckUpdatesBx
            // 
            AutoCheckUpdatesBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AutoCheckUpdatesBx.BackColor = System.Drawing.Color.Transparent;
            AutoCheckUpdatesBx.BoxChecked = false;
            AutoCheckUpdatesBx.BoxEnabled = true;
            AutoCheckUpdatesBx.CheckDark = Properties.Resources.Checkbox_Black;
            AutoCheckUpdatesBx.CheckWhite = Properties.Resources.Checkbox_White;
            AutoCheckUpdatesBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            AutoCheckUpdatesBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            AutoCheckUpdatesBx.DisplayText = "Automatically check for updates";
            AutoCheckUpdatesBx.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            AutoCheckUpdatesBx.IconBlack = Properties.Resources.Download_Black;
            AutoCheckUpdatesBx.IconBlue = Properties.Resources.Download_Blue;
            AutoCheckUpdatesBx.IconPurple = Properties.Resources.Download_Purple;
            AutoCheckUpdatesBx.IconRed = Properties.Resources.Download_Red;
            AutoCheckUpdatesBx.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            AutoCheckUpdatesBx.IconWhite = Properties.Resources.Download_White;
            AutoCheckUpdatesBx.Location = new System.Drawing.Point(35, 35);
            AutoCheckUpdatesBx.Name = "AutoCheckUpdatesBx";
            AutoCheckUpdatesBx.Size = new System.Drawing.Size(315, 35);
            AutoCheckUpdatesBx.TabIndex = 55;
            AutoCheckUpdatesBx.UncheckDark = Properties.Resources.CheckboxEmpy_Black;
            AutoCheckUpdatesBx.UncheckWhite = Properties.Resources.CheckboxEmpy_White;
            AutoCheckUpdatesBx.OnCheckChanged += AutoCheckUpdatesBx_OnCheckChanged;
            // 
            // InjectionTimeoutBx
            // 
            InjectionTimeoutBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InjectionTimeoutBx.BackColor = System.Drawing.Color.FromArgb(128, 128, 130);
            InjectionTimeoutBx.BoxEnabled = true;
            InjectionTimeoutBx.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
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
            InjectionTimeoutBx.Value = 20000;
            InjectionTimeoutBx.OnValueChanged += InjectionTimeoutBx_OnValueChanged;
            // 
            // BackgroundPnl
            // 
            BackgroundPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            BackgroundPnl.Controls.Add(TabPnl);
            BackgroundPnl.Controls.Add(TabCtrl);
            BackgroundPnl.Controls.Add(TermsPopup);
            BackgroundPnl.Controls.Add(PolicyPopup);
            BackgroundPnl.Controls.Add(OfflinePopup);
            BackgroundPnl.Controls.Add(DuplicatePopup);
            BackgroundPnl.Controls.Add(PathPopup);
            BackgroundPnl.Controls.Add(TitleBar);
            BackgroundPnl.Controls.Add(InstallPopup);
            BackgroundPnl.Controls.Add(UpdatePopup);
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
            AboutTabBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            AboutTabBtn.IconBlack = Properties.Resources.About_Black;
            AboutTabBtn.IconBlue = Properties.Resources.About_Blue;
            AboutTabBtn.IconPurple = Properties.Resources.About_Purple;
            AboutTabBtn.IconRed = Properties.Resources.About_Red;
            AboutTabBtn.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            AboutTabBtn.IconWhite = Properties.Resources.About_White;
            AboutTabBtn.Location = new System.Drawing.Point(0, 500);
            AboutTabBtn.Name = "AboutTabBtn";
            AboutTabBtn.Size = new System.Drawing.Size(60, 50);
            AboutTabBtn.TabEnabled = true;
            AboutTabBtn.TabIndex = 7;
            AboutTabBtn.TabSelected = false;
            AboutTabBtn.OnTabClick += AboutTabBtn_OnTabClick;
            // 
            // SettingsTabBtn
            // 
            SettingsTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SettingsTabBtn.BackColor = System.Drawing.Color.Transparent;
            SettingsTabBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            SettingsTabBtn.IconBlack = Properties.Resources.Settings_Black;
            SettingsTabBtn.IconBlue = Properties.Resources.Settings_Blue;
            SettingsTabBtn.IconPurple = Properties.Resources.Settings_Purple;
            SettingsTabBtn.IconRed = Properties.Resources.Settings_Red;
            SettingsTabBtn.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            SettingsTabBtn.IconWhite = Properties.Resources.Settings_White;
            SettingsTabBtn.Location = new System.Drawing.Point(0, 450);
            SettingsTabBtn.Name = "SettingsTabBtn";
            SettingsTabBtn.Size = new System.Drawing.Size(60, 50);
            SettingsTabBtn.TabEnabled = true;
            SettingsTabBtn.TabIndex = 6;
            SettingsTabBtn.TabSelected = false;
            SettingsTabBtn.OnTabClick += SettingsTabBtn_OnTabClick;
            // 
            // ExitTabBtn
            // 
            ExitTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ExitTabBtn.BackColor = System.Drawing.Color.Transparent;
            ExitTabBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            ExitTabBtn.IconBlack = Properties.Resources.Exit_Black;
            ExitTabBtn.IconBlue = Properties.Resources.Exit_Blue;
            ExitTabBtn.IconPurple = Properties.Resources.Exit_Purple;
            ExitTabBtn.IconRed = Properties.Resources.Exit_Red;
            ExitTabBtn.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            ExitTabBtn.IconWhite = Properties.Resources.Exit_White;
            ExitTabBtn.Location = new System.Drawing.Point(0, 550);
            ExitTabBtn.Name = "ExitTabBtn";
            ExitTabBtn.Size = new System.Drawing.Size(60, 50);
            ExitTabBtn.TabEnabled = true;
            ExitTabBtn.TabIndex = 5;
            ExitTabBtn.TabSelected = false;
            ExitTabBtn.OnTabClick += ExitTabBtn_OnTabClick;
            // 
            // NewsTabBtn
            // 
            NewsTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            NewsTabBtn.BackColor = System.Drawing.Color.Transparent;
            NewsTabBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            NewsTabBtn.IconBlack = Properties.Resources.News_Black;
            NewsTabBtn.IconBlue = Properties.Resources.News_Blue;
            NewsTabBtn.IconPurple = Properties.Resources.News_Purple;
            NewsTabBtn.IconRed = Properties.Resources.News_Red;
            NewsTabBtn.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            NewsTabBtn.IconWhite = Properties.Resources.News_White;
            NewsTabBtn.Location = new System.Drawing.Point(0, 50);
            NewsTabBtn.Name = "NewsTabBtn";
            NewsTabBtn.Size = new System.Drawing.Size(60, 50);
            NewsTabBtn.TabEnabled = true;
            NewsTabBtn.TabIndex = 1;
            NewsTabBtn.TabSelected = false;
            NewsTabBtn.OnTabClick += NewsTabBtn_OnTabClick;
            // 
            // DashboardTabBtn
            // 
            DashboardTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DashboardTabBtn.BackColor = System.Drawing.Color.FromArgb(10, 255, 50, 37);
            DashboardTabBtn.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            DashboardTabBtn.IconBlack = Properties.Resources.Dashboard_Black;
            DashboardTabBtn.IconBlue = Properties.Resources.Dashboard_Blue;
            DashboardTabBtn.IconPurple = Properties.Resources.Dashboard_Purple;
            DashboardTabBtn.IconRed = Properties.Resources.Dashboard_Red;
            DashboardTabBtn.IconType = CodeRedLauncher.Controls.IconTheme.Red;
            DashboardTabBtn.IconWhite = Properties.Resources.Dashboard_White;
            DashboardTabBtn.Location = new System.Drawing.Point(0, 0);
            DashboardTabBtn.Name = "DashboardTabBtn";
            DashboardTabBtn.Size = new System.Drawing.Size(60, 50);
            DashboardTabBtn.TabEnabled = true;
            DashboardTabBtn.TabIndex = 0;
            DashboardTabBtn.TabSelected = true;
            DashboardTabBtn.OnTabClick += DashboardTabBtn_OnTabClick;
            // 
            // TermsPopup
            // 
            TermsPopup.AcceptBlack = Properties.Resources.Yes_Black;
            TermsPopup.AcceptBlue = Properties.Resources.Yes_Blue;
            TermsPopup.AcceptPurple = Properties.Resources.Yes_Purple;
            TermsPopup.AcceptRed = Properties.Resources.Yes_Red;
            TermsPopup.AcceptWhite = Properties.Resources.Yes_White;
            TermsPopup.AltBlack = Properties.Resources.Yes_Black;
            TermsPopup.AltBlue = Properties.Resources.Yes_Blue;
            TermsPopup.AltPurple = Properties.Resources.Yes_Purple;
            TermsPopup.AltRed = Properties.Resources.Yes_Red;
            TermsPopup.AltWhite = Properties.Resources.Yes_White;
            TermsPopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            TermsPopup.BoundForm = null;
            TermsPopup.BoundTitle = null;
            TermsPopup.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            TermsPopup.DenyBlack = Properties.Resources.No_Black;
            TermsPopup.DenyBlue = Properties.Resources.No_Blue;
            TermsPopup.DenyPurple = Properties.Resources.No_Purple;
            TermsPopup.DenyRed = Properties.Resources.No_Red;
            TermsPopup.DenyWhite = Properties.Resources.No_White;
            TermsPopup.DescriptionText = "";
            TermsPopup.DisplayTitle = "Terms Of Use";
            TermsPopup.DisplayType = CodeRedLauncher.Controls.CRPolicy.PolicyView.Register;
            TermsPopup.IconType = CodeRedLauncher.Controls.IconTheme.White;
            TermsPopup.Location = new System.Drawing.Point(0, 0);
            TermsPopup.Name = "TermsPopup";
            TermsPopup.Size = new System.Drawing.Size(970, 630);
            TermsPopup.TabIndex = 9;
            TermsPopup.Visible = false;
            TermsPopup.ButtonClickAccept += TermsPopup_ButtonClickAccept;
            TermsPopup.ButtonClickDeny += TermsPopup_ButtonClickDeny;
            // 
            // PolicyPopup
            // 
            PolicyPopup.AcceptBlack = Properties.Resources.Yes_Black;
            PolicyPopup.AcceptBlue = Properties.Resources.Yes_Blue;
            PolicyPopup.AcceptPurple = Properties.Resources.Yes_Purple;
            PolicyPopup.AcceptRed = Properties.Resources.Yes_Red;
            PolicyPopup.AcceptWhite = Properties.Resources.Yes_White;
            PolicyPopup.AltBlack = Properties.Resources.Yes_Black;
            PolicyPopup.AltBlue = Properties.Resources.Yes_Blue;
            PolicyPopup.AltPurple = Properties.Resources.Yes_Purple;
            PolicyPopup.AltRed = Properties.Resources.Yes_Red;
            PolicyPopup.AltWhite = Properties.Resources.Yes_White;
            PolicyPopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            PolicyPopup.BoundForm = null;
            PolicyPopup.BoundTitle = null;
            PolicyPopup.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            PolicyPopup.DenyBlack = Properties.Resources.No_Black;
            PolicyPopup.DenyBlue = Properties.Resources.No_Blue;
            PolicyPopup.DenyPurple = Properties.Resources.No_Purple;
            PolicyPopup.DenyRed = Properties.Resources.No_Red;
            PolicyPopup.DenyWhite = Properties.Resources.No_White;
            PolicyPopup.DescriptionText = "";
            PolicyPopup.DisplayTitle = "Privacy Policy";
            PolicyPopup.DisplayType = CodeRedLauncher.Controls.CRPolicy.PolicyView.Register;
            PolicyPopup.IconType = CodeRedLauncher.Controls.IconTheme.White;
            PolicyPopup.Location = new System.Drawing.Point(0, 0);
            PolicyPopup.Name = "PolicyPopup";
            PolicyPopup.Size = new System.Drawing.Size(970, 630);
            PolicyPopup.TabIndex = 8;
            PolicyPopup.Visible = false;
            PolicyPopup.ButtonClickAccept += PolicyPopup_ButtonClickAccept;
            PolicyPopup.ButtonClickDeny += PolicyPopup_ButtonClickDeny;
            // 
            // OfflinePopup
            // 
            OfflinePopup.AcceptBlack = Properties.Resources.Yes_Black;
            OfflinePopup.AcceptBlue = Properties.Resources.Yes_Blue;
            OfflinePopup.AcceptPurple = Properties.Resources.Yes_Purple;
            OfflinePopup.AcceptRed = Properties.Resources.Yes_Red;
            OfflinePopup.AcceptWhite = Properties.Resources.Yes_White;
            OfflinePopup.AltBlack = Properties.Resources.Offline_Black;
            OfflinePopup.AltBlue = Properties.Resources.Offline_Blue;
            OfflinePopup.AltPurple = Properties.Resources.Offline_Purple;
            OfflinePopup.AltRed = Properties.Resources.Offline_Red;
            OfflinePopup.AltWhite = Properties.Resources.Offline_White;
            OfflinePopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            OfflinePopup.BoundForm = null;
            OfflinePopup.BoundTitle = null;
            OfflinePopup.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            OfflinePopup.DenyBlack = Properties.Resources.No_Black;
            OfflinePopup.DenyBlue = Properties.Resources.No_Blue;
            OfflinePopup.DenyPurple = Properties.Resources.No_Purple;
            OfflinePopup.DenyRed = Properties.Resources.No_Red;
            OfflinePopup.DenyWhite = Properties.Resources.No_White;
            OfflinePopup.IconType = CodeRedLauncher.Controls.IconTheme.White;
            OfflinePopup.Location = new System.Drawing.Point(0, 0);
            OfflinePopup.Name = "OfflinePopup";
            OfflinePopup.OfflineType = CodeRedLauncher.Controls.CROffline.OfflineLayouts.Default;
            OfflinePopup.Size = new System.Drawing.Size(970, 630);
            OfflinePopup.TabIndex = 8;
            OfflinePopup.Visible = false;
            OfflinePopup.ButtonClickAccept += OfflinePopup_ButtonClickAccept;
            OfflinePopup.ButtonClickDeny += OfflinePopup_ButtonClickDeny;
            OfflinePopup.ButtonClickAlt += OfflinePopup_ButtonClickAlt;
            // 
            // DuplicatePopup
            // 
            DuplicatePopup.AcceptBlack = Properties.Resources.Yes_Black;
            DuplicatePopup.AcceptBlue = Properties.Resources.Yes_Blue;
            DuplicatePopup.AcceptPurple = Properties.Resources.Yes_Purple;
            DuplicatePopup.AcceptRed = Properties.Resources.Yes_Red;
            DuplicatePopup.AcceptWhite = Properties.Resources.Yes_White;
            DuplicatePopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            DuplicatePopup.BoundForm = null;
            DuplicatePopup.BoundTitle = null;
            DuplicatePopup.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            DuplicatePopup.DenyBlack = Properties.Resources.No_Black;
            DuplicatePopup.DenyBlue = Properties.Resources.No_Blue;
            DuplicatePopup.DenyPurple = Properties.Resources.No_Purple;
            DuplicatePopup.DenyRed = Properties.Resources.No_Red;
            DuplicatePopup.DenyWhite = Properties.Resources.No_White;
            DuplicatePopup.IconType = CodeRedLauncher.Controls.IconTheme.White;
            DuplicatePopup.Location = new System.Drawing.Point(0, 0);
            DuplicatePopup.Name = "DuplicatePopup";
            DuplicatePopup.Size = new System.Drawing.Size(970, 630);
            DuplicatePopup.TabIndex = 8;
            DuplicatePopup.Visible = false;
            DuplicatePopup.ButtonClickAccept += DuplicatePopup_ButtonClickAccept;
            DuplicatePopup.ButtonClickDeny += DuplicatePopup_ButtonClickDeny;
            // 
            // PathPopup
            // 
            PathPopup.AcceptBlack = null;
            PathPopup.AcceptBlue = null;
            PathPopup.AcceptPurple = null;
            PathPopup.AcceptRed = null;
            PathPopup.AcceptWhite = null;
            PathPopup.AltBlack = null;
            PathPopup.AltBlue = null;
            PathPopup.AltPurple = null;
            PathPopup.AltRed = null;
            PathPopup.AltWhite = null;
            PathPopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            PathPopup.BoundForm = null;
            PathPopup.BoundTitle = null;
            PathPopup.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            PathPopup.DenyBlack = null;
            PathPopup.DenyBlue = null;
            PathPopup.DenyPurple = null;
            PathPopup.DenyRed = null;
            PathPopup.DenyWhite = null;
            PathPopup.IconType = CodeRedLauncher.Controls.IconTheme.White;
            PathPopup.Location = new System.Drawing.Point(0, 0);
            PathPopup.Name = "PathPopup";
            PathPopup.OfflineType = CodeRedLauncher.Controls.CRPathing.OfflineLayouts.Default;
            PathPopup.Size = new System.Drawing.Size(970, 630);
            PathPopup.TabIndex = 8;
            PathPopup.Visible = false;
            // 
            // TitleBar
            // 
            TitleBar.BackColor = System.Drawing.Color.FromArgb(50, 50, 55);
            TitleBar.BoundForm = null;
            TitleBar.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            TitleBar.DisplayText = "CODERED LAUNCHER";
            TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            TitleBar.ForeColor = System.Drawing.Color.FromArgb(242, 243, 245);
            TitleBar.Location = new System.Drawing.Point(0, 0);
            TitleBar.MaximizeButton = true;
            TitleBar.MinimizeButton = true;
            TitleBar.Name = "TitleBar";
            TitleBar.Size = new System.Drawing.Size(970, 30);
            TitleBar.TabIndex = 2;
            TitleBar.OnMinimized += TitleBar_OnMinimized;
            TitleBar.OnExit += TitleBar_OnExit;
            // 
            // InstallPopup
            // 
            InstallPopup.AcceptBlack = Properties.Resources.Download_Black;
            InstallPopup.AcceptBlue = Properties.Resources.Download_Blue;
            InstallPopup.AcceptPurple = Properties.Resources.Download_Purple;
            InstallPopup.AcceptRed = Properties.Resources.Download_Red;
            InstallPopup.AcceptWhite = Properties.Resources.Download_White;
            InstallPopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            InstallPopup.BoundForm = null;
            InstallPopup.BoundTitle = null;
            InstallPopup.ButtonsEnabled = true;
            InstallPopup.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            InstallPopup.DenyBlack = Properties.Resources.Folder_Black;
            InstallPopup.DenyBlue = Properties.Resources.Folder_Blue;
            InstallPopup.DenyPurple = Properties.Resources.Folder_Purple;
            InstallPopup.DenyRed = Properties.Resources.Folder_Red;
            InstallPopup.DenyWhite = Properties.Resources.Folder_White;
            InstallPopup.DisplayType = CodeRedLauncher.Controls.CRInstall.InstallLayouts.None;
            InstallPopup.IconType = CodeRedLauncher.Controls.IconTheme.White;
            InstallPopup.Location = new System.Drawing.Point(0, 0);
            InstallPopup.Name = "InstallPopup";
            InstallPopup.Size = new System.Drawing.Size(970, 630);
            InstallPopup.TabIndex = 8;
            InstallPopup.Visible = false;
            InstallPopup.ButtonClickAccept += InstallPopup_ButtonClickAccept;
            InstallPopup.ButtonClickDeny += InstallPopup_ButtonClickDeny;
            // 
            // UpdatePopup
            // 
            UpdatePopup.AcceptBlack = Properties.Resources.Yes_Black;
            UpdatePopup.AcceptBlue = Properties.Resources.Yes_Blue;
            UpdatePopup.AcceptPurple = Properties.Resources.Yes_Purple;
            UpdatePopup.AcceptRed = Properties.Resources.Yes_Red;
            UpdatePopup.AcceptWhite = Properties.Resources.Yes_White;
            UpdatePopup.AltBlack = Properties.Resources.Rocket_Black;
            UpdatePopup.AltBlue = Properties.Resources.Rocket_Blue;
            UpdatePopup.AltPurple = Properties.Resources.Rocket_Purple;
            UpdatePopup.AltRed = Properties.Resources.Rocket_Red;
            UpdatePopup.AltWhite = Properties.Resources.Rocket_White;
            UpdatePopup.BackColor = System.Drawing.Color.FromArgb(30, 30, 31);
            UpdatePopup.BoundForm = null;
            UpdatePopup.BoundTitle = null;
            UpdatePopup.ButtonsEnabled = true;
            UpdatePopup.ControlType = CodeRedLauncher.Controls.ControlTheme.Dark;
            UpdatePopup.DenyBlack = Properties.Resources.No_Black;
            UpdatePopup.DenyBlue = Properties.Resources.No_Blue;
            UpdatePopup.DenyPurple = Properties.Resources.No_Purple;
            UpdatePopup.DenyRed = Properties.Resources.No_Red;
            UpdatePopup.DenyWhite = Properties.Resources.No_White;
            UpdatePopup.IconType = CodeRedLauncher.Controls.IconTheme.White;
            UpdatePopup.Location = new System.Drawing.Point(0, 0);
            UpdatePopup.Name = "UpdatePopup";
            UpdatePopup.Size = new System.Drawing.Size(970, 630);
            UpdatePopup.TabIndex = 8;
            UpdatePopup.UpdateType = CodeRedLauncher.Controls.CRUpdate.UpdateLayouts.Module;
            UpdatePopup.Visible = false;
            UpdatePopup.ButtonClickAccept += UpdatePopup_ButtonClickAccept;
            UpdatePopup.ButtonClickDeny += UpdatePopup_ButtonClickDeny;
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
        private Controls.CRTitle TitleBar;
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
        private Controls.CRButton LaunchBtn;
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
        private System.Windows.Forms.PictureBox InjectionTimeoutImg;
        private Controls.CRInfo RemixInfoCtrl;
        private Controls.CRInfo DonateInfoCtrl;
        private Controls.CRInfo LauncherInfoCtrl;
        private Controls.CRInfo WebsiteInfoCtrl;
        private Controls.CRInfo DiscordInfoCtrl;
        private Controls.CRInfo PlatformInfoCtrl;
        private Controls.CRInfo BuildInfoCtrl;
        private Controls.CRInfo PsyonixInfoCtrl;
        private Controls.CRInfo ModuleInfoCtrl;
        private Controls.CRCheckbox ManualInjectBx;
        private Controls.CRLabel InjectionTimeoutLbl;
        private Controls.CRLabel InstallPathLbl;
        private Controls.CRCheckbox LightModeBx;
        private Controls.CRStatus ProcessStatusCtrl;
        private Controls.CRStatus UpdateStatusCtrl;
        private System.Windows.Forms.PictureBox EasterEggImg;
        private Controls.CROffline OfflinePopup;
        private Controls.CRUpdate UpdatePopup;
        private Controls.CRInstall InstallPopup;
        private Controls.CRPolicy PolicyPopup;
        private Controls.CRButton PolicyBtn;
        private Controls.CRCheckbox HideWhenMinimizedBx;
        private Controls.CRPolicy TermsPopup;
        private Controls.CRButton TermsBtn;
        private System.Windows.Forms.PictureBox DashboardArtTwo;
        private System.Windows.Forms.PictureBox DashboardArtOne;
        private System.Windows.Forms.PictureBox NewsArtOne;
        private System.Windows.Forms.PictureBox NewsArtTwo;
        private System.Windows.Forms.PictureBox SettingsArtOne;
        private System.Windows.Forms.PictureBox AboutArtOne;
        private System.Windows.Forms.PictureBox SettingsArtTwo;
        private Controls.CRDuplicate DuplicatePopup;
        private Controls.CRCheckbox AutoInstallBx;
        private Controls.CRPathing PathPopup;
    }
}