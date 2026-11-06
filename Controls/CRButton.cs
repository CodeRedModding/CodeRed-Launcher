using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRButton : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.White;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private IconStore m_icons = new IconStore();
        private bool m_enabled = true;

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
        public bool ButtonEnabled
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

        public CRButton()
        {
            InitializeComponent();
        }

        public Image GetIcon()
        {
            return m_icons.GetIcon();
        }

        public Image GetIcon(IconTheme iconTheme)
        {
            return m_icons.GetIcon(iconTheme);
        }

        public void SetIcon(IconTheme iconTheme, Image image)
        {
            m_icons.SetIcon(iconTheme, image);
            OnThemeUpdated();
        }

        private void OnThemeUpdated()
        {
            this.BackColor = (IsDarkMode() ? GPalette.CodeRed : GPalette.CodePurple);
            ButtonImg.BackgroundImage = m_icons.GetIcon();
            ButtonImg.Visible = (ButtonImg.BackgroundImage != null);
            TextLbl.ForeColor = GPalette.White;
            Invalidate();
        }

        private void OnMouseEnter()
        {
            if (ButtonEnabled)
            {
                this.BackColor = (IsDarkMode() ? GPalette.CodeRed_Highlight : GPalette.CodePurple_Highlight);
            }
        }

        private void OnMouseLeave()
        {
            this.BackColor = (IsDarkMode() ? GPalette.CodeRed : GPalette.CodePurple);
        }

        public event EventHandler OnButtonClick = null;
        protected void CRButton_OnClick(EventArgs eventArgs)
        {
            if (ButtonEnabled && (OnButtonClick != null))
            {
                OnButtonClick.Invoke(this, eventArgs);
            }
        }

        private void ButtonImg_MouseEnter(object sender, EventArgs eventArgs)
        {
            OnMouseEnter();
        }

        private void ButtonImg_Click(object sender, EventArgs eventArgs)
        {
            CRButton_OnClick(eventArgs);
        }

        private void ButtonImg_DoubleClick(object sender, EventArgs eventArgs)
        {
            CRButton_OnClick(eventArgs);
        }

        private void TextLbl_MouseEnter(object sender, EventArgs eventArgs)
        {
            OnMouseEnter();
        }

        private void TextLbl_MouseLeave(object sender, EventArgs eventArgs)
        {
            OnMouseLeave();
        }

        private void TextLbl_Click(object sender, EventArgs eventArgs)
        {
            CRButton_OnClick(eventArgs);
        }

        private void TextLbl_DoubleClick(object sender, EventArgs eventArgs)
        {
            CRButton_OnClick(eventArgs);
        }

        private void TextLbl_SizeChanged(object sender, EventArgs eventArgs)
        {
            ButtonImg.Width = ButtonImg.Height;
        }
    }
}