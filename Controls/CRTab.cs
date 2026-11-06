using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRTab : UserControl
    {
        private IconStore m_icons = new IconStore();
        private bool m_enabled = true;
        private bool m_active = false;

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
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDark
        {
            get
            {
                return m_icons.GetIcon(IconTheme.White);
            }
            set
            {
                m_icons.SetIcon(IconTheme.White, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDarkSelected
        {
            get
            {
                return m_icons.GetIcon(IconTheme.Red);
            }
            set
            {
                m_icons.SetIcon(IconTheme.Red, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconLight
        {
            get
            {
                return m_icons.GetIcon(IconTheme.Black);
            }
            set
            {
                m_icons.SetIcon(IconTheme.Black, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconLightSelected
        {
            get
            {
                return m_icons.GetIcon(IconTheme.Purple);
            }
            set
            {
                m_icons.SetIcon(IconTheme.Purple, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool TabEnabled
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
        public bool TabActive
        {
            get
            {
                return m_active;
            }
            set
            {
                m_active = value;
                OnThemeUpdated();
            }
        }

        public CRTab()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            if (TabActive)
            {
                m_icons.IconTheme = (IsDarkMode() ? IconTheme.Red : IconTheme.Purple);
                this.BackColor = (TabActive ? Color.FromArgb(10, ActiveImg.BackColor.R, ActiveImg.BackColor.G, ActiveImg.BackColor.B) : Color.Transparent);
            }
            else
            {
                m_icons.IconTheme = (IsDarkMode() ? IconTheme.White : IconTheme.Black);
                this.BackColor = Color.Transparent;
            }

            ActiveImg.Visible = TabActive;
            ActiveImg.BackColor = m_icons.GetIconColor();
            TabImg.BackgroundImage = m_icons.GetIcon();
            Invalidate();
        }

        public event EventHandler OnTabClick = null;
        protected void CRTab_OnClick(EventArgs eventArgs)
        {
            if (OnTabClick != null)
            {
                OnTabClick.Invoke(this, eventArgs);
            }
        }

        private void TabImg_Click(object sender, EventArgs eventArgs)
        {
            base.OnClick(eventArgs);
            CRTab_OnClick(eventArgs);
        }

        private void TabImg_DoubleClick(object sender, EventArgs eventArgs)
        {
            base.OnClick(eventArgs);
            CRTab_OnClick(eventArgs);
        }

        private void CRTab_Click(object sender, EventArgs eventArgs)
        {
            CRTab_OnClick(eventArgs);
        }

        private void CRTab_DoubleClick(object sender, EventArgs eventArgs)
        {
            CRTab_OnClick(eventArgs);
        }
    }
}
