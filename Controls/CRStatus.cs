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
        Process_Loading,
        Process_Idle,
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
        Version_Unsafe
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DescriptionText
        {
            get { return DescriptionLbl.Text; }
            set { DescriptionLbl.Text = value; UpdateTheme(); }
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
                this.BackColor = GPalette.White;
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

        public void FormatType()
        {
            bool antiCheated = LocalStorage.DetectedAntiCheat();
            bool shouldPrevent = (antiCheated && UserConfig.ShouldPreventEACInjection());
            string newTitle = "";

            switch (DisplayType)
            {
                case StatusTypes.Process_Loading:
                    newTitle = "Loading";
                    DescriptionText = "Loading...";
                    break;
                case StatusTypes.Process_Idle:
                    newTitle = "Rocket League Is Not Running";
                    DescriptionText = (shouldPrevent ? "Preventing injection for your own safety!" : "Waiting for the user to launch Rocket League.");
                    break;
                case StatusTypes.Process_Running:
                    newTitle = "Rocket League Is Running";
                    break;
                case StatusTypes.Process_Injecting:
                    newTitle = "Rocket League Is Running";
                    DescriptionText = (shouldPrevent ? "Preventing injection for your own safety!" : "Process found, attempting to inject module...");
                    break;
                case StatusTypes.Process_Manual:
                    newTitle = "Rocket League Is Running";
                    DescriptionText = (shouldPrevent ? "Preventing injection for your own safety!" : "Process found, ready for manual injection!");
                    break;
                case StatusTypes.Process_Outdated:
                    newTitle = "Rocket League Is Running";
                    DescriptionText = "Version mismatch, preventing injection!";
                    break;
                case StatusTypes.Version_Idle:
                    newTitle = "Waiting";
                    DescriptionText = "Automatically checking for updates disabled.";
                    antiCheated = false; // Process and version status controls use this same class, we don't want to use this for the version one.
                    break;
                case StatusTypes.Version_Checking:
                    newTitle = "Checking for Updates";
                    DescriptionText = "Waiting for response...";
                    antiCheated = false;
                    break;
                case StatusTypes.Version_Downloading:
                    newTitle = "Update in Progress";
                    DescriptionText = "Downloading and installing...";
                    antiCheated = false;
                    break;
                case StatusTypes.Version_Module:
                    newTitle = "Module Out of Date";
                    DescriptionText = "Your module version is out of date!";
                    antiCheated = false;
                    break;
                case StatusTypes.Version_Launcher:
                    newTitle = "Launcher Out of Date";
                    DescriptionText = "Your launcher version is out of date!";
                    antiCheated = false;
                    break;
                case StatusTypes.Version_Both:
                    newTitle = "Both Out of Date";
                    DescriptionText = "Your launcher and module are out of date!";
                    antiCheated = false;
                    break;
                case StatusTypes.Version_Safe:
                    newTitle = "Version up to Date";
                    DescriptionText = "You're running on the latest release!";
                    antiCheated = false;
                    break;
                case StatusTypes.Version_Unsafe:
                    newTitle = "Incompatible Version";
                    DescriptionText = "Please wait for a new version to be released!";
                    antiCheated = false;
                    break;
                default:
                    newTitle = "Loading";
                    DescriptionText = "Loading...";
                    antiCheated = false;
                    break;
            }

            if (antiCheated && shouldPrevent)
            {
                newTitle = "Easy Anti-Cheat Detected";
            }

            TitleLbl.Text = newTitle;
        }

        private void FormatResult()
        {
            switch (ResultType)
            {
                case InjectionResults.UnhandledException:
                    DescriptionText = "Failed to inject, an unhandled exception occurred!";
                    break;
                case InjectionResults.LibraryNotFound:
                    DescriptionText = "Failed to inject, could not find dll file!";
                    break;
                case InjectionResults.ProcessNotFound:
                    DescriptionText = "Failed to inject, process no longer exists!";
                    break;
                case InjectionResults.AlreadyInjected:
                    DescriptionText = "Successfully injected, changes applied in game.";
                    break;
                case InjectionResults.HandleNotFound:
                    DescriptionText = "Failed to inject, process handle is invalid!";
                    break;
                case InjectionResults.KernelNotFound:
                    DescriptionText = "Failed to inject, kernel32.dll not found!";
                    break;
                case InjectionResults.LoadLibraryNotFound:
                    DescriptionText = "Failed to inject, LoadLibraryW not found!";
                    break;
                case InjectionResults.AllocateFail:
                    DescriptionText = "Failed to inject, virtual allocate was blocked!";
                    break;
                case InjectionResults.WriteFail:
                    DescriptionText = "Failed to inject, could not write bytes into memory!";
                    break;
                case InjectionResults.ThreadFail:
                    DescriptionText = "Failed to inject, could not create remote thread!";
                    break;
                case InjectionResults.Success:
                    DescriptionText = "Successfully injected, changes applied in game.";
                    break;
                default:
                    break;
            }
        }
    }
}
