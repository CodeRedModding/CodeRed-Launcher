using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRNews : UserControl
    {
        private class NewsStorage
        {
            public string NewsUrl { get; set; } = "";
            public string ThumbnailUrl { get; set; } = "";
            public Image ThumbnailImage { get; set; } = null;
            public string Title { get; set; }
            public string Timestamp { get; set; } = "Rocket League";
            public string Category { get; set; } = "Game News";
            public string Author { get; set; } = "Psyonix";
            public bool Parsed { get; set; } = false;

            public NewsStorage(string bodyContent, bool bUsingAlt)
            {
                ParseJson(bodyContent, bUsingAlt);
            }

            public void ParseJson(string bodyContent, bool bUsingAlt)
            {
                if (bodyContent.Contains("slug"))
                {
                    bodyContent = bodyContent.Replace("\": \"", "\":\"");
                    Match titleMatch = Regex.Match(bodyContent, "(?<=\"title\":\")(.*?)(?=\")");
                    Match urlMatch = Regex.Match(bodyContent, "(?<=\"slug\":\")(.*?)(?=\")");
                    Match imageMatch = Regex.Match(bodyContent, "(?<=\"imageUrl\":\")(.*?)(?=\")");

                    if (titleMatch.Success && titleMatch.Groups[1].Success)
                    {
                        Title = titleMatch.Groups[1].Value;

                        if (Title.Length > 74) // Max length for title that can be displayed.
                        {
                            Title = Title.Substring(0, 74);
                            Title += "...";
                        }
                    }

                    if (urlMatch.Success && urlMatch.Groups[1].Success)
                    {
                        NewsUrl = ("https://www.rocketleague.com/en/news/" + urlMatch.Groups[1].Value);
                    }

                    if (imageMatch.Success && imageMatch.Groups[1].Success)
                    {
                        ThumbnailUrl = imageMatch.Groups[1].Value;
                    }

                    if (bUsingAlt)
                    {
                        // Specific to the GitHub fallback url.
                        Match dateMatch = Regex.Match(bodyContent, "(?<=\"date\":\")(.*?)(?=\")");
                        Match authorMatch = Regex.Match(bodyContent, "(?<=\"author\":\")(.*?)(?=\")");
                        Match categoryMatch = Regex.Match(bodyContent, "(?<=\"category\":\")(.*?)(?=\")");

                        if (dateMatch.Success && dateMatch.Groups[1].Success)
                        {
                            Timestamp = dateMatch.Groups[1].Value;
                        }

                        if (authorMatch.Success && authorMatch.Groups[1].Success)
                        {
                            Author = authorMatch.Groups[1].Value;
                        }

                        if (categoryMatch.Success && categoryMatch.Groups[1].Success)
                        {
                            Category = categoryMatch.Groups[1].Value;
                        }

                        Parsed = true;
                    }
                }
            }

            public void ParseBody(string bodyContent)
            {
                // This is deprecated, hasn't worked since Epic took over their website and started adding captchas and changing their entire html.

                //if (bodyContent.Contains("author"))
                //{
                //    Match timestampMatch = Regex.Match(bodyContent.Replace("\\", ""), "(?<=\"className\":\"is-5 is-uppercase\",\"children\":\")(.*?)(?=\"})");
                //    Match authorMatch = Regex.Match(bodyContent, "(?<=\"author\" content=\")(.*?)(?=\")");

                //    if (timestampMatch.Success && timestampMatch.Groups[1].Success)
                //    {
                //        Timestamp = timestampMatch.Groups[1].Value;
                //    }

                //    if (authorMatch.Success && authorMatch.Groups[1].Success)
                //    {
                //        Author = authorMatch.Groups[1].Value;
                //    }
                //}
            }
        }

        private static bool m_usingAlt = false;
        private static readonly string m_altUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Public/News.cr"; // Psyonix started blocking requests to their site so I have to use my own now.
        private static readonly string m_altThumbnail = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/refs/heads/main/Assets/News/default.jpg";
        const IconTheme m_darkIcon = IconTheme.Red;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private IconStore m_prevIcons = new IconStore();
        private IconStore m_nextIcons = new IconStore();
        private List<NewsStorage> m_articles = new List<NewsStorage>();
        private Int32 m_maxIndexes = 16;
        private Int32 m_index = -1;

        public bool IsDarkMode()
        {
            return m_prevIcons.IsDarkMode();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme Theme
        {
            get
            {
                return m_prevIcons.Theme;
            }
            set
            {
                m_prevIcons.Theme = value;
                m_prevIcons.IconTheme = (IsDarkMode() ? m_darkIcon : m_lightIcon);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image PrevDark
        {
            get
            {
                return m_prevIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_prevIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image PrevLight
        {
            get
            {
                return m_prevIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_prevIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image NextDark
        {
            get
            {
                return m_nextIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_nextIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image NextLight
        {
            get
            {
                return m_nextIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_nextIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image NewsThumbnail
        {
            get
            {
                return ThumbnailImg.BackgroundImage;
            }
            set
            {
                ThumbnailImg.BackgroundImage = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string NewsTitle
        {
            get
            {
                return TitleLbl.Text;
            }
            set
            {
                TitleLbl.Text = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string NewsDate
        {
            get
            {
                return DateIconLbl.DisplayText;
            }
            set
            {
                DateIconLbl.DisplayText = value;
                DateIconLbl.Visible = (!string.IsNullOrEmpty(value) && (value != "null"));
                OnThemeUpdated();
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string NewsCategory
        {
            get
            {
                return CategoryIconLbl.DisplayText;
            }
            set
            {
                CategoryIconLbl.DisplayText = value;
                CategoryIconLbl.Visible = (!string.IsNullOrEmpty(value) && (value != "null"));
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string NewsAuthor
        {
            get
            {
                return AuthorIconLbl.DisplayText;
            }
            set
            {
                AuthorIconLbl.DisplayText = value;
                AuthorIconLbl.Visible = (!string.IsNullOrEmpty(value) && (value != "null"));
                OnThemeUpdated();
            }
        }

        public CRNews()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            DateIconLbl.Theme = Theme;
            CategoryIconLbl.Theme = Theme;
            AuthorIconLbl.Theme = Theme;

            if (IsDarkMode())
            {
                this.BackColor = GPalette.DarkGrey;
                PreviousImg.BackColor = GPalette.LightBlack;
                NextImg.BackColor = GPalette.LightBlack;
                TitleLbl.ForeColor = GPalette.White;
            }
            else
            {
                this.BackColor = GPalette.White;
                PreviousImg.BackColor = GPalette.Grey;
                NextImg.BackColor = GPalette.Grey;
                TitleLbl.ForeColor = GPalette.Black;
            }

            m_nextIcons.Theme = Theme;
            m_nextIcons.IconTheme = m_prevIcons.IconTheme;

            if (PreviousImg.BackgroundImage != null)
            {
                PreviousImg.BackgroundImage = m_prevIcons.GetIcon();
            }

            if (NextImg.BackgroundImage != null)
            {
                NextImg.BackgroundImage = m_nextIcons.GetIcon();
            }

            Invalidate();
        }

        private void ResetArticles()
        {
            NewsDate = "Loading...";
            NewsCategory = "Loading...";
            NewsAuthor = "Loading...";
            NewsTitle = "Loading...";
            ThumbnailImg.BackgroundImage = null;
            PreviousImg.BackgroundImage = null;
            NextImg.BackgroundImage = null;
        }

        public void LoadPreviousArticle()
        {
            if (m_articles.Count > 0)
            {
                if (m_index > 0)
                {
                    m_index--;
                }
                else
                {
                    m_index = 0;
                }

                LoadCurrentIndex();
            }
            else
            {
                ResetArticles();
                m_index = -1;
            }
        }

        public void LoadNextArticle()
        {
            if (m_articles.Count > 0)
            {
                if (m_index < m_articles.Count)
                {
                    m_index++;
                }
                else
                {
                    m_index = (m_articles.Count - 1);
                }

                LoadCurrentIndex();
            }
            else
            {
                ResetArticles();
                m_index = -1;
            }
        }

        private void OpenCurrentArticle()
        {
            if ((m_index > -1) && (m_index < m_articles.Count) && !string.IsNullOrEmpty(m_articles[m_index].NewsUrl))
            {
                Process.Start(new ProcessStartInfo(m_articles[m_index].NewsUrl) { UseShellExecute = true });
            }
        }

        private async Task<NewsStorage> ParseLink(NewsStorage newsStorage)
        {
            if (!string.IsNullOrEmpty(newsStorage.NewsUrl) && !m_usingAlt)
            {
                string pageBody = await Downloaders.DownloadPage(newsStorage.NewsUrl);

                if (!string.IsNullOrEmpty(pageBody))
                {
                    newsStorage.ParseBody(pageBody);

                    if (string.IsNullOrEmpty(newsStorage.ThumbnailUrl))
                    {
                        Match thumbnailMatch = Regex.Match(pageBody, "property=\"og:image\" content=\"(.*)\" /><meta property=\"og:image:url");

                        if (thumbnailMatch.Success && thumbnailMatch.Groups[1].Success)
                        {
                            newsStorage.ThumbnailUrl = thumbnailMatch.Groups[1].Value;
                            Int32 jpg = newsStorage.ThumbnailUrl.IndexOf(".jpg");
                            Int32 png = newsStorage.ThumbnailUrl.IndexOf(".png");
                            Int32 webp = newsStorage.ThumbnailUrl.IndexOf(".webp");

                            if (jpg > 0)
                            {
                                newsStorage.ThumbnailUrl = (newsStorage.ThumbnailUrl.Substring(0, jpg) + ".jpg");
                            }
                            else if (png > 0)
                            {
                                newsStorage.ThumbnailUrl = (newsStorage.ThumbnailUrl.Substring(0, png) + ".png");
                            }
                            else if (webp > 0)
                            {
                                newsStorage.ThumbnailUrl = (newsStorage.ThumbnailUrl.Substring(0, webp) + ".webp");
                            }
                        }

                        Match thumbnailMatchAlt = Regex.Match(pageBody, "<p dir=\"ltr\"><img src=\"(.*)\" data-id=\"");

                        if (thumbnailMatchAlt.Success && thumbnailMatchAlt.Groups[1].Success)
                        {
                            newsStorage.ThumbnailUrl = thumbnailMatchAlt.Groups[1].Value;
                        }
                        else
                        {
                            thumbnailMatchAlt = Regex.Match(pageBody, "\"image\": \"(.*)\"");

                            if (thumbnailMatchAlt.Success && thumbnailMatchAlt.Groups[1].Success)
                            {
                                newsStorage.ThumbnailUrl = thumbnailMatchAlt.Groups[1].Value;
                            }
                        }
                    }

                    newsStorage.Parsed = true;
                }
                else
                {
                    Logger.Write("(ParseLink) Failed to download news body for url \"" + newsStorage.NewsUrl + "\"!", LogLevel.Warning);
                }
            }

            return newsStorage;
        }

        public async void ParseArticles(string url, bool bRecursive = false)
        {
            if (!string.IsNullOrEmpty(url))
            {
                bool fallback = false;
                string pageBody = await Downloaders.DownloadPage(url);

                if (!string.IsNullOrEmpty(pageBody))
                {
                    m_articles.Clear();
                    ResetArticles();

                    MatchCollection articleLinks = Regex.Matches(pageBody.Replace("\\", ""), (bRecursive ? "(?s)(?=\"title).*?(?=})" : "(?=\"title\")(.*?)(?=})"));

                    Int32 articles = 0;

                    for (Int32 i = 0; i < articleLinks.Count; i++)
                    {
                        Match link = articleLinks[i];

                        if (link.Success && link.Groups[0].Success && link.Groups[0].ToString().Contains("slug"))
                        {
                            articles++;
                            m_articles.Add(new NewsStorage(link.Groups[0].ToString(), m_usingAlt));
                        }

                        if (articles == m_maxIndexes)
                        {
                            break;
                        }
                    }

                    if (articles > 0)
                    {
                        Logger.Write("(ParseArticles) Found \"" + articles.ToString() + "\" article pages!");
                        LoadAllIndexes(); // Parse and download everything in the background.
                        LoadPreviousArticle();
                        return;
                    }
                    else
                    {
                        fallback = true;
                    }
                }
                else
                {
                    fallback = true;
                }

                if (fallback && !bRecursive)
                {
                    Logger.Write("(ParseArticles) Couldn't find official news links, resorting to fallback url!");
                    m_usingAlt = true;
                    ParseArticles(m_altUrl, true);
                }
                else if (bRecursive)
                {
                    Logger.Write("(ParseArticles) Fallback url failed, no news links found!");
                }
            }
        }

        public async void LoadAllIndexes()
        {
            for (Int32 i = 0; i < m_articles.Count; i++)
            {
                NewsStorage newsStorage = m_articles[i];

                if (!newsStorage.Parsed)
                {
                    m_articles[i] = await ParseLink(m_articles[i]);
                    newsStorage = m_articles[i];
                }

                if (newsStorage.ThumbnailImage == null)
                {
                    if (!string.IsNullOrEmpty(newsStorage.ThumbnailUrl))
                    {
                        newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl);

                        if (newsStorage.ThumbnailImage == null)
                        {
                            newsStorage.ThumbnailUrl = m_altThumbnail;
                            newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl);
                        }
                    }
                }

                m_articles[i] = newsStorage;
            }
        }

        private async void LoadCurrentIndex()
        {
            if (m_articles.Count > 0)
            {
                if ((m_index > -1) && (m_index < m_articles.Count))
                {
                    ResetArticles();
                    NewsStorage newsStorage = m_articles[m_index];

                    if (!newsStorage.Parsed)
                    {
                        m_articles[m_index] = await ParseLink(m_articles[m_index]);
                        newsStorage = m_articles[m_index];
                    }

                    NewsDate = newsStorage.Timestamp;
                    NewsCategory = newsStorage.Category;
                    NewsAuthor = newsStorage.Author;
                    TitleLbl.Text = newsStorage.Title;

                    if (newsStorage.ThumbnailImage == null)
                    {
                        if (!string.IsNullOrEmpty(newsStorage.ThumbnailUrl))
                        {
                            newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl);

                            if (newsStorage.ThumbnailImage == null)
                            {
                                newsStorage.ThumbnailUrl = m_altThumbnail;
                                newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl);
                            }

                            m_articles[m_index] = newsStorage;
                            ThumbnailImg.BackgroundImage = newsStorage.ThumbnailImage;
                        }
                    }
                    else
                    {
                        ThumbnailImg.BackgroundImage = newsStorage.ThumbnailImage;
                    }

                    if (m_index == 0)
                    {
                        PreviousImg.BackgroundImage = null;
                        NextImg.BackgroundImage = m_nextIcons.GetIcon();
                    }
                    else if (m_index < (m_articles.Count - 1))
                    {
                        PreviousImg.BackgroundImage = m_prevIcons.GetIcon();
                        NextImg.BackgroundImage = m_nextIcons.GetIcon();
                    }
                    else
                    {
                        PreviousImg.BackgroundImage = m_prevIcons.GetIcon();
                        NextImg.BackgroundImage = null;
                    }
                }
            }
            else
            {
                ResetArticles();
                m_index = -1;
            }
        }

        private void OnThumbnailEnter()
        {
            TitleLbl.Font = new Font(TitleLbl.Font, (FontStyle.Bold | FontStyle.Underline));
        }

        private void OnThumbnailLeave()
        {
            TitleLbl.Font = new Font(TitleLbl.Font, FontStyle.Bold);
        }

        private void ThumbnailImg_Click(object sender, EventArgs eventArgs)
        {
            OpenCurrentArticle();
        }

        private void ThumbnailImg_DoubleClick(object sender, EventArgs eventArgs)
        {
            OpenCurrentArticle();
        }

        private void ThumbnailImg_MouseEnter(object sender, EventArgs e)
        {
            OnThumbnailEnter();
        }

        private void ThumbnailImg_MouseLeave(object sender, EventArgs e)
        {
            OnThumbnailLeave();
        }

        private void TitleLbl_Click(object sender, EventArgs eventArgs)
        {
            OpenCurrentArticle();
        }

        private void TitleLbl_DoubleClick(object sender, EventArgs eventArgs)
        {
            OpenCurrentArticle();
        }

        private void TitleLbl_MouseEnter(object sender, EventArgs e)
        {
            OnThumbnailEnter();
        }

        private void TitleLbl_MouseLeave(object sender, EventArgs e)
        {
            OnThumbnailLeave();
        }

        private void PreviousBtn_Click(object sender, EventArgs eventArgs)
        {
            if (PreviousImg.BackgroundImage != null)
            {
                LoadPreviousArticle();
            }
        }

        private void PreviousBtn_DoubleClick(object sender, EventArgs eventArgs)
        {
            if (PreviousImg.BackgroundImage != null)
            {
                LoadPreviousArticle();
            }
        }

        private void PreviousImg_MouseEnter(object sender, EventArgs e)
        {
            if (PreviousImg.BackgroundImage != null)
            {
                PreviousImg.BackColor = (IsDarkMode() ? GPalette.LightBlack_Highlight : GPalette.Grey_Highlight);
            }
        }

        private void PreviousImg_MouseLeave(object sender, EventArgs e)
        {
            if (PreviousImg.BackgroundImage != null)
            {
                PreviousImg.BackColor = (IsDarkMode() ? GPalette.LightBlack : GPalette.Grey);
            }
        }


        private void NextImg_Click(object sender, EventArgs eventArgs)
        {
            if (NextImg.BackgroundImage != null)
            {
                LoadNextArticle();
            }
        }

        private void NexImg_DoubleClick(object sender, EventArgs eventArgs)
        {
            if (NextImg.BackgroundImage != null)
            {
                LoadNextArticle();
            }
        }

        private void NextImg_MouseEnter(object sender, EventArgs e)
        {
            if (NextImg.BackgroundImage != null)
            {
                NextImg.BackColor = (IsDarkMode() ? GPalette.LightBlack_Highlight : GPalette.Grey_Highlight);
            }
        }

        private void NextImg_MouseLeave(object sender, EventArgs e)
        {
            if (NextImg.BackgroundImage != null)
            {
                NextImg.BackColor = (IsDarkMode() ? GPalette.LightBlack : GPalette.Grey);
            }
        }
    }
}