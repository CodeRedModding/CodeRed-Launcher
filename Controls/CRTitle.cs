using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRTitle : UserControl
    {
        private ControlTheme _theme = ControlTheme.Dark;
        private Form _boundForm = null;
        private Point _mousePoint = new Point(0, 0);
        bool _minimizeButton = true;
        bool _maximizeButton = true;

        public ControlTheme ControlType
        {
            get { return _theme; }
            set { _theme = value; UpdateTheme(); }
        }

        public Form BoundForm
        {
            get { return _boundForm; }
            set { _boundForm = value; UpdateTheme(); }
        }

        public string DisplayText
        {
            get { return TitleLbl.Text; }
            set { TitleLbl.Text = value; UpdateTheme(); }
        }

        public bool MinimizeButton
        {
            get { return _minimizeButton; }
            set { _minimizeButton = value; UpdateTheme(); }
        }

        public bool MaximizeButton
        {
            get { return _maximizeButton; }
            set { _maximizeButton = value; UpdateTheme(); }
        }

        public CRTitle()
        {
            InitializeComponent();
        }

        private void UpdateTheme()
        {
            if (ControlType == ControlTheme.Dark)
            {
                this.BackColor = GPalette.DarkGrey;
                TitleLbl.ForeColor = GPalette.White;
                MinimizeBtn.ForeColor = GPalette.White;
                ExitBtn.ForeColor = GPalette.White;
            }
            else if (ControlType == ControlTheme.Light)
            {
                this.BackColor = GPalette.Grey;
                TitleLbl.ForeColor = GPalette.Black;
                MinimizeBtn.ForeColor = GPalette.Black;
                ExitBtn.ForeColor = GPalette.Black;
            }

            MinimizeBtn.Visible = MinimizeButton;
            ExitBtn.Visible = MaximizeButton;
            Invalidate();
        }

        public void ApplyTitle(string title)
        {
            TitleLbl.Text = title.ToUpper();
        }

        private void TitleLbl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BoundForm?.SetDesktopLocation((MousePosition.X - _mousePoint.X), (MousePosition.Y - _mousePoint.Y));
            }
            else
            {
                _mousePoint.X = (e.X + TitleLbl.Location.X);
                _mousePoint.Y = e.Y;
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            CRTitleBar_OnExit(e);
        }

        private void ExitBtn_DoubleClick(object sender, EventArgs e)
        {
            CRTitleBar_OnExit(e);
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            CRTitleBar_OnMinimized(e);
        }
        private void MinimizeBtn_DoubleClick(object sender, EventArgs e)
        {
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
