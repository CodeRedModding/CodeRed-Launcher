using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeRedLauncher.Controls
{
    public partial class CRPathPopup : UserControl
    {
        const IconTheme m_darkIcon = IconTheme.White;
        const IconTheme m_lightIcon = IconTheme.Purple;
        private Form m_boundForm = null;
        private CRTitleBar m_boundTitle = null;

        public bool IsDarkMode()
        {
            return AltBtn.IsDarkMode();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ControlTheme Theme
        {
            get
            {
                return AltBtn.Theme;
            }
            set
            {
                AltBtn.Theme = value;
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

        public CRPathPopup()
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
            if (IsDarkMode())
            {
                this.BackColor = GPalette.Black;
                BackgroundPnl.BackColor = GPalette.LightBlack;
                TitleLbl.ForeColor = GPalette.White;
                DescriptionLbl.ForeColor = GPalette.White;
                ArtImage.BackgroundImage = Properties.Resources.TL1_Dark;
            }
            else
            {
                this.BackColor = GPalette.GreyWhite;
                BackgroundPnl.BackColor = GPalette.Grey;
                TitleLbl.ForeColor = GPalette.Black;
                DescriptionLbl.ForeColor = GPalette.Black;
                ArtImage.BackgroundImage = Properties.Resources.TL1_Light;
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
    }
}
