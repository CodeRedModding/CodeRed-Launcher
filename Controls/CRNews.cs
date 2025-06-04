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
        private static bool m_usingAlt = false;
        private static readonly string m_altUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Public/News.cr"; // Psyonix started blocking requests to their site...have to use my own now.
        private static readonly string m_altThumbnail = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/refs/heads/main/Assets/News/Fallback.jpg";

        private IconStore m_calendarIcons = new IconStore();
        private IconStore m_authorIcons = new IconStore();
        private IconStore m_categoryIcons = new IconStore();
        private IconStore m_leftIcons = new IconStore();
        private IconStore m_rightIcons = new IconStore();
        private List<NewsStorage> m_articles = new List<NewsStorage>();
        private Int32 m_maxIndexes = 16;
        private Int32 m_index = -1;

        private class NewsStorage
        {
            public string NewsUrl { get; set; }
            public string ThumbnailUrl { get; set; }
            public string ThumbnailUrlAlt { get; set; }
            public Image ThumbnailImage { get; set; } = null;
            public string Title { get; set; }
            public string Timestamp { get; set; } = "Rocket League";
            public string Author { get; set; } = "Psyonix Team";
            public string Category { get; set; } = "Game News";
            public bool Parsed { get; set; } = false;

            public NewsStorage(string bodyContent)
            {
                ParseJson(bodyContent);
            }

            public void ParseJson(string bodyContent)
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

                    if (m_usingAlt)
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
                if (bodyContent.Contains("author"))
                {
                    Match timestampMatch = Regex.Match(bodyContent.Replace("\\", ""), "(?<=\"className\":\"is-5 is-uppercase\",\"children\":\")(.*?)(?=\"})");
                    Match authorMatch = Regex.Match(bodyContent, "(?<=\"author\" content=\")(.*?)(?=\")");

                    if (timestampMatch.Success && timestampMatch.Groups[1].Success)
                    {
                        Timestamp = timestampMatch.Groups[1].Value;
                    }

                    if (authorMatch.Success && authorMatch.Groups[1].Success)
                    {
                        Author = authorMatch.Groups[1].Value;
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme ControlType
        {
            get { return m_calendarIcons.Control; }
            set { m_calendarIcons.Control = value; m_authorIcons.Control = value; m_categoryIcons.Control = value; m_leftIcons.Control = value; m_rightIcons.Control = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public IconTheme IconType
        {
            get { return m_calendarIcons.Theme; }
            set { m_calendarIcons.Theme = value; m_authorIcons.Theme = value; m_categoryIcons.Theme = value; m_leftIcons.Theme = value; m_rightIcons.Theme = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CalendarWhite
        {
            get { return m_calendarIcons.GetIcon(IconTheme.White); }
            set { m_calendarIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CalendarBlack
        {
            get { return m_calendarIcons.GetIcon(IconTheme.Black); }
            set { m_calendarIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CalendarRed
        {
            get { return m_calendarIcons.GetIcon(IconTheme.Red); }
            set { m_calendarIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CalendarPurple
        {
            get { return m_calendarIcons.GetIcon(IconTheme.Purple); }
            set { m_calendarIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CalendarBlue
        {
            get { return m_calendarIcons.GetIcon(IconTheme.Blue); }
            set { m_calendarIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AuthorWhite
        {
            get { return m_authorIcons.GetIcon(IconTheme.White); }
            set { m_authorIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AuthorBlack
        {
            get { return m_authorIcons.GetIcon(IconTheme.Black); }
            set { m_authorIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AuthorRed
        {
            get { return m_authorIcons.GetIcon(IconTheme.Red); }
            set { m_authorIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AuthorPurple
        {
            get { return m_authorIcons.GetIcon(IconTheme.Purple); }
            set { m_authorIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AuthorBlue
        {
            get { return m_authorIcons.GetIcon(IconTheme.Blue); }
            set { m_authorIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CategoryWhite
        {
            get { return m_categoryIcons.GetIcon(IconTheme.White); }
            set { m_categoryIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CategoryBlack
        {
            get { return m_categoryIcons.GetIcon(IconTheme.Black); }
            set { m_categoryIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CategoryRed
        {
            get { return m_categoryIcons.GetIcon(IconTheme.Red); }
            set { m_categoryIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CategoryPurple
        {
            get { return m_categoryIcons.GetIcon(IconTheme.Purple); }
            set { m_categoryIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CategoryBlue
        {
            get { return m_categoryIcons.GetIcon(IconTheme.Blue); }
            set { m_categoryIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image LeftWhite
        {
            get { return m_leftIcons.GetIcon(IconTheme.White); }
            set { m_leftIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image LeftBlack
        {
            get { return m_leftIcons.GetIcon(IconTheme.Black); }
            set { m_leftIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image LeftRed
        {
            get { return m_leftIcons.GetIcon(IconTheme.Red); }
            set { m_leftIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image LeftPurple
        {
            get { return m_leftIcons.GetIcon(IconTheme.Purple); }
            set { m_leftIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image LeftBlue
        {
            get { return m_leftIcons.GetIcon(IconTheme.Blue); }
            set { m_leftIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image RightWhite
        {
            get { return m_rightIcons.GetIcon(IconTheme.White); }
            set { m_rightIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image RightBlack
        {
            get { return m_rightIcons.GetIcon(IconTheme.Black); }
            set { m_rightIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image RightRed
        {
            get { return m_rightIcons.GetIcon(IconTheme.Red); }
            set { m_rightIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image RightPurple
        {
            get { return m_rightIcons.GetIcon(IconTheme.Purple); }
            set { m_rightIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image RightBlue
        {
            get { return m_rightIcons.GetIcon(IconTheme.Blue); }
            set { m_rightIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PublishDate
        {
            get { return CalendarLbl.DisplayText; }
            set { CalendarLbl.DisplayText = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PublishAuthor
        {
            get { return AuthorLbl.DisplayText; }
            set { AuthorLbl.DisplayText = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string NewsCategory
        {
            get { return CategoryLbl.DisplayText; }
            set { CategoryLbl.DisplayText = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get { return TitleLbl.Text; }
            set { TitleLbl.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Thumbnail
        {
            get { return ThumbnailImg.BackgroundImage; }
            set { ThumbnailImg.BackgroundImage = value; }
        }

        public CRNews()
        {
            InitializeComponent();
        }

        public void SetTheme(ControlTheme control, IconTheme icon)
        {
            ControlType = control;
            IconType = icon;
        }

        private void UpdateTheme()
        {
            CalendarLbl.ControlType = ControlType;
            AuthorLbl.ControlType = ControlType;
            CategoryLbl.ControlType = ControlType;
            CalendarLbl.IconType = IconType;
            AuthorLbl.IconType = IconType;
            CategoryLbl.IconType = IconType;

            if (ControlType == ControlTheme.Dark)
            {
                PreviousBtn.BackColor = GPalette.LightBlack;
                NextBtn.BackColor = GPalette.LightBlack;
                CalendarLbl.BackColor = GPalette.DarkGrey;
                AuthorLbl.BackColor = GPalette.DarkGrey;
                CategoryLbl.BackColor = GPalette.DarkGrey;
                TitleLbl.BackColor = GPalette.DarkGrey;
                TitleLbl.ForeColor = GPalette.White;
            }
            else if (ControlType == ControlTheme.Light)
            {
                PreviousBtn.BackColor = GPalette.Grey;
                NextBtn.BackColor = GPalette.Grey;
                CalendarLbl.BackColor = GPalette.White;
                AuthorLbl.BackColor = GPalette.White;
                CategoryLbl.BackColor = GPalette.White;
                TitleLbl.BackColor = GPalette.White;
                TitleLbl.ForeColor = GPalette.Black;
            }

            if (PreviousBtn.BackgroundImage != null)
            {
                PreviousBtn.BackgroundImage = m_leftIcons.GetThemeIcon();
            }

            if (NextBtn.BackgroundImage != null)
            {
                NextBtn.BackgroundImage = m_rightIcons.GetThemeIcon();
            }

            Invalidate();
        }

        private void ResetArticles()
        {
            PublishDate = "Loading...";
            PublishAuthor = "Loading...";
            NewsCategory = "Loading...";
            Title = "Loading...";
            ThumbnailImg.BackgroundImage = null;
            PreviousBtn.BackgroundImage = null;
            NextBtn.BackgroundImage = null;
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

                LoadIndex();
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

                LoadIndex();
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
                            newsStorage.ThumbnailUrlAlt = thumbnailMatchAlt.Groups[1].Value;
                        }
                        else
                        {
                            thumbnailMatchAlt = Regex.Match(pageBody, "\"image\": \"(.*)\"");

                            if (thumbnailMatchAlt.Success && thumbnailMatchAlt.Groups[1].Success)
                            {
                                newsStorage.ThumbnailUrlAlt = thumbnailMatchAlt.Groups[1].Value;
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
                            m_articles.Add(new NewsStorage(link.Groups[0].ToString()));
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

                        if ((newsStorage.ThumbnailImage == null) && !string.IsNullOrEmpty(newsStorage.ThumbnailUrlAlt))
                        {
                            newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrlAlt);
                        }

                        // If no thumbnail was found we gotta use our own image.

                        if (newsStorage.ThumbnailImage == null)
                        {
                            newsStorage.ThumbnailUrl = "";
                            newsStorage.ThumbnailUrlAlt = m_altThumbnail;
                            newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrlAlt);
                        }
                    }
                }

                m_articles[i] = newsStorage;
            }
        }

        private async void LoadIndex()
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

                    PublishDate = newsStorage.Timestamp;
                    PublishAuthor = newsStorage.Author;
                    NewsCategory = newsStorage.Category;
                    Title = newsStorage.Title;

                    if (newsStorage.ThumbnailImage == null)
                    {
                        if (!string.IsNullOrEmpty(newsStorage.ThumbnailUrl))
                        {
                            newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl);

                            if ((newsStorage.ThumbnailImage == null) && !string.IsNullOrEmpty(newsStorage.ThumbnailUrlAlt))
                            {
                                newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrlAlt);
                            }

                            // If no thumbnail was found we gotta use our own image.

                            if (newsStorage.ThumbnailImage == null)
                            {
                                newsStorage.ThumbnailUrl = "";
                                newsStorage.ThumbnailUrlAlt = m_altThumbnail;
                                newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrlAlt);
                            }

                            m_articles[m_index] = newsStorage;
                            ThumbnailImg.BackgroundImage = newsStorage.ThumbnailImage;
                            ThumbnailImg.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                    else
                    {
                        ThumbnailImg.BackgroundImage = newsStorage.ThumbnailImage;
                        ThumbnailImg.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    if (m_index == 0)
                    {
                        PreviousBtn.BackgroundImage = null;
                        NextBtn.BackgroundImage = m_rightIcons.GetThemeIcon();
                    }
                    else if (m_index < (m_articles.Count - 1))
                    {
                        PreviousBtn.BackgroundImage = m_leftIcons.GetThemeIcon();
                        NextBtn.BackgroundImage = m_rightIcons.GetThemeIcon();
                    }
                    else
                    {
                        PreviousBtn.BackgroundImage = m_leftIcons.GetThemeIcon();
                        NextBtn.BackgroundImage = null;
                    }
                }
            }
            else
            {
                ResetArticles();
                m_index = -1;
            }
        }

        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            if (PreviousBtn.BackgroundImage != null)
            {
                LoadPreviousArticle();
            }
        }

        private void PreviousBtn_DoubleClick(object sender, EventArgs e)
        {
            if (PreviousBtn.BackgroundImage != null)
            {
                LoadPreviousArticle();
            }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (NextBtn.BackgroundImage != null)
            {
                LoadNextArticle();
            }
        }

        private void NextBtn_DoubleClick(object sender, EventArgs e)
        {
            if (NextBtn.BackgroundImage != null)
            {
                LoadNextArticle();
            }
        }

        private void ThumbnailImg_Click(object sender, EventArgs e)
        {
            OpenCurrentArticle();
        }

        private void ThumbnailImg_DoubleClick(object sender, EventArgs e)
        {
            OpenCurrentArticle();
        }

        private void TitleLbl_Click(object sender, EventArgs e)
        {
            OpenCurrentArticle();
        }

        private void TitleLbl_DoubleClick(object sender, EventArgs e)
        {
            OpenCurrentArticle();
        }
    }
}