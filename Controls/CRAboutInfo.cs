using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRAboutInfo : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.Red;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private IconStore m_icons = new IconStore();
        private bool m_hyperlink = false;

        public bool IsDarkMode()
        {
            return m_icons.IsDarkMode();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme Theme
        {
            get
            {
                return m_icons.Theme;
            }
            set
            {
                m_icons.Theme = value;
                m_icons.IconTheme = (IsDarkMode() ? m_darkIcon : m_lightIcon);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDark
        {
            get
            {
                return m_icons.GetIcon(m_darkIcon);
            }
            set
            {
                m_icons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconLight
        {
            get
            {
                return m_icons.GetIcon(m_lightIcon);
            }
            set
            {
                m_icons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Hyperlink
        {
            get
            {
                return m_hyperlink;
            }
            set
            {
                m_hyperlink = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TitleFont
        {
            get
            {
                return TitleLbl.Font;
            }
            set
            {
                TitleLbl.Font = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TitleText
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
        public Font DescriptionFont
        {
            get
            {
                return DescriptionLbl.Font;
            }
            set
            {
                DescriptionLbl.Font = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DescriptionText
        {
            get
            {
                return DescriptionLbl.Text;
            }
            set
            {
                DescriptionLbl.Text = value;
                OnThemeUpdated();
            }
        }

        public CRAboutInfo()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            IconImg.BackgroundImage = m_icons.GetIcon();
            TitleLbl.ForeColor = (IsDarkMode() ? GPalette.White : GPalette.Black);

            if (Hyperlink)
            {
                DescriptionLbl.ForeColor = (IsDarkMode() ? GPalette.CodeRed : GPalette.CodePurple);
                DescriptionLbl.Cursor = Cursors.Hand;
            }
            else
            {
                DescriptionLbl.ForeColor = (IsDarkMode() ? GPalette.Grey : GPalette.LightBlack);
                DescriptionLbl.Cursor = Cursors.Default;
            }

            Invalidate();
        }

        private void OpenLink()
        {
            if (Hyperlink && !string.IsNullOrEmpty(DescriptionText))
            {
                Process.Start(new ProcessStartInfo(DescriptionText) { UseShellExecute = true });
            }
        }

        private void DescriptionLbl_Click(object sender, EventArgs eventArgs)
        {
            OpenLink();
        }

        private void DescriptionLbl_DoubleClick(object sender, EventArgs eventArgs)
        {
            OpenLink();
        }
    }
}
