﻿using System;
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
    public partial class CROffline : UserControl
    {
        public enum OfflineLayouts : byte
        {
            Default,
            Installer
        }

        private OfflineLayouts _offlineType = OfflineLayouts.Default;
        private Form _boundForm = null;
        private CRTitle _boundTitle = null;

        public OfflineLayouts OfflineType
        {
            get { return _offlineType; }
            set { _offlineType = value; UpdateTheme(); }
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
            get { return _boundForm; }
            set { _boundForm = value; UpdateTheme(); }
        }

        public CRTitle BoundTitle
        {
            get { return _boundTitle; }
            set { _boundTitle = value; UpdateTheme(); }
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
            get { return AltBtn.GetIcon(IconTheme.White); }
            set { AltBtn.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image AltBlack
        {
            get { return AltBtn.GetIcon(IconTheme.Black); }
            set { AltBtn.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image AltRed
        {
            get { return AltBtn.GetIcon(IconTheme.Red); }
            set { AltBtn.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image AltPurple
        {
            get { return AltBtn.GetIcon(IconTheme.Purple); }
            set { AltBtn.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image AltBlue
        {
            get { return AltBtn.GetIcon(IconTheme.Blue); }
            set { AltBtn.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public CROffline()
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
            if (OfflineType == OfflineLayouts.Default)
            {
                TitleLbl.Text = "no connection";
                DescriptionLbl.Text = "failed to connect to the remote server, would you like to start in offline mode? version checking, changelog info, and news will all be disabled.";
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                AltBtn.Visible = false;
            }
            else if (OfflineType == OfflineLayouts.Installer)
            {
                TitleLbl.Text = "no connection";
                DescriptionLbl.Text = "an active internet connection is required to install codered, please try again later";
                AcceptBtn.Visible = false;
                DenyBtn.Visible = false;
                AltBtn.Visible = true;
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

            AcceptBtn.SetTheme(ControlType, IconType);
            DenyBtn.SetTheme(ControlType, IconType);
            AltBtn.SetTheme(ControlType, IconType);
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
        private void AcceptBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (ButtonClickAccept != null)
            {
                ButtonClickAccept.Invoke(this, e);
            }
        }

        public event EventHandler ButtonClickDeny = null;
        private void DenyBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (ButtonClickDeny != null)
            {
                ButtonClickDeny.Invoke(this, e);
            }
        }

        public event EventHandler ButtonClickAlt = null;
        private void AltBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (ButtonClickAlt != null)
            {
                ButtonClickAlt.Invoke(this, e);
            }
        }
    }
}
