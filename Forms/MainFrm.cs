using CodeRedLauncher.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeRedLauncher
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            SetupUserInterface();
            CheckForInstances();
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                TitleBar_OnMinimized(this, null);
            }
        }

        private void TitleBar_OnMinimized(object sender, EventArgs e)
        {
            if (UserConfig.ShouldHideWhenMinimized())
            {
                this.Hide();
            }
            else if (this.WindowState != FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void TitleBar_OnExit(object sender, EventArgs e)
        {
            this.TrayIcon.Visible = false;
            Environment.Exit(0);
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void DashboardTabBtn_OnTabClick(object sender, EventArgs e)
        {
            TabManager.SelectTab(Tabs.Dashboard);
        }

        private void NewsTabBtn_OnTabClick(object sender, EventArgs e)
        {
            TabManager.SelectTab(Tabs.News);
        }

        private void SettingsTabBtn_OnTabClick(object sender, EventArgs e)
        {
            TabManager.SelectTab(Tabs.Settings);
        }

        private void AboutTabBtn_OnTabClick(object sender, EventArgs e)
        {
            TabManager.SelectTab(Tabs.About);
        }

        private void ExitTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ManualInjectBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (Updater.IsOutdated())
            {
                Logger.Write("(ManualInjectBtn) Prevented injection, updater returned out of date!");
                ProcessCtrl.View = ProcessViews.Outdated;
                InjectTmr.Stop();
                return;
            }

            if (LocalStorage.DetectedAntiCheat() && UserConfig.ShouldPreventEACInjection())
            {
                Logger.Write("(ManualInjectBtn) Prevented injection, easy anti-cheat detected!");
                return;
            }

            if (!UserConfig.ShouldInjectAll())
            {
                List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                if (processes.Count > 0)
                {
                    Logger.Write("(ManualInjectBtn) Process found!");
                    ProcessInjectionResult(LibraryManager.TryLoadIndividual(processes[0], LocalStorage.GetLibraryFile()));
                }
            }
            else
            {
                List<InjectionResults> results = LibraryManager.TryLoadDynamic(LocalStorage.GetLibraryFile());

                if (results.Count > 0)
                {
                    Logger.Write("P(ManualInjectBtn) Process found!");

                    foreach (InjectionResults result in results)
                    {
                        ProcessInjectionResult(result);
                    }
                }
            }
        }

        private void AutoCheckUpdatesBx_OnCheckChanged(object sender, EventArgs e)
        {
            UserConfig.AutoCheckUpdates.SetValue(AutoCheckUpdatesBx.BoxChecked).Save();

            if (AutoCheckUpdatesBx.BoxChecked)
            {
                CheckForUpdates(true, true);
            }
        }

        private void AutoInstallBx_OnCheckChanged(object sender, EventArgs e)
        {
            UserConfig.AutoInstallUpdates.SetValue(AutoInstallBx.BoxChecked).Save();
        }

        private void PreventInjectionBx_OnCheckChanged(object sender, EventArgs e)
        {
            UserConfig.PreventInjection_EAC.SetValue(PreventInjectionBx.BoxChecked).Save();
        }

        private void RunOnStartupBx_OnCheckChanged(object sender, EventArgs e)
        {
            UserConfig.RunOnStartup.SetValue(RunOnStartupBx.BoxChecked).Save();
            RegistryKey startKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (startKey != null)
            {
                if (RunOnStartupBx.BoxChecked)
                {
                    Logger.Write("(RunOnStartupBx) Setting run on start registry value to \"" + Application.ExecutablePath + "\"...");
                    startKey.SetValue(Assembly.GetProduct(), Application.ExecutablePath);
                }
                else
                {
                    Logger.Write("(RunOnStartupBx) Deleting run on start registry key...");
                    startKey.DeleteValue(Assembly.GetProduct(), false);
                }

                startKey.Close();
            }
        }

        private void MinimizeOnStartupBx_OnCheckChanged(object sender, EventArgs e)
        {
            UserConfig.MinimizeOnStartup.SetValue(MinimizeOnStartupBx.BoxChecked).Save();
        }

        private void HideWhenMinimizedBx_OnCheckChanged(object sender, EventArgs e)
        {
            UserConfig.HideWhenMinimized.SetValue(HideWhenMinimizedBx.BoxChecked).Save();
        }

        private void InjectAllInstancesBx_OnCheckChanged(object sender, EventArgs e)
        {
            UserConfig.InjectAllInstances.SetValue(InjectAllInstancesBx.BoxChecked).Save();
        }

        private void ManualInjectBx_OnCheckChanged(object sender, EventArgs e)
        {
            if (ManualInjectBx.BoxChecked)
            {
                UserConfig.InjectionType.SetValue(InjectionTypes.Manual.ToString()).Save();

                if (LibraryManager.AnyProcessRunning())
                {
                    if (InjectTmr.Enabled)
                    {
                        InjectTmr.Stop();
                    }
                }
            }
            else
            {
                UserConfig.InjectionType.SetValue(InjectionTypes.Timeout.ToString()).Save();
            }
        }

        private void LightModeBx_OnCheckChanged(object sender, EventArgs e)
        {
            UserConfig.LightMode.SetValue(LightModeBx.BoxChecked).Save();
            UpdateTheme();
        }

        private void InjectionTimeoutBx_OnValueChanged(object sender, EventArgs e)
        {
            if (UserConfig.InjectionTimeoutRange.IsInRange(InjectionTimeoutBx.Value))
            {
                UserConfig.InjectionTimeout.SetValue(InjectionTimeoutBx.Value).Save();
                InjectTmr.Interval = InjectionTimeoutBx.Value;
            }
        }

        private void InstallPathBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (!LibraryManager.AnyProcessRunning())
            {
                Architecture.Path modulePath = LocalStorage.GetModulePath();

                if (modulePath.Exists())
                {
                    Architecture.Path newPath = new Architecture.Path();
                    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        newPath = new Architecture.Path(folderBrowser.SelectedPath);

                        if (newPath.Exists())
                        {
                            if (!newPath.GetPath().Contains("CodeRed"))
                            {
                                newPath.Append("CodeRed").CreateDirectory();
                            }
                        }

                        Logger.Write("(InstallPathBtn) User selected \"" + folderBrowser.SelectedPath + "\" for new install path.");
                    }

                    if (newPath.Exists())
                    {
                        if (modulePath != newPath)
                        {
                            PathPopup.ShowPopup();
                            Extensions.Filesystem.CopyDirectory(modulePath.GetPath(), newPath.GetPath(), true);
                            Directory.Delete(modulePath.GetPath(), true);

                            Installer.ModifyRegistry(false, newPath);
                            UserConfig.Invalidate(true);
                            LocalStorage.Invalidate(true);
                            ConfigToInterface();
                            StorageToInterface();
                            PathPopup.HidePopup();
                        }
                        else
                        {
                            Logger.Write("(InstallPathBtn) Selected path is the same as the current one, cannot move install path!", LogLevel.Warning);
                        }
                    }
                    else
                    {
                        Logger.Write("(InstallPathBtn) Selected path is invalid, cannot move install path!", LogLevel.Error);
                    }
                }
            }
        }

        private void OpenFolderBtn_OnButtonClick(object sender, EventArgs e)
        {
            Architecture.Path folderPath = LocalStorage.GetModulePath();

            if (folderPath.Exists())
            {
                Process.Start(new ProcessStartInfo(folderPath.GetPath()) { UseShellExecute = true });
            }
        }

        private void ExportLogsBtn_OnButtonClick(object sender, EventArgs e)
        {
            Architecture.Path modulePath = LocalStorage.GetModulePath();
            Architecture.Path launchPath = (modulePath / "Settings" / "Launcher.cr");
            Architecture.Path variablesPath = (modulePath / "Settings" / "Variables.cr");
            Architecture.Path logsPath = (LocalStorage.GetGamesPath() / "TAGame" / "Logs");

            if (modulePath.Exists())
            {
                Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

                if (tempFolder.Exists())
                {
                    Logger.Write("(ExportLogsBtn) Old temporary folder found, deleting...");
                    Directory.Delete(tempFolder.GetPath(), true);
                }

                List<string> filesToExport = new List<string>();
                List<Architecture.Path> moduleFiles = modulePath.GetFiles(true);

                foreach (Architecture.Path file in moduleFiles)
                {
                    if (file.Exists())
                    {
                        string filePath = file.GetPath();

                        if (filePath.Contains(".log"))
                        {
                            filesToExport.Add(filePath);
                        }
                    }
                }

                if (launchPath.Exists())
                {
                    filesToExport.Add(launchPath.GetPath());
                }

                if (variablesPath.Exists())
                {
                    filesToExport.Add(variablesPath.GetPath());
                }

                if (logsPath.Exists())
                {
                    List<Architecture.Path> logFiles = logsPath.GetFiles();

                    foreach (Architecture.Path file in logFiles)
                    {
                        if (file.Exists())
                        {
                            string filePath = file.GetPath();

                            if (filePath.Contains(".mdump") || filePath.Contains(".mdmp") || filePath.Contains(".dmp") || filePath.Contains(".log"))
                            {
                                filesToExport.Add(filePath);
                            }
                        }
                    }
                }

                if (filesToExport.Count > 0)
                {
                    MessageBox.Show("Found \"" + filesToExport.Count.ToString() + "\" files to export, select a folder to export them to!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        Directory.CreateDirectory(tempFolder.GetPath());

                        if (Directory.Exists(tempFolder.GetPath()))
                        {
                            string zipName = ("crash_logs_" + DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
                            Architecture.Path zipFolder = (tempFolder / zipName);
                            Directory.CreateDirectory(zipFolder.GetPath());

                            if (zipFolder.Exists())
                            {
                                Logger.Write("(ExportLogsBtn) Found \"" + filesToExport.Count + "\" files to export.");

                                foreach (string file in filesToExport)
                                {
                                    if (File.Exists(file))
                                    {
                                        FileInfo fileInfo = new FileInfo(file);
                                        File.Copy(file, (zipFolder / fileInfo.Name).GetPath());
                                    }
                                }

                                Architecture.Path zipFile = (tempFolder / (zipName + ".zip"));
                                ZipFile.CreateFromDirectory(zipFolder.GetPath(), zipFile.GetPath());
                                File.Move(zipFile.GetPath(), (folderBrowser.SelectedPath + "\\" + zipName + ".zip"));
                                Directory.Delete(tempFolder.GetPath(), true);
                                MessageBox.Show("Successfully exported \"" + filesToExport.Count.ToString() + "\" files to: " + folderBrowser.SelectedPath.ToString(), Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There were no crash dumps or logs found to export!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CheckUpdatesBtn_OnButtonClick(object sender, EventArgs e)
        {
            CheckUpdatesBtn.ButtonEnabled = false;
            CheckForUpdates(true, true);
        }

        private void EasterEggImg_Click(object sender, EventArgs e)
        {
            if (EasterEggImg.BackgroundImage == null)
            {
                EasterEggImg.BackgroundImage = (UserConfig.ShouldUseLightMode() ? Properties.Resources.Cupcake_Purple : Properties.Resources.Cupcake_Red);
            }
            else
            {
                EasterEggImg.BackgroundImage = null;
                Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=HU5Qq97cxvU") { UseShellExecute = true });
            }
        }

        private void ProcessTmr_Tick(object sender, EventArgs e)
        {
            if (LibraryManager.AnyProcessRunning())
            {
                if ((ProcessCtrl.View != ProcessViews.Injecting) && (ProcessCtrl.View != ProcessViews.Manual))
                {
                    Logger.Write("(ProcessTmr) Process is running!");

                    if (LocalStorage.DetectedAntiCheat() && UserConfig.ShouldPreventEACInjection())
                    {
                        Logger.Write("(ProcessTmr) Prevented injection, easy anti-cheat detected!");
                        InjectTmr.Stop();
                        return;
                    }

                    if (!Updater.IsOutdated())
                    {
                        CheckForUpdates(true, false);
                        ProcessCtrl.View = ProcessViews.Running;
                    }
                    else
                    {
                        ProcessCtrl.View = ProcessViews.Outdated;
                    }

                    if (Updater.IsOutdated())
                    {
                        Logger.Write("(ProcessTmr) Prevented injection, updater returned out of date!");
                        ProcessCtrl.View = ProcessViews.Outdated;
                        InjectTmr.Stop();
                    }
                    else
                    {
                        if (UserConfig.InjectionType.GetStringValue() == InjectionTypes.Manual.ToString())
                        {
                            ManualInjectBtn.BringToFront();
                            ManualInjectBtn.Visible = true;
                            ProcessCtrl.View = ProcessViews.Manual;
                            InjectTmr.Stop();
                        }
                        else
                        {
                            ManualInjectBtn.SendToBack();
                            ManualInjectBtn.Visible = false;
                            ProcessCtrl.View = ProcessViews.Injecting;
                            InjectTmr.Start();
                        }
                    }
                }
            }
            else
            {
                InjectTmr.Stop();
                ManualInjectBtn.SendToBack();
                ManualInjectBtn.Visible = false;
                ProcessCtrl.View = ProcessViews.Idle;
            }
        }

        private void InjectTmr_Tick(object sender, EventArgs e)
        {
            if (!UserConfig.OfflineMode.GetBoolValue())
            {
                if (Updater.IsOutdated())
                {
                    Logger.Write("(InjectTmr) Prevented injection, updater returned out of date!");
                    ProcessCtrl.View = ProcessViews.Outdated;
                    InjectTmr.Stop();
                    return;
                }
            }

            if (LocalStorage.DetectedAntiCheat() && UserConfig.ShouldPreventEACInjection())
            {
                Logger.Write("(InjectTmr) Prevented injection, easy anti-cheat detected!");
                InjectTmr.Stop();
                ManualInjectBtn.Visible = false;
            }

            if (UserConfig.GetInjectionType() == InjectionTypes.Manual)
            {
                ProcessCtrl.View = ProcessViews.Manual;
                ManualInjectBtn.Visible = true;
                return;
            }
            else
            {
                ManualInjectBtn.Visible = false;
            }

            if (!UserConfig.ShouldInjectAll())
            {
                List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                if (processes.Count > 0)
                {
                    Logger.Write("(InjectTmr) Process found!");
                    ProcessInjectionResult(LibraryManager.TryLoadIndividual(processes[0], LocalStorage.GetLibraryFile()));
                }

                InjectTmr.Stop();
            }
            else
            {
                List<InjectionResults> results = LibraryManager.TryLoadDynamic(LocalStorage.GetLibraryFile());

                if (results.Count > 0)
                {
                    Logger.Write("(InjectTmr) Process found!");

                    foreach (InjectionResults result in results)
                    {
                        ProcessInjectionResult(result);
                    }
                }

                InjectTmr.Stop();
            }
        }

        private void UpdateTmr_Tick(object sender, EventArgs e)
        {
            if (!Updater.IsOutdated())
            {
                Logger.Write("(UpdateTmr) Auto checking for updates...");
                CheckForUpdates(true, true);
            }
            else
            {
                UpdateTmr.Stop();
            }
        }

        void ProcessInjectionResult(InjectionResults injectionResult)
        {
            ProcessCtrl.Result = injectionResult;

            switch (injectionResult)
            {
                case InjectionResults.UnhandledException:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText, LogLevel.Error);
                    break;
                case InjectionResults.LibraryNotFound:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText, LogLevel.Error);
                    break;
                case InjectionResults.ProcessNotFound:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText, LogLevel.Warning);
                    InjectTmr.Stop();
                    break;
                case InjectionResults.HandleNotFound:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText, LogLevel.Error);
                    InjectTmr.Stop();
                    break;
                case InjectionResults.KernelNotFound:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText, LogLevel.Fatal);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.LoadLibraryNotFound:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText, LogLevel.Fatal);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.AllocateFail:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText, LogLevel.Error);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.WriteFail:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText, LogLevel.Error);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.ThreadFail:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText, LogLevel.Error);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.Success:
                    Logger.Write("(ProcessInjectionResult) " + ProcessCtrl.DescriptionText);
                    break;
                default:
                    break;
            }
        }

        private void CheckForInstances()
        {
            List<Process> launchers = new List<Process>();
            Process[] processList = Process.GetProcessesByName("CodeRedLauncher");

            foreach (Process process in processList)
            {
                if (process.ProcessName.Contains("CodeRedLauncher") || process.MainWindowTitle.Contains("CodeRed Launcher"))
                {
                    launchers.Add(process);
                }
            }

            if (launchers.Count > 1)
            {
                DuplicatePopup.Bind(this, TitleBar);
                DuplicatePopup.ShowPopup();
            }
            else
            {
                DuplicatePopup.HidePopup();
                StartupRoutine();
            }
        }

        private void SetupUserInterface()
        {
            this.Text = Assembly.GetTitle();
            TabPnl.BringToFront();

            TitleBar.BoundForm = this;
            TitleBar.DisplayText = Assembly.GetTitle().ToUpper();
            TitleBar.BringToFront();

            DuplicatePopup.Bind(this, TitleBar);
            InstallPopup.Bind(this, TitleBar);
            PathPopup.Bind(this, TitleBar);
            OfflinePopup.Bind(this, TitleBar);
            UpdatePopup.Bind(this, TitleBar);

            TabManager.BindControl(TabCtrl);
            TabManager.BindTab(Tabs.Dashboard, DashboardTabBtn, DashboardTab);
            TabManager.BindTab(Tabs.News, NewsTabBtn, NewsTab);
            TabManager.BindTab(Tabs.Settings, SettingsTabBtn, SettingsTab);
            TabManager.BindTab(Tabs.About, AboutTabBtn, AboutTab);
            TabManager.BindTab(Tabs.Exit, ExitTabBtn, null);
            TabManager.SelectTab(Tabs.Dashboard);

            UpdateTheme();
        }

        private async void StartupRoutine(bool bInvalidate = false)
        {
            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                Logger.Write("(StartupRoutine) Old launcher folder found, deleting...");
                Directory.Delete(tempFolder.GetPath(), true); // This is to cleanup anything left over by the auto updater program.
            }

            UserConfig.CheckInitialized();
            ContinuePolicy(false);
        }

        private async void ContinuePolicy(bool bInvalidate)
        {
            if (!LocalStorage.HasCodeRedRegistry() || !LocalStorage.GetModulePath().Exists())
            {
                if (await RemoteStorage.CheckInitialized())
                {
                    InstallPopup.ShowPopup();
                }
                else
                {
                    OfflinePopup.View = OfflineViews.Installer;
                    OfflinePopup.ShowPopup();
                }

                return;
            }

            if (bInvalidate)
            {
                LocalStorage.Invalidate(true);
                RemoteStorage.Invalidate();
            }

            Logger.CheckInitialized(); // Create and initialize the log file for the launcher.

            if (UserConfig.CheckInitialized())
            {
                if (await RemoteStorage.CheckInitialized())
                {
                    if (await Downloaders.WebsiteOnline(RemoteStorage.GetRemoteURL()) == false)
                    {
                        OfflinePopup.View = OfflineViews.Default;
                        OfflinePopup.ShowPopup();
                    }
                    else
                    {
                        ContinueStartup(false);
                    }
                }
                else
                {
                    OfflinePopup.View = OfflineViews.Default;
                    OfflinePopup.ShowPopup();
                }
            }
            else
            {
                if (!LocalStorage.GetLibraryFile().Exists())
                {
                    await Installer.DownloadModule();
                    StartupRoutine(true);
                }
                else
                {
                    ContinueStartup(false);
                }
            }

            ConfigToInterface(); // Retrieves the users configuration settings and assigns it to the UI.
            StorageToInterface(); // Retrieves Rocket League paths, version, and platform info to then assign to the UI.
        }

        private async void ContinueStartup(bool bInvalidate)
        {
            if (!UserConfig.OfflineMode.GetBoolValue())
            {
                if (bInvalidate)
                {
                    RemoteStorage.Invalidate();
                }

                if (UserConfig.ShouldCheckForUpdates())
                {
                    await CheckForUpdates(false, true);
                }
                else
                {
                    VersionCtrl.View = VersionViews.Idle;
                    RetrieversToInterface();
                    NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                }
            }
            else
            {
                ChangelogCtrl.View = ChangelogViews.Offline;
            }

            if (UserConfig.ShouldMinimizeOnStartup())
            {
                this.Hide();
            }

            ProcessTmr.Start();
        }

        private async void RetrieversToInterface()
        {
            if (!UserConfig.OfflineMode.GetBoolValue())
            {
                ChangelogCtrl.ModuleText = await RemoteStorage.GetModuleChangelog();
                ChangelogCtrl.LauncherText = await RemoteStorage.GetLauncherChangelog();
                DiscordInfoCtrl.DescriptionText = await RemoteStorage.GetDiscordUrl();
                DonateInfoCtrl.DescriptionText = await RemoteStorage.GetKofiUrl();

                if (ChangelogCtrl.View == ChangelogViews.Offline)
                {
                    ChangelogCtrl.View = ChangelogViews.Module;
                }
            }
            else
            {
                ChangelogCtrl.View = ChangelogViews.Offline;
            }
        }

        private void ConfigToInterface()
        {
            if (UserConfig.CheckInitialized())
            {
                AutoCheckUpdatesBx.BoxChecked = UserConfig.ShouldCheckForUpdates();
                AutoInstallBx.BoxChecked = UserConfig.ShouldAutoInstall();
                PreventInjectionBx.BoxChecked = UserConfig.ShouldPreventEACInjection();
                RunOnStartupBx.BoxChecked = UserConfig.ShouldRunOnStartup();
                MinimizeOnStartupBx.BoxChecked = UserConfig.ShouldMinimizeOnStartup();
                HideWhenMinimizedBx.BoxChecked = UserConfig.ShouldHideWhenMinimized();
                InjectAllInstancesBx.BoxChecked = UserConfig.ShouldInjectAll();
                ManualInjectBx.BoxChecked = (UserConfig.GetInjectionType() == InjectionTypes.Manual);
                LightModeBx.BoxChecked = UserConfig.ShouldUseLightMode();
                InjectionTimeoutBx.MinimumValue = UserConfig.InjectionTimeoutRange.Minimum;
                InjectionTimeoutBx.MaximumValue = UserConfig.InjectionTimeoutRange.Maximum;
                InjectionTimeoutBx.Value = UserConfig.GetInjectionTimeout();
                InjectTmr.Interval = InjectionTimeoutBx.Value;
                UserConfig.SaveChanges();
                UpdateTheme();
            }
        }

        private async void StorageToInterface()
        {
            if (LocalStorage.CheckInitialized())
            {
                InstallPathBx.DisplayText = LocalStorage.GetModulePath().GetPath();
                LauncherInfoCtrl.DescriptionText = Assembly.GetVersion();
                ModuleInfoCtrl.DescriptionText = LocalStorage.GetModuleVersion();
                PsyonixInfoCtrl.DescriptionText = LocalStorage.GetPsyonixVersion();
                BuildInfoCtrl.DescriptionText = LocalStorage.GetNetBuild().ToString();
                PlatformInfoCtrl.DescriptionText = LocalStorage.GetPlatformString(false);
                CreditsLbl.Text = "CodeRed was created by ItsBrank, but its creation would not have been possible without the inspiration of the following people: ";
                CreditsLbl.Text += await RemoteStorage.GetCredits();
            }
        }

        private void UpdateTheme()
        {
            bool lightMode = LightModeBx.BoxChecked;
            ControlTheme control = (lightMode ? ControlTheme.Light : ControlTheme.Dark);

            // Main
            {
                this.BackColor = (lightMode ? GPalette.DarkGrey : GPalette.PureBlack);
                TabManager.Theme = control;
                TitleBar.Theme = control;
                TabPnl.BackColor = (lightMode ? GPalette.White : GPalette.LightBlack);
                DuplicatePopup.Theme = control;
                InstallPopup.Theme = control;
                PathPopup.Theme = control;
                OfflinePopup.Theme = control;
                UpdatePopup.Theme = control;
            }

            // Dashboard
            {
                DashboardArtOne.BackgroundImage = (lightMode ? Properties.Resources.TL0_Purple : Properties.Resources.TL0_Red);
                DashboardArtTwo.BackgroundImage = (lightMode ? Properties.Resources.BR0_Purple : Properties.Resources.BR0_Red);
                ProcessCtrl.Theme = control;
                VersionCtrl.Theme = control;
                ChangelogCtrl.Theme = control;
                ManualInjectBtn.Theme = control;
            }

            // News
            {
                NewsArtOne.BackgroundImage = (lightMode ? Properties.Resources.TL2_Light : Properties.Resources.TL2_Dark);
                NewsArtTwo.BackgroundImage = (lightMode ? Properties.Resources.TR0_Purple : Properties.Resources.TR0_Red);
                NewsCtrl.Theme = control;
            }

            // Settings
            {
                SettingsArtOne.BackgroundImage = (lightMode ? Properties.Resources.TR3_Light : Properties.Resources.TR3_Dark);
                SettingsArtTwo.BackgroundImage = (lightMode ? Properties.Resources.BR3_Light : Properties.Resources.BR3_Dark);
                AutoCheckUpdatesBx.Theme = control;
                AutoInstallBx.Theme = control;
                PreventInjectionBx.Theme = control;
                RunOnStartupBx.Theme = control;
                MinimizeOnStartupBx.Theme = control;
                HideWhenMinimizedBx.Theme = control;
                InjectAllInstancesBx.Theme = control;
                ManualInjectBx.Theme = control;
                LightModeBx.Theme = control;
                InjectionTimeoutLbl.Theme = control;
                InjectionTimeoutBx.Theme = control;
                InstallPathLbl.Theme = control;
                InstallPathBx.Theme = control;
                InstallPathBtn.Theme = control;
                OpenFolderBtn.Theme = control;
                ExportLogsBtn.Theme = control;
            }

            // About
            {
                AboutArtOne.BackgroundImage = (lightMode ? Properties.Resources.TR4_Light : Properties.Resources.TR4_Dark);
                LauncherInfoCtrl.Theme = control;
                ModuleInfoCtrl.Theme = control;
                PsyonixInfoCtrl.Theme = control;
                BuildInfoCtrl.Theme = control;
                PlatformInfoCtrl.Theme = control;
                WebsiteInfoCtrl.Theme = control;
                DiscordInfoCtrl.Theme = control;
                DonateInfoCtrl.Theme = control;
                RemixInfoCtrl.Theme = control;
                CheckUpdatesBtn.Theme = control;
                CreditsLbl.ForeColor = (lightMode ? GPalette.DarkGrey : GPalette.LightGrey);

                if (EasterEggImg.BackgroundImage != null)
                {
                    EasterEggImg.BackgroundImage = (UserConfig.ShouldUseLightMode() ? Properties.Resources.Cupcake_Purple : Properties.Resources.Cupcake_Red);
                }
            }
        }

        // If "bInvalidate" is set to true it forces the application to retrieve all local and remote information.
        private async Task<bool> CheckForUpdates(bool bInvalidate, bool bShowPrompt)
        {
            if (!Updater.IsUpdating())
            {
                if (!UserConfig.OfflineMode.GetBoolValue() || bInvalidate)
                {
                    Logger.Write("(CheckForUpdates) Checking for updates...");
                    VersionCtrl.View = VersionViews.Checking;

                    if (await RemoteStorage.CheckInitialized())
                    {
                        bool moduleOutdated = await Updater.IsModuleOutdated(bInvalidate);
                        bool launcherOutdated = await Updater.IsLauncherOutdated(bInvalidate);

                        UInt32 localVersion = LocalStorage.GetPsyonixDate();
                        UInt32 remoteVersion = await RemoteStorage.GetPsyonixDate();
                        bool ignoreModule = (localVersion > remoteVersion);

                        // If the installed Rocket League version is greater than the one retrieved remotely, an update for the module is not out yet.

                        if (ignoreModule && !launcherOutdated)
                        {
                            Logger.Write("(CheckForUpdates) CodeRed is out of date, no new module version has been released yet!");
                            Updater.OverrideModule();
                            VersionCtrl.View = VersionViews.Unsafe;

                            // Every sixty seconds this timer automatically checks for updates.

                            if (!UpdateTmr.Enabled)
                            {
                                UpdateTmr.Start();
                            }

                            NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                        }
                        else if (Updater.IsOutdated())
                        {
                            UpdateTmr.Stop();

                            // Prioritize updating the module first, then the launcher.

                            if (!ignoreModule && moduleOutdated && launcherOutdated)
                            {
                                VersionCtrl.View = VersionViews.BothOutdated;

                                if (LibraryManager.AnyProcessRunning())
                                {
                                    List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                                    if (processes.Count > 0 && LibraryManager.IsModuleLoaded(processes[0], true))
                                    {
                                        UpdatePopup.View = UpdateViews.Running;
                                    }
                                    else
                                    {
                                        UpdatePopup.View = UpdateViews.Both;
                                    }
                                }
                                else
                                {
                                    UpdatePopup.View = UpdateViews.Both;
                                }

                                if (bShowPrompt)
                                {
                                    if (UserConfig.ShouldAutoInstall() && (UpdatePopup.View != UpdateViews.Running))
                                    {
                                        UpdatePopup_ButtonClickAccept(null, null);
                                    }
                                    else
                                    {
                                        UpdatePopup.ShowPopup();
                                    }
                                }
                                else
                                {
                                    NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                                }
                            }
                            else if (!ignoreModule && moduleOutdated)
                            {
                                VersionCtrl.View = VersionViews.ModuleOutdated;

                                if (LibraryManager.AnyProcessRunning())
                                {
                                    List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                                    if ((processes.Count > 0) && LibraryManager.IsModuleLoaded(processes[0], true))
                                    {
                                        Logger.Write("(CheckForUpdates) Process found!");
                                        UpdatePopup.View = UpdateViews.Running;
                                    }
                                    else
                                    {
                                        UpdatePopup.View = UpdateViews.Module;
                                    }
                                }
                                else
                                {
                                    UpdatePopup.View = UpdateViews.Module;
                                }

                                if (bShowPrompt)
                                {
                                    if (UserConfig.ShouldAutoInstall() && (UpdatePopup.View != UpdateViews.Running))
                                    {
                                        UpdatePopup_ButtonClickAccept(null, null);
                                    }
                                    else
                                    {
                                        UpdatePopup.ShowPopup();
                                    }
                                }
                                else
                                {
                                    NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                                }
                            }
                            else if (launcherOutdated)
                            {
                                VersionCtrl.View = VersionViews.LauncherOutdated;

                                // Doesn't matter if Rocket League is open or not when updating the launcher, so no need to check if any processes are running.

                                if (bShowPrompt)
                                {
                                    UpdatePopup.View = UpdateViews.Launcher;

                                    if (UserConfig.ShouldAutoInstall())
                                    {
                                        UpdatePopup_ButtonClickAccept(null, null);
                                    }
                                    else
                                    {
                                        UpdatePopup.ShowPopup();
                                    }
                                }
                                else
                                {
                                    NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                                }
                            }
                            else
                            {
                                VersionCtrl.View = VersionViews.Safe;

                                if (UserConfig.ShouldAutoInstall())
                                {
                                    UpdatePopup_ButtonClickAccept(null, null);
                                }
                                else
                                {
                                    UpdatePopup.ShowPopup();
                                }

                                ProcessTmr.Start();
                            }
                        }
                        else
                        {
                            Logger.Write("(CheckForUpdates) No updates found!");
                            VersionCtrl.View = VersionViews.Safe;
                            NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                        }
                    }
                }
                else
                {
                    Logger.Write("(CheckForUpdates) Could not check for updates, launcher is running in offline mode!");
                }
            }

            RetrieversToInterface();
            ConfigToInterface();
            StorageToInterface();
            CheckUpdatesBtn.ButtonEnabled = true;
            return true;
        }

        private async void InstallCodeRed(bool bManuallyChoose)
        {
            Result pathResult = Installer.CreateInstallPath(bManuallyChoose);

            if (pathResult.Succeeded)
            {
                Result moduleResult = await Installer.DownloadModule();

                if (moduleResult.Succeeded)
                {
                    await CheckForUpdates(true, false);
                    StartupRoutine(true);
                    InstallPopup.HidePopup();
                }
                else if (moduleResult.HasFailReason())
                {
                    Logger.Write("(InstallCodeRed) Module fail: " + moduleResult.FailReason, LogLevel.Fatal);
                    MessageBox.Show(moduleResult.FailReason, Assembly.GetTitle());
                }
            }
            else if (pathResult.HasFailReason())
            {
                Logger.Write("(InstallCodeRed) Path fail: " + pathResult.FailReason, LogLevel.Fatal);
                MessageBox.Show(pathResult.FailReason, Assembly.GetTitle());
            }

            InstallPopup.ButtonsEnabled = true;
        }

        private void DuplicatePopup_ButtonClickAccept(object sender, EventArgs e)
        {
            DuplicatePopup.HidePopup();
            StartupRoutine();
        }

        private void DuplicatePopup_ButtonClickDeny(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void InstallPopup_ButtonClickAccept(object sender, EventArgs e)
        {
            InstallPopup.ButtonsEnabled = false;
            InstallPopup.View = InstallViews.Downloading;
            InstallCodeRed(false);
        }

        private void InstallPopup_ButtonClickDeny(object sender, EventArgs e)
        {
            InstallPopup.ButtonsEnabled = false;
            InstallPopup.View = InstallViews.Downloading;
            InstallCodeRed(true);
        }

        private void OfflinePopup_ButtonClickAccept(object sender, EventArgs e)
        {
            UserConfig.OfflineMode.SetValue(false);
            ContinueStartup(true);
            OfflinePopup.HidePopup();
        }

        private void OfflinePopup_ButtonClickDeny(object sender, EventArgs e)
        {
            UserConfig.OfflineMode.SetValue(true);
            ContinueStartup(false);
            OfflinePopup.HidePopup();
        }

        private void OfflinePopup_ButtonClickAlt(object sender, EventArgs e)
        {
            TitleBar_OnExit(null, null);
        }

        private async void UpdatePopup_ButtonClickAccept(object sender, EventArgs e)
        {
            this.TopMost = false;
            UpdatePopup.ButtonsEnabled = false;
            VersionCtrl.View = VersionViews.Downloading;

            RemoteStorage.Invalidate();
            await RemoteStorage.CheckInitialized();

            Result installResult = await Updater.InstallUpdates(UpdatePopup);
            UpdatePopup.ButtonsEnabled = true;

            if (installResult.Succeeded)
            {
                NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                UpdatePopup.HidePopup();
                ProcessTmr.Start();
                CheckForUpdates(true, false);
            }
            else if (installResult.HasFailReason())
            {
                UpdatePopup.View = UpdateViews.Fail;
            }
        }

        private async void UpdatePopup_ButtonClickDeny(object sender, EventArgs e)
        {
            NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
        }
    }
}