﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRButton : UserControl
    {
        private IconStore m_icons = new IconStore();
        private bool m_syncColor = false;
        private bool m_enabled = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme ControlType
        {
            get { return m_icons.Control; }
            set { m_icons.Control = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public IconTheme IconType
        {
            get { return m_icons.Theme; }
            set { m_icons.Theme = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IconSync
        {
            get { return m_syncColor; }
            set { m_syncColor = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconWhite
        {
            get { return m_icons.GetIcon(IconTheme.White); }
            set { m_icons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconBlack
        {
            get { return m_icons.GetIcon(IconTheme.Black); }
            set { m_icons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconRed
        {
            get { return m_icons.GetIcon(IconTheme.Red); }
            set { m_icons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconPurple
        {
            get { return m_icons.GetIcon(IconTheme.Purple); }
            set { m_icons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image IconBlue
        {
            get { return m_icons.GetIcon(IconTheme.Blue); }
            set { m_icons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image GetThemeIcon()
        {
            return m_icons.GetThemeIcon();
        }

        public Image GetIcon(IconTheme type)
        {
            return m_icons.GetIcon(type);
        }

        public void SetIcon(IconTheme type, Image icon)
        {
            m_icons.SetIcon(type, icon);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font DisplayFont
        {
            get { return TextLbl.Font; }
            set { TextLbl.Font = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DisplayText
        {
            get { return TextLbl.Text; }
            set { TextLbl.Text = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ButtonEnabled
        {
            get { return m_enabled; }
            set { m_enabled = value; UpdateTheme(); }
        }

        public CRButton()
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
            ButtonImg.BackgroundImage = m_icons.GetThemeIcon();
            ButtonImg.Visible = (ButtonImg.BackgroundImage != null);

            if (ControlType == ControlTheme.Dark)
            {
                this.BackColor = GPalette.CodeRed;
                TextLbl.ForeColor = (IconSync ? m_icons.GetColor() : GPalette.White);
            }
            else if (ControlType == ControlTheme.Light)
            {
                this.BackColor = GPalette.CodePurple;
                TextLbl.ForeColor = (IconSync ? m_icons.GetColor() : GPalette.White);
            }

            Invalidate();
        }

        private void OnMouseEnter()
        {
            if (ButtonEnabled)
            {
                if (ControlType == ControlTheme.Dark)
                {
                    this.BackColor = GPalette.CodeRed_Highlight;
                }
                else if (ControlType == ControlTheme.Light)
                {
                    this.BackColor = GPalette.CodePurple_Highlight;
                }
            }
        }

        private void OnMouseLeave()
        {
            if (ControlType == ControlTheme.Dark)
            {
                this.BackColor = GPalette.CodeRed;
            }
            else if (ControlType == ControlTheme.Light)
            {
                this.BackColor = GPalette.CodePurple;
            }
        }

        public event EventHandler OnButtonClick;
        protected void CRButton_OnClick(EventArgs e)
        {
            if (ButtonEnabled)
            {
                OnButtonClick?.Invoke(this, e);
            }
        }

        private void ButtonImg_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter();
        }

        private void ButtonImg_Click(object sender, EventArgs e)
        {
            CRButton_OnClick(e);
        }

        private void ButtonImg_DoubleClick(object sender, EventArgs e)
        {
            CRButton_OnClick(e);
        }

        private void TextLbl_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter();
        }

        private void TextLbl_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave();
        }

        private void TextLbl_Click(object sender, EventArgs e)
        {
            CRButton_OnClick(e);
        }

        private void TextLbl_DoubleClick(object sender, EventArgs e)
        {
            CRButton_OnClick(e);
        }

        private void TextLbl_SizeChanged(object sender, EventArgs e)
        {
            ButtonImg.Width = ButtonImg.Height;
            UpdateTheme();
        }
    }
}