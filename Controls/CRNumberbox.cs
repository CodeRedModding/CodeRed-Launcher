using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRNumberbox : UserControl
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
        public Int32 Value
        {
            get
            {
                return (Int32)InputBx.Value;
            }
            set
            {
                InputBx.Value = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 MinimumValue
        {
            get
            {
                return (Int32)InputBx.Minimum;
            }
            set
            {
                InputBx.Minimum = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 MaximumValue
        {
            get
            {
                return (Int32)InputBx.Maximum;
            }
            set
            {
                InputBx.Maximum = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 Increment
        {
            get
            {
                return (Int32)InputBx.Increment;
            }
            set
            {
                InputBx.Increment = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Hexadecimal
        {
            get
            {
                return InputBx.Hexadecimal;
            }
            set
            {
                InputBx.Hexadecimal = value;
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

        public CRNumberbox()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            this.BackColor = GPalette.LightGrey;

            if (IsDarkMode())
            {
                BackgroundPnl.BackColor = GPalette.DarkGrey;
                ControlPnl.BackColor = GPalette.DarkGrey;
                InputBx.BackColor = GPalette.DarkGrey;
                InputBx.ForeColor = GPalette.White;
                IncrementBtn.ForeColor = GPalette.White;
                DecrementBtn.ForeColor = GPalette.White;
            }
            else
            {
                BackgroundPnl.BackColor = GPalette.Grey;
                ControlPnl.BackColor = GPalette.Grey;
                InputBx.BackColor = GPalette.Grey;
                InputBx.ForeColor = GPalette.Black;
                IncrementBtn.ForeColor = GPalette.Black;
                DecrementBtn.ForeColor = GPalette.Black;
            }

            Invalidate();
        }

        private void IncrementBtn_Click(object sender, EventArgs eventArgs)
        {
            Value++;
        }

        private void IncrementBtn_DoubleClick(object sender, EventArgs eventArgs)
        {
            Value++;
        }

        private void DecrementBtn_Click(object sender, EventArgs eventArgs)
        {
            Value--;
        }

        private void DecrementBtn_DoubleClick(object sender, EventArgs eventArgs)
        {
            Value--;
        }

        private void InputBx_ValueChanged(object sender, EventArgs eventArgs)
        {
            CRTextbox_ValueChanged(eventArgs);
        }

        public event EventHandler OnValueChanged = null;
        protected void CRTextbox_ValueChanged(EventArgs eventArgs)
        {
            if (OnValueChanged != null)
            {
                OnValueChanged.Invoke(this, eventArgs);
            }
        }

        private void CRNumberbox_SizeChanged(object sender, EventArgs eventArgs)
        {
            InputBx.Location = new Point(InputBx.Location.X, (BackgroundPnl.Height / 2) - (InputBx.Font.Height - (Int32)InputBx.Font.Size));
        }
    }
}
