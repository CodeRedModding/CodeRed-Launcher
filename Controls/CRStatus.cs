using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

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
        Version_Downloading,
        Version_Module,
        Version_Launcher,
        Version_Both,
        Version_Safe,
        Version_Unsafe,
    }

    public partial class CRStatus : UserControl
    {
        private StatusTypes m_status = StatusTypes.Process_Idle;
        private StatusViews m_view = StatusViews.One;
        private InjectionResults m_result = InjectionResults.None;
        private IconStore m_viewOne = new IconStore();
        private IconStore m_viewTwo = new IconStore();
        private IconStore m_viewThree = new IconStore();
        private IconStore m_descIcons = new IconStore();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StatusTypes DisplayType
        {
            get { return m_status; }
            set { m_status = value; ResultType = InjectionResults.None; FormatType(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StatusViews ViewType
        {
            get { return m_view; }
            set { m_view = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public InjectionResults ResultType
        {
            get { return m_result; }
            set { m_result = value; FormatResult(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme ControlType
        {
            get { return m_viewOne.Control; }
            set { m_viewOne.Control = value; m_viewTwo.Control = value; m_viewThree.Control = value; m_descIcons.Control = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public IconTheme IconType
        {
            get { return m_viewOne.Theme; }
            set { m_viewOne.Theme = value; m_viewTwo.Theme = value; m_viewThree.Theme = value; m_descIcons.Theme = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconFirstWhite
        {
            get { return m_viewOne.GetIcon(IconTheme.White); }
            set { m_viewOne.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconFirstBlack
        {
            get { return m_viewOne.GetIcon(IconTheme.Black); }
            set { m_viewOne.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconFirstRed
        {
            get { return m_viewOne.GetIcon(IconTheme.Red); }
            set { m_viewOne.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconFirstPurple
        {
            get { return m_viewOne.GetIcon(IconTheme.Purple); }
            set { m_viewOne.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconFirstBlue
        {
            get { return m_viewOne.GetIcon(IconTheme.Blue); }
            set { m_viewOne.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconSecondWhite
        {
            get { return m_viewTwo.GetIcon(IconTheme.White); }
            set { m_viewTwo.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconSecondBlack
        {
            get { return m_viewTwo.GetIcon(IconTheme.Black); }
            set { m_viewTwo.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconSecondRed
        {
            get { return m_viewTwo.GetIcon(IconTheme.Red); }
            set { m_viewTwo.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconSecondPurple
        {
            get { return m_viewTwo.GetIcon(IconTheme.Purple); }
            set { m_viewTwo.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconSecondBlue
        {
            get { return m_viewTwo.GetIcon(IconTheme.Blue); }
            set { m_viewTwo.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconThirdWhite
        {
            get { return m_viewThree.GetIcon(IconTheme.White); }
            set { m_viewThree.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconThirdBlack
        {
            get { return m_viewThree.GetIcon(IconTheme.Black); }
            set { m_viewThree.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconThirdRed
        {
            get { return m_viewThree.GetIcon(IconTheme.Red); }
            set { m_viewThree.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconThirdPurple
        {
            get { return m_viewThree.GetIcon(IconTheme.Purple); }
            set { m_viewThree.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconThirdBlue
        {
            get { return m_viewThree.GetIcon(IconTheme.Blue); }
            set { m_viewThree.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDescWhite
        {
            get { return m_descIcons.GetIcon(IconTheme.White); }
            set { m_descIcons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDescBlack
        {
            get { return m_descIcons.GetIcon(IconTheme.Black); }
            set { m_descIcons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDescRed
        {
            get { return m_descIcons.GetIcon(IconTheme.Red); }
            set { m_descIcons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDescPurple
        {
            get { return m_descIcons.GetIcon(IconTheme.Purple); }
            set { m_descIcons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDescBlue
        {
            get { return m_descIcons.GetIcon(IconTheme.Blue); }
            set { m_descIcons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TitleFont
        {
            get { return TitleLbl.Font; }
            set { TitleLbl.Font = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
                TitleImg.BackgroundImage = m_viewOne.GetThemeIcon();
            }
            else if (ViewType == StatusViews.Two)
            {
                TitleImg.BackgroundImage = m_viewTwo.GetThemeIcon();
            }
            else if (ViewType == StatusViews.Three)
            {
                TitleImg.BackgroundImage = m_viewThree.GetThemeIcon();
            }

            DescriptionImg.BackgroundImage = m_descIcons.GetThemeIcon();
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
                case StatusTypes.Version_Downloading:
                    TitleLbl.Text = "Update in Progress";
                    DescriptionLbl.Text = "Downloading and installing...";
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
                case InjectionResults.UnhandledException:
                    DescriptionLbl.Text = "Failed to inject, unhandled exception occurred!";
                    break;
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
