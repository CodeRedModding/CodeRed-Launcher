using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRChangelog : UserControl
    {
        public Image DisplayImage
        {
            get { return TitleImg.BackgroundImage; }
            set { TitleImg.BackgroundImage = value; Invalidate(); }
        }

        public string DisplayTitle
        {
            get { return TitleLbl.Text; }
            set { TitleLbl.Text = value; Invalidate(); }
        }

        public string DisplayText
        {
            get { return ChangelogLbl.Text; }
            set { ChangelogLbl.Text = value.Replace("\\n", Environment.NewLine); Invalidate(); }
        }

        public CRChangelog()
        {
            InitializeComponent();
        }

        private void TitleImg_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            CRChangelog_Swap(e);
        }

        private void TitleLbl_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            CRChangelog_Swap(e);
        }

        public event EventHandler OnChangelogSwap;
        protected void CRChangelog_Swap(EventArgs e)
        {
            OnChangelogSwap?.Invoke(this, e);
        }
    }
}
