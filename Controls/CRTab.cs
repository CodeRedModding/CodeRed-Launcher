using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRTab : UserControl
    {
        private IconStore _icons = new IconStore();
        private bool _enabled = true;
        private bool _selected = false;

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

        public bool TabEnabled
        {
            get { return _enabled; }
            set { _enabled = value; UpdateTheme(); }
        }

        public bool TabSelected
        {
            get { return _selected; }
            set { _selected = value; UpdateTheme(); }
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
            SelectedBox.BackColor = _icons.GetColor();

            if (TabSelected)
            {
                TabImg.BackgroundImage = GetIcon();
                Color color = _icons.GetColor();
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
