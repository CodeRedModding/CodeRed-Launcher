using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRProcessPanel : UserControl
    {
        public enum StatusTypes : byte
        {
            TYPE_LOADING,
            TYPE_DISABLED,
            TYPE_NOT_RUNNING,
            TYPE_RUNNING,
            TYPE_INJECTING,
            TYPE_MANUAL
        }

        StatusTypes CurrentStatus = StatusTypes.TYPE_LOADING;
        InjectionResults CurrentResult = InjectionResults.RESULT_NONE;

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
                    case StatusTypes.TYPE_DISABLED:
                        TitleLbl.Text = "Monitoring Rocket League Disabled";
                        DescriptionLbl.Text = "Always injected mode selected, load is done independently.";
                        break;
                    case StatusTypes.TYPE_NOT_RUNNING:
                        TitleLbl.Text = "Rocket League Is Not Running";
                        DescriptionLbl.Text = "Waiting for the user to launch Rocket League to apply changes.";
                        break;
                    case StatusTypes.TYPE_RUNNING:
                        TitleLbl.Text = "Rocket League Is Running";
                        break;
                    case StatusTypes.TYPE_INJECTING:
                        TitleLbl.Text = "Rocket League Is Running";
                        DescriptionLbl.Text = "Process found, attempting to load module...";
                        break;
                    case StatusTypes.TYPE_MANUAL:
                        TitleLbl.Text = "Rocket League Is Running";
                        DescriptionLbl.Text = "Process found, ready for manual injection!";
                        break;
                    default:
                        TitleLbl.Text = "Loading...";
                        DescriptionLbl.Text = "Loading...";
                        break;
                }
            }
        }

        public InjectionResults Result
        {
            get
            {
                return CurrentResult;
            }
            set
            {
                CurrentResult = value;

                switch (CurrentResult)
                {
                    case InjectionResults.RESULT_LIBRARY_NOT_FOUND:
                        DescriptionLbl.Text = "Failed to inject, could not find library file!";
                        break;
                    case InjectionResults.RESULT_PROCESS_NOT_FOUND:
                        DescriptionLbl.Text = "Failed to inject, process is no longer valid!";
                        break;
                    case InjectionResults.RESULT_RETRY_INJECTION:
                        DescriptionLbl.Text = "Process found, attempting to inject...";
                        break;
                    case InjectionResults.RESULT_ALREADY_INJECTED:
                        DescriptionLbl.Text = "Successfully injected, changes applied in-game.";
                        break;
                    case InjectionResults.RESULT_HANDLE_NOT_FOUND:
                        DescriptionLbl.Text = "Failed to inject, process handle is invalid!";
                        break;
                    case InjectionResults.RESULT_KERNAL_NOT_FOUND:
                        DescriptionLbl.Text = "Failed to inject, load library not found!";
                        break;
                    case InjectionResults.RESULT_ALLOCATE_FAIL:
                        DescriptionLbl.Text = "Failed to inject, could not allocate space in memory!";
                        break;
                    case InjectionResults.RESULT_WRITE_FAILT:
                        DescriptionLbl.Text = "Failed to inject, could not write into memory!";
                        break;
                    case InjectionResults.RESULT_THREAD_FAIL:
                        DescriptionLbl.Text = "Failed to inject, could not create remote thread!";
                        break;
                    case InjectionResults.RESULT_SUCCESS:
                        DescriptionLbl.Text = "Successfully injected, changes applied in-game.";
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

        public CRProcessPanel()
        {
            InitializeComponent();
        }
    }
}
