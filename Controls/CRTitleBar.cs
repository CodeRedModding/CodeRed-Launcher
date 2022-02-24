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

        private Form _Form = null;
        private Point _Mouse = new Point(0, 0);

        public string DisplayText
        {
            get { return TitleLbl.Text; }
            set { TitleLbl.Text = value; }
        }

        public Form BoundForm
        {
            get { return _Form; }
            set { _Form = value; }
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
            if (_Form != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _Form.SetDesktopLocation(MousePosition.X - _Mouse.X, MousePosition.Y - _Mouse.Y);
                }
                else
                {
                    _Mouse.X = e.X + TitleLbl.Location.X;
                    _Mouse.Y = e.Y;
                }
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
            Environment.Exit(0);
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
            CRTitleBar_Minimized(e);
        }

        public event EventHandler MinimizedEvent;
        protected void CRTitleBar_Minimized(EventArgs e)
        {
            MinimizedEvent?.Invoke(this, e);
        }
    }
}
