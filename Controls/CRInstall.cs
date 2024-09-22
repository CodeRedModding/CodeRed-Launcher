using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRInstall : UserControl
    {
        public enum InstallLayouts : byte
        {
            None,
            Downloading
        }

        private InstallLayouts m_layout = InstallLayouts.None;
        private Form m_boundForm = null;
        private CRTitle m_boundTitle = null;
        private bool m_buttonsEnabled = true;

        public InstallLayouts DisplayType
        {
            get { return m_layout; }
            set { m_layout = value; UpdateTheme(); }
        }

        public ControlTheme ControlType
        {
            get { return AcceptBtn.ControlType; }
            set { AcceptBtn.ControlType = value; DenyBtn.ControlType = value; UpdateTheme(); }
        }

        public IconTheme IconType
        {
            get { return AcceptBtn.IconType; }
            set { AcceptBtn.IconType = value; DenyBtn.IconType = value; UpdateTheme(); }
        }

        public Form BoundForm
        {
            get { return m_boundForm; }
            set { m_boundForm = value; UpdateTheme(); }
        }

        public CRTitle BoundTitle
        {
            get { return m_boundTitle; }
            set { m_boundTitle = value; UpdateTheme(); }
        }

        public bool ButtonsEnabled
        {
            get { return m_buttonsEnabled; }
            set { m_buttonsEnabled = value; UpdateTheme(); }
        }

        public Image AcceptWhite
        {
            get { return AcceptBtn.GetIcon(IconTheme.White); }
            set { AcceptBtn.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image AcceptBlack
        {
            get { return AcceptBtn.GetIcon(IconTheme.Black); }
            set { AcceptBtn.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image AcceptRed
        {
            get { return AcceptBtn.GetIcon(IconTheme.Red); }
            set { AcceptBtn.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image AcceptPurple
        {
            get { return AcceptBtn.GetIcon(IconTheme.Purple); }
            set { AcceptBtn.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image AcceptBlue
        {
            get { return AcceptBtn.GetIcon(IconTheme.Blue); }
            set { AcceptBtn.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image DenyWhite
        {
            get { return DenyBtn.GetIcon(IconTheme.White); }
            set { DenyBtn.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image DenyBlack
        {
            get { return DenyBtn.GetIcon(IconTheme.Black); }
            set { DenyBtn.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image DenyRed
        {
            get { return DenyBtn.GetIcon(IconTheme.Red); }
            set { DenyBtn.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image DenyPurple
        {
            get { return DenyBtn.GetIcon(IconTheme.Purple); }
            set { DenyBtn.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image DenyBlue
        {
            get { return DenyBtn.GetIcon(IconTheme.Blue); }
            set { DenyBtn.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public CRInstall()
        {
            InitializeComponent();
        }

        public void Bind(Form form, CRTitle title)
        {
            BoundForm = form;
            BoundTitle = title;
        }

        public void SetTheme(ControlTheme control, IconTheme icon)
        {
            ControlType = control;
            IconType = icon;
        }

        public void UpdateTheme()
        {
            if (DisplayType == InstallLayouts.None)
            {
                DescriptionLbl.Text = "It looks like this is your first time using codered, we need to download and install a few things first. Would you like to customize your install path?";
            }
            else if (DisplayType == InstallLayouts.Downloading)
            {
                DescriptionLbl.Text = "Downloading and installing files, please wait...";
            }

            if (ControlType == ControlTheme.Dark)
            {
                this.BackColor = GPalette.Black;
                BackgroundPnl.BackColor = GPalette.LightBlack;
                TitleLbl.ForeColor = GPalette.White;
                DescriptionLbl.ForeColor = GPalette.White;
                ArtImage.BackgroundImage = Properties.Resources.TL1_Dark;
            }
            else if (ControlType == ControlTheme.Light)
            {
                this.BackColor = GPalette.GreyWhite;
                BackgroundPnl.BackColor = GPalette.Grey;
                TitleLbl.ForeColor = GPalette.Black;
                DescriptionLbl.ForeColor = GPalette.Black;
                ArtImage.BackgroundImage = Properties.Resources.TL1_Light;
            }

            AcceptBtn.ButtonEnabled = ButtonsEnabled;
            DenyBtn.ButtonEnabled = ButtonsEnabled;
            AcceptBtn.SetTheme(ControlType, IconType);
            DenyBtn.SetTheme(ControlType, IconType);
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
                BoundTitle.MaximizeButton = true;
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
        private void AcceptBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (ButtonsEnabled && (ButtonClickAccept != null))
            {
                ButtonClickAccept.Invoke(this, e);
            }
        }

        public event EventHandler ButtonClickDeny = null;
        private void DenyBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (ButtonsEnabled && (ButtonClickDeny != null))
            {
                ButtonClickDeny.Invoke(this, e);
            }
        }
    }
}