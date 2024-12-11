using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRTextbox : UserControl
    {
        private ControlTheme m_controlTheme = ControlTheme.Dark;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme ControlType
        {
            get { return m_controlTheme; }
            set { m_controlTheme = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font DisplayFont
        {
            get { return InputBx.Font; }
            set { InputBx.Font = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DisplayText
        {
            get { return InputBx.Text; }
            set { InputBx.Text = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool BoxEnabled
        {
            get { return InputBx.Enabled; }
            set { InputBx.Enabled = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get { return InputBx.ReadOnly; }
            set { InputBx.ReadOnly = value; UpdateTheme(); }
        }

        public CRTextbox()
        {
            InitializeComponent();
        }

        private void UpdateTheme()
        {
            if (ControlType == ControlTheme.Dark)
            {
                this.BackColor = GPalette.LightGrey;
                BackgroundPnl.BackColor = GPalette.DarkGrey;
                InputBx.BackColor = GPalette.DarkGrey;
                InputBx.ForeColor = GPalette.White;
            }
            else if (ControlType == ControlTheme.Light)
            {
                this.BackColor = GPalette.LightGrey;
                BackgroundPnl.BackColor = GPalette.Grey;
                InputBx.BackColor = GPalette.Grey;
                InputBx.ForeColor = GPalette.Black;
            }

            Invalidate();
        }

        private void InputBx_TextChanged(object sender, EventArgs e)
        {
            CRTextbox_InputChanged(e);
        }

        public event EventHandler OnInputChanged;
        protected void CRTextbox_InputChanged(EventArgs e)
        {
            OnInputChanged?.Invoke(this, e);
        }

        private void CRTextbox_SizeChanged(object sender, EventArgs e)
        {
            InputBx.Location = new Point(InputBx.Location.X, (BackgroundPnl.Height / 2) - (InputBx.Font.Height - (Int32)InputBx.Font.Size));
            UpdateTheme();
        }
    }
}
