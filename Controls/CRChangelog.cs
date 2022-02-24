using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRChangelog : UserControl
    {
        public CRChangelog()
        {
            InitializeComponent();
        }

        public Image DisplayImage
        {
            get { return TitleImg.BackgroundImage; }
            set { TitleImg.BackgroundImage = value; }
        }

        public string DisplayText
        {
            get
            {
                return ChangelogLbl.Text;
            }
            set
            {
                ChangelogLbl.Text = value.Replace("\\n", Environment.NewLine);
            }
        }
    }
}
