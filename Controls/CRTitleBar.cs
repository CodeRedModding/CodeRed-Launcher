using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRTitleBar : UserControl
    {
        private struct Palette
        {
            public static readonly Color BackgroundColor = Color.FromArgb(22, 22, 22);
            public static readonly Color HoverColor = Color.FromArgb(24, 24, 24);
            public static readonly Color ClickColor = Color.FromArgb(20, 20, 20);
        }

        private Form InternalForm = null;
        private Point InternalMouse = new Point(0, 0);

        public Form BoundForm
        {
            get { return InternalForm; }
            set { InternalForm = value; }
        }

        public string DisplayText
        {
            get { return TitleLbl.Text; }
            set { TitleLbl.Text = value; }
        }

        public CRTitleBar()
        {
            InitializeComponent();
        }

        private void CRTitleBar_Load(object sender, EventArgs e)
        {
            this.BackColor = Palette.BackgroundColor;
            MinimizeBtn.BackColor = Color.Transparent;
            ExitBtn.BackColor = Color.Transparent;
        }

        public void ApplyTitle(string title)
        {
            TitleLbl.Text = title.ToUpper();
        }

        private void TitleLbl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                InternalForm?.SetDesktopLocation(MousePosition.X - InternalMouse.X, MousePosition.Y - InternalMouse.Y);
            }
            else
            {
                InternalMouse.X = e.X + TitleLbl.Location.X;
                InternalMouse.Y = e.Y;
            }
        }
        private void ExitBtn_MouseEnter(object sender, EventArgs e)
        {
            ExitBtn.BackColor = Palette.HoverColor;
        }

        private void ExitBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ExitBtn.BackColor = Palette.HoverColor;
        }

        private void ExitBtn_MouseDown(object sender, MouseEventArgs e)
        {
            ExitBtn.BackColor = Palette.ClickColor;
        }

        private void ExitBtn_MouseLeave(object sender, EventArgs e)
        {
            ExitBtn.BackColor = Color.Transparent;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            CRTitleBar_OnExit(e);
        }

        private void MinimizeBtn_MouseEnter(object sender, EventArgs e)
        {
            MinimizeBtn.BackColor = Palette.HoverColor;
        }

        private void MinimizeBtn_MouseDown(object sender, MouseEventArgs e)
        {
            MinimizeBtn.BackColor = Palette.HoverColor;
        }

        private void MinimizeBtn_MouseUp(object sender, MouseEventArgs e)
        {
            MinimizeBtn.BackColor = Palette.ClickColor;
        }

        private void MinimizeBtn_MouseLeave(object sender, EventArgs e)
        {
            MinimizeBtn.BackColor = Color.Transparent;
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            CRTitleBar_OnMinimized(e);
        }

        public event EventHandler OnMinimized;
        protected void CRTitleBar_OnMinimized(EventArgs e)
        {
            OnMinimized?.Invoke(this, e);
        }

        public event EventHandler OnExit;
        protected void CRTitleBar_OnExit(EventArgs e)
        {
            OnExit?.Invoke(this, e);
        }
    }
}
