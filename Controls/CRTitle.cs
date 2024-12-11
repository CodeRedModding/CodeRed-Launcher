using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRTitle : UserControl
    {
        private ControlTheme m_theme = ControlTheme.Dark;
        private Form m_boundForm = null;
        private Point m_mousePoint = new Point(0, 0);
        bool m_minimizeButton = true;
        bool m_maximizeButton = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme ControlType
        {
            get { return m_theme; }
            set { m_theme = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Form BoundForm
        {
            get { return m_boundForm; }
            set { m_boundForm = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DisplayText
        {
            get { return TitleLbl.Text; }
            set { TitleLbl.Text = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MinimizeButton
        {
            get { return m_minimizeButton; }
            set { m_minimizeButton = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MaximizeButton
        {
            get { return m_maximizeButton; }
            set { m_maximizeButton = value; UpdateTheme(); }
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
                BoundForm?.SetDesktopLocation((MousePosition.X - m_mousePoint.X), (MousePosition.Y - m_mousePoint.Y));
            }
            else
            {
                m_mousePoint.X = (e.X + TitleLbl.Location.X);
                m_mousePoint.Y = e.Y;
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
