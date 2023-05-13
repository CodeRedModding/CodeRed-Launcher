using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;

namespace CodeRedLauncher.Controls
{
    public partial class CRNewsPanel : UserControl
    {
        private Int32 CurrentIndex = -1;
        private List<NewsStorage> NewsArticles = new List<NewsStorage>();

        private class NewsStorage
        {
            public string NewsUrl { get; set; }
            public string ThumbnailUrl_Main { get; set; }
            public string ThumbnailUrl_Alt { get; set; }
            public Image ThumbnailImage { get; set; } = null;
            public string Title { get; set; }
            public string Calendar { get; set; }
            public string User { get; set; }
            public string Category { get; set; }
            public bool Parsed { get; set; } = false;

            public NewsStorage(string newsUrl)
            {
                NewsUrl = newsUrl;
            }
        }

        public string PublishDate
        {
            get { return CalendarLbl.Text; }
            set { CalendarLbl.Text = value; }
        }

        public string PublishAuthor
        {
            get { return UserLbl.Text; }
            set { UserLbl.Text = value; }
        }

        public string NewsCategory
        {
            get { return CategoryLbl.Text; }
            set { CategoryLbl.Text = value; }
        }

        public string Title
        {
            get { return TitleLbl.Text; }
            set { TitleLbl.Text = value; }
        }

        public Image Thumbnail
        {
            get { return ThumbnailImg.BackgroundImage; }
            set { ThumbnailImg.BackgroundImage = value; }
        }

        public CRNewsPanel()
        {
            InitializeComponent();
        }

        private async Task<NewsStorage> ParseLink(NewsStorage newsStorage)
        {
            if (!String.IsNullOrEmpty(newsStorage.NewsUrl))
            {
                string pageBody = await Downloaders.DownloadPage(newsStorage.NewsUrl);

                if (!String.IsNullOrEmpty(pageBody))
                {
                    Match titleMatch = Regex.Match(pageBody, "page-title\">(.*)<", RegexOptions.RightToLeft);
                    Match calendarMatch = Regex.Match(pageBody, "fa fa-calendar\"><\\/i> (.*)", RegexOptions.RightToLeft);
                    Match userMatch = Regex.Match(pageBody, "fa fa-user\"><\\/i>(.*) ", RegexOptions.RightToLeft);
                    Match categoryMatch = Regex.Match(pageBody, "category tag\">(.*)<", RegexOptions.RightToLeft);

                    if (titleMatch.Success && titleMatch.Groups[1].Success)
                    {
                        newsStorage.Title = titleMatch.Groups[1].Value;
                    }
                    else
                    {
                        Logger.Write("Failed to retrieve title for url \"" + newsStorage.NewsUrl + "\"!", LogLevel.LEVEL_WARN);
                    }

                    if (calendarMatch.Success && calendarMatch.Groups[1].Success)
                    {
                        newsStorage.Calendar = calendarMatch.Groups[1].Value;
                    }
                    else
                    {
                        Logger.Write("Failed to retrieve publish date for url \"" + newsStorage.NewsUrl + "\"!", LogLevel.LEVEL_WARN);
                    }

                    if (userMatch.Success && userMatch.Groups[1].Success)
                    {
                        newsStorage.User = userMatch.Groups[1].Value;
                    }
                    else
                    {
                        Logger.Write("Failed to retrieve publish author for url \"" + newsStorage.NewsUrl + "\"!", LogLevel.LEVEL_WARN);
                    }

                    if (categoryMatch.Success && categoryMatch.Groups[1].Success)
                    {
                        newsStorage.Category = categoryMatch.Groups[1].Value;
                    }
                    else
                    {
                        Logger.Write("Failed to retrieve news category for url \"" + newsStorage.NewsUrl + "\"!", LogLevel.LEVEL_WARN);
                    }

                    if (String.IsNullOrEmpty(newsStorage.ThumbnailUrl_Main))
                    {
                        Match thumbnailMatch = Regex.Match(pageBody, "property=\"og:image\" content=\"(.*)\" /><meta property=\"og:image:url");

                        if (thumbnailMatch.Success && thumbnailMatch.Groups[1].Success)
                        {
                            newsStorage.ThumbnailUrl_Main = thumbnailMatch.Groups[1].Value;
                            newsStorage.ThumbnailUrl_Main = (newsStorage.ThumbnailUrl_Main.Substring(0, newsStorage.ThumbnailUrl_Main.IndexOf(".jpg")) + ".jpg");
                        }

                        Match thumbnailMatchAlt = Regex.Match(pageBody, "<p dir=\"ltr\"><img src=\"(.*)\" data-id=\"");

                        if (thumbnailMatchAlt.Success && thumbnailMatchAlt.Groups[1].Success)
                        {
                            newsStorage.ThumbnailUrl_Alt = thumbnailMatchAlt.Groups[1].Value;
                        }
                    }

                    newsStorage.Parsed = true;
                }
                else
                {
                    Logger.Write("Failed to download news body for url \"" + newsStorage.NewsUrl + "\"!", LogLevel.LEVEL_WARN);
                }
            }

            return newsStorage;
        }

