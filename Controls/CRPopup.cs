using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRPopup : UserControl
    {
        public enum ButtonLayouts
        {
            TYPE_SINGLE,
            TYPE_DOUBLE
        }

        private Form? InternalForm = null;
        private ButtonLayouts CurrentLayout = ButtonLayouts.TYPE_SINGLE;

        public Form BoundForm
        {
            get { return InternalForm; }
            set { InternalForm = value; }
        }

        public ButtonLayouts ButtonLayout
        {
            get { return CurrentLayout; }
            set { CurrentLayout = value; UpdateLayout(); Invalidate(); }
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

        public string SingleButtonText
        {
            get { return SingleBtn.DisplayText; }
            set { SingleBtn.DisplayText = value; Invalidate(); }
        }

        public Image SingleButtonImage
        {
            get { return SingleBtn.DisplayImage; }
            set { SingleBtn.DisplayImage = value; Invalidate(); }
        }

        public string DoubleFirstText
        {
            get { return DoubleFirstBtn.DisplayText; }
            set { DoubleFirstBtn.DisplayText = value; Invalidate(); }
        }

        public Image DoubleFirstImage
        {
            get { return DoubleFirstBtn.DisplayImage; }
            set { DoubleFirstBtn.DisplayImage = value; Invalidate(); }
        }

        public string DoubleSecondText
        {
            get { return DoubleSecondBtn.DisplayText; }
            set { DoubleSecondBtn.DisplayText = value; Invalidate(); }
        }

        public Image DoubleSecondImage
        {
            get { return DoubleSecondBtn.DisplayImage; }
            set { DoubleSecondBtn.DisplayImage = value; Invalidate(); }
        }

        private void UpdateLayout()
        {
            if (CurrentLayout == ButtonLayouts.TYPE_SINGLE)
            {
                SinglePnl.Visible = true;
                DoublePnl.Visible = false;
            }
            else if (CurrentLayout == ButtonLayouts.TYPE_DOUBLE)
            {
                SinglePnl.Visible = false;
                DoublePnl.Visible = true;
            }
        }

        public CRPopup()
        {
            InitializeComponent();
        }

        private void SingleBtn_OnButtonClick(object sender, EventArgs e)
        {
            CRPopup_SingleClick(e);
        }

        private void DoubleFirstBtn_OnButtonClick(object sender, EventArgs e)
        {
            CRPopup_DoubleFirstClick(e);
        }

        private void DoubleSecondBtn_OnButtonClick(object sender, EventArgs e)
        {
            CRPopup_DoubleSecondClick(e);
        }

        public event EventHandler SingleButtonClick;
        protected void CRPopup_SingleClick(EventArgs e)
        {
            SingleButtonClick?.Invoke(this, e);
        }

        public event EventHandler DoubleFirstButtonClick;
        protected void CRPopup_DoubleFirstClick(EventArgs e)
        {
            DoubleFirstButtonClick?.Invoke(this, e);
        }

        public event EventHandler DoubleSecondButtonClick;
        protected void CRPopup_DoubleSecondClick(EventArgs e)
        {
            DoubleSecondButtonClick?.Invoke(this, e);
        }

        new public void Show()
        {
            this.Visible = true;
            this.BringToFront();

            if (InternalForm != null)
            {
                InternalForm.TopMost = true;
            }
        }

        new public void Hide()
        {
            this.Visible = false;
            this.SendToBack();

            if (InternalForm != null)
            {
                InternalForm.TopMost = false;
            }
        }
    }
}
