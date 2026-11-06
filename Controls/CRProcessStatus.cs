using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public enum ProcessViews : byte
    {
        Loading,
        Idle,
        Running,
        Injecting,
        Manual,
        Outdated
    }

    public partial class CRProcessStatus : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.Red;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private ProcessViews m_view = ProcessViews.Loading;
        private InjectionResults m_result = InjectionResults.None;
        private IconStore m_titleIcons = new IconStore();
        private IconStore m_descIcons = new IconStore();
        private IconStore m_warningIcons = new IconStore();

        public bool IsDarkMode()
        {
            return m_titleIcons.IsDarkMode();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme Theme
        {
            get
            {
                return m_titleIcons.Theme;
            }
            set
            {
                m_titleIcons.Theme = value;
                m_titleIcons.IconTheme = (IsDarkMode() ? m_darkIcon : m_lightIcon);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconTitleDark
        {
            get
            {
                return m_titleIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_titleIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconTitleLight
        {
            get
            {
                return m_titleIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_titleIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDescDark
        {
            get
            {
                return m_descIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_descIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconDescLight
        {
            get
            {
                return m_descIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_descIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconWarnDark
        {
            get
            {
                return m_warningIcons.GetIcon(m_darkIcon);
            }
            set
            {
                m_warningIcons.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconWarnLight
        {
            get
            {
                return m_warningIcons.GetIcon(m_lightIcon);
            }
            set
            {
                m_warningIcons.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ProcessViews View
        {
            get
            {
                return m_view;
            }
            set
            {
                if (m_view != value)
                {
                    m_view = value;
                    Result = InjectionResults.None;
                    OnThemeUpdated();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public InjectionResults Result
        {
            get
            {
                return m_result;
            }
            set
            {
                m_result = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TitleFont
        {
            get
            {
                return TitleLbl.Font;
            }
            set
            {
                TitleLbl.Font = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TitleText
        {
            get
            {
                return TitleLbl.Text;
            }
            set
            {
                TitleLbl.Text = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font DescriptionFont
        {
            get
            {
                return DescriptionLbl.Font;
            }
            set
            {
                DescriptionLbl.Font = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DescriptionText
        {
            get
            {
                return DescriptionLbl.Text;
            }
            set
            {
                DescriptionLbl.Text = value;
                OnThemeUpdated();
            }
        }

        public CRProcessStatus()
        {
            InitializeComponent();
        }

        private void OnThemeUpdated()
        {
            if (IsDarkMode())
            {
                this.BackColor = GPalette.LightBlack;
                TitleLbl.ForeColor = GPalette.White;
                DescriptionLbl.ForeColor = GPalette.White;
            }
            else
            {
                this.BackColor = GPalette.White;
                TitleLbl.ForeColor = GPalette.Black;
                DescriptionLbl.ForeColor = GPalette.Black;
            }

            m_descIcons.Theme = Theme;
            m_descIcons.IconTheme = m_titleIcons.IconTheme;
            m_warningIcons.Theme = Theme;
            m_warningIcons.IconTheme = m_titleIcons.IconTheme;
            TitleImg.BackgroundImage = m_titleIcons.GetIcon();
            DescriptionImg.BackgroundImage = m_descIcons.GetIcon();

            FormatView();
            FormatResult();
            Invalidate();
        }

        public void FormatView()
        {
            bool antiCheated = LocalStorage.DetectedAntiCheat();
            bool shouldPrevent = (antiCheated && UserConfig.ShouldPreventEACInjection());

            switch (View)
            {
                case ProcessViews.Idle:
                    TitleLbl.Text = "Rocket League Is Not Running";
                    DescriptionLbl.Text = (shouldPrevent ? "Preventing injection for your own safety!" : "Waiting for Rocket League to launch.");
                    break;
                case ProcessViews.Running:
                    TitleLbl.Text = "Rocket League Is Running";
                    break;
                case ProcessViews.Injecting:
                    TitleLbl.Text = "Rocket League Is Running";
                    DescriptionLbl.Text = (shouldPrevent ? "Preventing injection for your own safety!" : "Process found, attempting to inject module...");
                    break;
                case ProcessViews.Manual:
                    TitleLbl.Text = "Rocket League Is Running";
                    DescriptionLbl.Text = (shouldPrevent ? "Preventing injection for your own safety!" : "Process found, waiting for user to inject!");
                    break;
                case ProcessViews.Outdated:
                    TitleLbl.Text = "Rocket League Is Running";
                    DescriptionLbl.Text = "Version mismatch, preventing injection!";
                    break;
                default:
                    TitleLbl.Text = "Loading...";
                    DescriptionLbl.Text = "Loading...";
                    break;
            }
        }

        private void FormatResult()
        {
            switch (Result)
            {
                case InjectionResults.UnhandledException:
                    DescriptionLbl.Text = "Failed to inject, an unhandled exception occurred!";
                    DescriptionImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case InjectionResults.LibraryNotFound:
                    DescriptionLbl.Text = "Failed to inject, could not find dll file!";
                    DescriptionImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case InjectionResults.ProcessNotFound:
                    DescriptionLbl.Text = "Failed to inject, process no longer exists!";
                    DescriptionImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case InjectionResults.HandleNotFound:
                    DescriptionLbl.Text = "Failed to inject, process handle is invalid!";
                    DescriptionImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case InjectionResults.KernelNotFound:
                    DescriptionLbl.Text = "Failed to inject, kernel32.dll not found!";
                    DescriptionImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case InjectionResults.LoadLibraryNotFound:
                    DescriptionLbl.Text = "Failed to inject, LoadLibraryW not found!";
                    DescriptionImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case InjectionResults.AllocateFail:
                    DescriptionLbl.Text = "Failed to inject, virtual allocate was blocked!";
                    DescriptionImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case InjectionResults.WriteFail:
                    DescriptionLbl.Text = "Failed to inject, could not write bytes into memory!";
                    DescriptionImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case InjectionResults.ThreadFail:
                    DescriptionLbl.Text = "Failed to inject, could not create remote thread!";
                    DescriptionImg.BackgroundImage = m_warningIcons.GetIcon();
                    break;
                case InjectionResults.AlreadyInjected:
                case InjectionResults.Success:
                    DescriptionLbl.Text = "Successfully injected, changes applied in game.";
                    DescriptionImg.BackgroundImage = m_descIcons.GetIcon();
                    break;
                default:
                    break;
            }
        }
    }
}
