using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRTextbox : UserControl
    {
        private ControlTheme m_theme = ControlTheme.Dark;

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
        public Font DisplayFont
        {
            get
            {
                return InputBx.Font;
            }
            set
            {
                InputBx.Font = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DisplayText
        {
            get
            {
                return InputBx.Text;
            }
            set
            {
                InputBx.Text = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool BoxEnabled
        {
            get
            {
                return InputBx.Enabled;
            }
            set
            {
                InputBx.Enabled = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get
            {
                return InputBx.ReadOnly;
            }
            set
            {
                InputBx.ReadOnly = value;
                OnThemeUpdated();
            }
        }

        public CRTextbox()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            if (IsDarkMode())
            {
                this.BackColor = GPalette.LightGrey;
                BackgroundPnl.BackColor = GPalette.DarkGrey;
                InputBx.BackColor = GPalette.DarkGrey;
                InputBx.ForeColor = GPalette.White;
            }
            else 
            {
                this.BackColor = GPalette.LightGrey;
                BackgroundPnl.BackColor = GPalette.Grey;
                InputBx.BackColor = GPalette.Grey;
                InputBx.ForeColor = GPalette.Black;
            }

            Invalidate();
        }

        private void InputBx_TextChanged(object sender, EventArgs eventArgs)
        {
            CRTextbox_InputChanged(eventArgs);
        }

        public event EventHandler OnInputChanged = null;
        protected void CRTextbox_InputChanged(EventArgs eventArgs)
        {
            if (OnInputChanged != null)
            {
                OnInputChanged?.Invoke(this, eventArgs);
            }
        }

        private void CRTextbox_SizeChanged(object sender, EventArgs eventArgs)
        {
            InputBx.Location = new Point(InputBx.Location.X, (BackgroundPnl.Height / 2) - (InputBx.Font.Height - (Int32)InputBx.Font.Size));
        }
    }
}
