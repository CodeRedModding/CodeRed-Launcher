using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeRedLauncher.Controls
{
    public partial class CRNewsPanel : UserControl
    {
        private Int32 CurrentIndex = 0;
        private List<NewsStorage> NewsArticles = new List<NewsStorage>();

        private class NewsStorage
        {
            public string NewsUrl { get; set; }
            public string ThumbnailUrl { get; set; }
            public Image ThumbnailImage { get; set; } = null;
            public string Title { get; set; }
            public string Calendar { get; set; }
            public string User { get; set; }
            public string Category { get; set; }
            public bool Parsed { get; set; } = false;

            public NewsStorage(string newsUrl, string thumbnailUrl = null)
            {
                NewsUrl = newsUrl;
                ThumbnailUrl = thumbnailUrl;
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
                    Match titleMatch = Regex.Match(pageBody, "page-title\">(.*)<", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    Match calendarMatch = Regex.Match(pageBody, "fa fa-calendar\"><\\/i> (.*)", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    Match userMatch = Regex.Match(pageBody, "fa fa-user\"><\\/i>(.*) ", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    Match categoryMatch = Regex.Match(pageBody, "category tag\">(.*)<", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

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

                    if (String.IsNullOrEmpty(newsStorage.ThumbnailUrl))
                    {
                        Match thumbnailMatchOne = Regex.Match(pageBody, "\" src=\"(.*)\" class=\"attachment", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

                        if (thumbnailMatchOne.Success && thumbnailMatchOne.Groups[1].Success)
                        {
                            newsStorage.ThumbnailUrl = thumbnailMatchOne.Groups[1].Value;
                        }
                        else if (pageBody.Contains("blog-video-player")) // This usually happens when there is a video link instead of a thumbnail.
                        {
                            Match thumbnailMatchAlt = Regex.Match(pageBody, "<img src=\"(.*)\" alt=\"[^article]", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

                            if (thumbnailMatchAlt.Success && thumbnailMatchAlt.Groups[1].Success)
                            {
                                newsStorage.ThumbnailUrl = thumbnailMatchAlt.Groups[1].Value;
                            }
                        }
                        else if (newsStorage.Category.ToLower().Contains("community")) // This usually happens with community spotlights.
                        {
                            Match thumbnailMatchAlt = Regex.Match(pageBody, "<p dir=\"ltr\"><img src=\"(.*)\" data-id=\"", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

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
            Title = "Loading...";
            ThumbnailImg.BackgroundImage = null;
            PreviousBtn.Visible = false;
            NextBtn.Visible = true;
            CurrentIndex = 0;
            NewsArticles.Clear();
        }

        public async void ParseArticles(string url)
        {
            if (!String.IsNullOrEmpty(url))
            {
                string pageBody = await Downloaders.DownloadPage(url);

                if (!String.IsNullOrEmpty(pageBody))
                {
                    ResetArticles();
                    MatchCollection articleLinks = Regex.Matches(pageBody, "<a class=\"news-tile-wrap\" href=\"(.*)\">");
                    //MatchCollection thumbnailLinks = Regex.Matches(pageBody, "<img src=\"(.*)\" alt=\"article-image\"\\/>");

                    for (Int32 i = 0; i < articleLinks.Count; i++)
                    {
                        Match link = articleLinks[i];
                        //Match thumbnail = thumbnailLinks[i];

                        if (link.Success && link.Groups[1].Success)
                        {
                            //NewsArticles.Add(new NewsStorage("https://www.rocketleague.com" + link.Groups[1].Value, thumbnail.Groups[1].Value));
                            NewsArticles.Add(new NewsStorage("https://www.rocketleague.com" + link.Groups[1].Value));
                        }
                    }

                    LoadCurrentIndex();
                }
                else
                {
                    Logger.Write("Failed to download news article info!", LogLevel.LEVEL_WARN);
                }
            }
        }

        private async void LoadCurrentIndex()
        {
            if (CurrentIndex < NewsArticles.Count)
            {
                NewsStorage article = NewsArticles[CurrentIndex];

                if (!article.Parsed)
                {
                    NewsArticles[CurrentIndex] = await ParseLink(NewsArticles[CurrentIndex]);
                    article = NewsArticles[CurrentIndex];
                }

                PublishDate = article.Calendar;
                PublishAuthor = article.User;
                NewsCategory = article.Category;
                Title = article.Title;

                if (article.ThumbnailImage == null)
                {
                    if (!String.IsNullOrEmpty(article.ThumbnailUrl))
                    {
                        ThumbnailImg.LoadAsync(article.ThumbnailUrl);
                    }
                    else
                    {
                        ThumbnailImg.BackgroundImage = Properties.Resources.Warning_White;
                    }
                }
                else
                {
                    ThumbnailImg.BackgroundImage = article.ThumbnailImage;
                    ThumbnailImg.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        public void LoadPreviousArticle()
        {
            if (CurrentIndex > 0)
            {
                CurrentIndex--;
                LoadCurrentIndex();
            }

            if (CurrentIndex == 0)
            {
                PreviousBtn.Visible = false;
                NextBtn.Visible = true;
            }
            else if (CurrentIndex != (NewsArticles.Count - 1))
            {
                PreviousBtn.Visible = true;
                NextBtn.Visible = true;
            }
        }

        public void LoadNextArticle()
        {
            if (CurrentIndex < NewsArticles.Count)
            {
                CurrentIndex++;
                LoadCurrentIndex();
            }

            if (CurrentIndex == (NewsArticles.Count - 1))
            {
                PreviousBtn.Visible = true;
                NextBtn.Visible = false;
            }
            else if (CurrentIndex != 0)
            {
                PreviousBtn.Visible = true;
                NextBtn.Visible = true;
            }
        }

        private void ThumbnailImg_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (NewsArticles.Count > 0 && NewsArticles.Count > CurrentIndex)
            {
                if (NewsArticles[CurrentIndex].ThumbnailImage == null)
                {
                    NewsArticles[CurrentIndex].ThumbnailImage = ThumbnailImg.Image;
                }

                if (ThumbnailImg.Image != null)
                {
                    ThumbnailImg.BackgroundImage = ThumbnailImg.Image;
                    ThumbnailImg.Image = null;
                }

                ThumbnailImg.BackgroundImageLayout = ImageLayout.Stretch;
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

        private void ThumbnailImg_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(NewsArticles[CurrentIndex].NewsUrl) { UseShellExecute = true });
        }

        private void PreviousBtn_MouseEnter(object sender, EventArgs e)
        {
            PreviousBtn.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void PreviousBtn_MouseLeave(object sender, EventArgs e)
        {
            PreviousBtn.BackColor = Color.FromArgb(18, 18, 18);
        }

        private void NextBtn_MouseEnter(object sender, EventArgs e)
        {
            NextBtn.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void NextBtn_MouseLeave(object sender, EventArgs e)
        {
            NextBtn.BackColor = Color.FromArgb(18, 18, 18);
        }
    }
}
