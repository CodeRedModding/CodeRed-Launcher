using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Http.Headers;
using System.Drawing;

namespace CodeRedLauncher
{

    public static class Downloaders
    {
        private static TimeSpan m_fileTimeout = TimeSpan.FromMinutes(15);
        private static TimeSpan m_imageTimeout = TimeSpan.FromMinutes(5);
        private static TimeSpan m_pageTimeout = TimeSpan.FromMinutes(2.5f);
        private static string m_userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/135.0.0.0 Safari/537.36 Edg/135.0.0.0";
        private static Int32 m_pageExpiration = 60; // Minimum time in seconds to keep for downloading pages, GitHub now has a limit of one request per minute.
        private static Dictionary<string, WebCache> m_pageCache = new Dictionary<string, WebCache>(); // Only used for downloading raw page text, not images or files.

        private class WebCache
        {
            public string Body { get; set; } = "";
            public long ResponseTime { get; set; } = 0;

            public bool HasResponse()
            {
                return (ResponseTime != 0);
            }

            public bool IsExpired()
            {
                return (!HasResponse() || (DateTimeOffset.UtcNow.ToUnixTimeSeconds() - ResponseTime) > m_pageExpiration);
            }

            public void SetResponse(string body)
            {
                if (!string.IsNullOrEmpty(body))
                {
                    Body = body;
                    ResponseTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                }
            }
        }

        public static async Task<bool> WebsiteOnline(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Logger.Write("(WebsiteOnline) Pinging website for \"" + url + "\"...");
                Ping newPing = new Ping();

                try
                {
                    PingReply pingReply = await newPing.SendPingAsync(new Uri(url).Host, 2500);

                    if (pingReply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                    else
                    {
                        Logger.Write("(WebsiteOnline) Ping request failed: " + pingReply.Status.ToString(), LogLevel.Warning);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write("(WebsiteOnline) Exception: " + ex.Message, LogLevel.Error);
                    return false;
                }

            }

            return false;
        }

        public static async Task<Image> DownloadImage(string url, bool bNoCache = true)
        {
            Image image = null;

            if (!string.IsNullOrEmpty(url))
            {
                Logger.Write("(DownloadImage) Downloading image from \"" + url + "\"...");

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        client.Timeout = m_imageTimeout;
                        client.DefaultRequestHeaders.UserAgent.ParseAdd(m_userAgent);

                        if (bNoCache)
                        {
                            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };
                        }

                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            Stream stream = await response.Content.ReadAsStreamAsync();

                            try
                            {
                                image = Image.FromStream(stream);
                            }
                            catch (Exception ex)
                            {
                                Logger.Write("(DownloadImage) Image stream exception: " + ex.Message, LogLevel.Warning);
                                image = null;
                            }
                        }
                        else
                        {
                            Logger.Write("(DownloadImage) Website is offline, failed to download image for url \"" + url + "\"!", LogLevel.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Write("(DownloadImage) Exception: " + ex.Message, LogLevel.Error);
                        return null;
                    }
                }
            }

            return image;
        }

