using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public enum OfflineViews : byte
    {
        Default,
        Installer
    }

    public partial class CROfflinePopup : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.White;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private OfflineViews m_view = OfflineViews.Default;
        private Form m_boundForm = null;
        private CRTitleBar m_boundTitle = null;

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
        public OfflineViews View
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

        public CROfflinePopup()
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

            if (View == OfflineViews.Default)
            {
                TitleLbl.Text = "No Connection";
                DescriptionLbl.Text = "Failed to connect to the remote server, would you like to start in offline mode? version checking, changelog info, and news will all be disabled.";
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (View == OfflineViews.Installer)
            {
                TitleLbl.Text = "No Connection";
                DescriptionLbl.Text = "An active internet connection is required to install CodeRed, please try again!";
                AcceptBtn.Visible = false;
                DenyBtn.Visible = false;
                AltBtn.Visible = true;
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
        }

        public event EventHandler ButtonClickAccept = null;
        private void AcceptBtn_OnButtonClick(object sender, EventArgs eventArgs)
        {
            if (ButtonClickAccept != null)
            {
                ButtonClickAccept.Invoke(this, eventArgs);
            }
        }

        public event EventHandler ButtonClickDeny = null;
        private void DenyBtn_OnButtonClick(object sender, EventArgs eventArgs)
        {
            if (ButtonClickDeny != null)
            {
                ButtonClickDeny.Invoke(this, eventArgs);
            }
        }

        public event EventHandler ButtonClickAlt = null;
        private void AltBtn_OnButtonClick(object sender, EventArgs eventArgs)
        {
            if (ButtonClickAlt != null)
            {
                ButtonClickAlt.Invoke(this, eventArgs);
            }
        }
    }
}
