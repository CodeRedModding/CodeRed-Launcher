using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public enum VersionViews : byte
    {
        Loading,
        Idle,
        Checking,
        Downloading,
        ModuleOutdated,
        LauncherOutdated,
        BothOutdated,
        Safe,
        Unsafe
    }

    public partial class CRVersionStatus : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.Red;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private VersionViews m_view = VersionViews.Loading;
        private IconStore m_titleIcons = new IconStore();
        private IconStore m_descIcons = new IconStore();
        private IconStore m_warningIcons = new IconStore();

        public bool IsDarkMode()
        {
            return m_titleIcons.IsDarkMode();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme Theme
        {
            get
            {
                return m_titleIcons.Theme;
            }
            set
            {
                m_titleIcons.Theme = value;
                m_titleIcons.IconTheme = (IsDarkMode() ? m_darkIcon : m_lightIcon);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconTitleDark
        {
            get
            {
                return m_titleIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_titleIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconTitleLight
        {
            get
            {
                return m_titleIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_titleIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDescDark
        {
            get
            {
                return m_descIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_descIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDescLight
        {
            get
            {
                return m_descIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_descIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconWarnDark
        {
            get
            {
                return m_warningIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_warningIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconWarnLight
        {
            get
            {
                return m_warningIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_warningIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public VersionViews View
        {
            get
            {
                return m_view;
            }
            set
            {
                if (m_view != value)
                {
                    m_view = value;
                    OnThemeUpdated();
                }
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

        public CRVersionStatus()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            if (IsDarkMode())
            {
                this.BackColor = GPalette.LightBlack;
                TitleLbl.ForeColor = GPalette.White;
                DescriptionLbl.ForeColor = GPalette.White;
            }
            else
            {
                this.BackColor = GPalette.White;
                TitleLbl.ForeColor = GPalette.Black;
                DescriptionLbl.ForeColor = GPalette.Black;
            }

            m_warningIcons.Theme = Theme;
            m_warningIcons.IconTheme = m_titleIcons.IconTheme;
            m_descIcons.Theme = Theme;
            m_descIcons.IconTheme = m_titleIcons.IconTheme;
            DescriptionImg.BackgroundImage = m_descIcons.GetIcon();

            FormatView();
            Invalidate();
        }

        public void FormatView()
        {
            switch (View)
            {
                case VersionViews.Idle:
                    TitleLbl.Text = "Waiting";
                    DescriptionLbl.Text = "Automatically checking for updates is disabled.";
                    TitleImg.BackgroundImage = m_titleIcons.GetIcon();
                    break;
                case VersionViews.Checking:
                    TitleLbl.Text = "Checking for Updates";
                    DescriptionLbl.Text = "Waiting for response...";
                    TitleImg.BackgroundImage = m_titleIcons.GetIcon();
                    break;
                case VersionViews.Downloading:
                    TitleLbl.Text = "Update in Progress";
                    DescriptionLbl.Text = "Downloading and installing...";
                    TitleImg.BackgroundImage = m_titleIcons.GetIcon();
                    break;
                case VersionViews.ModuleOutdated:
                    TitleLbl.Text = "Module Out of Date";
                    DescriptionLbl.Text = "Your module version is out of date!";
                    TitleImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case VersionViews.LauncherOutdated:
                    TitleLbl.Text = "Launcher Out of Date";
                    DescriptionLbl.Text = "Your launcher version is out of date!";
                    TitleImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case VersionViews.BothOutdated:
                    TitleLbl.Text = "Both Out of Date";
                    DescriptionLbl.Text = "Both the launcher and module are out of date!";
                    TitleImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case VersionViews.Safe:
                    TitleLbl.Text = "Version up to Date";
                    DescriptionLbl.Text = "You're on the latest release of CodeRed.";
                    TitleImg.BackgroundImage = m_titleIcons.GetIcon();
                    break;
                case VersionViews.Unsafe:
                    TitleLbl.Text = "Incompatible Version";
                    DescriptionLbl.Text = "Please wait for a new version to be released.";
                    TitleImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                default:
                    TitleLbl.Text = "Loading...";
                    DescriptionLbl.Text = "Loading...";
                    TitleImg.BackgroundImage = m_titleIcons.GetIcon();
                    break;
            }
        }
    }
}