        private void ResetArticles()
        {
            PublishDate = "Loading...";
            PublishAuthor = "Loading...";
            NewsCategory = "Loading...";
            IndexLbl.Text = ((CurrentIndex + 1).ToString() + "/" + NewsArticles.Count.ToString());
            Title = "Loading...";
            ThumbnailImg.BackgroundImage = null;
            PreviousBtn.BackgroundImage = null;
            NextBtn.BackgroundImage = null;
            //PreviousBtn.Visible = false;
            //NextBtn.Visible = false;
        }

        // The commented out stuff in this function works fine, just the image links it retrieves are super low quality.
        public async void ParseArticles(string url)
        {
            if (!String.IsNullOrEmpty(url))
            {
                string pageBody = await Downloaders.DownloadPage(url);

                if (!String.IsNullOrEmpty(pageBody))
                {
                    NewsArticles.Clear();
                    ResetArticles();
                    MatchCollection articleLinks = Regex.Matches(pageBody, "<a class=\"news-tile-wrap\" href=\"(.*)\">");

                    for (Int32 i = 0; i < articleLinks.Count; i++)
                    {
                        Match link = articleLinks[i];

                        if (link.Success && link.Groups[1].Success)
                        {
                            NewsArticles.Add(new NewsStorage("https://www.rocketleague.com" + link.Groups[1].Value));
                        }
                    }

                    LoadAllIndexes(); // Parse and download everything in the background.
                    LoadNextArticle();
                }
                else
                {
                    Logger.Write("Failed to download news article info!", LogLevel.LEVEL_WARN);
                }
            }
        }

        public async void LoadAllIndexes()
        {
            for (Int32 i = 0; i < NewsArticles.Count; i++)
            {
                NewsStorage newsStorage = NewsArticles[i];

                if (!newsStorage.Parsed)
                {
                    NewsArticles[i] = await ParseLink(NewsArticles[i]);
                    newsStorage = NewsArticles[i];
                }

                if (newsStorage.ThumbnailImage == null)
                {
                    if (!String.IsNullOrEmpty(newsStorage.ThumbnailUrl_Main))
                    {
                        newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl_Main);

                        if ((newsStorage.ThumbnailImage == null) && !String.IsNullOrEmpty(newsStorage.ThumbnailUrl_Alt))
                        {
                            newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl_Alt);
                        }

                        // If no thumbnail was found we gotta use our own image.
                        if (newsStorage.ThumbnailImage == null)
                        {
                            newsStorage.ThumbnailUrl_Main = "https://i.imgur.com/dmpY0zQ.png";
                            newsStorage.ThumbnailUrl_Alt = "";
                            newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl_Main);
                        }
                    }
                }

