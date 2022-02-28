using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRMessagebox : UserControl
    {
        public Image DisplayImage
        {
            get { return IconImg.BackgroundImage; }
            set { IconImg.BackgroundImage = value; Invalidate(); }
        }

        public string DisplayTitle
        {
            get { return TitleLbl.Text; }
            set { TitleLbl.Text = value; Invalidate(); }
        }

        public string DisplayDescription
        {
            get { return DescriptionLbl.Text; }
            set { DescriptionLbl.Text = value; Invalidate(); }
        }

        public Image FirstButtonImage
        {
            get { return FirstOptionBtn.DisplayImage; }
            set { FirstOptionBtn.DisplayImage = value; Invalidate(); }
        }

        public string FirstButtonText
        {
            get { return FirstOptionBtn.DisplayText; }
            set { FirstOptionBtn.DisplayText = value; Invalidate(); }
        }

        public Image SecondButtonImage
        {
            get { return SecondOptionBtn.DisplayImage; }
            set { SecondOptionBtn.DisplayImage = value; Invalidate(); }
        }

        public string SecondButtonText
        {
            get { return SecondOptionBtn.DisplayText; }
            set { SecondOptionBtn.DisplayText = value; Invalidate(); }
        }

        public CRMessagebox()
        {
            InitializeComponent();
        }

        private void FirstOptionBtn_OnButtonClick(object sender, EventArgs e)
        {
            CRMessagebox_FirstButtonClick(e);
        }

        private void SecondOptionBtn_OnButtonClick(object sender, EventArgs e)
        {
            CRMessagebox_SecondButtonClick(e);
        }

        public event EventHandler OnFirstButtonClick;
        protected void CRMessagebox_FirstButtonClick(EventArgs e)
        {
            OnFirstButtonClick?.Invoke(this, e);
        }

        public event EventHandler OnSecondButtonClick;
        protected void CRMessagebox_SecondButtonClick(EventArgs e)
        {
            OnSecondButtonClick?.Invoke(this, e);
        }
    }
}
