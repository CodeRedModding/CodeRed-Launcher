using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRTab : UserControl
    {
        private IconStore m_icons = new IconStore();
        private bool m_enabled = true;
        private bool m_selected = false;

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

        public bool TabEnabled
        {
            get { return m_enabled; }
            set { m_enabled = value; UpdateTheme(); }
        }

        public bool TabSelected
        {
            get { return m_selected; }
            set { m_selected = value; UpdateTheme(); }
        }

        public CRTab()
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
            SelectedBox.Visible = TabSelected;
            SelectedBox.BackColor = m_icons.GetColor();

            if (TabSelected)
            {
                TabImg.BackgroundImage = GetIcon();
                Color color = m_icons.GetColor();
                this.BackColor = Color.FromArgb(10, color.R, color.G, color.B);
            }
            else if (ControlType == ControlTheme.Dark)
            {
                TabImg.BackgroundImage = IconWhite;
                this.BackColor = Color.Transparent;
            }
            else if (ControlType == ControlTheme.Light)
            {
                TabImg.BackgroundImage = IconBlack;
                this.BackColor = Color.Transparent;
            }

            Invalidate();
        }

        public event EventHandler OnTabClick;
        protected void CRTab_OnClick(EventArgs e)
        {
            OnTabClick?.Invoke(this, e);
        }

        private void TabImg_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            CRTab_OnClick(e);
        }

        private void TabImg_DoubleClick(object sender, EventArgs e)
        {
            base.OnClick(e);
            CRTab_OnClick(e);
        }

        private void CRTab_Click(object sender, EventArgs e)
        {
            CRTab_OnClick(e);
        }

        private void CRTab_DoubleClick(object sender, EventArgs e)
        {
            CRTab_OnClick(e);
        }
    }
}
