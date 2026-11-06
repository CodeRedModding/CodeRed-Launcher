using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRCheckbox : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.Red;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private IconStore m_icons = new IconStore();
        private IconStore m_uncheckedIcons = new IconStore();
        private IconStore m_checkedIcons = new IconStore();
        private bool m_enabled = true;
        private bool m_checked = false;

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
        public Image UncheckedDark
        {
            get
            {
                return m_uncheckedIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_uncheckedIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image UncheckedLight
        {
            get
            {
                return m_uncheckedIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_uncheckedIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CheckedDark
        {
            get
            {
                return m_checkedIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_checkedIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CheckedLight
        {
            get
            {
                return m_checkedIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_checkedIcons.SetIcon(m_lightIcon, value);
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool BoxEnabled
        {
            get
            {
                return m_enabled;
            }
            set
            { 
                m_enabled = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool BoxChecked
        {
            get
            {
                return m_checked;
            }
            set
            {
                m_checked = value;
                OnThemeUpdated();
            }
        }

        public CRCheckbox()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            m_uncheckedIcons.Theme = Theme;
            m_uncheckedIcons.IconTheme = m_icons.IconTheme;
            m_checkedIcons.Theme = Theme;
            m_checkedIcons.IconTheme = m_icons.IconTheme;
            TextLbl.ForeColor = (IsDarkMode() ? GPalette.White : GPalette.Black);
            IconImg.BackgroundImage = m_icons.GetIcon();
            CheckImg.BackgroundImage = (BoxChecked ? m_checkedIcons.GetIcon() : m_uncheckedIcons.GetIcon());
            Invalidate();
        }

        public event EventHandler OnCheckChanged = null;
        protected void CRButton_CheckChanged(EventArgs eventArgs)
        {
            if (BoxEnabled)
            {
                BoxChecked = !BoxChecked;

                if (OnCheckChanged != null)
                {
                    OnCheckChanged.Invoke(this, eventArgs);
                }
            }
        }

        private void CheckImg_Click(object sender, EventArgs eventArgs)
        {
            CRButton_CheckChanged(eventArgs);
        }

        private void CheckImg_DoubleClick(object sender, EventArgs eventArgs)
        {
            CRButton_CheckChanged(eventArgs);
        }

        private void TextLbl_Click(object sender, EventArgs eventArgs)
        {
            CRButton_CheckChanged(eventArgs);
        }

        private void TextLbl_DoubleClick(object sender, EventArgs eventArgs)
        {
            CRButton_CheckChanged(eventArgs);
        }
    }
}
