using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public enum UpdateViews : byte
    {
        None,
        Running,
        DownloadingModule,
        DownloadingLauncher,
        InstallingModule,
        InstallingLauncher,
        Module,
        Launcher,
        Framework,
        Both,
        Fail
    }

    public partial class CRUpdatePopup : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.White;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private UpdateViews m_view = UpdateViews.None;
        private Form m_boundForm = null;
        private CRTitleBar m_boundTitle = null;
        private bool m_buttonsEnabled = true;

        public bool IsDarkMode()
        {
            return AcceptBtn.IsDarkMode();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme Theme
        {
            get
            {
                return AcceptBtn.Theme;
            }
            set
            {
                AcceptBtn.Theme = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AcceptDark
        {
            get
            {
                return AcceptBtn.GetIcon(m_darkIcon);
            }
            set
            {
                AcceptBtn.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AcceptLight
        {
            get
            {
                return AcceptBtn.GetIcon(m_lightIcon);
            }
            set
            {
                AcceptBtn.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image DenyDark
        {
            get
            {
                return DenyBtn.GetIcon(m_darkIcon);
            }
            set
            {
                DenyBtn.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image DenyLight
        {
            get
            {
                return DenyBtn.GetIcon(m_lightIcon);
            }
            set
            {
                DenyBtn.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AltDark
        {
            get
            {
                return AltBtn.GetIcon(m_darkIcon);
            }
            set
            {
                AltBtn.SetIcon(m_darkIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AltLight
        {
            get
            {
                return AltBtn.GetIcon(m_lightIcon);
            }
            set
            {
                AltBtn.SetIcon(m_lightIcon, value);
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public UpdateViews View
        {
            get
            {
                return m_view;
            }
            set
            {
                m_view = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Form BoundForm
        {
            get
            {
                return m_boundForm;
            }
            set
            {
                m_boundForm = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public CRTitleBar BoundTitle
        {
            get
            {
                return m_boundTitle;
            }
            set
            {
                m_boundTitle = value;
                OnThemeUpdated();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ButtonsEnabled
        {
            get
            {
                return m_buttonsEnabled;
            }
            set
            {
                m_buttonsEnabled = value;
                OnThemeUpdated();
            }
        }

        public CRUpdatePopup()
        {
            InitializeComponent();
        }

        public void Bind(Form form, CRTitleBar title)
        {
            BoundForm = form;
            BoundTitle = title;
        }

        public void OnThemeUpdated()
        {
            DenyBtn.Theme = Theme;
            AltBtn.Theme = Theme;

            if (View == UpdateViews.Running)
            {
                DescriptionLbl.Text = "A new version of the CodeRed was found but Rocket League needs to be closed first in order to install!";
                m_buttonsEnabled = true;
                AcceptBtn.Visible = false;
                DenyBtn.Visible = false;
                AltBtn.Visible = true;
            }
            else if (View == UpdateViews.DownloadingModule)
            {
                DescriptionLbl.Text = "Downloading latest module version, please wait...";
                m_buttonsEnabled = false;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (View == UpdateViews.InstallingModule)
            {
                DescriptionLbl.Text = "Download complete, installing module...";
                m_buttonsEnabled = false;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (View == UpdateViews.DownloadingLauncher)
            {
                DescriptionLbl.Text = "Downloading latest launcher version, please wait...";
                m_buttonsEnabled = false;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (View == UpdateViews.InstallingLauncher)
            {
                DescriptionLbl.Text = "Download complete, installing launcher...";
                m_buttonsEnabled = false;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (View == UpdateViews.Module)
            {
                DescriptionLbl.Text = "A new version of the module was found, would you like to automatically install it now?";
                m_buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (View == UpdateViews.Launcher)
            {
                DescriptionLbl.Text = "A new version of the launcher was found, would you like to automatically install it now?";
                m_buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (View == UpdateViews.Framework)
            {
                DescriptionLbl.Text = "A new version of the launcher was found and requires a new version of .NET, would you like to open a link to install the .NET " + RemoteStorage.GetFrameworkVersion().Result + " runtime? If its already installed, you can skip this step and press no, if its not installed updating the launcher will fail.";
                m_buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (View == UpdateViews.Both)
            {
                DescriptionLbl.Text = "A new version both the launcher and module were found, would you like to automatically install it now?";
                m_buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (View == UpdateViews.Fail)
            {
                DescriptionLbl.Text = "An error occurred while downloading the latest version, would you like to try again?";
                m_buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }

            if (IsDarkMode())
            {
                this.BackColor = GPalette.Black;
                BackgroundPnl.BackColor = GPalette.LightBlack;
                TitleLbl.ForeColor = GPalette.White;
                DescriptionLbl.ForeColor = GPalette.White;
                ArtTLImg.BackgroundImage = Properties.Resources.TL2_Red;
            }
            else
            {
                this.BackColor = GPalette.GreyWhite;
                BackgroundPnl.BackColor = GPalette.Grey;
                TitleLbl.ForeColor = GPalette.Black;
                DescriptionLbl.ForeColor = GPalette.Black;
                ArtTLImg.BackgroundImage = Properties.Resources.TL2_Purple;
            }

            AcceptBtn.ButtonEnabled = ButtonsEnabled;
            DenyBtn.ButtonEnabled = ButtonsEnabled;
            AltBtn.ButtonEnabled = ButtonsEnabled;
            Invalidate();
        }

        public void HidePopup()
        {
            this.Visible = false;
            this.SendToBack();

            if (BoundForm != null)
            {
                BoundForm.TopMost = false;
            }

            if (BoundTitle != null)
            {
                BoundTitle.MinimizeButton = true;
                BoundTitle.BringToFront();
            }

            ButtonsEnabled = true;
        }

        public void ShowPopup(bool bNoTopmost = false)
        {
            this.Visible = true;
            this.BringToFront();

            if (BoundForm != null)
            {
                BoundForm.Show();

                if (!bNoTopmost)
                {
                    BoundForm.TopMost = true;
                }
            }

            if (BoundTitle != null)
            {
                BoundTitle.BringToFront();
            }

            ButtonsEnabled = true;
        }

        public event EventHandler ButtonClickAccept = null;
        private void AcceptBtn_OnButtonClick(object sender, EventArgs eventArgs)
        {
            if (ButtonsEnabled && (ButtonClickAccept != null))
            {
                ButtonClickAccept.Invoke(this, eventArgs);
            }
        }

        public event EventHandler ButtonClickDeny = null;
        private void DenyBtn_OnButtonClick(object sender, EventArgs eventArgs)
        {
            if (ButtonsEnabled && (ButtonClickDeny != null))
            {
                ButtonClickDeny.Invoke(this, eventArgs);
                HidePopup();
            }
        }

        private void AltBtn_OnButtonClick(object sender, EventArgs eventArgs)
        {
            if (ButtonsEnabled && (ButtonClickDeny != null))
            {
                ButtonClickDeny.Invoke(this, eventArgs);
                HidePopup();
            }
        }
    }
}