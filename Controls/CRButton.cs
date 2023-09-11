using System;
using System.Drawing;
using System.Windows.Forms;
using Windows.Devices.Sms;

namespace CodeRedLauncher.Controls
{
    public partial class CRButton : UserControl
    {
        private IconStore _icons = new IconStore();
        private bool _syncColor = false;
        private bool _enabled = true;

        public ControlTheme ControlType
        {
            get { return _icons.Control; }
            set { _icons.Control = value; UpdateTheme(); }
        }

        public IconTheme IconType
        {
            get { return _icons.Theme; }
            set { _icons.Theme = value; UpdateTheme(); }
        }

        public bool IconSync
        {
            get { return _syncColor; }
            set { _syncColor = value; UpdateTheme(); }
        }

        public Image IconWhite
        {
            get { return _icons.GetIcon(IconTheme.White); }
            set { _icons.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image IconBlack
        {
            get { return _icons.GetIcon(IconTheme.Black); }
            set { _icons.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image IconRed
        {
            get { return _icons.GetIcon(IconTheme.Red); }
            set { _icons.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image IconPurple
        {
            get { return _icons.GetIcon(IconTheme.Purple); }
            set { _icons.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
        }

        public Image IconBlue
        {
            get { return _icons.GetIcon(IconTheme.Blue); }
            set { _icons.SetIcon(IconTheme.Blue, value); UpdateTheme(); }
        }

        public Image GetThemeIcon()
        {
            return _icons.GetThemeIcon();
        }

        public Image GetIcon(IconTheme type)
        {
            return _icons.GetIcon(type);
        }

        public void SetIcon(IconTheme type, Image icon)
        {
            _icons.SetIcon(type, icon);
        }

        public Font DisplayFont
        {
            get { return TextLbl.Font; }
            set { TextLbl.Font = value; UpdateTheme(); }
        }

        public string DisplayText
        {
            get { return TextLbl.Text; }
            set { TextLbl.Text = value; UpdateTheme(); }
        }

        public bool ButtonEnabled
        {
            get { return _enabled; }
            set { _enabled = value; UpdateTheme(); }
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
            ButtonImg.BackgroundImage = _icons.GetThemeIcon();
            ButtonImg.Visible = (ButtonImg.BackgroundImage != null);

            if (ControlType == ControlTheme.Dark)
            {
                this.BackColor = GPalette.CodeRed;
                TextLbl.ForeColor = (IconSync ? _icons.GetColor() : GPalette.White);
            }
            else if (ControlType == ControlTheme.Light)
            {
                this.BackColor = GPalette.CodePurple;
                TextLbl.ForeColor = (IconSync ? _icons.GetColor() : GPalette.White);
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