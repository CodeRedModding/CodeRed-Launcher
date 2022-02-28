using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRProgressBar : UserControl
    {
        private float Percentage = 0.0f;
        private Int32 ProgressWidth = 0;

        public Color ProgressColor
        {
            get { return ProgressImg.BackColor; }
            set { ProgressImg.BackColor = value; Invalidate(); }
        }

        public float Value
        {
            get { return Percentage; }
            set { Percentage = value; CalculateValue(); Invalidate(); }
        }

        public CRProgressBar()
        {
            InitializeComponent();
        }

        private void CalculateValue()
        {
            Percentage = (Percentage > 100.0f ? 100.0f : Percentage);
            Percentage = Percentage < 0.0f ? 0.0f : Percentage;

            float scale = (100.0f / BackgroundPnl.Width);
            float scaledWidth = (Percentage / scale);
            ProgressWidth = (Int32)scaledWidth;

            ProgressWidth = (ProgressWidth > BackgroundPnl.Width ? BackgroundPnl.Width : ProgressWidth);
            ProgressWidth = (ProgressWidth < 0 ? 0 : ProgressWidth);
            ProgressImg.Width = ProgressWidth;
        }

        public void Increment()
        {
            Value++;
        }

        public void Decrement()
        {
            Value--;
        }

        public void Reset()
        {
            Value = 0;
        }
    }
}
