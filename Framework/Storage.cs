using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CodeRedLauncher.Architecture;
using System.Text;

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
        private static bool m_initialized = false;
        private static bool m_versionsValid = false;
        private static bool m_directoriesValid = true;
        private static PrivateSetting m_emptySetting = new PrivateSetting();
        private static PrivateSetting m_gamesFolder = new PrivateSetting();
        private static PrivateSetting m_logFile = new PrivateSetting();
        private static PrivateSetting m_moduleFolder = new PrivateSetting();
        private static PrivateSetting m_libraryFile = new PrivateSetting();
        private static PrivateSetting m_steamFolder = new PrivateSetting();
        private static PrivateSetting m_epicFolder = new PrivateSetting();
        private static PrivateSetting m_currentPlatform = new PrivateSetting(PlatformTypes.Unknown.ToString());
        private static PrivateSetting m_psyonixVersion = new PrivateSetting("000000.000000.000000");
        private static PrivateSetting m_netBuild = new PrivateSetting("0");
        private static PrivateSetting m_moduleVersion = new PrivateSetting("0.0.0");

        public static void Invalidate(bool bForceReset = false)
        {
            m_versionsValid = false;

            if (bForceReset)
            {
                m_initialized = false;
            }

            CheckInitialized();
        }

        public static bool CheckInitialized()
        {
            if (!m_initialized)
            {
                if (!FindDirectories())
                {
                    Logger.Write("Failed to retrieve local directory information, cannot verify Rocket League version!", LogLevel.LEVEL_ERROR);
                    MessageBox.Show("Error: Failed to retrieve local directory information!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!m_versionsValid)
            {
                ParseLogFile();
                ParseVersionFile();
            }

            return m_initialized;
        }

        private static void ParseLogFile()
        {
            Architecture.Path gamesPath = m_gamesFolder.GetPathValue();

            if (gamesPath.Exists())
            {
                Architecture.Path logFile = (gamesPath / "TAGame" / "Logs" / "Launch.log");

                if (logFile.Exists())
                {
                    m_logFile.SetValue(logFile);

                    // Opening with "FileAccess.Read + FileShare.ReadWrite" is important here because RocketLeague.exe locks the log file when the game is running, without it you wouldn't be able to read its contents.
                    FileStream logStream = File.Open(logFile.GetPath(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    string logContents;

                    using (StreamReader stream = new StreamReader(logStream))
                    {
                        logContents = stream.ReadToEnd();
                    }

                    logStream.Close();

                    Match psyMatch = Regex.Match(logContents, "Log: GPsyonixBuildID (.*)\r", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    Match directoryMatch = Regex.Match(logContents, "Init: Base directory: (.*)\r", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    Match netMatch = Regex.Match(logContents, "Log: BuildID: (.*) from GPsyonixBuildID", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

                    if (psyMatch.Groups[1].Success)
                    {
                        m_psyonixVersion.SetValue(psyMatch.Groups[1].Value);
                        m_versionsValid = true;
                    }
                    else
                    {
                        m_versionsValid = false;
                    }

                    if (netMatch.Groups[1].Success)
                    {
                        m_netBuild.SetValue(netMatch.Groups[1].Value);
                    }

                    if (directoryMatch.Groups[1].Success)
                    {
                        string baseDirectory = directoryMatch.Groups[1].Value;

                        if (baseDirectory.Contains("steamapps"))
                        {
                            m_steamFolder.SetValue(baseDirectory);
                            m_currentPlatform.SetValue(PlatformTypes.Steam.ToString());
                        }
                        else if (baseDirectory.Contains("Epic Games"))
                        {
                            m_epicFolder.SetValue(baseDirectory);
                            m_currentPlatform.SetValue(PlatformTypes.Epic.ToString());
                        }
                        else
                        {
                            m_currentPlatform.SetValue(PlatformTypes.Unknown.ToString());
                        }
                    }
                }
                else
                {
                    m_versionsValid = false;
                }
            }
            else
            {
                m_versionsValid = false;
            }
        }

        private static void ParseVersionFile()
        {
            if (!Updator.IsUpdating())
            {
                m_versionsValid = false;
                Architecture.Path moduleFolder = m_moduleFolder.GetPathValue();

                if (moduleFolder.Exists())
                {
                    Architecture.Path versionFile = (moduleFolder / "DLL" / "Version.txt");

                    if (versionFile.Exists())
                    {
                        string versionContents;

                        using (StreamReader stream = new StreamReader(versionFile.GetPath()))
                        {
                            versionContents = stream.ReadToEnd();
                        }

                        if (!string.IsNullOrEmpty(versionContents))
                        {
                            m_moduleVersion.SetValue(versionContents);

                            if (m_moduleVersion.GetFloatValue() != m_moduleVersion.GetFloatValue(true))
                            {
                                m_versionsValid = true;
                            }
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
                        m_moduleFolder.SetValue(moduleFolder);
                        m_libraryFile.SetValue(moduleFolder / "DLL" / "CodeRed.dll");
                        foundInstallDir = true;
                    }
                }

                coderedKey.Close();
            }

            if (m_steamFolder.IsNull())
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
                                            m_steamFolder.SetValue(steamFolder);
                                            foundAtLeastOnePath = true;
                                            break;
                                        }
                                        else
                                        {
                                            m_steamFolder.SetValue("");
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
                    Logger.Write("Steam Path Fail: " + ex.Message, LogLevel.LEVEL_WARN);
                }
            }
            else
            {
                foundAtLeastOnePath = true;
            }

            if (m_epicFolder.IsNull())
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
                                m_epicFolder.SetValue(epicFolder);
                                foundAtLeastOnePath = true;
                            }
                            else
                            {
                                m_epicFolder.SetValue("");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write("Epic Path Fail: " + ex.Message, LogLevel.LEVEL_WARN);
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
            if (!m_initialized && m_directoriesValid)
            {
                Architecture.Path gamesFolder = (new Architecture.Path(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) / "My Games" / "Rocket League");

                if (gamesFolder.Exists())
                {
                    m_gamesFolder.SetValue(gamesFolder);
                    ParseLogFile();
                    ParseVersionFile();

                    if (!ParseRegistryKeys())
                    {
                        if (!m_moduleFolder.IsNull())
                        {
                            MessageBox.Show("Error: Failed to locate the needed registry keys for CodeRed!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            m_initialized = true;
                        }
                    }
                    else
                    {
                        m_initialized = true;
                    }
                }
                else
                {
                    m_directoriesValid = false;
                    MessageBox.Show("Error: Failed to locate your Rocket League path, this could either be a result of not having the game installed or your antivirus is blocking CodeRed!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }

            return m_initialized;
        }

        public static Architecture.Path GetGamesPath()
        {
            if (CheckInitialized()) { return m_gamesFolder.GetPathValue(); }
            return m_emptySetting.GetPathValue();
        }

        public static Architecture.Path GetLogFile()
        {
            if (CheckInitialized()) { return m_logFile.GetPathValue(); }
            return m_emptySetting.GetPathValue();
        }

        public static Architecture.Path GetModulePath()
        {
            if (CheckInitialized()) { return m_moduleFolder.GetPathValue(); }
            return m_emptySetting.GetPathValue();
        }

        public static Architecture.Path GetLibraryFile()
        {
            if (CheckInitialized()) { return m_libraryFile.GetPathValue(); }
            return m_emptySetting.GetPathValue();
        }

        public static Architecture.Path GetSteamPath()
        {
            if (CheckInitialized()) { return m_steamFolder.GetPathValue(); }
            return m_emptySetting.GetPathValue();
        }

        public static Architecture.Path GetEpicPath()
        {
            if (CheckInitialized()) { return m_epicFolder.GetPathValue(); }
            return m_emptySetting.GetPathValue();
        }

        public static PlatformTypes GetCurrentPlatform(bool bInvalidate)
        {
            if (bInvalidate)
            {
                Invalidate();
            }

            if (CheckInitialized()) { return m_currentPlatform.GetEnumValue<PlatformTypes>(); }
            return m_currentPlatform.GetEnumValue<PlatformTypes>(true);
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
            if (CheckInitialized()) { return m_psyonixVersion.GetStringValue(); }
            return m_psyonixVersion.GetStringValue(true);
        }

        // The first six numbers in the Psyonix version string is actually a date timestamp.
        // First two numbers are the year, second two are the month, and last two are the day.
        public static UInt32 GetPsyonixDate()
        {
            if (CheckInitialized())
            {
                string psyonixVersion = m_psyonixVersion.GetStringValue();
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
            if (CheckInitialized()) { return m_netBuild.GetInt32Value(); }
            return m_netBuild.GetInt32Value(true);
        }

        public static string GetModuleVersion()
        {
            if (CheckInitialized()) { return m_moduleVersion.GetStringValue(); }
            return m_moduleVersion.GetStringValue(true);
        }
    }
}