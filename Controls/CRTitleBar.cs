using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRTitleBar : UserControl
    {
        private ControlTheme m_theme = ControlTheme.Dark;
        private Form m_boundForm = null;
        private Point m_mousePoint = new Point(0, 0);
        bool m_minimizeButton = true;

        public bool IsDarkMode()
        {
            return (Theme == ControlTheme.Dark);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme Theme
        {
            get
            {
                return m_theme;
            }
            set
            {
                m_theme = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Form BoundForm
        {
            get
            {
                return m_boundForm;
            }
            set
            {
                m_boundForm = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DisplayText
        {
            get
            {
                return TitleLbl.Text;
            }
            set
            {
                TitleLbl.Text = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MinimizeButton
        {
            get
            {
                return m_minimizeButton;
            }
            set
            {
                m_minimizeButton = value;
                MinimizeBtn.Visible = value;
                OnThemeUpdated();
            }
        }

        public CRTitleBar()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            if (IsDarkMode())
            {
                this.BackColor = GPalette.DarkGrey;
                TitleLbl.ForeColor = GPalette.White;
                MinimizeBtn.ForeColor = GPalette.White;
                ExitBtn.ForeColor = GPalette.White;
            }
            else
            {
                this.BackColor = GPalette.Grey;
                TitleLbl.ForeColor = GPalette.Black;
                MinimizeBtn.ForeColor = GPalette.Black;
                ExitBtn.ForeColor = GPalette.Black;
            }

            MinimizeBtn.BackColor = Color.Transparent;
            ExitBtn.BackColor = Color.Transparent;
            Invalidate();
        }

        public void ApplyTitle(string title)
        {
            TitleLbl.Text = title.ToUpper();
        }

        public event EventHandler OnMinimized = null;
        protected void CRTitleBar_OnMinimized(EventArgs eventArgs)
        {
            if (OnMinimized != null)
            {
                OnMinimized.Invoke(this, eventArgs);
            }
        }

        public event EventHandler OnExit = null;
        protected void CRTitleBar_OnExit(EventArgs eventArgs)
        {
            if (OnExit != null)
            {
                OnExit.Invoke(this, eventArgs);
            }
        }

        private void TitleLbl_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                BoundForm?.SetDesktopLocation((MousePosition.X - m_mousePoint.X), (MousePosition.Y - m_mousePoint.Y));
            }
            else
            {
                m_mousePoint.X = (mouseEventArgs.X + TitleLbl.Location.X);
                m_mousePoint.Y = mouseEventArgs.Y;
            }
        }

        private void MinimizeBtn_Click(object sender, EventArgs eventArgs)
        {
            CRTitleBar_OnMinimized(eventArgs);
        }
        private void MinimizeBtn_DoubleClick(object sender, EventArgs eventArgs)
        {
            CRTitleBar_OnMinimized(eventArgs);
        }

        private void MinimizeBtn_MouseEnter(object sender, EventArgs eventArgs)
        {
            MinimizeBtn.BackColor = (IsDarkMode() ? GPalette.DarkGrey_Highlight : GPalette.Grey_Highlight);
        }

        private void MinimizeBtn_MouseLeave(object sender, EventArgs eventArgs)
        {
            MinimizeBtn.BackColor = Color.Transparent;
        }

        private void ExitBtn_Click(object sender, EventArgs eventArgs)
        {
            CRTitleBar_OnExit(eventArgs);
        }

        private void ExitBtn_DoubleClick(object sender, EventArgs eventArgs)
        {
            CRTitleBar_OnExit(eventArgs);
        }

        private void ExitBtn_MouseEnter(object sender, EventArgs eventArgs)
        {
            ExitBtn.BackColor = (IsDarkMode() ? GPalette.DarkGrey_Highlight : GPalette.Grey_Highlight);
        }

        private void ExitBtn_MouseLeave(object sender, EventArgs eventArgs)
        {
            ExitBtn.BackColor = Color.Transparent;
        }
    }
}
