using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRCheckbox : UserControl
    {
        private IconStore _icons = new IconStore();
        private IconStore _checks = new IconStore();
        private bool _enabled = true;
        private bool _checked = false;

        public ControlTheme ControlType
        {
            get { return _icons.Control; }
            set { _icons.Control = value; _checks.Control = value; UpdateTheme(); }
        }

        public IconTheme IconType
        {
            get { return _icons.Theme; }
            set { _icons.Theme = value; _checks.Theme = value; UpdateTheme(); }
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

        public Image UncheckWhite
        {
            get { return _checks.GetIcon(IconTheme.White); }
            set { _checks.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        public Image UncheckDark
        {
            get { return _checks.GetIcon(IconTheme.Black); }
            set { _checks.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        public Image CheckWhite
        {
            get { return _checks.GetIcon(IconTheme.Red); }
            set { _checks.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        public Image CheckDark
        {
            get { return _checks.GetIcon(IconTheme.Purple); }
            set { _checks.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
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

        public bool BoxEnabled
        {
            get { return _enabled; }
            set { _enabled = value; UpdateTheme(); }
        }

        public bool BoxChecked
        {
            get { return _checked; }
            set { _checked = value; UpdateTheme(); }
        }

        public CRCheckbox()
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
            // White = Unchecked White
            // Black = Unchecked Dark
            // Red = Checked White
            // Purple = Checked Dark

            if (BoxChecked)
            {
                if (ControlType == ControlTheme.Dark)
                {
                    CheckImg.BackgroundImage = _checks.GetIcon(IconTheme.Red);
                }
                else if (ControlType == ControlTheme.Light)
                {
                    CheckImg.BackgroundImage = _checks.GetIcon(IconTheme.Purple);
                }
            }
            else if (ControlType == ControlTheme.Dark)
            {
                CheckImg.BackgroundImage = _checks.GetIcon(IconTheme.White);
            }
            else if (ControlType == ControlTheme.Light)
            {
                CheckImg.BackgroundImage = _checks.GetIcon(IconTheme.Black);
            }

            if (ControlType == ControlTheme.Dark)
            {
                TextLbl.ForeColor = GPalette.White;
            }
            else if (ControlType == ControlTheme.Light)
            {
                TextLbl.ForeColor = GPalette.Black;
            }

            IconImg.BackgroundImage = _icons.GetThemeIcon();
            Invalidate();
        }

        public event EventHandler OnCheckChanged;
        protected void CRButton_CheckChanged(EventArgs e)
        {
            if (BoxEnabled)
            {
                BoxChecked = !BoxChecked;
                OnCheckChanged?.Invoke(this, e);
            }
        }

        private void CRCheckbox_SizeChanged(object sender, EventArgs e)
        {
            //IconImg.Width = IconImg.Height;
            //CheckPnl.Width = CheckPnl.Height;
            //CheckPnl.Location = new Point(((IconImg.Location.X + IconImg.Width) + 5), CheckPnl.Location.Y);
            //TextLbl.Location = new Point(((CheckPnl.Location.X + CheckPnl.Width) + 5), TextLbl.Location.Y);
            //Invalidate();
        }

        private void CheckImg_Click(object sender, EventArgs e)
        {
            CRButton_CheckChanged(e);
        }

        private void CheckImg_DoubleClick(object sender, EventArgs e)
        {
            CRButton_CheckChanged(e);
        }

        private void TextLbl_Click(object sender, EventArgs e)
        {
            CRButton_CheckChanged(e);
        }

        private void TextLbl_DoubleClick(object sender, EventArgs e)
        {
            CRButton_CheckChanged(e);
        }
    }
}
