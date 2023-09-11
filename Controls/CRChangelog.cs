using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public enum ChangelogViews : byte
    {
        Module,
        Launcher,
        Offline
    }

    public partial class CRChangelog : UserControl
    {
        private IconStore _icons = new IconStore();
        private ChangelogViews _view = ChangelogViews.Module;
        private string _moduleTextRaw = "Loading...";
        private string _launcherTextRaw = "Loading...";
        private string _moduleText = "Loading...";
        private string _launcherText = "Loading...";

        public ControlTheme ControlType
        {
            get { return _icons.Control; }
            set { _icons.Control = value; UpdateTheme(); }
        }

        public IconTheme IconType
        {
            get { return _icons.Theme; }
            set { _icons.Theme = value; UpdateTheme(); }
        }

        public ChangelogViews DisplayType
        {
            get { return _view; }
            set { _view = value; UpdateTheme(); }
        }

        public Image IconWhite
        {
            get { return _icons.GetIcon(IconTheme.White); }
            set { _icons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image IconBlack
        {
            get { return _icons.GetIcon(IconTheme.Black); }
            set { _icons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image IconRed
        {
            get { return _icons.GetIcon(IconTheme.Red); }
            set { _icons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image IconPurple
        {
            get { return _icons.GetIcon(IconTheme.Purple); }
            set { _icons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image IconBlue
        {
            get { return _icons.GetIcon(IconTheme.Blue); }
            set { _icons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Font TitleFont
        {
            get { return TitleLbl.Font; }
            set { TitleLbl.Font = value; UpdateTheme(); }
        }

        public Font DescriptionFont
        {
            get { return DescriptionLbl.Font; }
            set { DescriptionLbl.Font = value; UpdateTheme(); }
        }

        public string ModuleText
        {
            get { return _moduleTextRaw; }
            set { _moduleText = Format(value); UpdateTheme(); }
        }

        public string LauncherText
        {
            get { return _launcherTextRaw; }
            set { _launcherText = Format(value); UpdateTheme(); }
        }

        public CRChangelog()
        {
            InitializeComponent();
        }

        private string Format(string str)
        {
            return ("- " + str.Replace("\\n", "\n- "));
        }

        public void SetTheme(ControlTheme control, IconTheme icon)
        {
            ControlType = control;
            IconType = icon;
        }

        private void UpdateTheme()
        {
            if (DisplayType == ChangelogViews.Module)
            {
                TitleLbl.Text = "Module Changelog";
                DescriptionLbl.Text = _moduleText;
                DescriptionLbl.TextAlign = ContentAlignment.MiddleLeft;
            }
            else if (DisplayType == ChangelogViews.Launcher)
            {
                TitleLbl.Text = "Launcher Changelog";
                DescriptionLbl.Text = _launcherText;
                DescriptionLbl.TextAlign = ContentAlignment.MiddleLeft;
            }
            else if (DisplayType == ChangelogViews.Offline)
            {
                TitleLbl.Text = "Module changelog";
                DescriptionLbl.Text = "Cannot retrieve changelog information while offline";
                DescriptionLbl.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (ControlType == ControlTheme.Dark)
            {
                this.BackColor = GPalette.LightBlack;
                TitleLbl.ForeColor = GPalette.White;
                DescriptionLbl.ForeColor = GPalette.White;
            }
            else if (ControlType == ControlTheme.Light)
            {
                this.BackColor = GPalette.White;
                TitleLbl.ForeColor = GPalette.Black;
                DescriptionLbl.ForeColor = GPalette.Black;
            }

            TitleImg.BackgroundImage = _icons.GetThemeIcon();
            Invalidate();
        }

        private void TitleImg_Click(object sender, EventArgs e)
        {
            ToggleType();
        }

        private void TitleImg_DoubleClick(object sender, EventArgs e)
        {
            ToggleType();
        }

        private void TitleLbl_Click(object sender, EventArgs e)
        {
            ToggleType();
        }

        private void TitleLbl_DoubleClick(object sender, EventArgs e)
        {
            ToggleType();
        }

        public void ToggleType()
        {
            DisplayType = ((DisplayType == ChangelogViews.Module) ? ChangelogViews.Launcher : ChangelogViews.Module);
            UpdateTheme();
        }
    }
}
