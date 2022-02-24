using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRUpdatePanel : UserControl
    {
        public enum StatusTypes : byte
        {
            TYPE_LOADING,
            TYPE_CHECKING,
            TYPE_MODULE,
            TYPE_LAUNCHER,
            TYPE_BOTH,
            TYPE_UPDATED
        }

        private StatusTypes CurrentStatus = StatusTypes.TYPE_LOADING;

        public StatusTypes Status
        {
            get
            {
                return CurrentStatus;
            }
            set
            {
                CurrentStatus = value;

                switch (CurrentStatus)
                {
                    case StatusTypes.TYPE_CHECKING:
                        TitleLbl.Text = "Waiting...";
                        DescriptionLbl.Text = "Checking for updates...";
                        break;
                    case StatusTypes.TYPE_MODULE:
                        TitleLbl.Text = "Module Out of Date";
                        DescriptionLbl.Text = "Your module version is out of date and requires an update!";
                        break;
                    case StatusTypes.TYPE_LAUNCHER:
                        TitleLbl.Text = "Launcher Out of Date";
                        DescriptionLbl.Text = "Your launcher version is out of date and requires an update!";
                        break;
                    case StatusTypes.TYPE_BOTH:
                        TitleLbl.Text = "Both Out of Date";
                        DescriptionLbl.Text = "Your launcher and module versions are out of date and require an update!";
                        break;
                    case StatusTypes.TYPE_UPDATED:
                        TitleLbl.Text = "Up to Date";
                        DescriptionLbl.Text = "You are running on the latest version!";
                        break;
                    default:
                        TitleLbl.Text = "Loading...";
                        DescriptionLbl.Text = "Loading...";
                        break;
                }
            }
        }

        public Image DescriptionImage
        {
            get { return DescriptionImg.BackgroundImage; }
            set { DescriptionImg.BackgroundImage = value; }
        }

        public Image TitleImage
        {
            get { return TitleImg.BackgroundImage; }
            set { TitleImg.BackgroundImage = value; }
        }

        public CRUpdatePanel()
        {
            InitializeComponent();
        }
    }
}
