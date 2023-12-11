using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Gaming.UI;

namespace CodeRedLauncher.Controls
{
    public partial class CRUpdate : UserControl
    {
        public enum UpdateLayouts : byte
        {
            None,
            Running,
            Downloading,
            Module,
            Launcher,
            Both
        }

        private UpdateLayouts _updateType = UpdateLayouts.Module;
        private Form _boundForm = null;
        private CRTitle _boundTitle = null;
        private bool _buttonsEnabled = true;

        public UpdateLayouts UpdateType
        {
            get { return _updateType; }
            set { _updateType = value; UpdateTheme(); }
        }

        public ControlTheme ControlType
        {
            get { return AcceptBtn.ControlType; }
            set { AcceptBtn.ControlType = value; DenyBtn.ControlType = value; GameBtn.ControlType = value; UpdateTheme(); }
        }

        public IconTheme IconType
        {
            get { return AcceptBtn.IconType; }
            set { AcceptBtn.IconType = value; DenyBtn.IconType = value; GameBtn.IconType = value; UpdateTheme(); }
        }

        public Form BoundForm
        {
            get { return _boundForm; }
            set { _boundForm = value; UpdateTheme(); }
        }

        public CRTitle BoundTitle
        {
            get { return _boundTitle; }
            set { _boundTitle = value; UpdateTheme(); }
        }

        public bool ButtonsEnabled
        {
            get { return _buttonsEnabled; }
            set { _buttonsEnabled = value; UpdateTheme(); }
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

        public Image AltWhite
        {
            get { return GameBtn.GetIcon(IconTheme.White); }
            set { GameBtn.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image AltBlack
        {
            get { return GameBtn.GetIcon(IconTheme.Black); }
            set { GameBtn.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image AltRed
        {
            get { return GameBtn.GetIcon(IconTheme.Red); }
            set { GameBtn.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image AltPurple
        {
            get { return GameBtn.GetIcon(IconTheme.Purple); }
            set { GameBtn.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image AltBlue
        {
            get { return GameBtn.GetIcon(IconTheme.Blue); }
            set { GameBtn.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public CRUpdate()
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
            if (UpdateType == UpdateLayouts.Running)
            {
                DescriptionLbl.Text = "A new version of the codered was found but Rocket League needs to be closed first in order to install!";
                _buttonsEnabled = true;
                AcceptBtn.Visible = false;
                DenyBtn.Visible = false;
                GameBtn.Visible = true;
            }
            else if (UpdateType == UpdateLayouts.Downloading)
            {
                DescriptionLbl.Text = "Downloading and installing files, please wait...";
                _buttonsEnabled = false;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.Module)
            {
                DescriptionLbl.Text = "A new version of the module was found, would you like to automatically install it now?";
                _buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.Launcher)
            {
                DescriptionLbl.Text = "A new version of the launcher was found, would you like to automatically install it now?";
                _buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.Both)
            {
                DescriptionLbl.Text = "A new version both the launcher and module were found, would you like to automatically install it now?";
                _buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
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
            GameBtn.ButtonEnabled = ButtonsEnabled;
            AcceptBtn.SetTheme(ControlType, IconType);
            DenyBtn.SetTheme(ControlType, IconType);
            GameBtn.SetTheme(ControlType, IconType);
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
            if (ButtonsEnabled)
            {
                if (ButtonClickDeny != null)
                {
                    ButtonClickDeny.Invoke(this, e);
                }

                HidePopup();
            }
        }

        private void GameBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (ButtonsEnabled)
            {
                HidePopup();
            }
        }
    }
}