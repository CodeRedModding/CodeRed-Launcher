using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public enum InstallViews : byte
    {
        None,
        Downloading
    }

    public partial class CRInstallPopup : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.White;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private InstallViews m_view = InstallViews.None;
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
        public InstallViews View
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

        public CRInstallPopup()
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
            if (View == InstallViews.None)
            {
                DescriptionLbl.Text = "It looks like this is your first time using CodeRed, we need to download and install a few things first. Would you like to customize your install path?";
            }
            else if (View == InstallViews.Downloading)
            {
                DescriptionLbl.Text = "Downloading and installing files, please wait...";
            }

            if (IsDarkMode())
            {
                this.BackColor = GPalette.Black;
                BackgroundPnl.BackColor = GPalette.LightBlack;
                TitleLbl.ForeColor = GPalette.White;
                DescriptionLbl.ForeColor = GPalette.White;
                ArtImage.BackgroundImage = Properties.Resources.TL1_Dark;
            }
            else
            {
                this.BackColor = GPalette.GreyWhite;
                BackgroundPnl.BackColor = GPalette.Grey;
                TitleLbl.ForeColor = GPalette.Black;
                DescriptionLbl.ForeColor = GPalette.Black;
                ArtImage.BackgroundImage = Properties.Resources.TL1_Light;
            }

            DenyBtn.Theme = Theme;
            AcceptBtn.ButtonEnabled = ButtonsEnabled;
            DenyBtn.ButtonEnabled = ButtonsEnabled;
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

        public void ShowPopup()
        {
            this.Visible = true;
            this.BringToFront();

            if (BoundForm != null)
            {
                BoundForm.Show();
                BoundForm.TopMost = true;
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
            }
        }
    }
}