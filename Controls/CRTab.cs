using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRTab : UserControl
    {
        private struct Palette
        {
            public static readonly Color BackgroundColor = Color.FromArgb(20, 20, 20);
            public static readonly Color HighlightColor = Color.FromArgb(22, 22, 22);
            public static readonly Color SelectedColor = Color.FromArgb(24, 24, 24);
            public static readonly Color TintColor = Color.FromArgb(255, 0, 0);
        }

        private Image SelectedImage = null;
        private Image UnselectedImage = null;

        public bool Selected
        {
            get { return TintPnl.Visible; }
            set { TintPnl.Visible = value; UpdateSelected(); Invalidate(); }
        }

        public Color SelectedColor
        {
            get { return TintPnl.BackColor; }
            set { TintPnl.BackColor = value; UpdateSelected(); Invalidate(); }
        }

        public Image ImageSelected
        {
            get { return SelectedImage; }
            set { SelectedImage = value; UpdateSelected(); Invalidate(); }
        }

        public Image ImageUnselected
        {
            get { return UnselectedImage; }
            set { UnselectedImage = value; UpdateSelected(); Invalidate(); }
        }

        private void UpdateSelected()
        {
            this.BackColor = (TintPnl.Visible ? Palette.SelectedColor : Palette.BackgroundColor);
            TabImg.BackgroundImage = (TintPnl.Visible ? SelectedImage : UnselectedImage);
        }

        public CRTab()
        {
            InitializeComponent();
        }

        private void TabImg_MouseEnter(object sender, EventArgs e)
        {
            if (!TintPnl.Visible)
            {
                this.BackColor = Palette.HighlightColor;
            }
        }

        private void TabImg_MouseLeave(object sender, EventArgs e)
        {
            if (!TintPnl.Visible)
            {
                this.BackColor = Palette.BackgroundColor;
            }
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

        public event EventHandler OnTabClick;
        protected void CRTab_OnClick(EventArgs e)
        {
            OnTabClick?.Invoke(this, e);
        }
    }
}
