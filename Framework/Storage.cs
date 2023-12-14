using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeRedLauncher
{
    public enum PlatformTypes : byte
    {
        Unknown,
        Steam,
        Epic
    }

    public static class Storage
    {
        private static bool _initialized = false;
        private static bool _versionsValid = false;
        private static PrivateSetting _emptySetting = new PrivateSetting();
        private static PrivateSetting _gamesFolder = new PrivateSetting();
        private static PrivateSetting _logFile = new PrivateSetting();
        private static PrivateSetting _moduleFolder = new PrivateSetting();
        private static PrivateSetting _libraryFile = new PrivateSetting();
        private static PrivateSetting _steamFolder = new PrivateSetting();
        private static PrivateSetting _epicFolder = new PrivateSetting();
        private static PrivateSetting _currentPlatform = new PrivateSetting(PlatformTypes.Unknown.ToString());
        private static PrivateSetting _psyonixVersion = new PrivateSetting("000000.000000.000000");
        private static PrivateSetting _netBuild = new PrivateSetting("0");
        private static PrivateSetting _moduleVersion = new PrivateSetting("0.0.0");

        public static void Invalidate(bool bForceReset = false)
        {
            _versionsValid = false;

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
                if (!FindDirectories())
                {
                    Logger.Write("Failed to retrieve local directory information, cannot verify Rocket League version!", LogLevel.LEVEL_ERROR);
                    MessageBox.Show("Error: Failed to retrieve local directory information!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!_versionsValid)
            {
                ParseLogFile();
                ParseVersionFile();
            }

            return _initialized;
        }

        private static void ParseLogFile()
        {
            Architecture.Path gamesPath = _gamesFolder.GetPathValue();

            if (gamesPath.Exists())
            {
                Architecture.Path logFile = (gamesPath / "TAGame" / "Logs" / "Launch.log");

                if (logFile.Exists())
                {
                    _logFile.SetValue(logFile);

                    // Opening with "FileAccess.Read + FileShare.ReadWrite" is important here because RocketLeague.exe locks the log file when the game is running, without it you wouldn't be able to read its contents.
                    FileStream logStream = File.Open(logFile.GetPath(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    string logContents;

                    using (StreamReader sr = new StreamReader(logStream))
                    {
                        logContents = sr.ReadToEnd();
                    }

                    logStream.Close();

                    Match psyMatch = Regex.Match(logContents, "Log: GPsyonixBuildID (.*)\r", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    Match directoryMatch = Regex.Match(logContents, "Init: Base directory: (.*)\r", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    Match netMatch = Regex.Match(logContents, "Log: BuildID: (.*) from GPsyonixBuildID", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

                    if (psyMatch.Groups[1].Success)
                    {
                        _psyonixVersion.SetValue(psyMatch.Groups[1].Value);
                        _versionsValid = true;
                    }
                    else
                    {
                        _versionsValid = false;
                    }

                    if (netMatch.Groups[1].Success)
                    {
                        _netBuild.SetValue(netMatch.Groups[1].Value);
                    }

                    if (directoryMatch.Groups[1].Success)
                    {
                        string baseDirectory = directoryMatch.Groups[1].Value;

                        if (baseDirectory.Contains("steamapps"))
                        {
                            _steamFolder.SetValue(baseDirectory);
                            _currentPlatform.SetValue(PlatformTypes.Steam.ToString());
                        }
                        else if (baseDirectory.Contains("Epic Games"))
                        {
                            _epicFolder.SetValue(baseDirectory);
                            _currentPlatform.SetValue(PlatformTypes.Epic.ToString());
                        }
                        else
                        {
                            _currentPlatform.SetValue(PlatformTypes.Unknown.ToString());
                        }
                    }
                }
                else
                {
                    _versionsValid = false;
                }
            }
            else
            {
                _versionsValid = false;
            }
        }

        private static void ParseVersionFile()
        {
            _versionsValid = false;
            Architecture.Path moduleFolder = _moduleFolder.GetPathValue();

            if (moduleFolder.Exists())
            {
                Architecture.Path versionFile = (moduleFolder / "DLL" / "Version.txt");

                if (versionFile.Exists())
                {
                    FileStream versionStream = File.Open(versionFile.GetPath(), FileMode.Open, FileAccess.Read);
                    string versionContents;

                    using (StreamReader sr = new StreamReader(versionStream))
                    {
                        versionContents = sr.ReadToEnd();
                    }

                    if (!String.IsNullOrEmpty(versionContents))
                    {
                        _moduleVersion.SetValue(versionContents);

                        if (_moduleVersion.GetFloatValue() != _moduleVersion.GetFloatValue(true))
                        {
                            _versionsValid = true;
                        }
                    }
                }
            }
        }

        private static bool ParseRegistryKeys()
        {
            bool foundAtLeastOnePath = false;
            bool foundInstallDir = false;
            RegistryKey coderedKey = Registry.CurrentUser.OpenSubKey("CodeRedModding");

            if (coderedKey != null)
            {
                Object installObject = coderedKey.GetValue("InstallPath");

                if (installObject != null)
                {
                    Architecture.Path moduleFolder = new Architecture.Path(installObject.ToString());

                    if (moduleFolder.Exists())
                    {
                        _moduleFolder.SetValue(moduleFolder);
                        _libraryFile.SetValue(moduleFolder / "DLL" / "CodeRed.dll");
                        foundInstallDir = true;
                    }
                }

                coderedKey.Close();
            }

            if (_steamFolder.IsNull())
            {
                try
                {
                    RegistryKey steamKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Valve\\Steam");

                    if (steamKey != null)
                    {
                        Object steamObj = steamKey.GetValue("InstallPath");

                        if (steamObj != null)
                        {
                            // We are phrasing the "libraryfolders.vdf" file here because it's possibe to have Steam installed on one drive, but have the "steamapps" folder on a different drive/location.
                            // This is not stored in the registry and this file is the only place that I could find where it has path/drive info like this.
                            // If anyone has a better solution or suggestion please do create an issue in the repo, or submit your own pull request.

                            Architecture.Path libraryFile = new Architecture.Path(steamObj.ToString()).Append("steamapps").Append("libraryfolders.vdf");

                            if (libraryFile.Exists())
                            {
                                string libraryContents = File.ReadAllText(libraryFile.GetPath());
                                MatchCollection pathMatches = Regex.Matches(libraryContents, "\"path\"\t\t\"(.*)\"", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

                                foreach (Match match in pathMatches)
                                {
                                    if (match.Success && match.Groups[1].Success)
                                    {
                                        Architecture.Path steamFolder = (new Architecture.Path(match.Groups[1].Value) / "steamapps" / "common" / "rocketleague" / "Binaries" / "Win64");

                                        if (steamFolder.Exists())
                                        {
                                            _steamFolder.SetValue(steamFolder);
                                            foundAtLeastOnePath = true;
                                            break;
                                        }
                                        else
                                        {
                                            _steamFolder.SetValue("");
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                foundAtLeastOnePath = true;
            }

            if (_epicFolder.IsNull())
            {
                try
                {
                    // This appears to be broken at the moment, if anyone has any ideas on how to get the install path on the EGS please let me know.

                    RegistryKey epicKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\EpicGames\\Unreal Engine");

                    if (epicKey != null)
                    {
                        Object epicObj = epicKey.GetValue("INSTALLDIR");

                        if (epicObj != null)
                        {
                            Architecture.Path epicFolder = (new Architecture.Path(epicObj.ToString()) / "rocketleague" / "Binaries" / "Win64");

                            if (epicFolder.Exists())
                            {
                                _epicFolder.SetValue(epicFolder);
                                foundAtLeastOnePath = true;
                            }
                            else
                            {
                                _epicFolder.SetValue("");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write(ex.Message, LogLevel.LEVEL_FATAL);
                }
            }
            else
            {
                foundAtLeastOnePath = true;
            }

            if (!foundInstallDir && !foundAtLeastOnePath)
            {
                return false;
            }

            return foundInstallDir;
        }

        public static bool HasCoderedRegistry()
        {
            bool regkeyValid = false;
            RegistryKey coderedKey = Registry.CurrentUser.OpenSubKey("CodeRedModding");

            if (coderedKey != null)
            {
                Object installObject = coderedKey.GetValue("InstallPath");

                if (installObject != null)
                {
                    Architecture.Path moduleFolder = new Architecture.Path(installObject.ToString());
                    regkeyValid = moduleFolder.Exists();
                }

                coderedKey.Close();
            }

            return regkeyValid;
        }

        public static bool FindDirectories()
        {
            if (!_initialized)
            {
                Architecture.Path gamesFolder = (new Architecture.Path(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) / "My Games" / "Rocket League");

                if (gamesFolder.Exists())
                {
                    _gamesFolder.SetValue(gamesFolder);
                    ParseLogFile();
                    ParseVersionFile();

                    if (!ParseRegistryKeys())
                    {
                        if (!_moduleFolder.IsNull())
                        {
                            MessageBox.Show("Error: Failed to locate the needed registry keys!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            _initialized = true;
                        }
                    }
                    else
                    {
                        _initialized = true;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Failed to find the Rocket League games folder!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return _initialized;
        }

        public static Architecture.Path GetGamesPath()
        {
            if (CheckInitialized()) { return _gamesFolder.GetPathValue(); }
            return _emptySetting.GetPathValue();
        }

        public static Architecture.Path GetLogFile()
        {
            if (CheckInitialized()) { return _logFile.GetPathValue(); }
            return _emptySetting.GetPathValue();
        }

        public static Architecture.Path GetModulePath()
        {
            if (CheckInitialized()) { return _moduleFolder.GetPathValue(); }
            return _emptySetting.GetPathValue();
        }

        public static Architecture.Path GetLibraryFile()
        {
            if (CheckInitialized()) { return _libraryFile.GetPathValue(); }
            return _emptySetting.GetPathValue();
        }

        public static Architecture.Path GetSteamPath()
        {
            if (CheckInitialized()) { return _steamFolder.GetPathValue(); }
            return _emptySetting.GetPathValue();
        }

        public static Architecture.Path GetEpicPath()
        {
            if (CheckInitialized()) { return _epicFolder.GetPathValue(); }
            return _emptySetting.GetPathValue();
        }

        public static PlatformTypes GetCurrentPlatform(bool bInvalidate)
        {
            if (bInvalidate)
            {
                Invalidate();
            }

            if (CheckInitialized()) { return _currentPlatform.GetEnumValue<PlatformTypes>(); }
            return _currentPlatform.GetEnumValue<PlatformTypes>(true);
        }

        public static string GetPlatformString(bool bInvalidate)
        {
            PlatformTypes platformType = GetCurrentPlatform(bInvalidate);

            switch (platformType)
            {
                case PlatformTypes.Steam:
                    return "Steam";
                case PlatformTypes.Epic:
                    return "Epic Games";
                default:
                    return "Unknown";
            }
        }

        public static string GetPsyonixVersion()
        {
            if (CheckInitialized()) { return _psyonixVersion.GetStringValue(); }
            return _psyonixVersion.GetStringValue(true);
        }

        // The first six numbers in the Psyonix version string is actually a date timestamp.
        // First two numbers are the year, second two are the month, and last two are the day.
        public static UInt32 GetPsyonixDate()
        {
            if (CheckInitialized())
            {
                string psyonixVersion = _psyonixVersion.GetStringValue();
                string buildDate = psyonixVersion.Substring(0, psyonixVersion.IndexOf("."));

                if (Extensions.Strings.IsStringDecimal(buildDate))
                {
                    return UInt32.Parse(buildDate);
                }
            }

            return 0;
        }

        public static Int32 GetNetBuild()
        {
            if (CheckInitialized()) { return _netBuild.GetInt32Value(); }
            return _netBuild.GetInt32Value(true);
        }

        public static string GetModuleVersion()
        {
            if (CheckInitialized()) { return _moduleVersion.GetStringValue(); }
            return _moduleVersion.GetStringValue(true);
        }
    }
}