                NewsArticles[i] = newsStorage;
            }
        }

        private async void LoadCurrentIndex()
        {
            if (NewsArticles.Count > 0)
            {
                if ((CurrentIndex > -1) && (CurrentIndex < NewsArticles.Count))
                {
                    ResetArticles();
                    NewsStorage newsStorage = NewsArticles[CurrentIndex];

                    if (!newsStorage.Parsed)
                    {
                        NewsArticles[CurrentIndex] = await ParseLink(NewsArticles[CurrentIndex]);
                        newsStorage = NewsArticles[CurrentIndex];
                    }

                    PublishDate = newsStorage.Calendar;
                    PublishAuthor = newsStorage.User;
                    NewsCategory = newsStorage.Category;
                    Title = newsStorage.Title;

                    if (newsStorage.ThumbnailImage == null)
                    {
                        if (!String.IsNullOrEmpty(newsStorage.ThumbnailUrl_Main))
                        {
                            newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl_Main);

                            if ((newsStorage.ThumbnailImage == null) && !String.IsNullOrEmpty(newsStorage.ThumbnailUrl_Alt))
                            {
                                newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl_Alt);
                            }

                            // If no thumbnail was found we gotta use our own image.
                            if (newsStorage.ThumbnailImage == null)
                            {
                                newsStorage.ThumbnailUrl_Main = "https://i.imgur.com/dmpY0zQ.png";
                                newsStorage.ThumbnailUrl_Alt = "";
                                newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrl_Main);
                            }

                            NewsArticles[CurrentIndex] = newsStorage;
                            ThumbnailImg.BackgroundImage = newsStorage.ThumbnailImage;
                            ThumbnailImg.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else
                        {
                            ThumbnailImg.BackgroundImage = Properties.Resources.Warning_White;
                            ThumbnailImg.BackgroundImageLayout = ImageLayout.Center;
                        }
                    }
                    else
                    {
                        ThumbnailImg.BackgroundImage = newsStorage.ThumbnailImage;
                        ThumbnailImg.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    if (CurrentIndex == 0)
                    {
                        PreviousBtn.BackgroundImage = null;
                        NextBtn.BackgroundImage = Properties.Resources.Forward_White;
                        //PreviousBtn.Visible = false;
                        //NextBtn.Visible = true;
                    }
                    else if (CurrentIndex < (NewsArticles.Count - 1))
                    {
                        PreviousBtn.BackgroundImage = Properties.Resources.Back_White;
                        NextBtn.BackgroundImage = Properties.Resources.Forward_White;
                        //PreviousBtn.Visible = true;
                        //NextBtn.Visible = true;
                    }
                    else
                    {
                        PreviousBtn.BackgroundImage = Properties.Resources.Back_White;
                        NextBtn.BackgroundImage = null;
                        //PreviousBtn.Visible = true;
                        //NextBtn.Visible = false;
                    }
                }
            }
            else
            {
                ResetArticles();
                CurrentIndex = -1;
            }
        }

        public void LoadPreviousArticle()
        {
            if (NewsArticles.Count > 0)
            {
                if (CurrentIndex > 0)
                {
                    CurrentIndex--;
                }
                else
                {
                    CurrentIndex = 0;
                }

                LoadCurrentIndex();
            }
            else
            {
                ResetArticles();
                CurrentIndex = -1;
            }
        }

        public void LoadNextArticle()
        {
            if (NewsArticles.Count > 0)
            {
                if (CurrentIndex < NewsArticles.Count)
                {
                    CurrentIndex++;
                }
                else
                {
                    CurrentIndex = (NewsArticles.Count - 1);
                }

                LoadCurrentIndex();
            }
            else
            {
                ResetArticles();
                CurrentIndex = -1;
            }
        }

        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            LoadPreviousArticle();
        }

        private void PreviousBtn_DoubleClick(object sender, EventArgs e)
        {
            LoadPreviousArticle();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            LoadNextArticle();
        }

        private void NextBtn_DoubleClick(object sender, EventArgs e)
        {
            LoadNextArticle();
        }

        private void OpenCurrentArticle()
        {
            if ((CurrentIndex > -1) && (CurrentIndex < NewsArticles.Count))
            {
                if (!String.IsNullOrEmpty(NewsArticles[CurrentIndex].NewsUrl))
                {
                    Process.Start(new ProcessStartInfo(NewsArticles[CurrentIndex].NewsUrl) { UseShellExecute = true });
                }
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

        private void PreviousBtn_MouseEnter(object sender, EventArgs e)
        {
            PreviousBtn.BackColor = Color.FromArgb(24, 24, 24);
        }

        private void PreviousBtn_MouseLeave(object sender, EventArgs e)
        {
            PreviousBtn.BackColor = Color.FromArgb(22, 22, 22);
        }

        private void NextBtn_MouseEnter(object sender, EventArgs e)
        {
            NextBtn.BackColor = Color.FromArgb(24, 24, 24); // 20
        }

        private void NextBtn_MouseLeave(object sender, EventArgs e)
        {
            NextBtn.BackColor = Color.FromArgb(22, 22, 22); // 18
        }
    }
}
