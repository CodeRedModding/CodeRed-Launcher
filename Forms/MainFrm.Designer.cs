
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.TabCtrl = new System.Windows.Forms.TabControl();
            this.DashboardTab = new System.Windows.Forms.TabPage();
            this.LaunchBtn = new CodeRedLauncher.Controls.CRButton();
            this.ChangelogCtrl = new CodeRedLauncher.Controls.CRChangelog();
            this.UpdateCtrl = new CodeRedLauncher.Controls.CRUpdatePanel();
            this.ProcessCtrl = new CodeRedLauncher.Controls.CRProcessPanel();
            this.ManualInjectBtn = new CodeRedLauncher.Controls.CRButton();
            this.NewsTab = new System.Windows.Forms.TabPage();
            this.NewsCtrl = new CodeRedLauncher.Controls.CRNewsPanel();
            this.SessionsTab = new System.Windows.Forms.TabPage();
            this.TotalSessionsLbl = new System.Windows.Forms.Label();
            this.ReloadSessionsBtn = new CodeRedLauncher.Controls.CRButton();
            this.TexturesTab = new System.Windows.Forms.TabPage();
            this.PlaceholderLblSecond = new System.Windows.Forms.Label();
            this.ScriptsTab = new System.Windows.Forms.TabPage();
            this.PlaceholderLblThird = new System.Windows.Forms.Label();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.InstallPathBtn = new CodeRedLauncher.Controls.CRButton();
            this.InstallPathBx = new CodeRedLauncher.Controls.CRTextbox();
            this.InstallPathImg = new System.Windows.Forms.PictureBox();
            this.InstallPathLbl = new System.Windows.Forms.Label();
            this.InjectionTimeoutBx = new CodeRedLauncher.Controls.CRNumberbox();
            this.InjectionTimeoutImg = new System.Windows.Forms.PictureBox();
            this.InjectionTimeoutLbl = new System.Windows.Forms.Label();
            this.OpenFolderBtn = new CodeRedLauncher.Controls.CRButton();
            this.ExportLogsBtn = new CodeRedLauncher.Controls.CRButton();
            this.InjectAllInstancesBx = new CodeRedLauncher.Controls.CRCheckbox();
            this.HideWhenMinimizedBx = new CodeRedLauncher.Controls.CRCheckbox();
            this.MinimizeOnStartupBx = new CodeRedLauncher.Controls.CRCheckbox();
            this.RunOnStartupBx = new CodeRedLauncher.Controls.CRCheckbox();
            this.PreventInjectionBx = new CodeRedLauncher.Controls.CRCheckbox();
            this.AutoCheckUpdatesBx = new CodeRedLauncher.Controls.CRCheckbox();
            this.ManualRadioBtn = new System.Windows.Forms.RadioButton();
            this.TimeoutRadioBtn = new System.Windows.Forms.RadioButton();
            this.ManualRadioImg = new System.Windows.Forms.PictureBox();
            this.TimeoutRadioImg = new System.Windows.Forms.PictureBox();
            this.AlwaysRadioBtn = new System.Windows.Forms.RadioButton();
            this.AlwaysRadioImg = new System.Windows.Forms.PictureBox();
            this.AboutTab = new System.Windows.Forms.TabPage();
            this.CheckUpdatesBtn = new CodeRedLauncher.Controls.CRButton();
            this.Icons8Link = new System.Windows.Forms.Label();
            this.KofiLink = new System.Windows.Forms.Label();
            this.DiscordLink = new System.Windows.Forms.Label();
            this.WebsiteLink = new System.Windows.Forms.Label();
            this.PlatformText = new System.Windows.Forms.Label();
            this.NetBuildText = new System.Windows.Forms.Label();
            this.PsyonixVersionText = new System.Windows.Forms.Label();
            this.ModuleVersionText = new System.Windows.Forms.Label();
            this.LauncherVersionText = new System.Windows.Forms.Label();
            this.CreditsLbl = new System.Windows.Forms.Label();
            this.Icons8Img = new System.Windows.Forms.PictureBox();
            this.IconsLbl = new System.Windows.Forms.Label();
            this.KofiImg = new System.Windows.Forms.PictureBox();
            this.KofiLbl = new System.Windows.Forms.Label();
            this.DiscordImg = new System.Windows.Forms.PictureBox();
            this.DiscordLbl = new System.Windows.Forms.Label();
            this.WebsiteImg = new System.Windows.Forms.PictureBox();
            this.WebsiteLbl = new System.Windows.Forms.Label();
            this.PlatformImg = new System.Windows.Forms.PictureBox();
            this.PlatformLbl = new System.Windows.Forms.Label();
            this.NetBuildImg = new System.Windows.Forms.PictureBox();
            this.NetBuildLbl = new System.Windows.Forms.Label();
            this.PsyonixVersionImg = new System.Windows.Forms.PictureBox();
            this.PsyonixVersionLbl = new System.Windows.Forms.Label();
            this.ModVersionImg = new System.Windows.Forms.PictureBox();
            this.ModuleVersionLbl = new System.Windows.Forms.Label();
            this.LauncherVersionImg = new System.Windows.Forms.PictureBox();
            this.LauncherVersionLbl = new System.Windows.Forms.Label();
            this.BackgroundPnl = new System.Windows.Forms.Panel();
            this.TabPnl = new System.Windows.Forms.Panel();
            this.AboutTabBtn = new CodeRedLauncher.Controls.CRTab();
            this.SettingsTabBtn = new CodeRedLauncher.Controls.CRTab();
            this.ExitTabBtn = new CodeRedLauncher.Controls.CRTab();
            this.ScriptsTabBtn = new CodeRedLauncher.Controls.CRTab();
            this.TexturesTabBtn = new CodeRedLauncher.Controls.CRTab();
            this.SessionsTabBtn = new CodeRedLauncher.Controls.CRTab();
            this.NewsTabBtn = new CodeRedLauncher.Controls.CRTab();
            this.DashboardTabBtn = new CodeRedLauncher.Controls.CRTab();
            this.TitleBar = new CodeRedLauncher.Controls.CRTitleBar();
            this.InstallOfflinePopupCtrl = new CodeRedLauncher.Controls.CRPopup();
            this.OfflinePopupCtrl = new CodeRedLauncher.Controls.CRPopup();
            this.UpdatePopupCtrl = new CodeRedLauncher.Controls.CRPopup();
            this.InstallPopupCtrl = new CodeRedLauncher.Controls.CRPopup();
            this.ProcessTmr = new System.Windows.Forms.Timer(this.components);
            this.InjectTmr = new System.Windows.Forms.Timer(this.components);
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.UpdateTmr = new System.Windows.Forms.Timer(this.components);
            this.TabCtrl.SuspendLayout();
            this.DashboardTab.SuspendLayout();
            this.NewsTab.SuspendLayout();
            this.SessionsTab.SuspendLayout();
            this.TexturesTab.SuspendLayout();
            this.ScriptsTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstallPathImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InjectionTimeoutImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualRadioImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutRadioImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlwaysRadioImg)).BeginInit();
            this.AboutTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icons8Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KofiImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscordImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebsiteImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlatformImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetBuildImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PsyonixVersionImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModVersionImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LauncherVersionImg)).BeginInit();
            this.BackgroundPnl.SuspendLayout();
            this.TabPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabCtrl
            // 
            this.TabCtrl.Controls.Add(this.DashboardTab);
            this.TabCtrl.Controls.Add(this.NewsTab);
            this.TabCtrl.Controls.Add(this.SessionsTab);
            this.TabCtrl.Controls.Add(this.TexturesTab);
            this.TabCtrl.Controls.Add(this.ScriptsTab);
            this.TabCtrl.Controls.Add(this.SettingsTab);
            this.TabCtrl.Controls.Add(this.AboutTab);
            this.TabCtrl.Location = new System.Drawing.Point(56, 6);
            this.TabCtrl.Name = "TabCtrl";
            this.TabCtrl.SelectedIndex = 0;
            this.TabCtrl.Size = new System.Drawing.Size(918, 628);
            this.TabCtrl.TabIndex = 3;
            // 
            // DashboardTab
            // 
            this.DashboardTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.DashboardTab.Controls.Add(this.LaunchBtn);
            this.DashboardTab.Controls.Add(this.ChangelogCtrl);
            this.DashboardTab.Controls.Add(this.UpdateCtrl);
            this.DashboardTab.Controls.Add(this.ProcessCtrl);
            this.DashboardTab.Controls.Add(this.ManualInjectBtn);
            this.DashboardTab.Location = new System.Drawing.Point(4, 24);
            this.DashboardTab.Name = "DashboardTab";
            this.DashboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.DashboardTab.Size = new System.Drawing.Size(910, 600);
            this.DashboardTab.TabIndex = 0;
            this.DashboardTab.Text = "Dashboard";
            // 
            // LaunchBtn
            // 
            this.LaunchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LaunchBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LaunchBtn.DisplayImage = global::CodeRedLauncher.Properties.Resources.Question_White;
            this.LaunchBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            this.LaunchBtn.DisplayText = "Launch Rocket League";
            this.LaunchBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.LaunchBtn.Location = new System.Drawing.Point(288, 530);
            this.LaunchBtn.Name = "LaunchBtn";
            this.LaunchBtn.Size = new System.Drawing.Size(320, 35);
            this.LaunchBtn.TabIndex = 32;
            this.LaunchBtn.Visible = false;
            this.LaunchBtn.OnButtonClick += new System.EventHandler(this.LaunchBtn_OnButtonClick);
            // 
            // ChangelogCtrl
            // 
            this.ChangelogCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ChangelogCtrl.DisplayImage = global::CodeRedLauncher.Properties.Resources.Log_White;
            this.ChangelogCtrl.DisplayText = "Loading...";
            this.ChangelogCtrl.DisplayTitle = "Module Changelog";
            this.ChangelogCtrl.Location = new System.Drawing.Point(25, 180);
            this.ChangelogCtrl.Name = "ChangelogCtrl";
            this.ChangelogCtrl.Size = new System.Drawing.Size(860, 315);
            this.ChangelogCtrl.TabIndex = 33;
            this.ChangelogCtrl.OnChangelogSwap += new System.EventHandler(this.ChangelogCtrl_OnChangelogSwap);
            // 
            // UpdateCtrl
            // 
            this.UpdateCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.UpdateCtrl.DescriptionImage = global::CodeRedLauncher.Properties.Resources.Info_White;
            this.UpdateCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.UpdateCtrl.Location = new System.Drawing.Point(535, 25);
            this.UpdateCtrl.Name = "UpdateCtrl";
            this.UpdateCtrl.Size = new System.Drawing.Size(350, 130);
            this.UpdateCtrl.Status = CodeRedLauncher.Controls.CRUpdatePanel.StatusTypes.TYPE_LOADING;
            this.UpdateCtrl.TabIndex = 1;
            this.UpdateCtrl.TitleImage = global::CodeRedLauncher.Properties.Resources.Question_White;
            // 
            // ProcessCtrl
            // 
            this.ProcessCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ProcessCtrl.DescriptionImage = global::CodeRedLauncher.Properties.Resources.Comment_White;
            this.ProcessCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ProcessCtrl.Location = new System.Drawing.Point(25, 25);
            this.ProcessCtrl.Name = "ProcessCtrl";
            this.ProcessCtrl.Result = CodeRedLauncher.InjectionResults.RESULT_NONE;
            this.ProcessCtrl.Size = new System.Drawing.Size(485, 130);
            this.ProcessCtrl.Status = CodeRedLauncher.Controls.CRProcessPanel.StatusTypes.TYPE_LOADING;
            this.ProcessCtrl.TabIndex = 0;
            this.ProcessCtrl.TitleImage = global::CodeRedLauncher.Properties.Resources.Rocket_White;
            // 
            // ManualInjectBtn
            // 
            this.ManualInjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ManualInjectBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ManualInjectBtn.DisplayImage = global::CodeRedLauncher.Properties.Resources.Hand_White;
            this.ManualInjectBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            this.ManualInjectBtn.DisplayText = "Manually Inject";
            this.ManualInjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ManualInjectBtn.Location = new System.Drawing.Point(288, 530);
            this.ManualInjectBtn.Name = "ManualInjectBtn";
            this.ManualInjectBtn.Size = new System.Drawing.Size(320, 35);
            this.ManualInjectBtn.TabIndex = 34;
            this.ManualInjectBtn.Visible = false;
            this.ManualInjectBtn.Click += new System.EventHandler(this.ManualInjectBtn_Click);
            // 
            // NewsTab
            // 
            this.NewsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.NewsTab.Controls.Add(this.NewsCtrl);
            this.NewsTab.Location = new System.Drawing.Point(4, 24);
            this.NewsTab.Name = "NewsTab";
            this.NewsTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewsTab.Size = new System.Drawing.Size(910, 600);
            this.NewsTab.TabIndex = 1;
            this.NewsTab.Text = "News";
            // 
            // NewsCtrl
            // 
            this.NewsCtrl.BackColor = System.Drawing.Color.Transparent;
            this.NewsCtrl.Location = new System.Drawing.Point(25, 25);
            this.NewsCtrl.Name = "NewsCtrl";
            this.NewsCtrl.NewsCategory = "Loading...";
            this.NewsCtrl.PublishAuthor = "Loading...";
            this.NewsCtrl.PublishDate = "Loading...";
            this.NewsCtrl.Size = new System.Drawing.Size(860, 550);
            this.NewsCtrl.TabIndex = 0;
            this.NewsCtrl.Thumbnail = null;
            this.NewsCtrl.Title = "Loading...";
            // 
            // SessionsTab
            // 
            this.SessionsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.SessionsTab.Controls.Add(this.TotalSessionsLbl);
            this.SessionsTab.Controls.Add(this.ReloadSessionsBtn);
            this.SessionsTab.Location = new System.Drawing.Point(4, 24);
            this.SessionsTab.Name = "SessionsTab";
            this.SessionsTab.Size = new System.Drawing.Size(910, 600);
            this.SessionsTab.TabIndex = 2;
            this.SessionsTab.Text = "Sessions";
            // 
            // TotalSessionsLbl
            // 
            this.TotalSessionsLbl.BackColor = System.Drawing.Color.Transparent;
            this.TotalSessionsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TotalSessionsLbl.Location = new System.Drawing.Point(35, 35);
            this.TotalSessionsLbl.Name = "TotalSessionsLbl";
            this.TotalSessionsLbl.Size = new System.Drawing.Size(275, 30);
            this.TotalSessionsLbl.TabIndex = 65;
            this.TotalSessionsLbl.Text = "Sessions Found: ";
            this.TotalSessionsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReloadSessionsBtn
            // 
            this.ReloadSessionsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ReloadSessionsBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ReloadSessionsBtn.DisplayImage = global::CodeRedLauncher.Properties.Resources.Refresh_White;
            this.ReloadSessionsBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            this.ReloadSessionsBtn.DisplayText = "Reload Sessions";
            this.ReloadSessionsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ReloadSessionsBtn.Location = new System.Drawing.Point(315, 540);
            this.ReloadSessionsBtn.Name = "ReloadSessionsBtn";
            this.ReloadSessionsBtn.Size = new System.Drawing.Size(300, 35);
            this.ReloadSessionsBtn.TabIndex = 64;
            this.ReloadSessionsBtn.OnButtonClick += new System.EventHandler(this.ReloadSessionsBtn_OnButtonClick);
            // 
            // TexturesTab
            // 
            this.TexturesTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.TexturesTab.Controls.Add(this.PlaceholderLblSecond);
            this.TexturesTab.Location = new System.Drawing.Point(4, 24);
            this.TexturesTab.Name = "TexturesTab";
            this.TexturesTab.Size = new System.Drawing.Size(910, 600);
            this.TexturesTab.TabIndex = 6;
            this.TexturesTab.Text = "Textures";
            // 
            // PlaceholderLblSecond
            // 
            this.PlaceholderLblSecond.BackColor = System.Drawing.Color.Transparent;
            this.PlaceholderLblSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaceholderLblSecond.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PlaceholderLblSecond.Location = new System.Drawing.Point(0, 0);
            this.PlaceholderLblSecond.Name = "PlaceholderLblSecond";
            this.PlaceholderLblSecond.Size = new System.Drawing.Size(910, 600);
            this.PlaceholderLblSecond.TabIndex = 3;
            this.PlaceholderLblSecond.Text = "Coming soon!";
            this.PlaceholderLblSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScriptsTab
            // 
            this.ScriptsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ScriptsTab.Controls.Add(this.PlaceholderLblThird);
            this.ScriptsTab.Location = new System.Drawing.Point(4, 24);
            this.ScriptsTab.Name = "ScriptsTab";
            this.ScriptsTab.Size = new System.Drawing.Size(910, 600);
            this.ScriptsTab.TabIndex = 3;
            this.ScriptsTab.Text = "Scripts";
            // 
            // PlaceholderLblThird
            // 
            this.PlaceholderLblThird.BackColor = System.Drawing.Color.Transparent;
            this.PlaceholderLblThird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaceholderLblThird.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PlaceholderLblThird.Location = new System.Drawing.Point(0, 0);
            this.PlaceholderLblThird.Name = "PlaceholderLblThird";
            this.PlaceholderLblThird.Size = new System.Drawing.Size(910, 600);
            this.PlaceholderLblThird.TabIndex = 4;
            this.PlaceholderLblThird.Text = "Coming soon!";
            this.PlaceholderLblThird.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsTab
            // 
            this.SettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.SettingsTab.Controls.Add(this.InstallPathBtn);
            this.SettingsTab.Controls.Add(this.InstallPathBx);
            this.SettingsTab.Controls.Add(this.InstallPathImg);
            this.SettingsTab.Controls.Add(this.InstallPathLbl);
            this.SettingsTab.Controls.Add(this.InjectionTimeoutBx);
            this.SettingsTab.Controls.Add(this.InjectionTimeoutImg);
            this.SettingsTab.Controls.Add(this.InjectionTimeoutLbl);
            this.SettingsTab.Controls.Add(this.OpenFolderBtn);
            this.SettingsTab.Controls.Add(this.ExportLogsBtn);
            this.SettingsTab.Controls.Add(this.InjectAllInstancesBx);
            this.SettingsTab.Controls.Add(this.HideWhenMinimizedBx);
            this.SettingsTab.Controls.Add(this.MinimizeOnStartupBx);
            this.SettingsTab.Controls.Add(this.RunOnStartupBx);
            this.SettingsTab.Controls.Add(this.PreventInjectionBx);
            this.SettingsTab.Controls.Add(this.AutoCheckUpdatesBx);
            this.SettingsTab.Controls.Add(this.ManualRadioBtn);
            this.SettingsTab.Controls.Add(this.TimeoutRadioBtn);
            this.SettingsTab.Controls.Add(this.ManualRadioImg);
            this.SettingsTab.Controls.Add(this.TimeoutRadioImg);
            this.SettingsTab.Controls.Add(this.AlwaysRadioBtn);
            this.SettingsTab.Controls.Add(this.AlwaysRadioImg);
            this.SettingsTab.Location = new System.Drawing.Point(4, 24);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(910, 600);
            this.SettingsTab.TabIndex = 4;
            this.SettingsTab.Text = "Settings";
            // 
            // InstallPathBtn
            // 
            this.InstallPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InstallPathBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InstallPathBtn.DisplayImage = null;
            this.InstallPathBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_DARK;
            this.InstallPathBtn.DisplayText = "Change";
            this.InstallPathBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.InstallPathBtn.Location = new System.Drawing.Point(384, 440);
            this.InstallPathBtn.Name = "InstallPathBtn";
            this.InstallPathBtn.Size = new System.Drawing.Size(71, 30);
            this.InstallPathBtn.TabIndex = 68;
            this.InstallPathBtn.OnButtonClick += new System.EventHandler(this.InstallPathBtn_OnButtonClick);
            // 
            // InstallPathBx
            // 
            this.InstallPathBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InstallPathBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InstallPathBx.DisplayText = "";
            this.InstallPathBx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.InstallPathBx.Location = new System.Drawing.Point(162, 440);
            this.InstallPathBx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InstallPathBx.Name = "InstallPathBx";
            this.InstallPathBx.ReadOnly = true;
            this.InstallPathBx.Size = new System.Drawing.Size(215, 30);
            this.InstallPathBx.TabIndex = 67;
            this.InstallPathBx.TextFilter = CodeRedLauncher.Controls.CRTextbox.FilterTypes.TYPE_NONE;
            // 
            // InstallPathImg
            // 
            this.InstallPathImg.BackColor = System.Drawing.Color.Transparent;
            this.InstallPathImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Folder_White;
            this.InstallPathImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.InstallPathImg.Location = new System.Drawing.Point(35, 440);
            this.InstallPathImg.Name = "InstallPathImg";
            this.InstallPathImg.Size = new System.Drawing.Size(30, 30);
            this.InstallPathImg.TabIndex = 66;
            this.InstallPathImg.TabStop = false;
            // 
            // InstallPathLbl
            // 
            this.InstallPathLbl.BackColor = System.Drawing.Color.Transparent;
            this.InstallPathLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InstallPathLbl.Location = new System.Drawing.Point(71, 440);
            this.InstallPathLbl.Name = "InstallPathLbl";
            this.InstallPathLbl.Size = new System.Drawing.Size(85, 30);
            this.InstallPathLbl.TabIndex = 65;
            this.InstallPathLbl.Text = "Install path:";
            this.InstallPathLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InjectionTimeoutBx
            // 
            this.InjectionTimeoutBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InjectionTimeoutBx.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InjectionTimeoutBx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.InjectionTimeoutBx.Hexadecimal = false;
            this.InjectionTimeoutBx.Increment = 1;
            this.InjectionTimeoutBx.Location = new System.Drawing.Point(202, 396);
            this.InjectionTimeoutBx.MaximumValue = 300000;
            this.InjectionTimeoutBx.MinimumValue = 5000;
            this.InjectionTimeoutBx.Name = "InjectionTimeoutBx";
            this.InjectionTimeoutBx.ReadOnly = false;
            this.InjectionTimeoutBx.Size = new System.Drawing.Size(175, 29);
            this.InjectionTimeoutBx.TabIndex = 64;
            this.InjectionTimeoutBx.Value = 20000;
            this.InjectionTimeoutBx.OnValueChanged += new System.EventHandler(this.InjectionTimeoutBx_OnValueChanged);
            // 
            // InjectionTimeoutImg
            // 
            this.InjectionTimeoutImg.BackColor = System.Drawing.Color.Transparent;
            this.InjectionTimeoutImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Hourglass_White;
            this.InjectionTimeoutImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.InjectionTimeoutImg.Location = new System.Drawing.Point(35, 395);
            this.InjectionTimeoutImg.Name = "InjectionTimeoutImg";
            this.InjectionTimeoutImg.Size = new System.Drawing.Size(30, 30);
            this.InjectionTimeoutImg.TabIndex = 40;
            this.InjectionTimeoutImg.TabStop = false;
            // 
            // InjectionTimeoutLbl
            // 
            this.InjectionTimeoutLbl.BackColor = System.Drawing.Color.Transparent;
            this.InjectionTimeoutLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InjectionTimeoutLbl.Location = new System.Drawing.Point(71, 395);
            this.InjectionTimeoutLbl.Name = "InjectionTimeoutLbl";
            this.InjectionTimeoutLbl.Size = new System.Drawing.Size(125, 30);
            this.InjectionTimeoutLbl.TabIndex = 39;
            this.InjectionTimeoutLbl.Text = "Injection timeout: ";
            this.InjectionTimeoutLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OpenFolderBtn
            // 
            this.OpenFolderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OpenFolderBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OpenFolderBtn.DisplayImage = global::CodeRedLauncher.Properties.Resources.Folder_White;
            this.OpenFolderBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            this.OpenFolderBtn.DisplayText = "Open CodeRed Folder";
            this.OpenFolderBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.OpenFolderBtn.Location = new System.Drawing.Point(135, 540);
            this.OpenFolderBtn.Name = "OpenFolderBtn";
            this.OpenFolderBtn.Size = new System.Drawing.Size(320, 35);
            this.OpenFolderBtn.TabIndex = 63;
            this.OpenFolderBtn.OnButtonClick += new System.EventHandler(this.OpenFolderBtn_OnButtonClick);
            // 
            // ExportLogsBtn
            // 
            this.ExportLogsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ExportLogsBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExportLogsBtn.DisplayImage = global::CodeRedLauncher.Properties.Resources.Archive_White;
            this.ExportLogsBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            this.ExportLogsBtn.DisplayText = "Export Crash Logs";
            this.ExportLogsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ExportLogsBtn.Location = new System.Drawing.Point(467, 540);
            this.ExportLogsBtn.Name = "ExportLogsBtn";
            this.ExportLogsBtn.Size = new System.Drawing.Size(320, 35);
            this.ExportLogsBtn.TabIndex = 62;
            this.ExportLogsBtn.OnButtonClick += new System.EventHandler(this.ExportLogsBtn_OnButtonClick);
            // 
            // InjectAllInstancesBx
            // 
            this.InjectAllInstancesBx.BackColor = System.Drawing.Color.Transparent;
            this.InjectAllInstancesBx.Checked = true;
            this.InjectAllInstancesBx.DisplayImage = global::CodeRedLauncher.Properties.Resources.Inject_White;
            this.InjectAllInstancesBx.DisplayText = "Inject into all game instances";
            this.InjectAllInstancesBx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.InjectAllInstancesBx.Location = new System.Drawing.Point(35, 260);
            this.InjectAllInstancesBx.Name = "InjectAllInstancesBx";
            this.InjectAllInstancesBx.Size = new System.Drawing.Size(300, 30);
            this.InjectAllInstancesBx.TabIndex = 60;
            this.InjectAllInstancesBx.OnCheckChanged += new System.EventHandler(this.InjectAllInstancesBx_OnCheckChanged);
            // 
            // HideWhenMinimizedBx
            // 
            this.HideWhenMinimizedBx.BackColor = System.Drawing.Color.Transparent;
            this.HideWhenMinimizedBx.Checked = false;
            this.HideWhenMinimizedBx.DisplayImage = global::CodeRedLauncher.Properties.Resources.Hide_White;
            this.HideWhenMinimizedBx.DisplayText = "Hide when minimized";
            this.HideWhenMinimizedBx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HideWhenMinimizedBx.Location = new System.Drawing.Point(35, 215);
            this.HideWhenMinimizedBx.Name = "HideWhenMinimizedBx";
            this.HideWhenMinimizedBx.Size = new System.Drawing.Size(300, 30);
            this.HideWhenMinimizedBx.TabIndex = 59;
            this.HideWhenMinimizedBx.OnCheckChanged += new System.EventHandler(this.HideWhenMinimizedBx_OnCheckChanged);
            // 
            // MinimizeOnStartupBx
            // 
            this.MinimizeOnStartupBx.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeOnStartupBx.Checked = false;
            this.MinimizeOnStartupBx.DisplayImage = global::CodeRedLauncher.Properties.Resources.Minimize_White;
            this.MinimizeOnStartupBx.DisplayText = "Minimize on startup";
            this.MinimizeOnStartupBx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.MinimizeOnStartupBx.Location = new System.Drawing.Point(35, 170);
            this.MinimizeOnStartupBx.Name = "MinimizeOnStartupBx";
            this.MinimizeOnStartupBx.Size = new System.Drawing.Size(300, 30);
            this.MinimizeOnStartupBx.TabIndex = 58;
            this.MinimizeOnStartupBx.OnCheckChanged += new System.EventHandler(this.MinimizeOnStartupBx_OnCheckChanged);
            // 
            // RunOnStartupBx
            // 
            this.RunOnStartupBx.BackColor = System.Drawing.Color.Transparent;
            this.RunOnStartupBx.Checked = false;
            this.RunOnStartupBx.DisplayImage = global::CodeRedLauncher.Properties.Resources.Windows_White;
            this.RunOnStartupBx.DisplayText = "Run on windows startup";
            this.RunOnStartupBx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.RunOnStartupBx.Location = new System.Drawing.Point(35, 125);
            this.RunOnStartupBx.Name = "RunOnStartupBx";
            this.RunOnStartupBx.Size = new System.Drawing.Size(300, 30);
            this.RunOnStartupBx.TabIndex = 57;
            this.RunOnStartupBx.OnCheckChanged += new System.EventHandler(this.RunOnStartupBx_OnCheckChanged);
            // 
            // PreventInjectionBx
            // 
            this.PreventInjectionBx.BackColor = System.Drawing.Color.Transparent;
            this.PreventInjectionBx.Checked = true;
            this.PreventInjectionBx.DisplayImage = global::CodeRedLauncher.Properties.Resources.Lock_White;
            this.PreventInjectionBx.DisplayText = "Prevent injection when out of date";
            this.PreventInjectionBx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.PreventInjectionBx.Location = new System.Drawing.Point(35, 80);
            this.PreventInjectionBx.Name = "PreventInjectionBx";
            this.PreventInjectionBx.Size = new System.Drawing.Size(300, 30);
            this.PreventInjectionBx.TabIndex = 56;
            this.PreventInjectionBx.OnCheckChanged += new System.EventHandler(this.PreventInjectionBx_OnCheckChanged);
            // 
            // AutoCheckUpdatesBx
            // 
            this.AutoCheckUpdatesBx.BackColor = System.Drawing.Color.Transparent;
            this.AutoCheckUpdatesBx.Checked = true;
            this.AutoCheckUpdatesBx.DisplayImage = global::CodeRedLauncher.Properties.Resources.Download_White;
            this.AutoCheckUpdatesBx.DisplayText = "Automatically check for updates";
            this.AutoCheckUpdatesBx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.AutoCheckUpdatesBx.Location = new System.Drawing.Point(35, 35);
            this.AutoCheckUpdatesBx.Name = "AutoCheckUpdatesBx";
            this.AutoCheckUpdatesBx.Size = new System.Drawing.Size(300, 30);
            this.AutoCheckUpdatesBx.TabIndex = 55;
            this.AutoCheckUpdatesBx.OnCheckChanged += new System.EventHandler(this.AutoCheckUpdatesBx_OnCheckChanged);
            // 
            // ManualRadioBtn
            // 
            this.ManualRadioBtn.BackColor = System.Drawing.Color.Transparent;
            this.ManualRadioBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ManualRadioBtn.Location = new System.Drawing.Point(71, 350);
            this.ManualRadioBtn.Name = "ManualRadioBtn";
            this.ManualRadioBtn.Size = new System.Drawing.Size(250, 30);
            this.ManualRadioBtn.TabIndex = 51;
            this.ManualRadioBtn.Text = "Manual injection";
            this.ManualRadioBtn.UseVisualStyleBackColor = false;
            this.ManualRadioBtn.CheckedChanged += new System.EventHandler(this.ManualRadioBtn_CheckedChanged);
            // 
            // TimeoutRadioBtn
            // 
            this.TimeoutRadioBtn.BackColor = System.Drawing.Color.Transparent;
            this.TimeoutRadioBtn.Checked = true;
            this.TimeoutRadioBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimeoutRadioBtn.Location = new System.Drawing.Point(71, 305);
            this.TimeoutRadioBtn.Name = "TimeoutRadioBtn";
            this.TimeoutRadioBtn.Size = new System.Drawing.Size(250, 30);
            this.TimeoutRadioBtn.TabIndex = 50;
            this.TimeoutRadioBtn.TabStop = true;
            this.TimeoutRadioBtn.Text = "Timeout injection";
            this.TimeoutRadioBtn.UseVisualStyleBackColor = false;
            this.TimeoutRadioBtn.CheckedChanged += new System.EventHandler(this.TimeoutRadioBtn_CheckedChanged);
            // 
            // ManualRadioImg
            // 
            this.ManualRadioImg.BackColor = System.Drawing.Color.Transparent;
            this.ManualRadioImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Hand_White;
            this.ManualRadioImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ManualRadioImg.Location = new System.Drawing.Point(35, 350);
            this.ManualRadioImg.Name = "ManualRadioImg";
            this.ManualRadioImg.Size = new System.Drawing.Size(30, 30);
            this.ManualRadioImg.TabIndex = 27;
            this.ManualRadioImg.TabStop = false;
            // 
            // TimeoutRadioImg
            // 
            this.TimeoutRadioImg.BackColor = System.Drawing.Color.Transparent;
            this.TimeoutRadioImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Stopwatch_White;
            this.TimeoutRadioImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TimeoutRadioImg.Location = new System.Drawing.Point(35, 305);
            this.TimeoutRadioImg.Name = "TimeoutRadioImg";
            this.TimeoutRadioImg.Size = new System.Drawing.Size(30, 30);
            this.TimeoutRadioImg.TabIndex = 26;
            this.TimeoutRadioImg.TabStop = false;
            // 
            // AlwaysRadioBtn
            // 
            this.AlwaysRadioBtn.BackColor = System.Drawing.Color.Transparent;
            this.AlwaysRadioBtn.Enabled = false;
            this.AlwaysRadioBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AlwaysRadioBtn.Location = new System.Drawing.Point(71, 395);
            this.AlwaysRadioBtn.Name = "AlwaysRadioBtn";
            this.AlwaysRadioBtn.Size = new System.Drawing.Size(250, 30);
            this.AlwaysRadioBtn.TabIndex = 52;
            this.AlwaysRadioBtn.Text = "Always injected (Disabled for alpha)";
            this.AlwaysRadioBtn.UseVisualStyleBackColor = false;
            this.AlwaysRadioBtn.Visible = false;
            this.AlwaysRadioBtn.CheckedChanged += new System.EventHandler(this.AlwaysRadioBtn_CheckedChanged);
            // 
            // AlwaysRadioImg
            // 
            this.AlwaysRadioImg.BackColor = System.Drawing.Color.Transparent;
            this.AlwaysRadioImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Library_White;
            this.AlwaysRadioImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AlwaysRadioImg.Location = new System.Drawing.Point(35, 395);
            this.AlwaysRadioImg.Name = "AlwaysRadioImg";
            this.AlwaysRadioImg.Size = new System.Drawing.Size(30, 30);
            this.AlwaysRadioImg.TabIndex = 38;
            this.AlwaysRadioImg.TabStop = false;
            this.AlwaysRadioImg.Visible = false;
            // 
            // AboutTab
            // 
            this.AboutTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.AboutTab.Controls.Add(this.CheckUpdatesBtn);
            this.AboutTab.Controls.Add(this.Icons8Link);
            this.AboutTab.Controls.Add(this.KofiLink);
            this.AboutTab.Controls.Add(this.DiscordLink);
            this.AboutTab.Controls.Add(this.WebsiteLink);
            this.AboutTab.Controls.Add(this.PlatformText);
            this.AboutTab.Controls.Add(this.NetBuildText);
            this.AboutTab.Controls.Add(this.PsyonixVersionText);
            this.AboutTab.Controls.Add(this.ModuleVersionText);
            this.AboutTab.Controls.Add(this.LauncherVersionText);
            this.AboutTab.Controls.Add(this.CreditsLbl);
            this.AboutTab.Controls.Add(this.Icons8Img);
            this.AboutTab.Controls.Add(this.IconsLbl);
            this.AboutTab.Controls.Add(this.KofiImg);
            this.AboutTab.Controls.Add(this.KofiLbl);
            this.AboutTab.Controls.Add(this.DiscordImg);
            this.AboutTab.Controls.Add(this.DiscordLbl);
            this.AboutTab.Controls.Add(this.WebsiteImg);
            this.AboutTab.Controls.Add(this.WebsiteLbl);
            this.AboutTab.Controls.Add(this.PlatformImg);
            this.AboutTab.Controls.Add(this.PlatformLbl);
            this.AboutTab.Controls.Add(this.NetBuildImg);
            this.AboutTab.Controls.Add(this.NetBuildLbl);
            this.AboutTab.Controls.Add(this.PsyonixVersionImg);
            this.AboutTab.Controls.Add(this.PsyonixVersionLbl);
            this.AboutTab.Controls.Add(this.ModVersionImg);
            this.AboutTab.Controls.Add(this.ModuleVersionLbl);
            this.AboutTab.Controls.Add(this.LauncherVersionImg);
            this.AboutTab.Controls.Add(this.LauncherVersionLbl);
            this.AboutTab.Location = new System.Drawing.Point(4, 24);
            this.AboutTab.Name = "AboutTab";
            this.AboutTab.Size = new System.Drawing.Size(910, 600);
            this.AboutTab.TabIndex = 5;
            this.AboutTab.Text = "About";
            // 
            // CheckUpdatesBtn
            // 
            this.CheckUpdatesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CheckUpdatesBtn.DisplayFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CheckUpdatesBtn.DisplayImage = global::CodeRedLauncher.Properties.Resources.Refresh_White;
            this.CheckUpdatesBtn.DisplayStyle = CodeRedLauncher.Controls.CRButton.ButtonStyles.STYLE_COLORED;
            this.CheckUpdatesBtn.DisplayText = "Check for Updates";
            this.CheckUpdatesBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.CheckUpdatesBtn.Location = new System.Drawing.Point(235, 529);
            this.CheckUpdatesBtn.Name = "CheckUpdatesBtn";
            this.CheckUpdatesBtn.Size = new System.Drawing.Size(440, 35);
            this.CheckUpdatesBtn.TabIndex = 31;
            this.CheckUpdatesBtn.OnButtonClick += new System.EventHandler(this.CheckUpdatesBtn_OnButtonClick);
            // 
            // Icons8Link
            // 
            this.Icons8Link.BackColor = System.Drawing.Color.Transparent;
            this.Icons8Link.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icons8Link.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icons8Link.ForeColor = System.Drawing.Color.Red;
            this.Icons8Link.Location = new System.Drawing.Point(207, 395);
            this.Icons8Link.Name = "Icons8Link";
            this.Icons8Link.Size = new System.Drawing.Size(275, 30);
            this.Icons8Link.TabIndex = 30;
            this.Icons8Link.Text = "https://icons8.com/";
            this.Icons8Link.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Icons8Link.Click += new System.EventHandler(this.Icons8Link_Click);
            // 
            // KofiLink
            // 
            this.KofiLink.BackColor = System.Drawing.Color.Transparent;
            this.KofiLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.KofiLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KofiLink.ForeColor = System.Drawing.Color.Red;
            this.KofiLink.Location = new System.Drawing.Point(207, 350);
            this.KofiLink.Name = "KofiLink";
            this.KofiLink.Size = new System.Drawing.Size(275, 30);
            this.KofiLink.TabIndex = 29;
            this.KofiLink.Text = "https://ko-fi.com/coderedmodding/";
            this.KofiLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KofiLink.Click += new System.EventHandler(this.KofiLink_Click);
            // 
            // DiscordLink
            // 
            this.DiscordLink.BackColor = System.Drawing.Color.Transparent;
            this.DiscordLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DiscordLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DiscordLink.ForeColor = System.Drawing.Color.Red;
            this.DiscordLink.Location = new System.Drawing.Point(207, 305);
            this.DiscordLink.Name = "DiscordLink";
            this.DiscordLink.Size = new System.Drawing.Size(275, 30);
            this.DiscordLink.TabIndex = 28;
            this.DiscordLink.Text = "Loading...";
            this.DiscordLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DiscordLink.Click += new System.EventHandler(this.DiscordLink_Click);
            // 
            // WebsiteLink
            // 
            this.WebsiteLink.BackColor = System.Drawing.Color.Transparent;
            this.WebsiteLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WebsiteLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WebsiteLink.ForeColor = System.Drawing.Color.Red;
            this.WebsiteLink.Location = new System.Drawing.Point(207, 260);
            this.WebsiteLink.Name = "WebsiteLink";
            this.WebsiteLink.Size = new System.Drawing.Size(275, 30);
            this.WebsiteLink.TabIndex = 27;
            this.WebsiteLink.Text = "https://coderedmodding.github.io/";
            this.WebsiteLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WebsiteLink.Click += new System.EventHandler(this.WebsiteLink_Click);
            // 
            // PlatformText
            // 
            this.PlatformText.BackColor = System.Drawing.Color.Transparent;
            this.PlatformText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlatformText.Location = new System.Drawing.Point(207, 215);
            this.PlatformText.Name = "PlatformText";
            this.PlatformText.Size = new System.Drawing.Size(275, 30);
            this.PlatformText.TabIndex = 26;
            this.PlatformText.Text = "Loading...";
            this.PlatformText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NetBuildText
            // 
            this.NetBuildText.BackColor = System.Drawing.Color.Transparent;
            this.NetBuildText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NetBuildText.Location = new System.Drawing.Point(207, 170);
            this.NetBuildText.Name = "NetBuildText";
            this.NetBuildText.Size = new System.Drawing.Size(275, 30);
            this.NetBuildText.TabIndex = 25;
            this.NetBuildText.Text = "Loading...";
            this.NetBuildText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PsyonixVersionText
            // 
            this.PsyonixVersionText.BackColor = System.Drawing.Color.Transparent;
            this.PsyonixVersionText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PsyonixVersionText.Location = new System.Drawing.Point(207, 125);
            this.PsyonixVersionText.Name = "PsyonixVersionText";
            this.PsyonixVersionText.Size = new System.Drawing.Size(275, 30);
            this.PsyonixVersionText.TabIndex = 24;
            this.PsyonixVersionText.Text = "Loading...";
            this.PsyonixVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModuleVersionText
            // 
            this.ModuleVersionText.BackColor = System.Drawing.Color.Transparent;
            this.ModuleVersionText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModuleVersionText.Location = new System.Drawing.Point(207, 80);
            this.ModuleVersionText.Name = "ModuleVersionText";
            this.ModuleVersionText.Size = new System.Drawing.Size(275, 30);
            this.ModuleVersionText.TabIndex = 23;
            this.ModuleVersionText.Text = "Loading...";
            this.ModuleVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LauncherVersionText
            // 
            this.LauncherVersionText.BackColor = System.Drawing.Color.Transparent;
            this.LauncherVersionText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LauncherVersionText.Location = new System.Drawing.Point(207, 35);
            this.LauncherVersionText.Name = "LauncherVersionText";
            this.LauncherVersionText.Size = new System.Drawing.Size(275, 30);
            this.LauncherVersionText.TabIndex = 22;
            this.LauncherVersionText.Text = "Loading...";
            this.LauncherVersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreditsLbl
            // 
            this.CreditsLbl.BackColor = System.Drawing.Color.Transparent;
            this.CreditsLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreditsLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.CreditsLbl.Location = new System.Drawing.Point(35, 440);
            this.CreditsLbl.Name = "CreditsLbl";
            this.CreditsLbl.Size = new System.Drawing.Size(840, 64);
            this.CreditsLbl.TabIndex = 21;
            this.CreditsLbl.Text = resources.GetString("CreditsLbl.Text");
            this.CreditsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Icons8Img
            // 
            this.Icons8Img.BackColor = System.Drawing.Color.Transparent;
            this.Icons8Img.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Icons8_White;
            this.Icons8Img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Icons8Img.Location = new System.Drawing.Point(35, 395);
            this.Icons8Img.Name = "Icons8Img";
            this.Icons8Img.Size = new System.Drawing.Size(30, 30);
            this.Icons8Img.TabIndex = 19;
            this.Icons8Img.TabStop = false;
            // 
            // IconsLbl
            // 
            this.IconsLbl.BackColor = System.Drawing.Color.Transparent;
            this.IconsLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IconsLbl.Location = new System.Drawing.Point(71, 395);
            this.IconsLbl.Name = "IconsLbl";
            this.IconsLbl.Size = new System.Drawing.Size(130, 30);
            this.IconsLbl.TabIndex = 18;
            this.IconsLbl.Text = "Icons provided by:";
            this.IconsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KofiImg
            // 
            this.KofiImg.BackColor = System.Drawing.Color.Transparent;
            this.KofiImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Coffee_White;
            this.KofiImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.KofiImg.Location = new System.Drawing.Point(35, 350);
            this.KofiImg.Name = "KofiImg";
            this.KofiImg.Size = new System.Drawing.Size(30, 30);
            this.KofiImg.TabIndex = 17;
            this.KofiImg.TabStop = false;
            // 
            // KofiLbl
            // 
            this.KofiLbl.BackColor = System.Drawing.Color.Transparent;
            this.KofiLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.KofiLbl.Location = new System.Drawing.Point(71, 350);
            this.KofiLbl.Name = "KofiLbl";
            this.KofiLbl.Size = new System.Drawing.Size(130, 30);
            this.KofiLbl.TabIndex = 16;
            this.KofiLbl.Text = "Ko-fi:";
            this.KofiLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DiscordImg
            // 
            this.DiscordImg.BackColor = System.Drawing.Color.Transparent;
            this.DiscordImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Discord_White;
            this.DiscordImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DiscordImg.Location = new System.Drawing.Point(35, 305);
            this.DiscordImg.Name = "DiscordImg";
            this.DiscordImg.Size = new System.Drawing.Size(30, 30);
            this.DiscordImg.TabIndex = 15;
            this.DiscordImg.TabStop = false;
            // 
            // DiscordLbl
            // 
            this.DiscordLbl.BackColor = System.Drawing.Color.Transparent;
            this.DiscordLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DiscordLbl.Location = new System.Drawing.Point(71, 305);
            this.DiscordLbl.Name = "DiscordLbl";
            this.DiscordLbl.Size = new System.Drawing.Size(130, 30);
            this.DiscordLbl.TabIndex = 14;
            this.DiscordLbl.Text = "Discord:";
            this.DiscordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WebsiteImg
            // 
            this.WebsiteImg.BackColor = System.Drawing.Color.Transparent;
            this.WebsiteImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Box_White;
            this.WebsiteImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.WebsiteImg.Location = new System.Drawing.Point(35, 260);
            this.WebsiteImg.Name = "WebsiteImg";
            this.WebsiteImg.Size = new System.Drawing.Size(30, 30);
            this.WebsiteImg.TabIndex = 13;
            this.WebsiteImg.TabStop = false;
            // 
            // WebsiteLbl
            // 
            this.WebsiteLbl.BackColor = System.Drawing.Color.Transparent;
            this.WebsiteLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WebsiteLbl.Location = new System.Drawing.Point(71, 260);
            this.WebsiteLbl.Name = "WebsiteLbl";
            this.WebsiteLbl.Size = new System.Drawing.Size(130, 30);
            this.WebsiteLbl.TabIndex = 12;
            this.WebsiteLbl.Text = "Website:";
            this.WebsiteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlatformImg
            // 
            this.PlatformImg.BackColor = System.Drawing.Color.Transparent;
            this.PlatformImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Question_White;
            this.PlatformImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PlatformImg.Location = new System.Drawing.Point(35, 215);
            this.PlatformImg.Name = "PlatformImg";
            this.PlatformImg.Size = new System.Drawing.Size(30, 30);
            this.PlatformImg.TabIndex = 11;
            this.PlatformImg.TabStop = false;
            // 
            // PlatformLbl
            // 
            this.PlatformLbl.BackColor = System.Drawing.Color.Transparent;
            this.PlatformLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PlatformLbl.Location = new System.Drawing.Point(71, 215);
            this.PlatformLbl.Name = "PlatformLbl";
            this.PlatformLbl.Size = new System.Drawing.Size(130, 30);
            this.PlatformLbl.TabIndex = 10;
            this.PlatformLbl.Text = "Active Platform:";
            this.PlatformLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NetBuildImg
            // 
            this.NetBuildImg.BackColor = System.Drawing.Color.Transparent;
            this.NetBuildImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Circuit_White;
            this.NetBuildImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NetBuildImg.Location = new System.Drawing.Point(35, 170);
            this.NetBuildImg.Name = "NetBuildImg";
            this.NetBuildImg.Size = new System.Drawing.Size(30, 30);
            this.NetBuildImg.TabIndex = 9;
            this.NetBuildImg.TabStop = false;
            // 
            // NetBuildLbl
            // 
            this.NetBuildLbl.BackColor = System.Drawing.Color.Transparent;
            this.NetBuildLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NetBuildLbl.Location = new System.Drawing.Point(71, 170);
            this.NetBuildLbl.Name = "NetBuildLbl";
            this.NetBuildLbl.Size = new System.Drawing.Size(130, 30);
            this.NetBuildLbl.TabIndex = 8;
            this.NetBuildLbl.Text = "Net Build:";
            this.NetBuildLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PsyonixVersionImg
            // 
            this.PsyonixVersionImg.BackColor = System.Drawing.Color.Transparent;
            this.PsyonixVersionImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Server_White;
            this.PsyonixVersionImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PsyonixVersionImg.Location = new System.Drawing.Point(35, 125);
            this.PsyonixVersionImg.Name = "PsyonixVersionImg";
            this.PsyonixVersionImg.Size = new System.Drawing.Size(30, 30);
            this.PsyonixVersionImg.TabIndex = 7;
            this.PsyonixVersionImg.TabStop = false;
            // 
            // PsyonixVersionLbl
            // 
            this.PsyonixVersionLbl.BackColor = System.Drawing.Color.Transparent;
            this.PsyonixVersionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PsyonixVersionLbl.Location = new System.Drawing.Point(71, 125);
            this.PsyonixVersionLbl.Name = "PsyonixVersionLbl";
            this.PsyonixVersionLbl.Size = new System.Drawing.Size(130, 30);
            this.PsyonixVersionLbl.TabIndex = 6;
            this.PsyonixVersionLbl.Text = "Psyonix Version:";
            this.PsyonixVersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModVersionImg
            // 
            this.ModVersionImg.BackColor = System.Drawing.Color.Transparent;
            this.ModVersionImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Chip_White;
            this.ModVersionImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ModVersionImg.Location = new System.Drawing.Point(35, 80);
            this.ModVersionImg.Name = "ModVersionImg";
            this.ModVersionImg.Size = new System.Drawing.Size(30, 30);
            this.ModVersionImg.TabIndex = 5;
            this.ModVersionImg.TabStop = false;
            // 
            // ModuleVersionLbl
            // 
            this.ModuleVersionLbl.BackColor = System.Drawing.Color.Transparent;
            this.ModuleVersionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ModuleVersionLbl.Location = new System.Drawing.Point(71, 80);
            this.ModuleVersionLbl.Name = "ModuleVersionLbl";
            this.ModuleVersionLbl.Size = new System.Drawing.Size(130, 30);
            this.ModuleVersionLbl.TabIndex = 4;
            this.ModuleVersionLbl.Text = "Module Version:";
            this.ModuleVersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LauncherVersionImg
            // 
            this.LauncherVersionImg.BackColor = System.Drawing.Color.Transparent;
            this.LauncherVersionImg.BackgroundImage = global::CodeRedLauncher.Properties.Resources.Software_White;
            this.LauncherVersionImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LauncherVersionImg.Location = new System.Drawing.Point(35, 35);
            this.LauncherVersionImg.Name = "LauncherVersionImg";
            this.LauncherVersionImg.Size = new System.Drawing.Size(30, 30);
            this.LauncherVersionImg.TabIndex = 3;
            this.LauncherVersionImg.TabStop = false;
            // 
            // LauncherVersionLbl
            // 
            this.LauncherVersionLbl.BackColor = System.Drawing.Color.Transparent;
            this.LauncherVersionLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LauncherVersionLbl.Location = new System.Drawing.Point(71, 35);
            this.LauncherVersionLbl.Name = "LauncherVersionLbl";
            this.LauncherVersionLbl.Size = new System.Drawing.Size(130, 30);
            this.LauncherVersionLbl.TabIndex = 2;
            this.LauncherVersionLbl.Text = "Launcher Version:";
            this.LauncherVersionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackgroundPnl
            // 
            this.BackgroundPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.BackgroundPnl.Controls.Add(this.TabPnl);
            this.BackgroundPnl.Controls.Add(this.TitleBar);
            this.BackgroundPnl.Controls.Add(this.TabCtrl);
            this.BackgroundPnl.Controls.Add(this.InstallOfflinePopupCtrl);
            this.BackgroundPnl.Controls.Add(this.OfflinePopupCtrl);
            this.BackgroundPnl.Controls.Add(this.UpdatePopupCtrl);
            this.BackgroundPnl.Controls.Add(this.InstallPopupCtrl);
            this.BackgroundPnl.Location = new System.Drawing.Point(1, 1);
            this.BackgroundPnl.Name = "BackgroundPnl";
            this.BackgroundPnl.Size = new System.Drawing.Size(970, 630);
            this.BackgroundPnl.TabIndex = 4;
            // 
            // TabPnl
            // 
            this.TabPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TabPnl.Controls.Add(this.AboutTabBtn);
            this.TabPnl.Controls.Add(this.SettingsTabBtn);
            this.TabPnl.Controls.Add(this.ExitTabBtn);
            this.TabPnl.Controls.Add(this.ScriptsTabBtn);
            this.TabPnl.Controls.Add(this.TexturesTabBtn);
            this.TabPnl.Controls.Add(this.SessionsTabBtn);
            this.TabPnl.Controls.Add(this.NewsTabBtn);
            this.TabPnl.Controls.Add(this.DashboardTabBtn);
            this.TabPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.TabPnl.Location = new System.Drawing.Point(0, 30);
            this.TabPnl.Name = "TabPnl";
            this.TabPnl.Size = new System.Drawing.Size(60, 600);
            this.TabPnl.TabIndex = 2;
            // 
            // AboutTabBtn
            // 
            this.AboutTabBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AboutTabBtn.ImageSelected = global::CodeRedLauncher.Properties.Resources.About_Red;
            this.AboutTabBtn.ImageUnselected = global::CodeRedLauncher.Properties.Resources.About_White;
            this.AboutTabBtn.Location = new System.Drawing.Point(0, 500);
            this.AboutTabBtn.Name = "AboutTabBtn";
            this.AboutTabBtn.Selected = false;
            this.AboutTabBtn.Size = new System.Drawing.Size(60, 50);
            this.AboutTabBtn.TabIndex = 7;
            this.AboutTabBtn.OnTabClick += new System.EventHandler(this.AboutTabBtn_OnTabClick);
            // 
            // SettingsTabBtn
            // 
            this.SettingsTabBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SettingsTabBtn.ImageSelected = global::CodeRedLauncher.Properties.Resources.Settings_Red;
            this.SettingsTabBtn.ImageUnselected = global::CodeRedLauncher.Properties.Resources.Settings_White;
            this.SettingsTabBtn.Location = new System.Drawing.Point(0, 450);
            this.SettingsTabBtn.Name = "SettingsTabBtn";
            this.SettingsTabBtn.Selected = false;
            this.SettingsTabBtn.Size = new System.Drawing.Size(60, 50);
            this.SettingsTabBtn.TabIndex = 6;
            this.SettingsTabBtn.OnTabClick += new System.EventHandler(this.SettingsTabBtn_OnTabClick);
            // 
            // ExitTabBtn
            // 
            this.ExitTabBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ExitTabBtn.ImageSelected = global::CodeRedLauncher.Properties.Resources.Exit_Red;
            this.ExitTabBtn.ImageUnselected = global::CodeRedLauncher.Properties.Resources.Exit_White;
            this.ExitTabBtn.Location = new System.Drawing.Point(0, 550);
            this.ExitTabBtn.Name = "ExitTabBtn";
            this.ExitTabBtn.Selected = false;
            this.ExitTabBtn.Size = new System.Drawing.Size(60, 50);
            this.ExitTabBtn.TabIndex = 5;
            this.ExitTabBtn.OnTabClick += new System.EventHandler(this.ExitTabBtn_OnTabClick);
            // 
            // ScriptsTabBtn
            // 
            this.ScriptsTabBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ScriptsTabBtn.ImageSelected = global::CodeRedLauncher.Properties.Resources.Paper_Red;
            this.ScriptsTabBtn.ImageUnselected = global::CodeRedLauncher.Properties.Resources.Paper_White;
            this.ScriptsTabBtn.Location = new System.Drawing.Point(0, 200);
            this.ScriptsTabBtn.Name = "ScriptsTabBtn";
            this.ScriptsTabBtn.Selected = false;
            this.ScriptsTabBtn.Size = new System.Drawing.Size(60, 50);
            this.ScriptsTabBtn.TabIndex = 4;
            this.ScriptsTabBtn.Visible = false;
            this.ScriptsTabBtn.OnTabClick += new System.EventHandler(this.ScriptsTabBtn_OnTabClick);
            // 
            // TexturesTabBtn
            // 
            this.TexturesTabBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TexturesTabBtn.ImageSelected = global::CodeRedLauncher.Properties.Resources.Texture_Red;
            this.TexturesTabBtn.ImageUnselected = global::CodeRedLauncher.Properties.Resources.Texture_White;
            this.TexturesTabBtn.Location = new System.Drawing.Point(0, 150);
            this.TexturesTabBtn.Name = "TexturesTabBtn";
            this.TexturesTabBtn.Selected = false;
            this.TexturesTabBtn.Size = new System.Drawing.Size(60, 50);
            this.TexturesTabBtn.TabIndex = 3;
            this.TexturesTabBtn.Visible = false;
            this.TexturesTabBtn.OnTabClick += new System.EventHandler(this.TexturesTabBtn_OnTabClick);
            // 
            // SessionsTabBtn
            // 
            this.SessionsTabBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SessionsTabBtn.ImageSelected = global::CodeRedLauncher.Properties.Resources.Chart_Red;
            this.SessionsTabBtn.ImageUnselected = global::CodeRedLauncher.Properties.Resources.Chart_White;
            this.SessionsTabBtn.Location = new System.Drawing.Point(0, 100);
            this.SessionsTabBtn.Name = "SessionsTabBtn";
            this.SessionsTabBtn.Selected = false;
            this.SessionsTabBtn.Size = new System.Drawing.Size(60, 50);
            this.SessionsTabBtn.TabIndex = 2;
            this.SessionsTabBtn.Visible = false;
            this.SessionsTabBtn.OnTabClick += new System.EventHandler(this.SessionsTabBtn_OnTabClick);
            // 
            // NewsTabBtn
            // 
            this.NewsTabBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.NewsTabBtn.ImageSelected = global::CodeRedLauncher.Properties.Resources.Newspaper_Red;
            this.NewsTabBtn.ImageUnselected = global::CodeRedLauncher.Properties.Resources.Newspaper_White;
            this.NewsTabBtn.Location = new System.Drawing.Point(0, 50);
            this.NewsTabBtn.Name = "NewsTabBtn";
            this.NewsTabBtn.Selected = false;
            this.NewsTabBtn.Size = new System.Drawing.Size(60, 50);
            this.NewsTabBtn.TabIndex = 1;
            this.NewsTabBtn.OnTabClick += new System.EventHandler(this.NewsTabBtn_OnTabClick);
            // 
            // DashboardTabBtn
            // 
            this.DashboardTabBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.DashboardTabBtn.ImageSelected = global::CodeRedLauncher.Properties.Resources.Dashboard_Red;
            this.DashboardTabBtn.ImageUnselected = global::CodeRedLauncher.Properties.Resources.Dashboard_White;
            this.DashboardTabBtn.Location = new System.Drawing.Point(0, 0);
            this.DashboardTabBtn.Name = "DashboardTabBtn";
            this.DashboardTabBtn.Selected = true;
            this.DashboardTabBtn.Size = new System.Drawing.Size(60, 50);
            this.DashboardTabBtn.TabIndex = 0;
            this.DashboardTabBtn.OnTabClick += new System.EventHandler(this.DashboardTabBtn_OnTabClick);
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.TitleBar.BoundForm = null;
            this.TitleBar.DisplayText = "CODERED LAUNCHER";
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(970, 30);
            this.TitleBar.TabIndex = 2;
            this.TitleBar.OnMinimized += new System.EventHandler(this.TitleBar_OnMinimized);
            this.TitleBar.OnExit += new System.EventHandler(this.TitleBar_OnExit);
            // 
            // InstallOfflinePopupCtrl
            // 
            this.InstallOfflinePopupCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InstallOfflinePopupCtrl.BoundForm = null;
            this.InstallOfflinePopupCtrl.ButtonLayout = CodeRedLauncher.Controls.CRPopup.ButtonLayouts.TYPE_SINGLE;
            this.InstallOfflinePopupCtrl.DisplayDescription = "Failed to connect to the remote server, an active internet connection is required" +
    " to install CodeRed! Please connect to the internet and try again";
            this.InstallOfflinePopupCtrl.DisplayTitle = "NO CONNECTION";
            this.InstallOfflinePopupCtrl.DoubleFirstImage = null;
            this.InstallOfflinePopupCtrl.DoubleFirstText = "First Option";
            this.InstallOfflinePopupCtrl.DoubleSecondImage = null;
            this.InstallOfflinePopupCtrl.DoubleSecondText = "Second Option";
            this.InstallOfflinePopupCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.InstallOfflinePopupCtrl.Location = new System.Drawing.Point(0, 0);
            this.InstallOfflinePopupCtrl.Name = "InstallOfflinePopupCtrl";
            this.InstallOfflinePopupCtrl.SingleButtonImage = null;
            this.InstallOfflinePopupCtrl.SingleButtonText = "Ok fine, I\'ll go do that";
            this.InstallOfflinePopupCtrl.Size = new System.Drawing.Size(970, 630);
            this.InstallOfflinePopupCtrl.TabIndex = 38;
            this.InstallOfflinePopupCtrl.Visible = false;
            this.InstallOfflinePopupCtrl.SingleButtonClick += new System.EventHandler(this.InstallOfflinePopupCtrl_SingleButtonClick);
            // 
            // OfflinePopupCtrl
            // 
            this.OfflinePopupCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.OfflinePopupCtrl.BoundForm = null;
            this.OfflinePopupCtrl.ButtonLayout = CodeRedLauncher.Controls.CRPopup.ButtonLayouts.TYPE_DOUBLE;
            this.OfflinePopupCtrl.DisplayDescription = "Failed to connect to the remote server, would you like to start in offline mode? " +
    "Version checking, news, changelog, and remote information will all be disabled.";
            this.OfflinePopupCtrl.DisplayTitle = "NO CONNECTION";
            this.OfflinePopupCtrl.DoubleFirstImage = null;
            this.OfflinePopupCtrl.DoubleFirstText = "No thanks, let\'s try again";
            this.OfflinePopupCtrl.DoubleSecondImage = null;
            this.OfflinePopupCtrl.DoubleSecondText = "Sure, sounds good to me";
            this.OfflinePopupCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.OfflinePopupCtrl.Location = new System.Drawing.Point(0, 0);
            this.OfflinePopupCtrl.Name = "OfflinePopupCtrl";
            this.OfflinePopupCtrl.SingleButtonImage = null;
            this.OfflinePopupCtrl.SingleButtonText = "Single Option";
            this.OfflinePopupCtrl.Size = new System.Drawing.Size(970, 630);
            this.OfflinePopupCtrl.TabIndex = 36;
            this.OfflinePopupCtrl.Visible = false;
            this.OfflinePopupCtrl.DoubleFirstButtonClick += new System.EventHandler(this.OfflinePopupCtrl_DoubleFirstButtonClick);
            this.OfflinePopupCtrl.DoubleSecondButtonClick += new System.EventHandler(this.OfflinePopupCtrl_DoubleSecondButtonClick);
            // 
            // UpdatePopupCtrl
            // 
            this.UpdatePopupCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.UpdatePopupCtrl.BoundForm = null;
            this.UpdatePopupCtrl.ButtonLayout = CodeRedLauncher.Controls.CRPopup.ButtonLayouts.TYPE_DOUBLE;
            this.UpdatePopupCtrl.DisplayDescription = "A new version was found, would you like to automatically install it now?";
            this.UpdatePopupCtrl.DisplayTitle = "UPDATE AVAILABLE";
            this.UpdatePopupCtrl.DoubleFirstImage = null;
            this.UpdatePopupCtrl.DoubleFirstText = "No thanks, I\'ll update later";
            this.UpdatePopupCtrl.DoubleSecondImage = null;
            this.UpdatePopupCtrl.DoubleSecondText = "Yes please, show me what you got";
            this.UpdatePopupCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.UpdatePopupCtrl.Location = new System.Drawing.Point(0, 0);
            this.UpdatePopupCtrl.Name = "UpdatePopupCtrl";
            this.UpdatePopupCtrl.SingleButtonImage = null;
            this.UpdatePopupCtrl.SingleButtonText = "Ok fine, I\'ll close the game";
            this.UpdatePopupCtrl.Size = new System.Drawing.Size(970, 630);
            this.UpdatePopupCtrl.TabIndex = 35;
            this.UpdatePopupCtrl.Visible = false;
            this.UpdatePopupCtrl.SingleButtonClick += new System.EventHandler(this.UpdatePopupCtrl_SingleButtonClick);
            this.UpdatePopupCtrl.DoubleFirstButtonClick += new System.EventHandler(this.UpdatePopupCtrl_DoubleFirstButtonClick);
            this.UpdatePopupCtrl.DoubleSecondButtonClick += new System.EventHandler(this.UpdatePopupCtrl_DoubleSecondButtonClick);
            // 
            // InstallPopupCtrl
            // 
            this.InstallPopupCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InstallPopupCtrl.BoundForm = null;
            this.InstallPopupCtrl.ButtonLayout = CodeRedLauncher.Controls.CRPopup.ButtonLayouts.TYPE_DOUBLE;
            this.InstallPopupCtrl.DisplayDescription = "It looks like this if your first time using CodeRed, we need to download and setu" +
    "p a few things first before we can get started. First, would you like to customi" +
    "ze your install path?";
            this.InstallPopupCtrl.DisplayTitle = "WELCOME TO CODERED";
            this.InstallPopupCtrl.DoubleFirstImage = null;
            this.InstallPopupCtrl.DoubleFirstText = "Sure, let me pick a folder";
            this.InstallPopupCtrl.DoubleSecondImage = null;
            this.InstallPopupCtrl.DoubleSecondText = "Nah, do everything for me";
            this.InstallPopupCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.InstallPopupCtrl.Location = new System.Drawing.Point(0, 0);
            this.InstallPopupCtrl.Name = "InstallPopupCtrl";
            this.InstallPopupCtrl.SingleButtonImage = null;
            this.InstallPopupCtrl.SingleButtonText = "Single Option";
            this.InstallPopupCtrl.Size = new System.Drawing.Size(970, 630);
            this.InstallPopupCtrl.TabIndex = 37;
            this.InstallPopupCtrl.Visible = false;
            this.InstallPopupCtrl.DoubleFirstButtonClick += new System.EventHandler(this.InstallPopupCtrl_DoubleFirstButtonClick);
            this.InstallPopupCtrl.DoubleSecondButtonClick += new System.EventHandler(this.InstallPopupCtrl_DoubleSecondButtonClick);
            // 
            // ProcessTmr
            // 
            this.ProcessTmr.Interval = 250;
            this.ProcessTmr.Tick += new System.EventHandler(this.ProcessTmr_Tick);
            // 
            // InjectTmr
            // 
            this.InjectTmr.Interval = 5000;
            this.InjectTmr.Tick += new System.EventHandler(this.InjectTmr_Tick);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "CodeRed Launcher";
            this.TrayIcon.Visible = true;
            this.TrayIcon.Click += new System.EventHandler(this.TrayIcon_Click);
            // 
            // UpdateTmr
            // 
            this.UpdateTmr.Interval = 150000;
            this.UpdateTmr.Tick += new System.EventHandler(this.UpdateTmr_Tick);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(972, 632);
            this.Controls.Add(this.BackgroundPnl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            this.TabCtrl.ResumeLayout(false);
            this.DashboardTab.ResumeLayout(false);
            this.NewsTab.ResumeLayout(false);
            this.SessionsTab.ResumeLayout(false);
            this.TexturesTab.ResumeLayout(false);
            this.ScriptsTab.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InstallPathImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InjectionTimeoutImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualRadioImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutRadioImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlwaysRadioImg)).EndInit();
            this.AboutTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Icons8Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KofiImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscordImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebsiteImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlatformImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetBuildImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PsyonixVersionImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModVersionImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LauncherVersionImg)).EndInit();
            this.BackgroundPnl.ResumeLayout(false);
            this.TabPnl.ResumeLayout(false);
            this.ResumeLayout(false);

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

