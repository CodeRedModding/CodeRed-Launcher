using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRNumberbox : UserControl
    {
        private ControlTheme _controlTheme = ControlTheme.Dark;

        public ControlTheme ControlType
        {
            get { return _controlTheme; }
            set { _controlTheme = value; UpdateTheme(); }
        }

        public Int32 Value
        {
            get { return (Int32)InputBx.Value; }
            set { InputBx.Value = value; UpdateTheme(); }
        }

        public Int32 MinimumValue
        {
            get { return (Int32)InputBx.Minimum; }
            set { InputBx.Minimum = value; UpdateTheme(); }
        }

        public Int32 MaximumValue
        {
            get { return (Int32)InputBx.Maximum; }
            set { InputBx.Maximum = value; UpdateTheme(); }
        }

        public Int32 Increment
        {
            get { return (Int32)InputBx.Increment; }
            set { InputBx.Increment = value; UpdateTheme(); }
        }

        public bool Hexadecimal
        {
            get { return InputBx.Hexadecimal; }
            set { InputBx.Hexadecimal = value; UpdateTheme(); }
        }

        public Font DisplayFont
        {
            get { return InputBx.Font; }
            set { InputBx.Font = value; UpdateTheme(); }
        }

        public bool BoxEnabled
        {
            get { return InputBx.Enabled; }
            set { InputBx.Enabled = value; UpdateTheme(); }
        }

        public bool ReadOnly
        {
            get { return InputBx.ReadOnly; }
            set { InputBx.ReadOnly = value; UpdateTheme(); }
        }

        public CRNumberbox()
        {
            InitializeComponent();
        }

        private void UpdateTheme()
        {
            if (ControlType == ControlTheme.Dark)
            {
                this.BackColor = GPalette.LightGrey;
                BackgroundPnl.BackColor = GPalette.DarkGrey;
                ControlPnl.BackColor = GPalette.DarkGrey;
                InputBx.BackColor = GPalette.DarkGrey;
                InputBx.ForeColor = GPalette.White;
                IncrementBtn.ForeColor = GPalette.White;
                DecrementBtn.ForeColor = GPalette.White;
            }
            else if (ControlType == ControlTheme.Light)
            {
                this.BackColor = GPalette.LightGrey;
                BackgroundPnl.BackColor = GPalette.Grey;
                ControlPnl.BackColor = GPalette.Grey;
                InputBx.BackColor = GPalette.Grey;
                InputBx.ForeColor = GPalette.Black;
                IncrementBtn.ForeColor = GPalette.Black;
                DecrementBtn.ForeColor = GPalette.Black;
            }

            Invalidate();
        }

        private void IncrementBtn_Click(object sender, EventArgs e)
        {
            Value++;
        }

        private void IncrementBtn_DoubleClick(object sender, EventArgs e)
        {
            Value++;
        }

        private void DecrementBtn_Click(object sender, EventArgs e)
        {
            Value--;
        }

        private void DecrementBtn_DoubleClick(object sender, EventArgs e)
        {
            Value--;
        }

        private void InputBx_ValueChanged(object sender, EventArgs e)
        {
            CRTextbox_ValueChanged(e);
        }

        public event EventHandler OnValueChanged;
        protected void CRTextbox_ValueChanged(EventArgs e)
        {
            OnValueChanged?.Invoke(this, e);
        }

        private void CRNumberbox_SizeChanged(object sender, EventArgs e)
        {
            InputBx.Location = new Point(InputBx.Location.X, (BackgroundPnl.Height / 2) - (InputBx.Font.Height - (Int32)InputBx.Font.Size));
            UpdateTheme();
        }
    }
}
