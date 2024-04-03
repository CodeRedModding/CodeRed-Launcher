using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRInfo : UserControl
    {
        private IconStore m_icons = new IconStore();
        private bool m_syncColor = false;
        private bool m_hyperlink = false;

        public ControlTheme ControlType
        {
            get { return m_icons.Control; }
            set { m_icons.Control = value; UpdateTheme(); }
        }

        public IconTheme IconType
        {
            get { return m_icons.Theme; }
            set { m_icons.Theme = value; UpdateTheme(); }
        }

        public bool IconSync
        {
            get { return m_syncColor; }
            set { m_syncColor = value; UpdateTheme(); }
        }

        public Image IconWhite
        {
            get { return m_icons.GetIcon(IconTheme.White); }
            set { m_icons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image IconBlack
        {
            get { return m_icons.GetIcon(IconTheme.Black); }
            set { m_icons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image IconRed
        {
            get { return m_icons.GetIcon(IconTheme.Red); }
            set { m_icons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image IconPurple
        {
            get { return m_icons.GetIcon(IconTheme.Purple); }
            set { m_icons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image IconBlue
        {
            get { return m_icons.GetIcon(IconTheme.Blue); }
            set { m_icons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image GetIcon()
        {
            return m_icons.GetThemeIcon();
        }

        public bool Hyperlink
        {
            get { return m_hyperlink; }
            set { m_hyperlink = value; UpdateTheme(); }
        }

        public Font TitleFont
        {
            get { return InfoTitleLbl.Font; }
            set { InfoTitleLbl.Font = value; UpdateTheme(); }
        }

        public Font DescriptionFont
        {
            get { return InfoDescriptionLbl.Font; }
            set { InfoDescriptionLbl.Font = value; UpdateTheme(); }
        }

        public string DisplayTitle
        {
            get { return InfoTitleLbl.Text; }
            set { InfoTitleLbl.Text = value; UpdateTheme(); }
        }

        public string DisplayDescription
        {
            get { return InfoDescriptionLbl.Text; }
            set { InfoDescriptionLbl.Text = value; }
        }

        public CRInfo()
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
            InfoImg.BackgroundImage = GetIcon();
            InfoImg.Visible = (InfoImg.BackgroundImage != null);

            if (ControlType == ControlTheme.Dark)
            {
                InfoTitleLbl.ForeColor = GPalette.White;
                InfoDescriptionLbl.ForeColor = GPalette.Grey;
            }
            else if (ControlType == ControlTheme.Light)
            {
                InfoTitleLbl.ForeColor = GPalette.Black;
                InfoDescriptionLbl.ForeColor = GPalette.LightBlack;
            }

            if (Hyperlink)
            {
                if (IconSync)
                {
                    InfoDescriptionLbl.ForeColor = m_icons.GetColor();
                }
                else if (ControlType == ControlTheme.Dark)
                {
                    InfoDescriptionLbl.ForeColor = GPalette.CodeRed;
                }
                else if (ControlType == ControlTheme.Light)
                {
                    InfoDescriptionLbl.ForeColor = GPalette.CodePurple;
                }

                InfoDescriptionLbl.Cursor = Cursors.Hand;
            }
            else
            {
                InfoDescriptionLbl.Cursor = Cursors.Default;
            }

            Invalidate();
        }

        private void OpenLink()
        {
            if (Hyperlink && !string.IsNullOrEmpty(InfoDescriptionLbl.Text))
            {
                Process.Start(new ProcessStartInfo(InfoDescriptionLbl.Text) { UseShellExecute = true });
            }
        }

        private void InfoDescriptionLbl_Click(object sender, EventArgs e)
        {
            OpenLink();
        }

        private void InfoDescriptionLbl_DoubleClick(object sender, EventArgs e)
        {
            OpenLink();
        }
    }
}
