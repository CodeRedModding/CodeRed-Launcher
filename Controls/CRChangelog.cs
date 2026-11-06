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
        const IconTheme m_darkIcon = IconTheme.Red;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private IconStore m_moduleIcons = new IconStore();
        private IconStore m_launcherIcons = new IconStore();
        private ChangelogViews m_view = ChangelogViews.Module;
        private string m_moduleText = "Loading...";
        private string m_moduleTextRaw = "Loading...";
        private string m_launcherTextRaw = "Loading...";
        private string m_launcherText = "Loading...";
        const Int32 m_titleSpacing = 13;

        public bool IsDarkMode()
        {
            return m_moduleIcons.IsDarkMode();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme Theme
        {
            get
            {
                return m_moduleIcons.Theme;
            }
            set
            {
                m_moduleIcons.Theme = value;
                m_moduleIcons.IconTheme = (IsDarkMode() ? m_darkIcon : m_lightIcon);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconModuleDark
        {
            get
            {
                return m_moduleIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_moduleIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconModuleLight
        {
            get
            {
                return m_moduleIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_moduleIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconLauncherDark
        {
            get
            {
                return m_launcherIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_launcherIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconLauncherLight
        {
            get
            {
                return m_launcherIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_launcherIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ChangelogViews View
        {
            get
            {
                return m_view;
            }
            set
            {
                m_view = value;
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
        public string ModuleText
        {
            get
            {
                return m_moduleTextRaw;
            }
            set
            {
                m_moduleTextRaw = value;
                m_moduleText = FormatText(value);
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
        public string LauncherText
        {
            get
            {
                return m_launcherTextRaw;
            }
            set
            {
                m_launcherTextRaw = value;
                m_launcherText = FormatText(value);
                OnThemeUpdated();
            }
        }

        public CRChangelog()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            m_launcherIcons.Theme = Theme;
            m_launcherIcons.IconTheme = m_moduleIcons.IconTheme;

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

            TitleLbl.Text = "";

            for (Int32 i = 0; i < m_titleSpacing; i++)
            {
                TitleLbl.Text += " ";
            }

            if (View == ChangelogViews.Module)
            {
                TitleImg.BackgroundImage = m_moduleIcons.GetIcon();
                TitleLbl.Text += "Module Changelog";
                DescriptionLbl.Text = m_moduleText;
                DescriptionLbl.TextAlign = ContentAlignment.MiddleLeft;
            }
            else if (View == ChangelogViews.Launcher)
            {
                TitleImg.BackgroundImage = m_launcherIcons.GetIcon();
                TitleLbl.Text += "Launcher Changelog";
                DescriptionLbl.Text = m_launcherText;
                DescriptionLbl.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                TitleImg.BackgroundImage = m_moduleIcons.GetIcon();
                TitleLbl.Text += "Module Changelog";
                DescriptionLbl.Text = "Cannot retrieve changelog information while offline";
                DescriptionLbl.TextAlign = ContentAlignment.MiddleCenter;
            }

            OnMouseLeave();
            Invalidate();
        }

        private string FormatText(string str)
        {
            str = ("- " + str.Replace("\\n", "\n- "));
            str = str.Replace("`", "\"");
            return str;
        }

        private void ToggleView()
        {
            if (View != ChangelogViews.Offline)
            {
                View = ((View == ChangelogViews.Module) ? ChangelogViews.Launcher : ChangelogViews.Module);
            }
        }

        private void OnMouseEnter()
        {
            TitleLbl.BackColor = (IsDarkMode() ? GPalette.LightBlack_Highlight : GPalette.White_Highlight);
            TitleImg.BackColor = TitleLbl.BackColor;
        }

        private void OnMouseLeave()
        {
            TitleLbl.BackColor = Color.Transparent;
            TitleImg.BackColor = Color.Transparent;
        }

        private void TitleImg_Click(object sender, EventArgs eventArgs)
        {
            ToggleView();
        }

        private void TitleImg_DoubleClick(object sender, EventArgs eventArgs)
        {
            ToggleView();
        }

        private void TitleLbl_Click(object sender, EventArgs eventArgs)
        {
            ToggleView();
        }

        private void TitleLbl_DoubleClick(object sender, EventArgs eventArgs)
        {
            ToggleView();
        }

        private void TitleLbl_MouseEnter(object sender, EventArgs eeventArgs)
        {
            OnMouseEnter();
        }

        private void TitleLbl_MouseLeave(object sender, EventArgs eeventArgs)
        {
            OnMouseLeave();
        }

        private void TitleImg_MouseEnter(object sender, EventArgs eeventArgs)
        {
            OnMouseEnter();
        }
    }
}
