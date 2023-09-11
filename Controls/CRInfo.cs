using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRInfo : UserControl
    {
        private IconStore _icons = new IconStore();
        private bool _syncColor = false;
        private bool _hyperlink = false;

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

        public bool IconSync
        {
            get { return _syncColor; }
            set { _syncColor = value; UpdateTheme(); }
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

        public Image GetIcon()
        {
            return _icons.GetThemeIcon();
        }

        public bool Hyperlink
        {
            get { return _hyperlink; }
            set { _hyperlink = value; UpdateTheme(); }
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
                    InfoDescriptionLbl.ForeColor = _icons.GetColor();
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
