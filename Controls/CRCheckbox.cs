using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRCheckbox : UserControl
    {
        private struct Palette
        {
            public static readonly Color Unchecked = Color.FromArgb(24, 24, 24);
            public static readonly Color Checked = Color.FromArgb(235, 235, 235);
        }

        public bool Checked
        {
            get
            {
                return BackgroundPnl.BackgroundImage != null; 
            }
            set
            {
                if (value)
                {
                    BackgroundPnl.BackgroundImage = Properties.Resources.Check_Black;
                    BackgroundPnl.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    BackgroundPnl.BackgroundImage = null;
                }

                Invalidate();
            }
        }

        public Image DisplayImage
        {
            get { return DisplayImg.BackgroundImage; }
            set { DisplayImg.BackgroundImage = value; Invalidate(); }
        }

        public string DisplayText
        {
            get { return TextLbl.Text; }
            set { TextLbl.Text = value; Invalidate(); }
        }

        public CRCheckbox()
        {
            InitializeComponent();
        }

        private void TextLbl_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
            CRButton_CheckChanged(e);
        }

        private void BackgroundPnl_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
            CRButton_CheckChanged(e);
        }

        private void CheckedPnl_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
            CRButton_CheckChanged(e);
        }

        public event EventHandler OnCheckChanged;
        protected void CRButton_CheckChanged(EventArgs e)
        {
            OnCheckChanged?.Invoke(this, e);
        }
    }
}
