﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRUpdate : UserControl
    {
        public enum UpdateLayouts : byte
        {
            None,
            Running,
            DownloadingModule,
            DownloadingLauncher,
            InstallingModule,
            InstallingLauncher,
            Module,
            Launcher,
            Both,
            Fail
        }

        private UpdateLayouts m_updateType = UpdateLayouts.Module;
        private Form m_boundForm = null;
        private CRTitle m_boundTitle = null;
        private bool m_buttonsEnabled = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public UpdateLayouts UpdateType
        {
            get { return m_updateType; }
            set { m_updateType = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme ControlType
        {
            get { return AcceptBtn.ControlType; }
            set { AcceptBtn.ControlType = value; DenyBtn.ControlType = value; GameBtn.ControlType = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public IconTheme IconType
        {
            get { return AcceptBtn.IconType; }
            set { AcceptBtn.IconType = value; DenyBtn.IconType = value; GameBtn.IconType = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Form BoundForm
        {
            get { return m_boundForm; }
            set { m_boundForm = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public CRTitle BoundTitle
        {
            get { return m_boundTitle; }
            set { m_boundTitle = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ButtonsEnabled
        {
            get { return m_buttonsEnabled; }
            set { m_buttonsEnabled = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AcceptWhite
        {
            get { return AcceptBtn.GetIcon(IconTheme.White); }
            set { AcceptBtn.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AcceptBlack
        {
            get { return AcceptBtn.GetIcon(IconTheme.Black); }
            set { AcceptBtn.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AcceptRed
        {
            get { return AcceptBtn.GetIcon(IconTheme.Red); }
            set { AcceptBtn.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AcceptPurple
        {
            get { return AcceptBtn.GetIcon(IconTheme.Purple); }
            set { AcceptBtn.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AcceptBlue
        {
            get { return AcceptBtn.GetIcon(IconTheme.Blue); }
            set { AcceptBtn.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image DenyWhite
        {
            get { return DenyBtn.GetIcon(IconTheme.White); }
            set { DenyBtn.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image DenyBlack
        {
            get { return DenyBtn.GetIcon(IconTheme.Black); }
            set { DenyBtn.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image DenyRed
        {
            get { return DenyBtn.GetIcon(IconTheme.Red); }
            set { DenyBtn.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image DenyPurple
        {
            get { return DenyBtn.GetIcon(IconTheme.Purple); }
            set { DenyBtn.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image DenyBlue
        {
            get { return DenyBtn.GetIcon(IconTheme.Blue); }
            set { DenyBtn.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AltWhite
        {
            get { return GameBtn.GetIcon(IconTheme.White); }
            set { GameBtn.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AltBlack
        {
            get { return GameBtn.GetIcon(IconTheme.Black); }
            set { GameBtn.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AltRed
        {
            get { return GameBtn.GetIcon(IconTheme.Red); }
            set { GameBtn.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image AltPurple
        {
            get { return GameBtn.GetIcon(IconTheme.Purple); }
            set { GameBtn.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
                m_buttonsEnabled = true;
                AcceptBtn.Visible = false;
                DenyBtn.Visible = false;
                GameBtn.Visible = true;
            }
            else if (UpdateType == UpdateLayouts.DownloadingModule)
            {
                DescriptionLbl.Text = "Downloading latest module version, please wait...";
                m_buttonsEnabled = false;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.InstallingModule)
            {
                DescriptionLbl.Text = "Download complete, installing module...";
                m_buttonsEnabled = false;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.DownloadingLauncher)
            {
                DescriptionLbl.Text = "Downloading latest launcher version, please wait...";
                m_buttonsEnabled = false;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.InstallingLauncher)
            {
                DescriptionLbl.Text = "Download complete, installing launcher...";
                m_buttonsEnabled = false;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.Module)
            {
                DescriptionLbl.Text = "A new version of the module was found, would you like to automatically install it now?";
                m_buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.Launcher)
            {
                DescriptionLbl.Text = "A new version of the launcher was found, would you like to automatically install it now?";
                m_buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.Both)
            {
                DescriptionLbl.Text = "A new version both the launcher and module were found, would you like to automatically install it now?";
                m_buttonsEnabled = true;
                AcceptBtn.Visible = true;
                DenyBtn.Visible = true;
                GameBtn.Visible = false;
            }
            else if (UpdateType == UpdateLayouts.Fail)
            {
                DescriptionLbl.Text = "An error occurred while downloading the latest version, would you like to try again?";
                m_buttonsEnabled = true;
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
                if (ButtonClickDeny != null)
                {
                    ButtonClickDeny.Invoke(this, e);
                }

                HidePopup();
            }
        }
    }
}