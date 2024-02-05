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
    public partial class CRNews : UserControl
    {
        private IconStore _calendarIcons = new IconStore();
        private IconStore _authorIcons = new IconStore();
        private IconStore _categoryIcons = new IconStore();
        private IconStore _leftIcons = new IconStore();
        private IconStore _rightIcons = new IconStore();
        private List<NewsStorage> _articles = new List<NewsStorage>();
        private Int32 _index = -1;

        private class NewsStorage
        {
            public string NewsUrl { get; set; }
            public string ThumbnailUrl { get; set; }
            public string ThumbnailUrlAlt { get; set; }
            public Image ThumbnailImage { get; set; } = null;
            public string Title { get; set; }
            public string Calendar { get; set; }
            public string Author { get; set; }
            public string Category { get; set; }
            public bool Parsed { get; set; } = false;

            public NewsStorage(string bodyContent)
            {
                ParseJson(bodyContent);
            }

            public void ParseJson(string bodyContent)
            {
                if (bodyContent.Contains("slug"))
                {
                    Match titleMatch = Regex.Match(bodyContent, "(?<=\"title\":\")(.*?)(?=\")");
                    Match urlMatch = Regex.Match(bodyContent, "(?<=\"slug\":\")(.*?)(?=\")");
                    Match imageMatch = Regex.Match(bodyContent, "(?<=\"imageUrl\":\")(.*?)(?=\")");

                    if (titleMatch.Success && titleMatch.Groups[1].Success)
                    {
                        Title = titleMatch.Groups[1].Value;
                    }

                    if (urlMatch.Success && urlMatch.Groups[1].Success)
                    {
                        NewsUrl = ("https://www.rocketleague.com/en/news/" + urlMatch.Groups[1].Value);
                    }

                    if (imageMatch.Success && imageMatch.Groups[1].Success)
                    {
                        ThumbnailUrl = imageMatch.Groups[1].Value;
                    }
                }
            }
        }

        public ControlTheme ControlType
        {
            get { return _calendarIcons.Control; }
            set { _calendarIcons.Control = value; _authorIcons.Control = value; _categoryIcons.Control = value; _leftIcons.Control = value; _rightIcons.Control = value; UpdateTheme(); }
        }

        public IconTheme IconType
        {
            get { return _calendarIcons.Theme; }
            set { _calendarIcons.Theme = value; _authorIcons.Theme = value; _categoryIcons.Theme = value; _leftIcons.Theme = value; _rightIcons.Theme = value; UpdateTheme(); }
        }

        public Image CalendarWhite
        {
            get { return _calendarIcons.GetIcon(IconTheme.White); }
            set { _calendarIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image CalendarBlack
        {
            get { return _calendarIcons.GetIcon(IconTheme.Black); }
            set { _calendarIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image CalendarRed
        {
            get { return _calendarIcons.GetIcon(IconTheme.Red); }
            set { _calendarIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image CalendarPurple
        {
            get { return _calendarIcons.GetIcon(IconTheme.Purple); }
            set { _calendarIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image CalendarBlue
        {
            get { return _calendarIcons.GetIcon(IconTheme.Blue); }
            set { _calendarIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image AuthorWhite
        {
            get { return _authorIcons.GetIcon(IconTheme.White); }
            set { _authorIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image AuthorBlack
        {
            get { return _authorIcons.GetIcon(IconTheme.Black); }
            set { _authorIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image AuthorRed
        {
            get { return _authorIcons.GetIcon(IconTheme.Red); }
            set { _authorIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image AuthorPurple
        {
            get { return _authorIcons.GetIcon(IconTheme.Purple); }
            set { _authorIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image AuthorBlue
        {
            get { return _authorIcons.GetIcon(IconTheme.Blue); }
            set { _authorIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image CategoryWhite
        {
            get { return _categoryIcons.GetIcon(IconTheme.White); }
            set { _categoryIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image CategoryBlack
        {
            get { return _categoryIcons.GetIcon(IconTheme.Black); }
            set { _categoryIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image CategoryRed
        {
            get { return _categoryIcons.GetIcon(IconTheme.Red); }
            set { _categoryIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image CategoryPurple
        {
            get { return _categoryIcons.GetIcon(IconTheme.Purple); }
            set { _categoryIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image CategoryBlue
        {
            get { return _categoryIcons.GetIcon(IconTheme.Blue); }
            set { _categoryIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image LeftWhite
        {
            get { return _leftIcons.GetIcon(IconTheme.White); }
            set { _leftIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image LeftBlack
        {
            get { return _leftIcons.GetIcon(IconTheme.Black); }
            set { _leftIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image LeftRed
        {
            get { return _leftIcons.GetIcon(IconTheme.Red); }
            set { _leftIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image LeftPurple
        {
            get { return _leftIcons.GetIcon(IconTheme.Purple); }
            set { _leftIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image LeftBlue
        {
            get { return _leftIcons.GetIcon(IconTheme.Blue); }
            set { _leftIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image RightWhite
        {
            get { return _rightIcons.GetIcon(IconTheme.White); }
            set { _rightIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image RightBlack
        {
            get { return _rightIcons.GetIcon(IconTheme.Black); }
            set { _rightIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image RightRed
        {
            get { return _rightIcons.GetIcon(IconTheme.Red); }
            set { _rightIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image RightPurple
        {
            get { return _rightIcons.GetIcon(IconTheme.Purple); }
            set { _rightIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image RightBlue
        {
            get { return _rightIcons.GetIcon(IconTheme.Blue); }
            set { _rightIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public string PublishDate
        {
            get { return CalendarLbl.DisplayText; }
            set { CalendarLbl.DisplayText = value; }
        }

        public string PublishAuthor
        {
            get { return AuthorLbl.DisplayText; }
            set { AuthorLbl.DisplayText = value; }
        }

        public string NewsCategory
        {
            get { return CategoryLbl.DisplayText; }
            set { CategoryLbl.DisplayText = value; }
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
                PreviousBtn.BackgroundImage = _leftIcons.GetThemeIcon();
            }

            if (NextBtn.BackgroundImage != null)
            {
                NextBtn.BackgroundImage = _rightIcons.GetThemeIcon();
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
            if (_articles.Count > 0)
            {
                if (_index > 0)
                {
                    _index--;
                }
                else
                {
                    _index = 0;
                }

                LoadIndex();
            }
            else
            {
                ResetArticles();
                _index = -1;
            }
        }

        public void LoadNextArticle()
        {
            if (_articles.Count > 0)
            {
                if (_index < _articles.Count)
                {
                    _index++;
                }
                else
                {
                    _index = (_articles.Count - 1);
                }

                LoadIndex();
            }
            else
            {
                ResetArticles();
                _index = -1;
            }
        }

        private void OpenCurrentArticle()
        {
            if ((_index > -1) && (_index < _articles.Count) && !string.IsNullOrEmpty(_articles[_index].NewsUrl))
            {
                Process.Start(new ProcessStartInfo(_articles[_index].NewsUrl) { UseShellExecute = true });
            }
        }

        private async Task<NewsStorage> ParseLink(NewsStorage newsStorage)
        {
            if (!string.IsNullOrEmpty(newsStorage.NewsUrl))
            {
                string pageBody = await Downloaders.DownloadPage(newsStorage.NewsUrl);

                if (!string.IsNullOrEmpty(pageBody))
                {
                    if (string.IsNullOrEmpty(newsStorage.Title))
                    {
                        Match titleMatch = Regex.Match(pageBody, "\"headline\": \"(.*)\"");

                        if (titleMatch.Success && titleMatch.Groups[1].Success)
                        {
                            newsStorage.Title = titleMatch.Groups[1].Value;
                        }
                    }

                    Match calendarMatch = Regex.Match(pageBody.Replace("\r", "").Replace("  ", "").Replace("\n", ""), "<p class=\"is-5 is-uppercase\">(.*?)<");
                    Match userMatch = Regex.Match(pageBody, "\"author\": \"(.*)\"");
                    Match categoryMatch = Regex.Match(pageBody, "\"category tag\">(.*)<\\/a><\\/p>");

                    if (calendarMatch.Success && calendarMatch.Groups[1].Success)
                    {
                        newsStorage.Calendar = calendarMatch.Groups[1].Value;
                    }

                    if (userMatch.Success && userMatch.Groups[1].Success)
                    {
                        newsStorage.Author = userMatch.Groups[1].Value;
                    }

                    if (categoryMatch.Success && categoryMatch.Groups[1].Success)
                    {
                        newsStorage.Category = categoryMatch.Groups[1].Value;
                    }

                    if (string.IsNullOrEmpty(newsStorage.ThumbnailUrl))
                    {
                        Match thumbnailMatch = Regex.Match(pageBody, "property=\"og:image\" content=\"(.*)\" /><meta property=\"og:image:url");

                        if (thumbnailMatch.Success && thumbnailMatch.Groups[1].Success)
                        {
                            newsStorage.ThumbnailUrl = thumbnailMatch.Groups[1].Value;
                            Int32 jpg = newsStorage.ThumbnailUrl.IndexOf(".jpg");
                            Int32 png = newsStorage.ThumbnailUrl.IndexOf(".png");

                            if (jpg > 0)
                            {
                                newsStorage.ThumbnailUrl = (newsStorage.ThumbnailUrl.Substring(0, jpg) + ".jpg");
                            }
                            else if (png > 0)
                            {
                                newsStorage.ThumbnailUrl = (newsStorage.ThumbnailUrl.Substring(0, png) + ".png");
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
                    Logger.Write("Failed to download news body for url \"" + newsStorage.NewsUrl + "\"!", LogLevel.LEVEL_WARN);
                }
            }

            return newsStorage;
        }

        public async void ParseArticles(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                string pageBody = await Downloaders.DownloadPage(url);

                if (!string.IsNullOrEmpty(pageBody))
                {
                    _articles.Clear();
                    ResetArticles();
                    MatchCollection articleLinks = Regex.Matches(pageBody.Replace("\\", ""), "(?=\"title\")(.*?)(?=})");

                    for (Int32 i = 0; i < articleLinks.Count; i++)
                    {
                        Match link = articleLinks[i];

                        if (link.Success && link.Groups[1].Success && link.Groups[1].Value.Contains("slug"))
                        {
                            _articles.Add(new NewsStorage(link.Groups[1].Value));
                        }
                    }

                    LoadAllIndexes(); // Parse and download everything in the background.
                    LoadPreviousArticle();
                }
                else
                {
                    Logger.Write("Failed to download news article info!", LogLevel.LEVEL_WARN);
                }
            }
        }

        public async void LoadAllIndexes()
        {
            for (Int32 i = 0; i < _articles.Count; i++)
            {
                NewsStorage newsStorage = _articles[i];

                if (!newsStorage.Parsed)
                {
                    _articles[i] = await ParseLink(_articles[i]);
                    newsStorage = _articles[i];
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
                            newsStorage.ThumbnailUrlAlt = "https://i.imgur.com/dmpY0zQ.png";
                            newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrlAlt);
                        }
                    }
                }

                _articles[i] = newsStorage;
            }
        }

        private async void LoadIndex()
        {
            if (_articles.Count > 0)
            {
                if ((_index > -1) && (_index < _articles.Count))
                {
                    ResetArticles();
                    NewsStorage newsStorage = _articles[_index];

                    if (!newsStorage.Parsed)
                    {
                        _articles[_index] = await ParseLink(_articles[_index]);
                        newsStorage = _articles[_index];
                    }

                    PublishDate = newsStorage.Calendar;
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
                                newsStorage.ThumbnailUrlAlt = "https://i.imgur.com/dmpY0zQ.png";
                                newsStorage.ThumbnailImage = await Downloaders.DownloadImage(newsStorage.ThumbnailUrlAlt);
                            }

                            _articles[_index] = newsStorage;
                            ThumbnailImg.BackgroundImage = newsStorage.ThumbnailImage;
                            ThumbnailImg.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                    else
                    {
                        ThumbnailImg.BackgroundImage = newsStorage.ThumbnailImage;
                        ThumbnailImg.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    if (_index == 0)
                    {
                        PreviousBtn.BackgroundImage = null;
                        NextBtn.BackgroundImage = _rightIcons.GetThemeIcon();
                    }
                    else if (_index < (_articles.Count - 1))
                    {
                        PreviousBtn.BackgroundImage = _leftIcons.GetThemeIcon();
                        NextBtn.BackgroundImage = _rightIcons.GetThemeIcon();
                    }
                    else
                    {
                        PreviousBtn.BackgroundImage = _leftIcons.GetThemeIcon();
                        NextBtn.BackgroundImage = null;
                    }
                }
            }
            else
            {
                ResetArticles();
                _index = -1;
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