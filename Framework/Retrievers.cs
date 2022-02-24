using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CodeRedLauncher
{
    public static class Downloaders
    {
        public static async Task<string> DownloadPage(string url)
        {
            string pageContent = "";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    pageContent = await response.Content.ReadAsStringAsync();
                }
            }

            return pageContent;
        }

        public static async Task<bool> DownloadFile(string url, Path folder, string fileName)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string path = folder.GetPath() + fileName;
                    byte[] file = await response.Content.ReadAsByteArrayAsync();

                    if (file.Length > 0)
                    {
                        File.Create(path);

                        if (File.Exists(path))
                        {
                            File.WriteAllBytes(path, file);
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }


    public static class CRJson
    {
        private static bool CharacterSeqMatch(string baseStr, string matchStr, Int32 startOffset)
        {
            Int32 matches = 0;

            if ((baseStr.Length - startOffset) + matchStr.Length <= baseStr.Length)
            {
                for (Int32 i = 0; i < matchStr.Length; i++)
                {
                    if (baseStr[startOffset + i] == matchStr[i])
                    {
                        matches++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return (matches == matchStr.Length);
        }

        public static string StripPageBody(string pageContent)
        {
            string returnBody = "";
            bool reconstruct = false;

            for (Int32 i = 0; i < pageContent.Length; i++)
            {
                if (i + 6 <= pageContent.Length)
                {
                    if (!reconstruct)
                    {
                        if (CharacterSeqMatch(pageContent, "<body>", i))
                        {
                            reconstruct = true;
                            i += 6;
                        }
                    }
                    else
                    {
                        if (!CharacterSeqMatch(pageContent, "</body>", i))
                        {
                            returnBody += pageContent[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return returnBody;
        }

        // Super duper specific case only for this project, I don't need to make it support anything other than strings becasue I'm only using strings.
        public static Dictionary<string, string> ParseJSONStrings(string jsonString)
        {
            List<string> keys = new List<string>();
            List<string> values = new List<string>();

            bool keyStart = false;
            bool valueStart = false;
            string currentKey = "";
            string currentValue = "";

            for (Int32 i = 0; i < jsonString.Length; i++)
            {
                if (i + 1 <= jsonString.Length)
                {
                    if (jsonString[i] == '"')
                    {
                        if (jsonString[i - 1] == '\t')
                        {
                            keyStart = true;
                            valueStart = false;
                        }
                        else if (jsonString[i - 2] == ':')
                        {
                            keyStart = false;
                            valueStart = true;
                        }
                        else
                        {
                            keyStart = false;
                            valueStart = false;
                        }

                        if (!String.IsNullOrEmpty(currentKey))
                        {
                            keys.Add(currentKey);
                            currentKey = "";
                        }

                        if (!String.IsNullOrEmpty(currentValue))
                        {
                            values.Add(currentValue);
                            currentValue = "";
                        }
                    }
                    else
                    {
                        if (keyStart)
                        {
                            currentKey += jsonString[i];
                        }
                        else if (valueStart)
                        {
                            currentValue += jsonString[i];
                        }
                    }
                }
            }

            if (!String.IsNullOrEmpty(currentKey))
            {
                keys.Add(currentKey);
            }

            if (!String.IsNullOrEmpty(currentValue))
            {
                values.Add(currentValue);
            }

            Dictionary<string, string> returnDictionary = new Dictionary<string, string>();

            if (keys.Count == values.Count)
            {
                for (Int32 i = 0; i < keys.Count; i++)
                {
                    returnDictionary.Add(keys[i], values[i]);
                }
            }

            return returnDictionary;
        }
    }

    public static class Retrievers
    {
        private static bool Initialized = false;
        private static readonly string RemoteUrl = "https://coderedmodding.github.io/retriever.html";

        private static PrivateSetting PsyonixVersion = new PrivateSetting("000000.000000.000000");
        private static PrivateSetting InstallerVersion = new PrivateSetting("0.0f");
        private static PrivateSetting LauncherVersion = new PrivateSetting("0.0.0");
        private static PrivateSetting ModuleVersion = new PrivateSetting("0.0f");
        private static PrivateSetting InstallerUrl = new PrivateSetting();
        private static PrivateSetting LauncherUrl = new PrivateSetting();
        private static PrivateSetting ModuleUrl = new PrivateSetting();
        private static PrivateSetting DiscordUrl = new PrivateSetting();
        private static PrivateSetting Changelog = new PrivateSetting("No changelog provided for the most recent update.");

        private static async Task<bool> DownloadRemote()
        {
            if (!Initialized)
            {
                string pageBody = await Downloaders.DownloadPage(RemoteUrl);
                pageBody = CRJson.StripPageBody(pageBody);

                if (!String.IsNullOrEmpty(pageBody))
                {
                    Dictionary<string, string> bodyContent = CRJson.ParseJSONStrings(pageBody);

                    if (bodyContent.Count >= 9)
                    {
                        PsyonixVersion.SetValue(bodyContent["Psyonix_Version"]);
                        InstallerVersion.SetValue(bodyContent["Installer_Version"]);
                        LauncherVersion.SetValue(bodyContent["Launcher_Version"]);
                        ModuleVersion.SetValue(bodyContent["Module_Version"]);
                        InstallerUrl.SetValue(bodyContent["Installer_Url"]);
                        LauncherUrl.SetValue(bodyContent["Launcher_Url"]);
                        ModuleUrl.SetValue(bodyContent["Module_Url"]);
                        DiscordUrl.SetValue(bodyContent["Discord_Url"]);
                        Changelog.SetValue(bodyContent["Changelog"]);
                        Initialized = true;
                    }
                }
            }

            return Initialized;
        }

        public static async void Invalidate()
        {
            Initialized = false;
            await CheckInitialized();
        }

        public static async Task<bool> CheckInitialized()
        {
            if (!Initialized)
            {
                if (await DownloadRemote())
                {
                    return true;
                }
                else
                {
                    bool shownMessage = false;

                    if (!shownMessage)
                    {
                        shownMessage = true;
                        MessageBox.Show("Warning: Failed to connect to the remote server, cannot grab latest versions!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    return false;
                }
            }

            return true;
        }

        public static async Task<string> GetPsyonixBuild()
        {
            if (await CheckInitialized()) { return PsyonixVersion.GetStringValue(); }
            return PsyonixVersion.GetStringValue(true);
        }

        public static async Task<float> GetInstallerVersion()
        {
            if (await CheckInitialized()) { return InstallerVersion.GetFloatValue(); }
            return InstallerVersion.GetFloatValue(true);
        }

        public static async Task<string> GetLauncherVersion()
        {
            if (await CheckInitialized()) { return LauncherVersion.GetStringValue(); }
            return LauncherVersion.GetStringValue(true);
        }

        public static async Task<float> GetModuleVersion()
        {
            if (await CheckInitialized()) { return ModuleVersion.GetFloatValue(); }
            return ModuleVersion.GetFloatValue(true);
        }

        public static async Task<string> GetInstallerUrl()
        {
            if (await CheckInitialized()) { return InstallerUrl.GetStringValue(); }
            return InstallerUrl.GetStringValue(true);
        }

        public static async Task<string> GetInjectorUrl()
        {
            if (await CheckInitialized()) { return LauncherUrl.GetStringValue(); }
            return LauncherUrl.GetStringValue(true);
        }

        public static async Task<string> GetModuleUrl()
        {
            if (await CheckInitialized()) { return ModuleUrl.GetStringValue(); }
            return ModuleUrl.GetStringValue(true);
        }

        public static async Task<string> GetDiscordUrl()
        {
            if (await CheckInitialized()) { return DiscordUrl.GetStringValue(); }
            return DiscordUrl.GetStringValue(true);
        }

        public static async Task<string> GetChangelog()
        {
            if (await CheckInitialized()) { return Changelog.GetStringValue(); }
            return Changelog.GetStringValue(true);
        }
    }
}