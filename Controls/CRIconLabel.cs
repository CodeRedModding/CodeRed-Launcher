using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public enum IconSizes : byte
    {
        Small,
        Medium
    }

    public partial class CRIconLabel : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.Red;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private IconStore m_icons = new IconStore();
        private IconSizes m_iconSize = IconSizes.Medium;

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
        public IconSizes IconSize
        {
            get
            {
                return m_iconSize;
            }
            set
            {
                m_iconSize = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font DisplayFont
        {
            get
            {
                return TextLbl.Font;
            }
            set
            {
                TextLbl.Font = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DisplayText
        {
            get
            {
                return TextLbl.Text;
            }
            set
            {
                TextLbl.Text = value;
                OnThemeUpdated();
            }
        }

        public CRIconLabel()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            TextLbl.ForeColor = IsDarkMode() ? GPalette.White : GPalette.Black;
            IconImg.BackgroundImage = m_icons.GetIcon();

            if (IconSize == IconSizes.Small)
            {
                IconImg.Size = new Size(24, 24);
                IconImg.Location = new Point(6, 6);
            }
            else
            {
                IconImg.Size = new Size(28, 28);
                IconImg.Location = new Point(4, 4);
            }

            Invalidate();
        }
    }
}