        public static async Task<string> DownloadPage(string url, bool bNoCache = true)
        {
            string pageContent = "";

            if (!string.IsNullOrEmpty(url))
            {
                if (m_pageCache.ContainsKey(url))
                {
                    WebCache webCache = m_pageCache[url];

                    if (!webCache.IsExpired())
                    {
                        Logger.Write("(DownloadPage) Cache not yet expired for \"" + url + "\", grabbing from last stored response!");
                        return webCache.Body;
                    }
                    else
                    {
                        Logger.Write("(DownloadPage) Cache expired for \"" + url + "\"!");
                    }
                }
                else
                {
                    m_pageCache[url] = new WebCache();
                }

                try
                {
                    Logger.Write("(DownloadPage) Downloading page from \"" + url + "\"...");

                    using (HttpClient client = new HttpClient())
                    {
                        client.Timeout = m_pageTimeout;
                        client.DefaultRequestHeaders.UserAgent.ParseAdd(m_userAgent);

                        if (bNoCache)
                        {
                            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };
                        }

                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            pageContent = await response.Content.ReadAsStringAsync();
                            m_pageCache[url].SetResponse(pageContent);
                        }
                        else
                        {
                            Logger.Write(("(DownloadPage) Website response failed for url \"" + url + "\", status code \"" + response.StatusCode.ToString() + "\"!"), LogLevel.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write("(DownloadPage) Exception: " + ex.Message, LogLevel.Error);
                }
            }

            return pageContent;
        }

        public static async Task<bool> DownloadFile(string url, Architecture.Path folder, string fileName, bool bNoCache = true)
        {
            if (folder.Exists() && !string.IsNullOrEmpty(url))
            {
                Logger.Write("(DownloadFile) Downloading file from \"" + url + "\"...");

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.Timeout = m_fileTimeout;
                        client.DefaultRequestHeaders.UserAgent.ParseAdd(m_userAgent);

                        if (bNoCache)
                        {
                            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };
                        }

                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string path = (folder / fileName).GetPath();
                            byte[] content = await response.Content.ReadAsByteArrayAsync();

                            if (content.Length > 0)
                            {
                                File.WriteAllBytes(path, content);
                                return File.Exists(path);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write("(DownloadFile) Exception: " + ex.Message, LogLevel.Error);
                    return false;
                }
            }

            return false;
        }
    }

    // Dowwnloads and stores values from the remote config.
    public static class RemoteStorage
    {
        private static bool m_initialized = false;
        private static string m_remoteUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Public/Launcher.cr";
        private static string m_privacyUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Public/PrivacyPolicy.cr";
        private static string m_tosUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Public/TermsOfService.cr";
        private static string m_privacyContent = "";
        private static string m_tosContent = "";

        private static List<InternalSetting> m_remoteSettings = new List<InternalSetting>()
        {
            new InternalSetting("000000.000000.000000", "PsyonixVersion"),
            new InternalSetting("0.0.0", "LauncherVersion"),
            new InternalSetting("0.0.0", "ModuleVersion"),
            new InternalSetting(null, "UninstallerUrl"),
            new InternalSetting(null, "LauncherUrl"),
            new InternalSetting(null, "DropperUrl"),
            new InternalSetting(null, "ModuleUrl"),
            new InternalSetting("https://discord.com/", "DiscordUrl"),
            new InternalSetting("https://ko-fi.com/", "KofiUrl"),
            new InternalSetting(null, "NewsUrl"),
            new InternalSetting(null, "LauncherAlt"),
            new InternalSetting("No changelog provided for the most recent update.", "LauncherChangelog"),
            new InternalSetting("No changelog provided for the most recent update.", "ModuleChangelog"),
            new InternalSetting("Bakkes, Martinn, TaylorSasser, ButternCream, GlenHumphrey, Segal, ToolB0x, lchmagKekse, MrMythical, and Megasplat", "Credits"),
            new InternalSetting("false", "AltEndpoint"),
        };

        private static InternalSetting? GetStoredSetting(string name)
        {
            foreach (InternalSetting setting in m_remoteSettings)
            {
                if (setting.Name == name)
                {
                    return setting;
                }
            }

            return null;
        }

        private static async Task<bool> DownloadRemote()
        {
            if (!m_initialized && (await Downloaders.WebsiteOnline(GetRemoteURL())))
            {
                string pageBody = await Downloaders.DownloadPage(GetRemoteURL());

                if (!string.IsNullOrEmpty(pageBody))
                {
                    Dictionary<string, string> mappedBody = Extensions.Json.MapValuesToKeys(pageBody);

                    for (Int32 i = 0; i < m_remoteSettings.Count; i++)
                    {
                        if (mappedBody.ContainsKey(m_remoteSettings[i].Name))
                        {
                            m_remoteSettings[i].SetValue(mappedBody[m_remoteSettings[i].Name]);
                            Logger.Write("(DownloadRemote) Retrieved value: " + m_remoteSettings[i].GetStringValue());

                            if ((m_remoteSettings[i].Name == "LauncherAlt") && (m_remoteSettings[i].GetStringValue() != "null"))
                            {
                                m_remoteUrl = m_remoteSettings[i].GetStringValue();
                            }
                        }
                    }

                    m_initialized = true;
                }
            }

            return m_initialized;
        }

        public static async void Invalidate()
        {
            m_initialized = false;
            await CheckInitialized();
        }

        public static async Task<bool> CheckInitialized()
        {
            if (!m_initialized)
            {
                if (await DownloadRemote() == false)
                {
                    Logger.Write("(CheckInitialized) Failed to download remote information, cannot check for updates or verify installed version!", LogLevel.Warning);
                }
            }

            return m_initialized;
        }

        public static string GetRemoteURL()
        {
            return m_remoteUrl;
        }

        public static string GetPrivacyURL()
        {
            return m_privacyUrl;
        }

        public static string GetTermsURL()
        {
            return m_tosUrl;
        }

        public static async Task<string> GetPsyonixVersion()
        {
            if (await CheckInitialized()) { return GetStoredSetting("PsyonixVersion").GetStringValue(); }
            return GetStoredSetting("PsyonixVersion").GetStringValue(true);
        }

        // The first twelve numbers in the Psyonix version string is a date timestamp, with the remaining six being the perforce changelist.
        // First two numbers are the year, second two are the month, and last two are the day.
        public static async Task<UInt32> GetPsyonixDate()
        {
            UInt32 dateNumber = 0;

            if (await CheckInitialized())
            {
                string psyonixVersion = GetStoredSetting("PsyonixVersion").GetStringValue();
                string dateString = psyonixVersion.Substring(0, psyonixVersion.IndexOf("."));

                if (UInt32.TryParse(dateString, out dateNumber))
                {
                    Logger.Write("(GetPsyonixDate) Found date \"" + dateNumber.ToString() + "\"!");
                }
            }

            return dateNumber;
        }

        public static async Task<string> GetLauncherVersion()
        {
            if (await CheckInitialized()) { return GetStoredSetting("LauncherVersion").GetStringValue(); }
            return GetStoredSetting("LauncherVersion").GetStringValue(true);
        }

        public static async Task<string> GetModuleVersion()
        {
            if (await CheckInitialized()) { return GetStoredSetting("ModuleVersion").GetStringValue(); }
            return GetStoredSetting("ModuleVersion").GetStringValue(true);
        }

        public static async Task<string> GetUninstallerUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("UninstallerUrl").GetStringValue(); }
            return GetStoredSetting("UninstallerUrl").GetStringValue(true);
        }

        public static async Task<string> GetLauncherUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("LauncherUrl").GetStringValue(); }
            return GetStoredSetting("LauncherUrl").GetStringValue(true);
        }

        public static async Task<string> GetDropperUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("DropperUrl").GetStringValue(); }
            return GetStoredSetting("DropperUrl").GetStringValue(true);
        }

        public static async Task<string> GetModuleUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("ModuleUrl").GetStringValue(); }
            return GetStoredSetting("ModuleUrl").GetStringValue(true);
        }

        public static async Task<string> GetDiscordUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("DiscordUrl").GetStringValue(); }
            return GetStoredSetting("DiscordUrl").GetStringValue(true);
        }

        public static async Task<string> GetKofiUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("KofiUrl").GetStringValue(); }
            return GetStoredSetting("KofiUrl").GetStringValue(true);
        }

        public static async Task<string> GetNewsUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("NewsUrl").GetStringValue(); }
            return GetStoredSetting("NewsUrl").GetStringValue(true);
        }

        public static async Task<string> GetLauncherChangelog()
        {
            if (await CheckInitialized()) { return GetStoredSetting("LauncherChangelog").GetStringValue(); }
            return GetStoredSetting("LauncherChangelog").GetStringValue(true);
        }

        public static async Task<string> GetModuleChangelog()
        {
            if (await CheckInitialized()) { return GetStoredSetting("ModuleChangelog").GetStringValue(); }
            return GetStoredSetting("ModuleChangelog").GetStringValue(true);
        }

        public static async Task<string> GetCredits()
        {
            if (await CheckInitialized()) { return GetStoredSetting("Credits").GetStringValue(); }
            return GetStoredSetting("Credits").GetStringValue(true);
        }

        public static async Task<string> GetPrivacyPolicy()
        {
            if (string.IsNullOrEmpty(m_privacyContent)) { m_privacyContent = await Downloaders.DownloadPage(GetPrivacyURL()); }
            return m_privacyContent;
        }

        public static async Task<string> GetTermsOfUse()
        {
            if (string.IsNullOrEmpty(m_tosContent)) { m_tosContent = await Downloaders.DownloadPage(GetTermsURL()); }
            return m_tosContent;
        }
    }
}