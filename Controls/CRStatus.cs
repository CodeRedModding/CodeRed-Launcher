using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public enum StatusViews : byte
    {
        One,
        Two,
        Three
    }

    public enum StatusTypes : byte
    {
        Process_Idle,
        Process_Loading,
        Process_Running,
        Process_Injecting,
        Process_Manual,
        Process_Outdated,
        Version_Idle,
        Version_Checking,
        Version_Module,
        Version_Launcher,
        Version_Both,
        Version_Safe,
        Version_Unsafe,
    }

    public partial class CRStatus : UserControl
    {
        private StatusTypes _status = StatusTypes.Process_Idle;
        private StatusViews _view = StatusViews.One;
        private InjectionResults _result = InjectionResults.None;
        private IconStore _viewOne = new IconStore();
        private IconStore _viewTwo = new IconStore();
        private IconStore _viewThree = new IconStore();
        private IconStore _descIcons = new IconStore();

        public StatusTypes DisplayType
        {
            get { return _status; }
            set { _status = value; ResultType = InjectionResults.None; FormatType(); }
        }

        public StatusViews ViewType
        {
            get { return _view; }
            set { _view = value; UpdateTheme(); }
        }

        public InjectionResults ResultType
        {
            get { return _result; }
            set { _result = value; FormatResult(); }
        }

        public ControlTheme ControlType
        {
            get { return _viewOne.Control; }
            set { _viewOne.Control = value; _viewTwo.Control = value; _viewThree.Control = value; _descIcons.Control = value; UpdateTheme(); }
        }

        public IconTheme IconType
        {
            get { return _viewOne.Theme; }
            set { _viewOne.Theme = value; _viewTwo.Theme = value; _viewThree.Theme = value; _descIcons.Theme = value; UpdateTheme(); }
        }

        public Image IconFirstWhite
        {
            get { return _viewOne.GetIcon(IconTheme.White); }
            set { _viewOne.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image IconFirstBlack
        {
            get { return _viewOne.GetIcon(IconTheme.Black); }
            set { _viewOne.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image IconFirstRed
        {
            get { return _viewOne.GetIcon(IconTheme.Red); }
            set { _viewOne.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image IconFirstPurple
        {
            get { return _viewOne.GetIcon(IconTheme.Purple); }
            set { _viewOne.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image IconFirstBlue
        {
            get { return _viewOne.GetIcon(IconTheme.Blue); }
            set { _viewOne.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image IconSecondWhite
        {
            get { return _viewTwo.GetIcon(IconTheme.White); }
            set { _viewTwo.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image IconSecondBlack
        {
            get { return _viewTwo.GetIcon(IconTheme.Black); }
            set { _viewTwo.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image IconSecondRed
        {
            get { return _viewTwo.GetIcon(IconTheme.Red); }
            set { _viewTwo.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image IconSecondPurple
        {
            get { return _viewTwo.GetIcon(IconTheme.Purple); }
            set { _viewTwo.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image IconSecondBlue
        {
            get { return _viewTwo.GetIcon(IconTheme.Blue); }
            set { _viewTwo.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image IconThirdWhite
        {
            get { return _viewThree.GetIcon(IconTheme.White); }
            set { _viewThree.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image IconThirdBlack
        {
            get { return _viewThree.GetIcon(IconTheme.Black); }
            set { _viewThree.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image IconThirdRed
        {
            get { return _viewThree.GetIcon(IconTheme.Red); }
            set { _viewThree.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image IconThirdPurple
        {
            get { return _viewThree.GetIcon(IconTheme.Purple); }
            set { _viewThree.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image IconThirdBlue
        {
            get { return _viewThree.GetIcon(IconTheme.Blue); }
            set { _viewThree.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image IconDescWhite
        {
            get { return _descIcons.GetIcon(IconTheme.White); }
            set { _descIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image IconDescBlack
        {
            get { return _descIcons.GetIcon(IconTheme.Black); }
            set { _descIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image IconDescRed
        {
            get { return _descIcons.GetIcon(IconTheme.Red); }
            set { _descIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image IconDescPurple
        {
            get { return _descIcons.GetIcon(IconTheme.Purple); }
            set { _descIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image IconDescBlue
        {
            get { return _descIcons.GetIcon(IconTheme.Blue); }
            set { _descIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Font TitleFont
        {
            get { return TitleLbl.Font; }
            set { TitleLbl.Font = value; UpdateTheme(); }
        }

        public Font DescriptionFont
        {
            get { return DescriptionLbl.Font; }
            set { DescriptionLbl.Font = value; UpdateTheme(); }
        }

        public CRStatus()
        {
            InitializeComponent();
        }

        public void SetTheme(ControlTheme control, IconTheme icon)
        {
            ControlType = control;
            IconType = icon;
        }

        private void UpdateTheme()
        {
            if (ControlType == ControlTheme.Dark)
            {
                this.BackColor = GPalette.LightBlack;
                TitleLbl.ForeColor = GPalette.White;
                DescriptionLbl.ForeColor = GPalette.White;
            }
            else if (ControlType == ControlTheme.Light)
            {
                this.BackColor = GPalette.White; // Grey
                TitleLbl.ForeColor = GPalette.Black;
                DescriptionLbl.ForeColor = GPalette.Black;
            }

            if (ViewType == StatusViews.One)
            {
                TitleImg.BackgroundImage = _viewOne.GetThemeIcon();
            }
            else if (ViewType == StatusViews.Two)
            {
                TitleImg.BackgroundImage = _viewTwo.GetThemeIcon();
            }
            else if (ViewType == StatusViews.Three)
            {
                TitleImg.BackgroundImage = _viewThree.GetThemeIcon();
            }

            DescriptionImg.BackgroundImage = _descIcons.GetThemeIcon();
            Invalidate();
        }

        private void FormatType()
        {
            switch (DisplayType)
            {
                case StatusTypes.Process_Idle:
                    TitleLbl.Text = "Rocket League Is Not Running";
                    DescriptionLbl.Text = "Waiting for the user to launch Rocket League.";
                    break;
                case StatusTypes.Process_Loading:
                    TitleLbl.Text = "Loading";
                    DescriptionLbl.Text = "Loading...";
                    break;
                case StatusTypes.Process_Running:
                    TitleLbl.Text = "Rocket League Is Running";
                    break;
                case StatusTypes.Process_Injecting:
                    TitleLbl.Text = "Rocket League Is Running";
                    DescriptionLbl.Text = "Process found, attempting to inject module...";
                    break;
                case StatusTypes.Process_Manual:
                    TitleLbl.Text = "Rocket League Is Running";
                    DescriptionLbl.Text = "Process found, ready for manual injection!";
                    break;
                case StatusTypes.Process_Outdated:
                    TitleLbl.Text = "Rocket League Is Running";
                    DescriptionLbl.Text = "Version mismatch, preventing injection!";
                    break;
                case StatusTypes.Version_Idle:
                    TitleLbl.Text = "Waiting";
                    DescriptionLbl.Text = "Automatically checking for updates disabled.";
                    break;
                case StatusTypes.Version_Checking:
                    TitleLbl.Text = "Checking for Updates";
                    DescriptionLbl.Text = "Waiting for response...";
                    break;
                case StatusTypes.Version_Module:
                    TitleLbl.Text = "Module Out of Date";
                    DescriptionLbl.Text = "Your module version is out of date!";
                    break;
                case StatusTypes.Version_Launcher:
                    TitleLbl.Text = "Launcher Out of Date";
                    DescriptionLbl.Text = "Your launcher version is out of date!";
                    break;
                case StatusTypes.Version_Both:
                    TitleLbl.Text = "Both Out of Date";
                    DescriptionLbl.Text = "Your launcher and module are out of date!";
                    break;
                case StatusTypes.Version_Safe:
                    TitleLbl.Text = "Version up to Date";
                    DescriptionLbl.Text = "You're running on the latest release!";
                    break;
                case StatusTypes.Version_Unsafe:
                    TitleLbl.Text = "Incompatible Version";
                    DescriptionLbl.Text = "Please wait for a new version to be released!";
                    break;
                default:
                    TitleLbl.Text = "Loading";
                    DescriptionLbl.Text = "Loading...";
                    break;
            }
        }

        private void FormatResult()
        {
            switch (ResultType)
            {
                case InjectionResults.LibraryNotFound:
                    DescriptionLbl.Text = "Failed to inject, could not find module file!";
                    break;
                case InjectionResults.ProcessNotFound:
                    DescriptionLbl.Text = "Failed to inject, process no longer exists!";
                    break;
                case InjectionResults.AlreadyInjected:
                    DescriptionLbl.Text = "Successfully injected, changes applied in-game.";
                    break;
                case InjectionResults.HandleNotFound:
                    DescriptionLbl.Text = "Failed to inject, process handle is invalid!";
                    break;
                case InjectionResults.KernalNotFound:
                    DescriptionLbl.Text = "Failed to inject, load library not found!";
                    break;
                case InjectionResults.AllocateFail:
                    DescriptionLbl.Text = "Failed to inject, could not allocate space in memory!";
                    break;
                case InjectionResults.WriteFail:
                    DescriptionLbl.Text = "Failed to inject, could not write bytes into memory!";
                    break;
                case InjectionResults.ThreadFail:
                    DescriptionLbl.Text = "Failed to inject, could not create remote thread!";
                    break;
                case InjectionResults.Success:
                    DescriptionLbl.Text = "Successfully injected, changes applied in-game.";
                    break;
            }
        }
    }
}
