using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRLabel : UserControl
    {
        private IconStore m_icons = new IconStore();

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

        public CRLabel()
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
    }
}
