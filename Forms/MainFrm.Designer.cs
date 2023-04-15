
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
            DashboardTab = new System.Windows.Forms.TabPage();
            ProcessCtrl = new Controls.CRProcessPanel();
            UpdateCtrl = new Controls.CRUpdatePanel();
            ChangelogCtrl = new Controls.CRChangelog();
            LaunchBtn = new Controls.CRButton();
            ManualInjectBtn = new Controls.CRButton();
            NewsTab = new System.Windows.Forms.TabPage();
            NewsCtrl = new Controls.CRNewsPanel();
            SessionsTab = new System.Windows.Forms.TabPage();
            TotalSessionsLbl = new System.Windows.Forms.Label();
            ReloadSessionsBtn = new Controls.CRButton();
            TexturesTab = new System.Windows.Forms.TabPage();
            PlaceholderLblSecond = new System.Windows.Forms.Label();
            ScriptsTab = new System.Windows.Forms.TabPage();
            PlaceholderLblThird = new System.Windows.Forms.Label();
            SettingsTab = new System.Windows.Forms.TabPage();
            InstallPathBtn = new Controls.CRButton();
            InstallPathBx = new Controls.CRTextbox();
            InstallPathImg = new System.Windows.Forms.PictureBox();
            InstallPathLbl = new System.Windows.Forms.Label();
            InjectionTimeoutBx = new Controls.CRNumberbox();
            InjectionTimeoutImg = new System.Windows.Forms.PictureBox();
            InjectionTimeoutLbl = new System.Windows.Forms.Label();
            OpenFolderBtn = new Controls.CRButton();
            ExportLogsBtn = new Controls.CRButton();
            InjectAllInstancesBx = new Controls.CRCheckbox();
            HideWhenMinimizedBx = new Controls.CRCheckbox();
            MinimizeOnStartupBx = new Controls.CRCheckbox();
            RunOnStartupBx = new Controls.CRCheckbox();
            PreventInjectionBx = new Controls.CRCheckbox();
            AutoCheckUpdatesBx = new Controls.CRCheckbox();
            ManualRadioBtn = new System.Windows.Forms.RadioButton();
            TimeoutRadioBtn = new System.Windows.Forms.RadioButton();
            ManualRadioImg = new System.Windows.Forms.PictureBox();
            TimeoutRadioImg = new System.Windows.Forms.PictureBox();
            AlwaysRadioBtn = new System.Windows.Forms.RadioButton();
            AlwaysRadioImg = new System.Windows.Forms.PictureBox();
            AboutTab = new System.Windows.Forms.TabPage();
            CheckUpdatesBtn = new Controls.CRButton();
            Icons8Link = new System.Windows.Forms.Label();
            KofiLink = new System.Windows.Forms.Label();
            DiscordLink = new System.Windows.Forms.Label();
            WebsiteLink = new System.Windows.Forms.Label();
            PlatformText = new System.Windows.Forms.Label();
            NetBuildText = new System.Windows.Forms.Label();
            PsyonixVersionText = new System.Windows.Forms.Label();
            ModuleVersionText = new System.Windows.Forms.Label();
            LauncherVersionText = new System.Windows.Forms.Label();
            CreditsLbl = new System.Windows.Forms.Label();
            Icons8Img = new System.Windows.Forms.PictureBox();
            IconsLbl = new System.Windows.Forms.Label();
            KofiImg = new System.Windows.Forms.PictureBox();
            KofiLbl = new System.Windows.Forms.Label();
            DiscordImg = new System.Windows.Forms.PictureBox();
            DiscordLbl = new System.Windows.Forms.Label();
            WebsiteImg = new System.Windows.Forms.PictureBox();
            WebsiteLbl = new System.Windows.Forms.Label();
            PlatformImg = new System.Windows.Forms.PictureBox();
            PlatformLbl = new System.Windows.Forms.Label();
            NetBuildImg = new System.Windows.Forms.PictureBox();
            NetBuildLbl = new System.Windows.Forms.Label();
            PsyonixVersionImg = new System.Windows.Forms.PictureBox();
            PsyonixVersionLbl = new System.Windows.Forms.Label();
            ModVersionImg = new System.Windows.Forms.PictureBox();
            ModuleVersionLbl = new System.Windows.Forms.Label();
            LauncherVersionImg = new System.Windows.Forms.PictureBox();
            LauncherVersionLbl = new System.Windows.Forms.Label();
            BackgroundPnl = new System.Windows.Forms.Panel();
            TabPnl = new System.Windows.Forms.Panel();
            AboutTabBtn = new Controls.CRTab();
            SettingsTabBtn = new Controls.CRTab();
            ExitTabBtn = new Controls.CRTab();
            ScriptsTabBtn = new Controls.CRTab();
            TexturesTabBtn = new Controls.CRTab();
            SessionsTabBtn = new Controls.CRTab();
            NewsTabBtn = new Controls.CRTab();
            DashboardTabBtn = new Controls.CRTab();
            TitleBar = new Controls.CRTitleBar();
            InstallOfflinePopupCtrl = new Controls.CRPopup();
            OfflinePopupCtrl = new Controls.CRPopup();
            UpdatePopupCtrl = new Controls.CRPopup();
            InstallPopupCtrl = new Controls.CRPopup();
            ProcessTmr = new System.Windows.Forms.Timer(components);
            InjectTmr = new System.Windows.Forms.Timer(components);
            TrayIcon = new System.Windows.Forms.NotifyIcon(components);
            UpdateTmr = new System.Windows.Forms.Timer(components);
            TabCtrl.SuspendLayout();
            DashboardTab.SuspendLayout();
            NewsTab.SuspendLayout();
            SessionsTab.SuspendLayout();
            TexturesTab.SuspendLayout();
            ScriptsTab.SuspendLayout();
            SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InstallPathImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InjectionTimeoutImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ManualRadioImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TimeoutRadioImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlwaysRadioImg).BeginInit();
            AboutTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Icons8Img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KofiImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DiscordImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WebsiteImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlatformImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NetBuildImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PsyonixVersionImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ModVersionImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LauncherVersionImg).BeginInit();
            BackgroundPnl.SuspendLayout();
            TabPnl.SuspendLayout();
            SuspendLayout();
            // 
            // TabCtrl
            // 
            TabCtrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TabCtrl.Controls.Add(DashboardTab);
            TabCtrl.Controls.Add(NewsTab);
            TabCtrl.Controls.Add(SessionsTab);
            TabCtrl.Controls.Add(TexturesTab);
            TabCtrl.Controls.Add(ScriptsTab);
            TabCtrl.Controls.Add(SettingsTab);
            TabCtrl.Controls.Add(AboutTab);
            TabCtrl.Location = new System.Drawing.Point(56, 6);
            TabCtrl.Name = "TabCtrl";
            TabCtrl.SelectedIndex = 0;
            TabCtrl.Size = new System.Drawing.Size(918, 628);
            TabCtrl.TabIndex = 3;
            // 
            // DashboardTab
            // 
            DashboardTab.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            DashboardTab.Controls.Add(ProcessCtrl);
            DashboardTab.Controls.Add(UpdateCtrl);
            DashboardTab.Controls.Add(ChangelogCtrl);
            DashboardTab.Controls.Add(LaunchBtn);
            DashboardTab.Controls.Add(ManualInjectBtn);
            DashboardTab.Location = new System.Drawing.Point(4, 24);
            DashboardTab.Name = "DashboardTab";
            DashboardTab.Padding = new System.Windows.Forms.Padding(3);
            DashboardTab.Size = new System.Drawing.Size(910, 600);
            DashboardTab.TabIndex = 0;
            DashboardTab.Text = "Dashboard";
            // 
            // ProcessCtrl
            // 
            ProcessCtrl.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            ProcessCtrl.DescriptionImage = Properties.Resources.Comment_White;
            ProcessCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            ProcessCtrl.Location = new System.Drawing.Point(25, 25);
            ProcessCtrl.Name = "ProcessCtrl";
            ProcessCtrl.Result = InjectionResults.RESULT_NONE;
            ProcessCtrl.Size = new System.Drawing.Size(485, 130);
            ProcessCtrl.Status = CodeRedLauncher.Controls.CRProcessPanel.StatusTypes.TYPE_LOADING;
            ProcessCtrl.TabIndex = 0;
            ProcessCtrl.TitleImage = Properties.Resources.Rocket_White;
            // 
            // UpdateCtrl
            // 
            UpdateCtrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            UpdateCtrl.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            UpdateCtrl.DescriptionImage = Properties.Resources.Info_White;
            UpdateCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            UpdateCtrl.Location = new System.Drawing.Point(535, 25);
            UpdateCtrl.Name = "UpdateCtrl";
            UpdateCtrl.Size = new System.Drawing.Size(350, 130);
            UpdateCtrl.Status = CodeRedLauncher.Controls.CRUpdatePanel.StatusTypes.TYPE_LOADING;
            UpdateCtrl.TabIndex = 1;
            UpdateCtrl.TitleImage = Properties.Resources.Question_White;
            // 
            // ChangelogCtrl
            // 
            ChangelogCtrl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ChangelogCtrl.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            ChangelogCtrl.DisplayImage = Properties.Resources.Log_White;
            ChangelogCtrl.DisplayText = "Loading...";
            ChangelogCtrl.DisplayTitle = "Module Changelog";
            ChangelogCtrl.Location = new System.Drawing.Point(25, 180);
            ChangelogCtrl.Name = "ChangelogCtrl";
            ChangelogCtrl.Size = new System.Drawing.Size(860, 315);
            ChangelogCtrl.TabIndex = 33;
            ChangelogCtrl.OnChangelogSwap += ChangelogCtrl_OnChangelogSwap;
            // 
            // LaunchBtn
            // 
            LaunchBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            LaunchBtn.BackColor = System.Drawing.Color.FromArgb(175, 0, 0);
            LaunchBtn.ButtonEnabled = true;
            LaunchBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LaunchBtn.DisplayImage = Properties.Resources.Question_White;
            LaunchBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            LaunchBtn.DisplayText = "Launch Rocket League";
            LaunchBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            LaunchBtn.Location = new System.Drawing.Point(288, 530);
            LaunchBtn.Name = "LaunchBtn";
            LaunchBtn.Size = new System.Drawing.Size(320, 35);
            LaunchBtn.TabIndex = 32;
            LaunchBtn.Visible = false;
            LaunchBtn.OnButtonClick += LaunchBtn_OnButtonClick;
            // 
            // ManualInjectBtn
            // 
            ManualInjectBtn.BackColor = System.Drawing.Color.FromArgb(175, 0, 0);
            ManualInjectBtn.ButtonEnabled = true;
            ManualInjectBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ManualInjectBtn.DisplayImage = Properties.Resources.Hand_White;
            ManualInjectBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            ManualInjectBtn.DisplayText = "Manually Inject";
            ManualInjectBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            ManualInjectBtn.Location = new System.Drawing.Point(288, 530);
            ManualInjectBtn.Name = "ManualInjectBtn";
            ManualInjectBtn.Size = new System.Drawing.Size(320, 35);
            ManualInjectBtn.TabIndex = 34;
            ManualInjectBtn.Visible = false;
            ManualInjectBtn.Click += ManualInjectBtn_Click;
            // 
            // NewsTab
            // 
            NewsTab.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            NewsTab.Controls.Add(NewsCtrl);
            NewsTab.Location = new System.Drawing.Point(4, 24);
            NewsTab.Name = "NewsTab";
            NewsTab.Padding = new System.Windows.Forms.Padding(3);
            NewsTab.Size = new System.Drawing.Size(910, 600);
            NewsTab.TabIndex = 1;
            NewsTab.Text = "News";
            // 
            // NewsCtrl
            // 
            NewsCtrl.BackColor = System.Drawing.Color.Transparent;
            NewsCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            NewsCtrl.Location = new System.Drawing.Point(3, 3);
            NewsCtrl.Name = "NewsCtrl";
            NewsCtrl.NewsCategory = "Loading...";
            NewsCtrl.PublishAuthor = "Loading...";
            NewsCtrl.PublishDate = "Loading...";
            NewsCtrl.Size = new System.Drawing.Size(904, 594);
            NewsCtrl.TabIndex = 0;
            NewsCtrl.Thumbnail = null;
            NewsCtrl.Title = "Loading...";
            // 
            // SessionsTab
            // 
            SessionsTab.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            SessionsTab.Controls.Add(TotalSessionsLbl);
            SessionsTab.Controls.Add(ReloadSessionsBtn);
            SessionsTab.Location = new System.Drawing.Point(4, 24);
            SessionsTab.Name = "SessionsTab";
            SessionsTab.Size = new System.Drawing.Size(910, 600);
            SessionsTab.TabIndex = 2;
            SessionsTab.Text = "Sessions";
            // 
            // TotalSessionsLbl
            // 
            TotalSessionsLbl.BackColor = System.Drawing.Color.Transparent;
            TotalSessionsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TotalSessionsLbl.Location = new System.Drawing.Point(35, 35);
            TotalSessionsLbl.Name = "TotalSessionsLbl";
            TotalSessionsLbl.Size = new System.Drawing.Size(275, 30);
            TotalSessionsLbl.TabIndex = 65;
            TotalSessionsLbl.Text = "Sessions Found: ";
            TotalSessionsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReloadSessionsBtn
            // 
            ReloadSessionsBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            ReloadSessionsBtn.BackColor = System.Drawing.Color.FromArgb(175, 0, 0);
            ReloadSessionsBtn.ButtonEnabled = true;
            ReloadSessionsBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ReloadSessionsBtn.DisplayImage = Properties.Resources.Refresh_White;
            ReloadSessionsBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            ReloadSessionsBtn.DisplayText = "Reload Sessions";
            ReloadSessionsBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            ReloadSessionsBtn.Location = new System.Drawing.Point(315, 540);
            ReloadSessionsBtn.Name = "ReloadSessionsBtn";
            ReloadSessionsBtn.Size = new System.Drawing.Size(300, 35);
            ReloadSessionsBtn.TabIndex = 64;
            ReloadSessionsBtn.OnButtonClick += ReloadSessionsBtn_OnButtonClick;
            // 
            // TexturesTab
            // 
            TexturesTab.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            TexturesTab.Controls.Add(PlaceholderLblSecond);
            TexturesTab.Location = new System.Drawing.Point(4, 24);
            TexturesTab.Name = "TexturesTab";
            TexturesTab.Size = new System.Drawing.Size(910, 600);
            TexturesTab.TabIndex = 6;
            TexturesTab.Text = "Textures";
            // 
            // PlaceholderLblSecond
            // 
            PlaceholderLblSecond.BackColor = System.Drawing.Color.Transparent;
            PlaceholderLblSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            PlaceholderLblSecond.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            PlaceholderLblSecond.Location = new System.Drawing.Point(0, 0);
            PlaceholderLblSecond.Name = "PlaceholderLblSecond";
            PlaceholderLblSecond.Size = new System.Drawing.Size(910, 600);
            PlaceholderLblSecond.TabIndex = 3;
            PlaceholderLblSecond.Text = "Coming soon!";
            PlaceholderLblSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScriptsTab
            // 
            ScriptsTab.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            ScriptsTab.Controls.Add(PlaceholderLblThird);
            ScriptsTab.Location = new System.Drawing.Point(4, 24);
            ScriptsTab.Name = "ScriptsTab";
            ScriptsTab.Size = new System.Drawing.Size(910, 600);
            ScriptsTab.TabIndex = 3;
            ScriptsTab.Text = "Scripts";
            // 
            // PlaceholderLblThird
            // 
            PlaceholderLblThird.BackColor = System.Drawing.Color.Transparent;
            PlaceholderLblThird.Dock = System.Windows.Forms.DockStyle.Fill;
            PlaceholderLblThird.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            PlaceholderLblThird.Location = new System.Drawing.Point(0, 0);
            PlaceholderLblThird.Name = "PlaceholderLblThird";
            PlaceholderLblThird.Size = new System.Drawing.Size(910, 600);
            PlaceholderLblThird.TabIndex = 4;
            PlaceholderLblThird.Text = "Coming soon!";
            PlaceholderLblThird.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsTab
            // 
            SettingsTab.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            SettingsTab.Controls.Add(InstallPathBtn);
            SettingsTab.Controls.Add(InstallPathBx);
            SettingsTab.Controls.Add(InstallPathImg);
            SettingsTab.Controls.Add(InstallPathLbl);
            SettingsTab.Controls.Add(InjectionTimeoutBx);
            SettingsTab.Controls.Add(InjectionTimeoutImg);
            SettingsTab.Controls.Add(InjectionTimeoutLbl);
            SettingsTab.Controls.Add(OpenFolderBtn);
            SettingsTab.Controls.Add(ExportLogsBtn);
            SettingsTab.Controls.Add(InjectAllInstancesBx);
            SettingsTab.Controls.Add(HideWhenMinimizedBx);
            SettingsTab.Controls.Add(MinimizeOnStartupBx);
            SettingsTab.Controls.Add(RunOnStartupBx);
            SettingsTab.Controls.Add(PreventInjectionBx);
            SettingsTab.Controls.Add(AutoCheckUpdatesBx);
            SettingsTab.Controls.Add(ManualRadioBtn);
            SettingsTab.Controls.Add(TimeoutRadioBtn);
            SettingsTab.Controls.Add(ManualRadioImg);
            SettingsTab.Controls.Add(TimeoutRadioImg);
            SettingsTab.Controls.Add(AlwaysRadioBtn);
            SettingsTab.Controls.Add(AlwaysRadioImg);
            SettingsTab.Location = new System.Drawing.Point(4, 24);
            SettingsTab.Name = "SettingsTab";
            SettingsTab.Size = new System.Drawing.Size(910, 600);
            SettingsTab.TabIndex = 4;
            SettingsTab.Text = "Settings";
            // 
            // InstallPathBtn
            // 
            InstallPathBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InstallPathBtn.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            InstallPathBtn.ButtonEnabled = true;
            InstallPathBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            InstallPathBtn.DisplayImage = null;
            InstallPathBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_DARK;
            InstallPathBtn.DisplayText = "Change";
            InstallPathBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InstallPathBtn.Location = new System.Drawing.Point(384, 440);
            InstallPathBtn.Name = "InstallPathBtn";
            InstallPathBtn.Size = new System.Drawing.Size(71, 30);
            InstallPathBtn.TabIndex = 68;
            InstallPathBtn.OnButtonClick += InstallPathBtn_OnButtonClick;
            // 
            // InstallPathBx
            // 
            InstallPathBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InstallPathBx.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            InstallPathBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            InstallPathBx.DisplayText = "";
            InstallPathBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InstallPathBx.Location = new System.Drawing.Point(162, 440);
            InstallPathBx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            InstallPathBx.Name = "InstallPathBx";
            InstallPathBx.ReadOnly = true;
            InstallPathBx.Size = new System.Drawing.Size(215, 30);
            InstallPathBx.TabIndex = 67;
            InstallPathBx.TextFilter = CodeRedLauncher.Controls.CRTextbox.FilterTypes.TYPE_NONE;
            // 
            // InstallPathImg
            // 
            InstallPathImg.BackColor = System.Drawing.Color.Transparent;
            InstallPathImg.BackgroundImage = Properties.Resources.Folder_White;
            InstallPathImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            InstallPathImg.Location = new System.Drawing.Point(35, 440);
            InstallPathImg.Name = "InstallPathImg";
            InstallPathImg.Size = new System.Drawing.Size(30, 30);
            InstallPathImg.TabIndex = 66;
            InstallPathImg.TabStop = false;
            // 
            // InstallPathLbl
            // 
            InstallPathLbl.BackColor = System.Drawing.Color.Transparent;
            InstallPathLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            InstallPathLbl.Location = new System.Drawing.Point(71, 440);
            InstallPathLbl.Name = "InstallPathLbl";
            InstallPathLbl.Size = new System.Drawing.Size(85, 30);
            InstallPathLbl.TabIndex = 65;
            InstallPathLbl.Text = "Install path:";
            InstallPathLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InjectionTimeoutBx
            // 
            InjectionTimeoutBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            InjectionTimeoutBx.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            InjectionTimeoutBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            InjectionTimeoutBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InjectionTimeoutBx.Hexadecimal = false;
            InjectionTimeoutBx.Increment = 1;
            InjectionTimeoutBx.Location = new System.Drawing.Point(202, 396);
            InjectionTimeoutBx.MaximumValue = 300000;
            InjectionTimeoutBx.MinimumValue = 5000;
            InjectionTimeoutBx.Name = "InjectionTimeoutBx";
            InjectionTimeoutBx.ReadOnly = false;
            InjectionTimeoutBx.Size = new System.Drawing.Size(175, 29);
            InjectionTimeoutBx.TabIndex = 64;
            InjectionTimeoutBx.Value = 20000;
            InjectionTimeoutBx.OnValueChanged += InjectionTimeoutBx_OnValueChanged;
            // 
            // InjectionTimeoutImg
            // 
            InjectionTimeoutImg.BackColor = System.Drawing.Color.Transparent;
            InjectionTimeoutImg.BackgroundImage = Properties.Resources.Hourglass_White;
            InjectionTimeoutImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            InjectionTimeoutImg.Location = new System.Drawing.Point(35, 395);
            InjectionTimeoutImg.Name = "InjectionTimeoutImg";
            InjectionTimeoutImg.Size = new System.Drawing.Size(30, 30);
            InjectionTimeoutImg.TabIndex = 40;
            InjectionTimeoutImg.TabStop = false;
            // 
            // InjectionTimeoutLbl
            // 
            InjectionTimeoutLbl.BackColor = System.Drawing.Color.Transparent;
            InjectionTimeoutLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            InjectionTimeoutLbl.Location = new System.Drawing.Point(71, 395);
            InjectionTimeoutLbl.Name = "InjectionTimeoutLbl";
            InjectionTimeoutLbl.Size = new System.Drawing.Size(125, 30);
            InjectionTimeoutLbl.TabIndex = 39;
            InjectionTimeoutLbl.Text = "Injection timeout: ";
            InjectionTimeoutLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OpenFolderBtn
            // 
            OpenFolderBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            OpenFolderBtn.BackColor = System.Drawing.Color.FromArgb(175, 0, 0);
            OpenFolderBtn.ButtonEnabled = true;
            OpenFolderBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            OpenFolderBtn.DisplayImage = Properties.Resources.Folder_White;
            OpenFolderBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            OpenFolderBtn.DisplayText = "Open CodeRed Folder";
            OpenFolderBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            OpenFolderBtn.Location = new System.Drawing.Point(135, 540);
            OpenFolderBtn.Name = "OpenFolderBtn";
            OpenFolderBtn.Size = new System.Drawing.Size(320, 35);
            OpenFolderBtn.TabIndex = 63;
            OpenFolderBtn.OnButtonClick += OpenFolderBtn_OnButtonClick;
            // 
            // ExportLogsBtn
            // 
            ExportLogsBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            ExportLogsBtn.BackColor = System.Drawing.Color.FromArgb(175, 0, 0);
            ExportLogsBtn.ButtonEnabled = true;
            ExportLogsBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ExportLogsBtn.DisplayImage = Properties.Resources.Archive_White;
            ExportLogsBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            ExportLogsBtn.DisplayText = "Export Crash Logs";
            ExportLogsBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
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
            InjectAllInstancesBx.Checked = true;
            InjectAllInstancesBx.DisplayImage = Properties.Resources.Inject_White;
            InjectAllInstancesBx.DisplayText = "Inject into all game instances";
            InjectAllInstancesBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InjectAllInstancesBx.Location = new System.Drawing.Point(35, 260);
            InjectAllInstancesBx.Name = "InjectAllInstancesBx";
            InjectAllInstancesBx.Size = new System.Drawing.Size(300, 30);
            InjectAllInstancesBx.TabIndex = 60;
            InjectAllInstancesBx.OnCheckChanged += InjectAllInstancesBx_OnCheckChanged;
            // 
            // HideWhenMinimizedBx
            // 
            HideWhenMinimizedBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            HideWhenMinimizedBx.BackColor = System.Drawing.Color.Transparent;
            HideWhenMinimizedBx.Checked = false;
            HideWhenMinimizedBx.DisplayImage = Properties.Resources.Hide_White;
            HideWhenMinimizedBx.DisplayText = "Hide when minimized";
            HideWhenMinimizedBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            HideWhenMinimizedBx.Location = new System.Drawing.Point(35, 215);
            HideWhenMinimizedBx.Name = "HideWhenMinimizedBx";
            HideWhenMinimizedBx.Size = new System.Drawing.Size(300, 30);
            HideWhenMinimizedBx.TabIndex = 59;
            HideWhenMinimizedBx.OnCheckChanged += HideWhenMinimizedBx_OnCheckChanged;
            // 
            // MinimizeOnStartupBx
            // 
            MinimizeOnStartupBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            MinimizeOnStartupBx.BackColor = System.Drawing.Color.Transparent;
            MinimizeOnStartupBx.Checked = false;
            MinimizeOnStartupBx.DisplayImage = Properties.Resources.Minimize_White;
            MinimizeOnStartupBx.DisplayText = "Minimize on startup";
            MinimizeOnStartupBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            MinimizeOnStartupBx.Location = new System.Drawing.Point(35, 170);
            MinimizeOnStartupBx.Name = "MinimizeOnStartupBx";
            MinimizeOnStartupBx.Size = new System.Drawing.Size(300, 30);
            MinimizeOnStartupBx.TabIndex = 58;
            MinimizeOnStartupBx.OnCheckChanged += MinimizeOnStartupBx_OnCheckChanged;
            // 
            // RunOnStartupBx
            // 
            RunOnStartupBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            RunOnStartupBx.BackColor = System.Drawing.Color.Transparent;
            RunOnStartupBx.Checked = false;
            RunOnStartupBx.DisplayImage = Properties.Resources.Windows_White;
            RunOnStartupBx.DisplayText = "Run on windows startup";
            RunOnStartupBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            RunOnStartupBx.Location = new System.Drawing.Point(35, 125);
            RunOnStartupBx.Name = "RunOnStartupBx";
            RunOnStartupBx.Size = new System.Drawing.Size(300, 30);
            RunOnStartupBx.TabIndex = 57;
            RunOnStartupBx.OnCheckChanged += RunOnStartupBx_OnCheckChanged;
            // 
            // PreventInjectionBx
            // 
            PreventInjectionBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PreventInjectionBx.BackColor = System.Drawing.Color.Transparent;
            PreventInjectionBx.Checked = true;
            PreventInjectionBx.DisplayImage = Properties.Resources.Lock_White;
            PreventInjectionBx.DisplayText = "Prevent injection when out of date";
            PreventInjectionBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            PreventInjectionBx.Location = new System.Drawing.Point(35, 80);
            PreventInjectionBx.Name = "PreventInjectionBx";
            PreventInjectionBx.Size = new System.Drawing.Size(300, 30);
            PreventInjectionBx.TabIndex = 56;
            PreventInjectionBx.OnCheckChanged += PreventInjectionBx_OnCheckChanged;
            // 
            // AutoCheckUpdatesBx
            // 
            AutoCheckUpdatesBx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AutoCheckUpdatesBx.BackColor = System.Drawing.Color.Transparent;
            AutoCheckUpdatesBx.Checked = true;
            AutoCheckUpdatesBx.DisplayImage = Properties.Resources.Download_White;
            AutoCheckUpdatesBx.DisplayText = "Automatically check for updates";
            AutoCheckUpdatesBx.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            AutoCheckUpdatesBx.Location = new System.Drawing.Point(35, 35);
            AutoCheckUpdatesBx.Name = "AutoCheckUpdatesBx";
            AutoCheckUpdatesBx.Size = new System.Drawing.Size(300, 30);
            AutoCheckUpdatesBx.TabIndex = 55;
            AutoCheckUpdatesBx.OnCheckChanged += AutoCheckUpdatesBx_OnCheckChanged;
            // 
            // ManualRadioBtn
            // 
            ManualRadioBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ManualRadioBtn.BackColor = System.Drawing.Color.Transparent;
            ManualRadioBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ManualRadioBtn.Location = new System.Drawing.Point(71, 350);
            ManualRadioBtn.Name = "ManualRadioBtn";
            ManualRadioBtn.Size = new System.Drawing.Size(250, 30);
            ManualRadioBtn.TabIndex = 51;
            ManualRadioBtn.Text = "Manual injection";
            ManualRadioBtn.UseVisualStyleBackColor = false;
            ManualRadioBtn.CheckedChanged += ManualRadioBtn_CheckedChanged;
            // 
            // TimeoutRadioBtn
            // 
            TimeoutRadioBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TimeoutRadioBtn.BackColor = System.Drawing.Color.Transparent;
            TimeoutRadioBtn.Checked = true;
            TimeoutRadioBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TimeoutRadioBtn.Location = new System.Drawing.Point(71, 305);
            TimeoutRadioBtn.Name = "TimeoutRadioBtn";
            TimeoutRadioBtn.Size = new System.Drawing.Size(250, 30);
            TimeoutRadioBtn.TabIndex = 50;
            TimeoutRadioBtn.TabStop = true;
            TimeoutRadioBtn.Text = "Timeout injection";
            TimeoutRadioBtn.UseVisualStyleBackColor = false;
            TimeoutRadioBtn.CheckedChanged += TimeoutRadioBtn_CheckedChanged;
            // 
            // ManualRadioImg
            // 
            ManualRadioImg.BackColor = System.Drawing.Color.Transparent;
            ManualRadioImg.BackgroundImage = Properties.Resources.Hand_White;
            ManualRadioImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            ManualRadioImg.Location = new System.Drawing.Point(35, 350);
            ManualRadioImg.Name = "ManualRadioImg";
            ManualRadioImg.Size = new System.Drawing.Size(30, 30);
            ManualRadioImg.TabIndex = 27;
            ManualRadioImg.TabStop = false;
            // 
            // TimeoutRadioImg
            // 
            TimeoutRadioImg.BackColor = System.Drawing.Color.Transparent;
            TimeoutRadioImg.BackgroundImage = Properties.Resources.Stopwatch_White;
            TimeoutRadioImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            TimeoutRadioImg.Location = new System.Drawing.Point(35, 305);
            TimeoutRadioImg.Name = "TimeoutRadioImg";
            TimeoutRadioImg.Size = new System.Drawing.Size(30, 30);
            TimeoutRadioImg.TabIndex = 26;
            TimeoutRadioImg.TabStop = false;
            // 
            // AlwaysRadioBtn
            // 
            AlwaysRadioBtn.BackColor = System.Drawing.Color.Transparent;
            AlwaysRadioBtn.Enabled = false;
            AlwaysRadioBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            AlwaysRadioBtn.Location = new System.Drawing.Point(71, 395);
            AlwaysRadioBtn.Name = "AlwaysRadioBtn";
            AlwaysRadioBtn.Size = new System.Drawing.Size(250, 30);
            AlwaysRadioBtn.TabIndex = 52;
            AlwaysRadioBtn.Text = "Always injected (Disabled for alpha)";
            AlwaysRadioBtn.UseVisualStyleBackColor = false;
            AlwaysRadioBtn.Visible = false;
            AlwaysRadioBtn.CheckedChanged += AlwaysRadioBtn_CheckedChanged;
            // 
            // AlwaysRadioImg
            // 
            AlwaysRadioImg.BackColor = System.Drawing.Color.Transparent;
            AlwaysRadioImg.BackgroundImage = Properties.Resources.Library_White;
            AlwaysRadioImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            AlwaysRadioImg.Location = new System.Drawing.Point(35, 395);
            AlwaysRadioImg.Name = "AlwaysRadioImg";
            AlwaysRadioImg.Size = new System.Drawing.Size(30, 30);
            AlwaysRadioImg.TabIndex = 38;
            AlwaysRadioImg.TabStop = false;
            AlwaysRadioImg.Visible = false;
            // 
            // AboutTab
            // 
            AboutTab.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            AboutTab.Controls.Add(CheckUpdatesBtn);
            AboutTab.Controls.Add(Icons8Link);
            AboutTab.Controls.Add(KofiLink);
            AboutTab.Controls.Add(DiscordLink);
            AboutTab.Controls.Add(WebsiteLink);
            AboutTab.Controls.Add(PlatformText);
            AboutTab.Controls.Add(NetBuildText);
            AboutTab.Controls.Add(PsyonixVersionText);
            AboutTab.Controls.Add(ModuleVersionText);
            AboutTab.Controls.Add(LauncherVersionText);
            AboutTab.Controls.Add(CreditsLbl);
            AboutTab.Controls.Add(Icons8Img);
            AboutTab.Controls.Add(IconsLbl);
            AboutTab.Controls.Add(KofiImg);
            AboutTab.Controls.Add(KofiLbl);
            AboutTab.Controls.Add(DiscordImg);
            AboutTab.Controls.Add(DiscordLbl);
            AboutTab.Controls.Add(WebsiteImg);
            AboutTab.Controls.Add(WebsiteLbl);
            AboutTab.Controls.Add(PlatformImg);
            AboutTab.Controls.Add(PlatformLbl);
            AboutTab.Controls.Add(NetBuildImg);
            AboutTab.Controls.Add(NetBuildLbl);
            AboutTab.Controls.Add(PsyonixVersionImg);
            AboutTab.Controls.Add(PsyonixVersionLbl);
            AboutTab.Controls.Add(ModVersionImg);
            AboutTab.Controls.Add(ModuleVersionLbl);
            AboutTab.Controls.Add(LauncherVersionImg);
            AboutTab.Controls.Add(LauncherVersionLbl);
            AboutTab.Location = new System.Drawing.Point(4, 24);
            AboutTab.Name = "AboutTab";
            AboutTab.Size = new System.Drawing.Size(910, 600);
            AboutTab.TabIndex = 5;
            AboutTab.Text = "About";
            // 
            // CheckUpdatesBtn
            // 
            CheckUpdatesBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            CheckUpdatesBtn.BackColor = System.Drawing.Color.FromArgb(175, 0, 0);
            CheckUpdatesBtn.ButtonEnabled = true;
            CheckUpdatesBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CheckUpdatesBtn.DisplayImage = Properties.Resources.Refresh_White;
            CheckUpdatesBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            CheckUpdatesBtn.DisplayText = "Check for Updates";
            CheckUpdatesBtn.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            CheckUpdatesBtn.Location = new System.Drawing.Point(235, 529);
            CheckUpdatesBtn.Name = "CheckUpdatesBtn";
            CheckUpdatesBtn.Size = new System.Drawing.Size(440, 35);
            CheckUpdatesBtn.TabIndex = 31;
            CheckUpdatesBtn.OnButtonClick += CheckUpdatesBtn_OnButtonClick;
            // 
            // Icons8Link
            // 
            Icons8Link.BackColor = System.Drawing.Color.Transparent;
            Icons8Link.Cursor = System.Windows.Forms.Cursors.Hand;
            Icons8Link.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icons8Link.ForeColor = System.Drawing.Color.Red;
            Icons8Link.Location = new System.Drawing.Point(207, 395);
            Icons8Link.Name = "Icons8Link";
            Icons8Link.Size = new System.Drawing.Size(275, 30);
            Icons8Link.TabIndex = 30;
            Icons8Link.Text = "https://icons8.com/";
            Icons8Link.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Icons8Link.Click += Icons8Link_Click;
            // 
            // KofiLink
            // 
            KofiLink.BackColor = System.Drawing.Color.Transparent;
            KofiLink.Cursor = System.Windows.Forms.Cursors.Hand;
            KofiLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            KofiLink.ForeColor = System.Drawing.Color.Red;
            KofiLink.Location = new System.Drawing.Point(207, 350);
            KofiLink.Name = "KofiLink";
            KofiLink.Size = new System.Drawing.Size(275, 30);
            KofiLink.TabIndex = 29;
            KofiLink.Text = "https://ko-fi.com/coderedmodding/";
            KofiLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            KofiLink.Click += KofiLink_Click;
            // 
            // DiscordLink
            // 
            DiscordLink.BackColor = System.Drawing.Color.Transparent;
            DiscordLink.Cursor = System.Windows.Forms.Cursors.Hand;
            DiscordLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DiscordLink.ForeColor = System.Drawing.Color.Red;
            DiscordLink.Location = new System.Drawing.Point(207, 305);
            DiscordLink.Name = "DiscordLink";
            DiscordLink.Size = new System.Drawing.Size(275, 30);
            DiscordLink.TabIndex = 28;
            DiscordLink.Text = "Loading...";
            DiscordLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            DiscordLink.Click += DiscordLink_Click;
            // 
            // WebsiteLink
            // 
            WebsiteLink.BackColor = System.Drawing.Color.Transparent;
            WebsiteLink.Cursor = System.Windows.Forms.Cursors.Hand;
            WebsiteLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            WebsiteLink.ForeColor = System.Drawing.Color.Red;
            WebsiteLink.Location = new System.Drawing.Point(207, 260);
            WebsiteLink.Name = "WebsiteLink";
            WebsiteLink.Size = new System.Drawing.Size(275, 30);
            WebsiteLink.TabIndex = 27;
            WebsiteLink.Text = "https://coderedmodding.github.io/";
            WebsiteLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            WebsiteLink.Click += WebsiteLink_Click;
            // 
            // PlatformText
            // 
            PlatformText.BackColor = System.Drawing.Color.Transparent;
            PlatformText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PlatformText.Location = new System.Drawing.Point(207, 215);
            PlatformText.Name = "PlatformText";
            PlatformText.Size = new System.Drawing.Size(275, 30);
            PlatformText.TabIndex = 26;
            PlatformText.Text = "Loading...";
            PlatformText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NetBuildText
            // 
            NetBuildText.BackColor = System.Drawing.Color.Transparent;
            NetBuildText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            NetBuildText.Location = new System.Drawing.Point(207, 170);
            NetBuildText.Name = "NetBuildText";
            NetBuildText.Size = new System.Drawing.Size(275, 30);
            NetBuildText.TabIndex = 25;
            NetBuildText.Text = "Loading...";
            NetBuildText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PsyonixVersionText
            // 
            PsyonixVersionText.BackColor = System.Drawing.Color.Transparent;
            PsyonixVersionText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PsyonixVersionText.Location = new System.Drawing.Point(207, 125);
            PsyonixVersionText.Name = "PsyonixVersionText";
            PsyonixVersionText.Size = new System.Drawing.Size(275, 30);
            PsyonixVersionText.TabIndex = 24;
            PsyonixVersionText.Text = "Loading...";
            PsyonixVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModuleVersionText
            // 
            ModuleVersionText.BackColor = System.Drawing.Color.Transparent;
            ModuleVersionText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ModuleVersionText.Location = new System.Drawing.Point(207, 80);
            ModuleVersionText.Name = "ModuleVersionText";
            ModuleVersionText.Size = new System.Drawing.Size(275, 30);
            ModuleVersionText.TabIndex = 23;
            ModuleVersionText.Text = "Loading...";
            ModuleVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LauncherVersionText
            // 
            LauncherVersionText.BackColor = System.Drawing.Color.Transparent;
            LauncherVersionText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LauncherVersionText.Location = new System.Drawing.Point(207, 35);
            LauncherVersionText.Name = "LauncherVersionText";
            LauncherVersionText.Size = new System.Drawing.Size(275, 30);
            LauncherVersionText.TabIndex = 22;
            LauncherVersionText.Text = "Loading...";
            LauncherVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreditsLbl
            // 
            CreditsLbl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CreditsLbl.BackColor = System.Drawing.Color.Transparent;
            CreditsLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CreditsLbl.ForeColor = System.Drawing.Color.FromArgb(165, 165, 165);
            CreditsLbl.Location = new System.Drawing.Point(35, 440);
            CreditsLbl.Name = "CreditsLbl";
            CreditsLbl.Size = new System.Drawing.Size(840, 64);
            CreditsLbl.TabIndex = 21;
            CreditsLbl.Text = resources.GetString("CreditsLbl.Text");
            CreditsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Icons8Img
            // 
            Icons8Img.BackColor = System.Drawing.Color.Transparent;
            Icons8Img.BackgroundImage = Properties.Resources.Icons8_White;
            Icons8Img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            Icons8Img.Location = new System.Drawing.Point(35, 395);
            Icons8Img.Name = "Icons8Img";
            Icons8Img.Size = new System.Drawing.Size(30, 30);
            Icons8Img.TabIndex = 19;
            Icons8Img.TabStop = false;
            // 
            // IconsLbl
            // 
            IconsLbl.BackColor = System.Drawing.Color.Transparent;
            IconsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            IconsLbl.Location = new System.Drawing.Point(71, 395);
            IconsLbl.Name = "IconsLbl";
            IconsLbl.Size = new System.Drawing.Size(130, 30);
            IconsLbl.TabIndex = 18;
            IconsLbl.Text = "Icons provided by:";
            IconsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KofiImg
            // 
            KofiImg.BackColor = System.Drawing.Color.Transparent;
            KofiImg.BackgroundImage = Properties.Resources.Coffee_White;
            KofiImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            KofiImg.Location = new System.Drawing.Point(35, 350);
            KofiImg.Name = "KofiImg";
            KofiImg.Size = new System.Drawing.Size(30, 30);
            KofiImg.TabIndex = 17;
            KofiImg.TabStop = false;
            // 
            // KofiLbl
            // 
            KofiLbl.BackColor = System.Drawing.Color.Transparent;
            KofiLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            KofiLbl.Location = new System.Drawing.Point(71, 350);
            KofiLbl.Name = "KofiLbl";
            KofiLbl.Size = new System.Drawing.Size(130, 30);
            KofiLbl.TabIndex = 16;
            KofiLbl.Text = "Ko-fi:";
            KofiLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DiscordImg
            // 
            DiscordImg.BackColor = System.Drawing.Color.Transparent;
            DiscordImg.BackgroundImage = Properties.Resources.Discord_White;
            DiscordImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            DiscordImg.Location = new System.Drawing.Point(35, 305);
            DiscordImg.Name = "DiscordImg";
            DiscordImg.Size = new System.Drawing.Size(30, 30);
            DiscordImg.TabIndex = 15;
            DiscordImg.TabStop = false;
            // 
            // DiscordLbl
            // 
            DiscordLbl.BackColor = System.Drawing.Color.Transparent;
            DiscordLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            DiscordLbl.Location = new System.Drawing.Point(71, 305);
            DiscordLbl.Name = "DiscordLbl";
            DiscordLbl.Size = new System.Drawing.Size(130, 30);
            DiscordLbl.TabIndex = 14;
            DiscordLbl.Text = "Discord:";
            DiscordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WebsiteImg
            // 
            WebsiteImg.BackColor = System.Drawing.Color.Transparent;
            WebsiteImg.BackgroundImage = Properties.Resources.Box_White;
            WebsiteImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            WebsiteImg.Location = new System.Drawing.Point(35, 260);
            WebsiteImg.Name = "WebsiteImg";
            WebsiteImg.Size = new System.Drawing.Size(30, 30);
            WebsiteImg.TabIndex = 13;
            WebsiteImg.TabStop = false;
            // 
            // WebsiteLbl
            // 
            WebsiteLbl.BackColor = System.Drawing.Color.Transparent;
            WebsiteLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            WebsiteLbl.Location = new System.Drawing.Point(71, 260);
            WebsiteLbl.Name = "WebsiteLbl";
            WebsiteLbl.Size = new System.Drawing.Size(130, 30);
            WebsiteLbl.TabIndex = 12;
            WebsiteLbl.Text = "Website:";
            WebsiteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlatformImg
            // 
            PlatformImg.BackColor = System.Drawing.Color.Transparent;
            PlatformImg.BackgroundImage = Properties.Resources.Question_White;
            PlatformImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            PlatformImg.Location = new System.Drawing.Point(35, 215);
            PlatformImg.Name = "PlatformImg";
            PlatformImg.Size = new System.Drawing.Size(30, 30);
            PlatformImg.TabIndex = 11;
            PlatformImg.TabStop = false;
            // 
            // PlatformLbl
            // 
            PlatformLbl.BackColor = System.Drawing.Color.Transparent;
            PlatformLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            PlatformLbl.Location = new System.Drawing.Point(71, 215);
            PlatformLbl.Name = "PlatformLbl";
            PlatformLbl.Size = new System.Drawing.Size(130, 30);
            PlatformLbl.TabIndex = 10;
            PlatformLbl.Text = "Active Platform:";
            PlatformLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NetBuildImg
            // 
            NetBuildImg.BackColor = System.Drawing.Color.Transparent;
            NetBuildImg.BackgroundImage = Properties.Resources.Circuit_White;
            NetBuildImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            NetBuildImg.Location = new System.Drawing.Point(35, 170);
            NetBuildImg.Name = "NetBuildImg";
            NetBuildImg.Size = new System.Drawing.Size(30, 30);
            NetBuildImg.TabIndex = 9;
            NetBuildImg.TabStop = false;
            // 
            // NetBuildLbl
            // 
            NetBuildLbl.BackColor = System.Drawing.Color.Transparent;
            NetBuildLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            NetBuildLbl.Location = new System.Drawing.Point(71, 170);
            NetBuildLbl.Name = "NetBuildLbl";
            NetBuildLbl.Size = new System.Drawing.Size(130, 30);
            NetBuildLbl.TabIndex = 8;
            NetBuildLbl.Text = "Net Build:";
            NetBuildLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PsyonixVersionImg
            // 
            PsyonixVersionImg.BackColor = System.Drawing.Color.Transparent;
            PsyonixVersionImg.BackgroundImage = Properties.Resources.Server_White;
            PsyonixVersionImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            PsyonixVersionImg.Location = new System.Drawing.Point(35, 125);
            PsyonixVersionImg.Name = "PsyonixVersionImg";
            PsyonixVersionImg.Size = new System.Drawing.Size(30, 30);
            PsyonixVersionImg.TabIndex = 7;
            PsyonixVersionImg.TabStop = false;
            // 
            // PsyonixVersionLbl
            // 
            PsyonixVersionLbl.BackColor = System.Drawing.Color.Transparent;
            PsyonixVersionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            PsyonixVersionLbl.Location = new System.Drawing.Point(71, 125);
            PsyonixVersionLbl.Name = "PsyonixVersionLbl";
            PsyonixVersionLbl.Size = new System.Drawing.Size(130, 30);
            PsyonixVersionLbl.TabIndex = 6;
            PsyonixVersionLbl.Text = "Psyonix Version:";
            PsyonixVersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModVersionImg
            // 
            ModVersionImg.BackColor = System.Drawing.Color.Transparent;
            ModVersionImg.BackgroundImage = Properties.Resources.Chip_White;
            ModVersionImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            ModVersionImg.Location = new System.Drawing.Point(35, 80);
            ModVersionImg.Name = "ModVersionImg";
            ModVersionImg.Size = new System.Drawing.Size(30, 30);
            ModVersionImg.TabIndex = 5;
            ModVersionImg.TabStop = false;
            // 
            // ModuleVersionLbl
            // 
            ModuleVersionLbl.BackColor = System.Drawing.Color.Transparent;
            ModuleVersionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ModuleVersionLbl.Location = new System.Drawing.Point(71, 80);
            ModuleVersionLbl.Name = "ModuleVersionLbl";
            ModuleVersionLbl.Size = new System.Drawing.Size(130, 30);
            ModuleVersionLbl.TabIndex = 4;
            ModuleVersionLbl.Text = "Module Version:";
            ModuleVersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LauncherVersionImg
            // 
            LauncherVersionImg.BackColor = System.Drawing.Color.Transparent;
            LauncherVersionImg.BackgroundImage = Properties.Resources.Software_White;
            LauncherVersionImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            LauncherVersionImg.Location = new System.Drawing.Point(35, 35);
            LauncherVersionImg.Name = "LauncherVersionImg";
            LauncherVersionImg.Size = new System.Drawing.Size(30, 30);
            LauncherVersionImg.TabIndex = 3;
            LauncherVersionImg.TabStop = false;
            // 
            // LauncherVersionLbl
            // 
            LauncherVersionLbl.BackColor = System.Drawing.Color.Transparent;
            LauncherVersionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LauncherVersionLbl.Location = new System.Drawing.Point(71, 35);
            LauncherVersionLbl.Name = "LauncherVersionLbl";
            LauncherVersionLbl.Size = new System.Drawing.Size(130, 30);
            LauncherVersionLbl.TabIndex = 2;
            LauncherVersionLbl.Text = "Launcher Version:";
            LauncherVersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackgroundPnl
            // 
            BackgroundPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            BackgroundPnl.Controls.Add(TabPnl);
            BackgroundPnl.Controls.Add(TitleBar);
            BackgroundPnl.Controls.Add(TabCtrl);
            BackgroundPnl.Controls.Add(InstallOfflinePopupCtrl);
            BackgroundPnl.Controls.Add(OfflinePopupCtrl);
            BackgroundPnl.Controls.Add(UpdatePopupCtrl);
            BackgroundPnl.Controls.Add(InstallPopupCtrl);
            BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            BackgroundPnl.Name = "BackgroundPnl";
            BackgroundPnl.Size = new System.Drawing.Size(970, 630);
            BackgroundPnl.TabIndex = 4;
            // 
            // TabPnl
            // 
            TabPnl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            TabPnl.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            TabPnl.Controls.Add(AboutTabBtn);
            TabPnl.Controls.Add(SettingsTabBtn);
            TabPnl.Controls.Add(ExitTabBtn);
            TabPnl.Controls.Add(ScriptsTabBtn);
            TabPnl.Controls.Add(TexturesTabBtn);
            TabPnl.Controls.Add(SessionsTabBtn);
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
            AboutTabBtn.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            AboutTabBtn.ImageSelected = Properties.Resources.About_Red;
            AboutTabBtn.ImageUnselected = Properties.Resources.About_White;
            AboutTabBtn.Location = new System.Drawing.Point(0, 500);
            AboutTabBtn.Name = "AboutTabBtn";
            AboutTabBtn.Selected = false;
            AboutTabBtn.SelectedColor = System.Drawing.Color.Red;
            AboutTabBtn.Size = new System.Drawing.Size(60, 50);
            AboutTabBtn.TabIndex = 7;
            AboutTabBtn.OnTabClick += AboutTabBtn_OnTabClick;
            // 
            // SettingsTabBtn
            // 
            SettingsTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SettingsTabBtn.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            SettingsTabBtn.ImageSelected = Properties.Resources.Settings_Red;
            SettingsTabBtn.ImageUnselected = Properties.Resources.Settings_White;
            SettingsTabBtn.Location = new System.Drawing.Point(0, 450);
            SettingsTabBtn.Name = "SettingsTabBtn";
            SettingsTabBtn.Selected = false;
            SettingsTabBtn.SelectedColor = System.Drawing.Color.Red;
            SettingsTabBtn.Size = new System.Drawing.Size(60, 50);
            SettingsTabBtn.TabIndex = 6;
            SettingsTabBtn.OnTabClick += SettingsTabBtn_OnTabClick;
            // 
            // ExitTabBtn
            // 
            ExitTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ExitTabBtn.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ExitTabBtn.ImageSelected = Properties.Resources.Exit_Red;
            ExitTabBtn.ImageUnselected = Properties.Resources.Exit_White;
            ExitTabBtn.Location = new System.Drawing.Point(0, 550);
            ExitTabBtn.Name = "ExitTabBtn";
            ExitTabBtn.Selected = false;
            ExitTabBtn.SelectedColor = System.Drawing.Color.Red;
            ExitTabBtn.Size = new System.Drawing.Size(60, 50);
            ExitTabBtn.TabIndex = 5;
            ExitTabBtn.OnTabClick += ExitTabBtn_OnTabClick;
            // 
            // ScriptsTabBtn
            // 
            ScriptsTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ScriptsTabBtn.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ScriptsTabBtn.ImageSelected = Properties.Resources.Paper_Red;
            ScriptsTabBtn.ImageUnselected = Properties.Resources.Paper_White;
            ScriptsTabBtn.Location = new System.Drawing.Point(0, 200);
            ScriptsTabBtn.Name = "ScriptsTabBtn";
            ScriptsTabBtn.Selected = false;
            ScriptsTabBtn.SelectedColor = System.Drawing.Color.Red;
            ScriptsTabBtn.Size = new System.Drawing.Size(60, 50);
            ScriptsTabBtn.TabIndex = 4;
            ScriptsTabBtn.Visible = false;
            ScriptsTabBtn.OnTabClick += ScriptsTabBtn_OnTabClick;
            // 
            // TexturesTabBtn
            // 
            TexturesTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TexturesTabBtn.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            TexturesTabBtn.ImageSelected = Properties.Resources.Texture_Red;
            TexturesTabBtn.ImageUnselected = Properties.Resources.Texture_White;
            TexturesTabBtn.Location = new System.Drawing.Point(0, 150);
            TexturesTabBtn.Name = "TexturesTabBtn";
            TexturesTabBtn.Selected = false;
            TexturesTabBtn.SelectedColor = System.Drawing.Color.Red;
            TexturesTabBtn.Size = new System.Drawing.Size(60, 50);
            TexturesTabBtn.TabIndex = 3;
            TexturesTabBtn.Visible = false;
            TexturesTabBtn.OnTabClick += TexturesTabBtn_OnTabClick;
            // 
            // SessionsTabBtn
            // 
            SessionsTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SessionsTabBtn.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            SessionsTabBtn.ImageSelected = Properties.Resources.Chart_Red;
            SessionsTabBtn.ImageUnselected = Properties.Resources.Chart_White;
            SessionsTabBtn.Location = new System.Drawing.Point(0, 100);
            SessionsTabBtn.Name = "SessionsTabBtn";
            SessionsTabBtn.Selected = false;
            SessionsTabBtn.SelectedColor = System.Drawing.Color.Red;
            SessionsTabBtn.Size = new System.Drawing.Size(60, 50);
            SessionsTabBtn.TabIndex = 2;
            SessionsTabBtn.Visible = false;
            SessionsTabBtn.OnTabClick += SessionsTabBtn_OnTabClick;
            // 
            // NewsTabBtn
            // 
            NewsTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            NewsTabBtn.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            NewsTabBtn.ImageSelected = Properties.Resources.Newspaper_Red;
            NewsTabBtn.ImageUnselected = Properties.Resources.Newspaper_White;
            NewsTabBtn.Location = new System.Drawing.Point(0, 50);
            NewsTabBtn.Name = "NewsTabBtn";
            NewsTabBtn.Selected = false;
            NewsTabBtn.SelectedColor = System.Drawing.Color.Red;
            NewsTabBtn.Size = new System.Drawing.Size(60, 50);
            NewsTabBtn.TabIndex = 1;
            NewsTabBtn.OnTabClick += NewsTabBtn_OnTabClick;
            // 
            // DashboardTabBtn
            // 
            DashboardTabBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DashboardTabBtn.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            DashboardTabBtn.ImageSelected = Properties.Resources.Dashboard_Red;
            DashboardTabBtn.ImageUnselected = Properties.Resources.Dashboard_White;
            DashboardTabBtn.Location = new System.Drawing.Point(0, 0);
            DashboardTabBtn.Name = "DashboardTabBtn";
            DashboardTabBtn.Selected = true;
            DashboardTabBtn.SelectedColor = System.Drawing.Color.Red;
            DashboardTabBtn.Size = new System.Drawing.Size(60, 50);
            DashboardTabBtn.TabIndex = 0;
            DashboardTabBtn.OnTabClick += DashboardTabBtn_OnTabClick;
            // 
            // TitleBar
            // 
            TitleBar.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            TitleBar.BoundForm = null;
            TitleBar.DisplayText = "CODERED LAUNCHER";
            TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            TitleBar.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            TitleBar.Location = new System.Drawing.Point(0, 0);
            TitleBar.Name = "TitleBar";
            TitleBar.Size = new System.Drawing.Size(970, 30);
            TitleBar.TabIndex = 2;
            TitleBar.OnMinimized += TitleBar_OnMinimized;
            TitleBar.OnExit += TitleBar_OnExit;
            // 
            // InstallOfflinePopupCtrl
            // 
            InstallOfflinePopupCtrl.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            InstallOfflinePopupCtrl.BoundForm = null;
            InstallOfflinePopupCtrl.ButtonLayout = CodeRedLauncher.Controls.CRPopup.ButtonLayouts.TYPE_SINGLE;
            InstallOfflinePopupCtrl.ButtonsEnabled = true;
            InstallOfflinePopupCtrl.DisplayDescription = "Failed to connect to the remote server, an active internet connection is required to install CodeRed! Please connect to the internet and try again";
            InstallOfflinePopupCtrl.DisplayTitle = "NO CONNECTION";
            InstallOfflinePopupCtrl.DoubleFirstImage = null;
            InstallOfflinePopupCtrl.DoubleFirstText = "First Option";
            InstallOfflinePopupCtrl.DoubleSecondImage = null;
            InstallOfflinePopupCtrl.DoubleSecondText = "Second Option";
            InstallOfflinePopupCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InstallOfflinePopupCtrl.Location = new System.Drawing.Point(0, 0);
            InstallOfflinePopupCtrl.Name = "InstallOfflinePopupCtrl";
            InstallOfflinePopupCtrl.SingleButtonImage = null;
            InstallOfflinePopupCtrl.SingleButtonText = "Ok fine, I'll go do that";
            InstallOfflinePopupCtrl.Size = new System.Drawing.Size(970, 630);
            InstallOfflinePopupCtrl.TabIndex = 38;
            InstallOfflinePopupCtrl.Visible = false;
            InstallOfflinePopupCtrl.SingleButtonClick += InstallOfflinePopupCtrl_SingleButtonClick;
            // 
            // OfflinePopupCtrl
            // 
            OfflinePopupCtrl.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            OfflinePopupCtrl.BoundForm = null;
            OfflinePopupCtrl.ButtonLayout = CodeRedLauncher.Controls.CRPopup.ButtonLayouts.TYPE_DOUBLE;
            OfflinePopupCtrl.ButtonsEnabled = true;
            OfflinePopupCtrl.DisplayDescription = "Failed to connect to the remote server, would you like to start in offline mode? Version checking, news, changelog, and remote information will all be disabled.";
            OfflinePopupCtrl.DisplayTitle = "NO CONNECTION";
            OfflinePopupCtrl.DoubleFirstImage = null;
            OfflinePopupCtrl.DoubleFirstText = "No thanks, let's try again";
            OfflinePopupCtrl.DoubleSecondImage = null;
            OfflinePopupCtrl.DoubleSecondText = "Sure, sounds good to me";
            OfflinePopupCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            OfflinePopupCtrl.Location = new System.Drawing.Point(0, 0);
            OfflinePopupCtrl.Name = "OfflinePopupCtrl";
            OfflinePopupCtrl.SingleButtonImage = null;
            OfflinePopupCtrl.SingleButtonText = "Single Option";
            OfflinePopupCtrl.Size = new System.Drawing.Size(970, 630);
            OfflinePopupCtrl.TabIndex = 36;
            OfflinePopupCtrl.Visible = false;
            OfflinePopupCtrl.DoubleFirstButtonClick += OfflinePopupCtrl_DoubleFirstButtonClick;
            OfflinePopupCtrl.DoubleSecondButtonClick += OfflinePopupCtrl_DoubleSecondButtonClick;
            // 
            // UpdatePopupCtrl
            // 
            UpdatePopupCtrl.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            UpdatePopupCtrl.BoundForm = null;
            UpdatePopupCtrl.ButtonLayout = CodeRedLauncher.Controls.CRPopup.ButtonLayouts.TYPE_DOUBLE;
            UpdatePopupCtrl.ButtonsEnabled = true;
            UpdatePopupCtrl.DisplayDescription = "A new version was found, would you like to automatically install it now?";
            UpdatePopupCtrl.DisplayTitle = "UPDATE AVAILABLE";
            UpdatePopupCtrl.DoubleFirstImage = null;
            UpdatePopupCtrl.DoubleFirstText = "No thanks, I'll update later";
            UpdatePopupCtrl.DoubleSecondImage = null;
            UpdatePopupCtrl.DoubleSecondText = "Yes please, show me what you got";
            UpdatePopupCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            UpdatePopupCtrl.Location = new System.Drawing.Point(0, 0);
            UpdatePopupCtrl.Name = "UpdatePopupCtrl";
            UpdatePopupCtrl.SingleButtonImage = null;
            UpdatePopupCtrl.SingleButtonText = "Ok fine, I'll close the game";
            UpdatePopupCtrl.Size = new System.Drawing.Size(970, 630);
            UpdatePopupCtrl.TabIndex = 35;
            UpdatePopupCtrl.Visible = false;
            UpdatePopupCtrl.SingleButtonClick += UpdatePopupCtrl_SingleButtonClick;
            UpdatePopupCtrl.DoubleFirstButtonClick += UpdatePopupCtrl_DoubleFirstButtonClick;
            UpdatePopupCtrl.DoubleSecondButtonClick += UpdatePopupCtrl_DoubleSecondButtonClick;
            // 
            // InstallPopupCtrl
            // 
            InstallPopupCtrl.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            InstallPopupCtrl.BoundForm = null;
            InstallPopupCtrl.ButtonLayout = CodeRedLauncher.Controls.CRPopup.ButtonLayouts.TYPE_DOUBLE;
            InstallPopupCtrl.ButtonsEnabled = true;
            InstallPopupCtrl.DisplayDescription = "It looks like this if your first time using CodeRed, we need to download and setup a few things first before we can get started. First, would you like to customize your install path?";
            InstallPopupCtrl.DisplayTitle = "WELCOME TO CODERED";
            InstallPopupCtrl.DoubleFirstImage = null;
            InstallPopupCtrl.DoubleFirstText = "Sure, let me pick a folder";
            InstallPopupCtrl.DoubleSecondImage = null;
            InstallPopupCtrl.DoubleSecondText = "Nah, do everything for me";
            InstallPopupCtrl.ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            InstallPopupCtrl.Location = new System.Drawing.Point(0, 0);
            InstallPopupCtrl.Name = "InstallPopupCtrl";
            InstallPopupCtrl.SingleButtonImage = null;
            InstallPopupCtrl.SingleButtonText = "Single Option";
            InstallPopupCtrl.Size = new System.Drawing.Size(970, 630);
            InstallPopupCtrl.TabIndex = 37;
            InstallPopupCtrl.Visible = false;
            InstallPopupCtrl.DoubleFirstButtonClick += InstallPopupCtrl_DoubleFirstButtonClick;
            InstallPopupCtrl.DoubleSecondButtonClick += InstallPopupCtrl_DoubleSecondButtonClick;
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
            BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            ClientSize = new System.Drawing.Size(972, 632);
            Controls.Add(BackgroundPnl);
            DoubleBuffered = true;
            ForeColor = System.Drawing.Color.FromArgb(235, 235, 235);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainFrm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += MainFrm_Load;
            Resize += MainFrm_Resize;
            TabCtrl.ResumeLayout(false);
            DashboardTab.ResumeLayout(false);
            NewsTab.ResumeLayout(false);
            SessionsTab.ResumeLayout(false);
            TexturesTab.ResumeLayout(false);
            ScriptsTab.ResumeLayout(false);
            SettingsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)InstallPathImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)InjectionTimeoutImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)ManualRadioImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)TimeoutRadioImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlwaysRadioImg).EndInit();
            AboutTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Icons8Img).EndInit();
            ((System.ComponentModel.ISupportInitialize)KofiImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)DiscordImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)WebsiteImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlatformImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)NetBuildImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)PsyonixVersionImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)ModVersionImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)LauncherVersionImg).EndInit();
            BackgroundPnl.ResumeLayout(false);
            TabPnl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl TabCtrl;
        private System.Windows.Forms.TabPage NewsTab;
        private System.Windows.Forms.TabPage SessionsTab;
        private System.Windows.Forms.TabPage ScriptsTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.TabPage AboutTab;
        private System.Windows.Forms.Panel BackgroundPnl;
        private System.Windows.Forms.PictureBox LauncherVersionImg;
        private System.Windows.Forms.Label LauncherVersionLbl;
        private System.Windows.Forms.PictureBox ModVersionImg;
        private System.Windows.Forms.Label ModuleVersionLbl;
        private System.Windows.Forms.PictureBox KofiImg;
        private System.Windows.Forms.Label KofiLbl;
        private System.Windows.Forms.PictureBox DiscordImg;
        private System.Windows.Forms.Label DiscordLbl;
        private System.Windows.Forms.PictureBox WebsiteImg;
        private System.Windows.Forms.Label WebsiteLbl;
        private System.Windows.Forms.PictureBox PlatformImg;
        private System.Windows.Forms.Label PlatformLbl;
        private System.Windows.Forms.PictureBox NetBuildImg;
        private System.Windows.Forms.Label NetBuildLbl;
        private System.Windows.Forms.PictureBox PsyonixVersionImg;
        private System.Windows.Forms.Label PsyonixVersionLbl;
        private System.Windows.Forms.PictureBox Icons8Img;
        private System.Windows.Forms.Label IconsLbl;
        private System.Windows.Forms.Label CreditsLbl;
        private System.Windows.Forms.Label Icons8Link;
        private System.Windows.Forms.Label KofiLink;
        private System.Windows.Forms.Label DiscordLink;
        private System.Windows.Forms.Label WebsiteLink;
        private System.Windows.Forms.Label PlatformText;
        private System.Windows.Forms.Label NetBuildText;
        private System.Windows.Forms.Label PsyonixVersionText;
        private System.Windows.Forms.Label ModuleVersionText;
        private System.Windows.Forms.Label LauncherVersionText;
        private System.Windows.Forms.PictureBox ManualRadioImg;
        private System.Windows.Forms.PictureBox TimeoutRadioImg;
        private System.Windows.Forms.PictureBox AlwaysRadioImg;
        private System.Windows.Forms.PictureBox InjectionTimeoutImg;
        private System.Windows.Forms.Label InjectionTimeoutLbl;
        private System.Windows.Forms.TabPage DashboardTab;
        private System.Windows.Forms.TabPage TexturesTab;
        private System.Windows.Forms.Timer ProcessTmr;
        private System.Windows.Forms.RadioButton AlwaysRadioBtn;
        private System.Windows.Forms.RadioButton ManualRadioBtn;
        private System.Windows.Forms.RadioButton TimeoutRadioBtn;
        private System.Windows.Forms.Timer InjectTmr;
        private Controls.CRProcessPanel ProcessCtrl;
        private Controls.CRUpdatePanel UpdateCtrl;
        private Controls.CRTitleBar TitleBar;
        private System.Windows.Forms.Panel TabPnl;
        private Controls.CRButton CheckUpdatesBtn;
        private Controls.CRCheckbox AutoCheckUpdatesBx;
        private Controls.CRCheckbox PreventInjectionBx;
        private Controls.CRCheckbox RunOnStartupBx;
        private Controls.CRCheckbox MinimizeOnStartupBx;
        private Controls.CRCheckbox HideWhenMinimizedBx;
        private Controls.CRCheckbox InjectAllInstancesBx;
        private Controls.CRTab DashboardTabBtn;
        private Controls.CRTab NewsTabBtn;
        private Controls.CRTab SessionsTabBtn;
        private Controls.CRTab TexturesTabBtn;
        private Controls.CRTab ScriptsTabBtn;
        private Controls.CRTab ExitTabBtn;
        private Controls.CRTab AboutTabBtn;
        private Controls.CRTab SettingsTabBtn;
        private Controls.CRButton LaunchBtn;
        private Controls.CRChangelog ChangelogCtrl;
        private System.Windows.Forms.Label PlaceholderLblSecond;
        private System.Windows.Forms.Label PlaceholderLblThird;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private Controls.CRButton ManualInjectBtn;
        private Controls.CRNewsPanel NewsCtrl;
        private Controls.CRButton OpenFolderBtn;
        private Controls.CRButton ExportLogsBtn;
        private Controls.CRNumberbox InjectionTimeoutBx;
        private Controls.CRButton ReloadSessionsBtn;
        private Controls.CRPopup UpdatePopupCtrl;
        private Controls.CRPopup OfflinePopupCtrl;
        private Controls.CRPopup InstallPopupCtrl;
        private Controls.CRPopup InstallOfflinePopupCtrl;
        private System.Windows.Forms.Timer UpdateTmr;
        private System.Windows.Forms.Label TotalSessionsLbl;
        private System.Windows.Forms.PictureBox InstallPathImg;
        private System.Windows.Forms.Label InstallPathLbl;
        private Controls.CRTextbox InstallPathBx;
        private Controls.CRButton InstallPathBtn;
    }
}

