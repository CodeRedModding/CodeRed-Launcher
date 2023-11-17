using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CodeRedLauncher
{
    public enum InjectionTypes : byte
    {
        Timeout,
        Manual
    }

    // Stores and manages all user modifiable settings in the launcher, as well as saving them offline.
    public static class Configuration
    {
        private static bool _initialized = false;
        private static Architecture.Path _storageFile = new Architecture.Path();

        public static PublicSetting PrivacyPolicy = new PublicSetting(
            "False",
            "PrivacyPolicy",
            "Agree to the private policy.",
            "If the user has argeed to use the private policy or not."
        );

        public static PublicSetting TermsOfUse = new PublicSetting(
            "False",
            "TermsOfUse",
            "Agree to the terms of use.",
            "If the user has argeed to use the terms of use or not."
        );

        public static PublicSetting PrivacyHash = new PublicSetting(
            "0",
            "PrivacyHash",
            "The current privacy policy hash.",
            "The last known hash of the privacy policy the user agreed to"
        );

        public static PublicSetting TermsHash = new PublicSetting(
            "0",
            "TermsHash",
            "The current terms of use hash.",
            "The last known hash of the terms of use the user agreed to"
        );

        public static PublicSetting OfflineMode = new PublicSetting(
            "False",
            "OfflineMode",
            "Run the launcher in offline mode.",
            "Disables update and version checks when not connected to the internet."
        );

        public static PublicSetting AutoCheckUpdates = new PublicSetting(
            "True",
            "AutoCheckUpdates",
            "Automatically check for updates",
            "Choose to automatically check for updates and compare versions, as well as before each injection.",
            SaveChanges
        );

        public static PublicSetting AutoInstallUpdates = new PublicSetting(
            "False",
            "AutoInstallUpdates",
            "Automatically install updates in the background",
            "Automatically installs updates for you in the background if a new version is found.",
            SaveChanges
        );

        public static PublicSetting PreventInjection = new PublicSetting(
            "True",
            "PreventInjection",
            "Prevent injection when out of date",
            "Prevents injecting out of date modules into unsupported Rocket League versions.",
            SaveChanges
        );

        public static PublicSetting RunOnStartup = new PublicSetting(
            "False",
            "RunOnStartup",
            "Run on windows startup",
            "Choose to automatically open the launcher on Windows startup.",
            SaveChanges
        );

        public static PublicSetting MinimizeOnStartup = new PublicSetting(
            "False",
            "MinimizeOnStartup",
            "Minimize on startup",
            "Choose to automatically minimize the launcher when opened.",
            SaveChanges
        );

        public static PublicSetting HideWhenMinimized = new PublicSetting(
            "False",
            "HideWhenMinimized",
            "Hide when minimized",
            "Choose to automatically hide to the system tray when the launcher is minimized.",
            SaveChanges
        );

        public static PublicSetting InjectAllInstances = new PublicSetting(
            "False",
            "InjectAllInstances",
            "Inject into all game instances",
            "Choose to inject the module into all running Rocket League instances, may take up more resources.",
            SaveChanges
        );

        public static PublicSetting InjectionType = new PublicSetting(
            "Timeout",
            "InjectionType",
            "Module injection type",
            "Injection method to use by the launcher when injecting modules.",
            SaveChanges
        );

        public static PublicSetting InjectionTimeout = new PublicSetting(
            "20000",
            "InjectionTimeout",
            "Module injection timeout",
            "Time delay in milliseconds used when injecting into Rocket League.",
            SaveChanges
        );

        public static PublicSetting LightMode = new PublicSetting(
            "False",
            "LightMode",
            "Interface light mode",
            "Use light mode for all user interface elements.",
            SaveChanges
        );

        public static Architecture.Range32 InjectionTimeoutRange = new Architecture.Range32(2500, 300000); // 2.5 seconds to 5 minutes.

        private static bool ParseConfigFile()
        {
            if (_storageFile.Exists())
            {
                string[] fileLines = File.ReadAllLines(_storageFile.GetPath());

                if (fileLines.Length > 0)
                {
                    foreach (string line in fileLines)
                    {
                        try
                        {
                            if (line.Contains(PrivacyPolicy.Name)) { PrivacyPolicy.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                            if (line.Contains(TermsOfUse.Name)) { TermsOfUse.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                            if (line.Contains(PrivacyHash.Name)) { PrivacyHash.SetValue(line.Substring((PrivacyHash.Name.Length + 1), (line.Length - (PrivacyHash.Name.Length + 1)))); continue; }
                            if (line.Contains(TermsHash.Name)) { TermsHash.SetValue(line.Substring((TermsHash.Name.Length + 1), (line.Length - (TermsHash.Name.Length + 1)))); continue; }
                            if (line.Contains(AutoCheckUpdates.Name)) { AutoCheckUpdates.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                            if (line.Contains(AutoInstallUpdates.Name)) { AutoInstallUpdates.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                            if (line.Contains(PreventInjection.Name)) { PreventInjection.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                            if (line.Contains(RunOnStartup.Name)) { RunOnStartup.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                            if (line.Contains(MinimizeOnStartup.Name)) { MinimizeOnStartup.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                            if (line.Contains(HideWhenMinimized.Name)) { HideWhenMinimized.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                            if (line.Contains(InjectAllInstances.Name)) { InjectAllInstances.SetValue(line.Contains("True") ? "True" : "False"); continue; }

                            if (line.Contains(InjectionType.Name))
                            {
                                if (line.Contains("Timeout")) { InjectionType.SetValue(InjectionTypes.Timeout.ToString()); continue; }
                                if (line.Contains("Manual")) { InjectionType.SetValue(InjectionTypes.Manual.ToString()); continue; }
                            }

                            if (line.Contains(InjectionTimeout.Name))  { InjectionTimeout.SetValue(line.Substring((InjectionTimeout.Name.Length + 1), (line.Length - (InjectionTimeout.Name.Length + 1)))); continue;  }
                            if (line.Contains(LightMode.Name)) { LightMode.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                        }
                        catch (Exception ex)
                        {
                            SetDefaultSettings(true);
                            return true;
                        }
                    }

                    return true;
                }
                else
                {
                    SetDefaultSettings(true);
                }
            }
            else
            {
                SetDefaultSettings(true);
            }

            return false;
        }

        public static void Invalidate(bool bForceReset = false)
        {
            if (bForceReset)
            {
                _initialized = false;
            }

            CheckInitialized();
        }

        public static bool CheckInitialized()
        {
            if (!_initialized)
            {
                _storageFile = (Storage.GetModulePath() / "Settings" / "Launcher.cr");

                if (!_storageFile.Exists())
                {
                    _storageFile = (Storage.GetModulePath() / "Settings" / "Injector.cr"); // Old file name, have to keep for backwards compatibility.
                }

                if (_storageFile.Exists())
                {
                    if (ParseConfigFile())
                    {
                        _initialized = true;
                    }
                }
                else
                {
                    SetDefaultSettings(true);
                    _initialized = true;
                }
            }

            return _initialized;
        }

        public static void SetDefaultSettings(bool bSaveChanges = false)
        {
            _storageFile = (Storage.GetModulePath() / "Settings" / "Launcher.cr");
            PrivacyPolicy.ResetToDefault();
            TermsOfUse.ResetToDefault();
            PrivacyHash.ResetToDefault();
            TermsHash.ResetToDefault();
            AutoCheckUpdates.ResetToDefault();
            AutoInstallUpdates.ResetToDefault();
            PreventInjection.ResetToDefault();
            RunOnStartup.ResetToDefault();
            MinimizeOnStartup.ResetToDefault();
            HideWhenMinimized.ResetToDefault();
            InjectAllInstances.ResetToDefault();
            InjectionType.ResetToDefault();
            InjectionTimeout.ResetToDefault();
            LightMode.ResetToDefault();

            if (bSaveChanges)
            {
                SaveChanges();
            }
        }

        public async static void SaveChanges()
        {
            if (_storageFile.Parent().Exists())
            {
                _storageFile.Set(Storage.GetModulePath() / "Settings" / "Launcher.cr");
                Architecture.Path oldFile = (Storage.GetModulePath() / "Settings" / "Injector.cr");

                if (oldFile.Exists())
                {
                    oldFile.DeleteFile();
                }

                if (!_storageFile.Exists())
                {
                    await File.Create(_storageFile.GetPath()).DisposeAsync();
                }

                string file = _storageFile.GetPath();

                File.WriteAllText(file, string.Empty); // "Truncuating" the file without needing to open it in a stream.
                File.AppendAllText(file, PrivacyPolicy.Name + " " + PrivacyPolicy.GetStringValue() + "\n");
                File.AppendAllText(file, TermsOfUse.Name + " " + TermsOfUse.GetStringValue() + "\n");
                File.AppendAllText(file, PrivacyHash.Name + " " + PrivacyHash.GetStringValue() + "\n");
                File.AppendAllText(file, TermsHash.Name + " " + TermsHash.GetStringValue() + "\n");
                File.AppendAllText(file, AutoCheckUpdates.Name + " " + AutoCheckUpdates.GetStringValue() + "\n");
                File.AppendAllText(file, AutoInstallUpdates.Name + " " + AutoInstallUpdates.GetStringValue() + "\n");
                File.AppendAllText(file, PreventInjection.Name + " " + PreventInjection.GetStringValue() + "\n");
                File.AppendAllText(file, RunOnStartup.Name + " " + RunOnStartup.GetStringValue() + "\n");
                File.AppendAllText(file, MinimizeOnStartup.Name + " " + MinimizeOnStartup.GetStringValue() + "\n");
                File.AppendAllText(file, HideWhenMinimized.Name + " " + HideWhenMinimized.GetStringValue() + "\n");
                File.AppendAllText(file, InjectAllInstances.Name + " " + InjectAllInstances.GetStringValue() + "\n");
                File.AppendAllText(file, InjectionType.Name + " " + InjectionType.GetStringValue() + "\n");
                File.AppendAllText(file, InjectionTimeout.Name + " " + InjectionTimeout.GetStringValue() + "\n");
                File.AppendAllText(file, LightMode.Name + " " + LightMode.GetStringValue());
            }
            else
            {
                Logger.Write("Launcher settings folder doesn't exist, failed to save settings!");
            }
        }

        public static string HashMD5(string str)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }

        public static bool AgreedToPolicy()
        {
            if (CheckInitialized()) { return PrivacyPolicy.GetBoolValue(); }
            return PrivacyPolicy.GetBoolValue(true);
        }

        public static bool AgreedToTerms()
        {
            if (CheckInitialized()) { return TermsOfUse.GetBoolValue(); }
            return TermsOfUse.GetBoolValue(true);
        }

        public static string GetPrivacyHash()
        {
            if (CheckInitialized()) { return PrivacyHash.GetStringValue(); }
            return PrivacyHash.GetStringValue(true);
        }

        public static string GetTermsHash()
        {
            if (CheckInitialized()) { return TermsHash.GetStringValue(); }
            return TermsHash.GetStringValue(true);
        }

        public static bool ShouldCheckForUpdates()
        {
            if (CheckInitialized()) { return AutoCheckUpdates.GetBoolValue(); }
            return AutoCheckUpdates.GetBoolValue(true);
        }

        public static bool ShouldAutoInstall()
        {
            if (CheckInitialized()) { return AutoInstallUpdates.GetBoolValue(); }
            return AutoInstallUpdates.GetBoolValue(true);
        }

        public static bool ShouldPreventInjection()
        {
            if (CheckInitialized()) { return PreventInjection.GetBoolValue(); }
            return PreventInjection.GetBoolValue(true);
        }

        public static bool ShouldRunOnStartup()
        {
            if (CheckInitialized()) { return RunOnStartup.GetBoolValue(); }
            return RunOnStartup.GetBoolValue(true);
        }

        public static bool ShouldMinimizeOnStartup()
        {
            if (CheckInitialized()) { return MinimizeOnStartup.GetBoolValue(); }
            return MinimizeOnStartup.GetBoolValue(true);
        }

        public static bool ShouldHideWhenMinimized()
        {
            if (CheckInitialized()) { return HideWhenMinimized.GetBoolValue(); }
            return HideWhenMinimized.GetBoolValue(true);
        }

        public static bool ShouldInjectAll()
        {
            if (CheckInitialized()) { return InjectAllInstances.GetBoolValue(); }
            return InjectAllInstances.GetBoolValue(true);
        }

        public static InjectionTypes GetInjectionType()
        {
            if (CheckInitialized()) { return InjectionType.GetEnumValue<InjectionTypes>(); }
            return InjectionType.GetEnumValue<InjectionTypes>(true);
        }

        public static Int32 GetInjectionTimeout()
        {
            if (CheckInitialized()) { return InjectionTimeout.GetInt32Value(); }
            return InjectionTimeout.GetInt32Value(true);
        }

        public static bool ShouldUseLightMode()
        {
            if (CheckInitialized()) { return LightMode.GetBoolValue(); }
            return LightMode.GetBoolValue(true);
        }
    }
}