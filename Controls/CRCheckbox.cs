using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRCheckbox : UserControl
    {
        private IconStore m_icons = new IconStore();
        private IconStore m_checks = new IconStore();
        private bool m_enabled = true;
        private bool m_checked = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme ControlType
        {
            get { return m_icons.Control; }
            set { m_icons.Control = value; m_checks.Control = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public IconTheme IconType
        {
            get { return m_icons.Theme; }
            set { m_icons.Theme = value; m_checks.Theme = value; UpdateTheme(); }
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image UncheckWhite
        {
            get { return m_checks.GetIcon(IconTheme.White); }
            set { m_checks.SetIcon(IconTheme.White, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image UncheckDark
        {
            get { return m_checks.GetIcon(IconTheme.Black); }
            set { m_checks.SetIcon(IconTheme.Black, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CheckWhite
        {
            get { return m_checks.GetIcon(IconTheme.Red); }
            set { m_checks.SetIcon(IconTheme.Red, value); UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image CheckDark
        {
            get { return m_checks.GetIcon(IconTheme.Purple); }
            set { m_checks.SetIcon(IconTheme.Purple, value); UpdateTheme(); }
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
        public bool BoxEnabled
        {
            get { return m_enabled; }
            set { m_enabled = value; UpdateTheme(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool BoxChecked
        {
            get { return m_checked; }
            set { m_checked = value; UpdateTheme(); }
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
                    CheckImg.BackgroundImage = m_checks.GetIcon(IconTheme.Red);
                }
                else if (ControlType == ControlTheme.Light)
                {
                    CheckImg.BackgroundImage = m_checks.GetIcon(IconTheme.Purple);
                }
            }
            else if (ControlType == ControlTheme.Dark)
            {
                CheckImg.BackgroundImage = m_checks.GetIcon(IconTheme.White);
            }
            else if (ControlType == ControlTheme.Light)
            {
                CheckImg.BackgroundImage = m_checks.GetIcon(IconTheme.Black);
            }

            if (ControlType == ControlTheme.Dark)
            {
                TextLbl.ForeColor = GPalette.White;
            }
            else if (ControlType == ControlTheme.Light)
            {
                TextLbl.ForeColor = GPalette.Black;
            }

            IconImg.BackgroundImage = m_icons.GetThemeIcon();
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
