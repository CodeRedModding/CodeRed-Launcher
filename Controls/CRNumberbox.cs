﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRNumberbox : UserControl
    {
        public Int32 Value
        {
            get { return (Int32)InputBx.Value; }
            set { InputBx.Value = value; }
        }

        public Int32 MinimumValue
        {
            get { return (Int32)InputBx.Minimum; }
            set { InputBx.Minimum = value; }
        }

        public Int32 MaximumValue
        {
            get { return (Int32)InputBx.Maximum; }
            set { InputBx.Maximum = value; }
        }

        public Int32 Increment
        {
            get { return (Int32)InputBx.Increment; }
            set { InputBx.Increment = value; }
        }

        public bool Hexadecimal
        {
            get { return InputBx.Hexadecimal; }
            set { InputBx.Hexadecimal = value; }
        }

        public CRNumberbox()
        {
            InitializeComponent();
        }

        private void IncrementBtn_MouseEnter(object sender, EventArgs e)
        {
            IncrementBtn.BackColor = Color.FromArgb(26, 26, 26);
        }

        private void IncrementBtn_MouseLeave(object sender, EventArgs e)
        {
            IncrementBtn.BackColor = Color.FromArgb(24, 24, 24);
        }

        private void DecrementBtn_MouseEnter(object sender, EventArgs e)
        {
            DecrementBtn.BackColor = Color.FromArgb(26, 26, 26);
        }

        private void DecrementBtn_MouseLeave(object sender, EventArgs e)
        {
            DecrementBtn.BackColor = Color.FromArgb(24, 24, 24);
        }

        private void InputBx_ValueChanged(object sender, EventArgs e)
        {
            CRTextbox_ValueChanged(e);
        }

        public event EventHandler ValueChangedEvent;
        protected void CRTextbox_ValueChanged(EventArgs e)
        {
            ValueChangedEvent?.Invoke(this, e);
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
    }
}
