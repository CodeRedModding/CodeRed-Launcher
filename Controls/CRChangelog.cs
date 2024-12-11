using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

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
        private IconStore m_icons = new IconStore();
        private ChangelogViews m_view = ChangelogViews.Module;
        private string m_moduleTextRaw = "Loading...";
        private string m_launcherTextRaw = "Loading...";
        private string m_moduleText = "Loading...";
        private string m_launcherText = "Loading...";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme ControlType
        {
            get { return m_icons.Control; }
            set { m_icons.Control = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public IconTheme IconType
        {
            get { return m_icons.Theme; }
            set { m_icons.Theme = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ChangelogViews DisplayType
        {
            get { return m_view; }
            set { m_view = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconWhite
        {
            get { return m_icons.GetIcon(IconTheme.White); }
            set { m_icons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconBlack
        {
            get { return m_icons.GetIcon(IconTheme.Black); }
            set { m_icons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconRed
        {
            get { return m_icons.GetIcon(IconTheme.Red); }
            set { m_icons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconPurple
        {
            get { return m_icons.GetIcon(IconTheme.Purple); }
            set { m_icons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconBlue
        {
            get { return m_icons.GetIcon(IconTheme.Blue); }
            set { m_icons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TitleFont
        {
            get { return TitleLbl.Font; }
            set { TitleLbl.Font = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font DescriptionFont
        {
            get { return DescriptionLbl.Font; }
            set { DescriptionLbl.Font = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ModuleText
        {
            get { return m_moduleTextRaw; }
            set { m_moduleText = Format(value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string LauncherText
        {
            get { return m_launcherTextRaw; }
            set { m_launcherText = Format(value); UpdateTheme(); }
        }

        public CRChangelog()
        {
            InitializeComponent();
        }

        private string Format(string str)
        {
            str = ("- " + str.Replace("\\n", "\n- "));
            str = str.Replace("`", "\"");
            return str;
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
                DescriptionLbl.Text = m_moduleText;
                DescriptionLbl.TextAlign = ContentAlignment.MiddleLeft;
            }
            else if (DisplayType == ChangelogViews.Launcher)
            {
                TitleLbl.Text = "Launcher Changelog";
                DescriptionLbl.Text = m_launcherText;
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

            TitleImg.BackgroundImage = m_icons.GetThemeIcon();
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
