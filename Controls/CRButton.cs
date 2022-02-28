using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRButton : UserControl
    {
        private struct Palette
        {
            public static readonly Color FontLight = Color.FromArgb(235, 235, 235);
            public static readonly Color FontDark = Color.FromArgb(22, 22, 22);
            // Colored
            public static readonly Color BorderColor0 = Color.FromArgb(175, 0, 0);
            public static readonly Color BackgroundColor0 = Color.FromArgb(255, 0, 0);
            public static readonly Color HoverColor0 = Color.FromArgb(255, 50, 50);
            public static readonly Color ClickColor0 = Color.FromArgb(200, 20, 0);
            // Light
            public static readonly Color BorderColor1 = Color.FromArgb(185, 185, 185);
            public static readonly Color BackgroundColor1 = Color.FromArgb(235, 235, 235);
            public static readonly Color HoverColor1 = Color.FromArgb(245, 245, 245);
            public static readonly Color ClickColor1 = Color.FromArgb(215, 215, 215);
            // Dark
            public static readonly Color BorderColor2 = Color.FromArgb(30, 30, 30);
            public static readonly Color BackgroundColor2 = Color.FromArgb(26, 26, 26);
            public static readonly Color HoverColor2 = Color.FromArgb(28, 28, 28);
            public static readonly Color ClickColor2 = Color.FromArgb(24, 24, 24);
        }

        public enum ButtonStyles : byte
        {
            STYLE_COLORED,
            STYLE_LIGHT,
            STYLE_DARK
        }

        private ButtonStyles ButtonStyle = ButtonStyles.STYLE_COLORED;

        public ButtonStyles DisplayStyle
        {
            get { return ButtonStyle; }
            set { ButtonStyle = value; UpdateStyle(); Invalidate(); }
        }

        public Image DisplayImage
        {
            get { return ButtonImg.BackgroundImage; }
            set { ButtonImg.BackgroundImage = value; ButtonImg.Visible = (value != null); Invalidate(); }
        }

        public Font DisplayFont
        {
            get { return TextLbl.Font; }
            set { TextLbl.Font = value; Invalidate(); }
        }

        public string DisplayText
        {
            get { return TextLbl.Text; }
            set { TextLbl.Text = value; Invalidate(); }
        }

        public CRButton()
        {
            InitializeComponent();
        }

        private void UpdateStyle()
        {
            if (ButtonStyle == ButtonStyles.STYLE_COLORED)
            {
                this.BackColor = Palette.BorderColor0;
                BackgroundPnl.BackColor = Palette.BackgroundColor0;
                TextLbl.ForeColor = Palette.FontLight;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_LIGHT)
            {
                this.BackColor = Palette.BorderColor1;
                BackgroundPnl.BackColor = Palette.BackgroundColor1;
                TextLbl.ForeColor = Palette.FontDark;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_DARK)
            {
                this.BackColor = Palette.BorderColor2;
                BackgroundPnl.BackColor = Palette.BackgroundColor2;
                TextLbl.ForeColor = Palette.FontLight;
            }
        }

        private void GlobalMouseEnter()
        {
            if (ButtonStyle == ButtonStyles.STYLE_COLORED)
            {
                BackgroundPnl.BackColor = Palette.HoverColor0;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_LIGHT)
            {
                BackgroundPnl.BackColor = Palette.HoverColor1;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_DARK)
            {
                BackgroundPnl.BackColor = Palette.HoverColor2;
            }
        }

        private void GlobalMouseDown()
        {
            if (ButtonStyle == ButtonStyles.STYLE_COLORED)
            {
                BackgroundPnl.BackColor = Palette.ClickColor0;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_LIGHT)
            {
                BackgroundPnl.BackColor = Palette.ClickColor1;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_DARK)
            {
                BackgroundPnl.BackColor = Palette.ClickColor2;
            }
        }

        private void GlobalMouseUp()
        {
            if (ButtonStyle == ButtonStyles.STYLE_COLORED)
            {
                BackgroundPnl.BackColor = Palette.HoverColor0;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_LIGHT)
            {
                BackgroundPnl.BackColor = Palette.HoverColor1;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_DARK)
            {
                BackgroundPnl.BackColor = Palette.HoverColor2;
            }
        }

        private void GlobalMouseLeave()
        {
            if (ButtonStyle == ButtonStyles.STYLE_COLORED)
            {
                BackgroundPnl.BackColor = Palette.BackgroundColor0;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_LIGHT)
            {
                BackgroundPnl.BackColor = Palette.BackgroundColor1;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_DARK)
            {
                BackgroundPnl.BackColor = Palette.BackgroundColor2;
            }
        }

        private void TextLbl_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            GlobalMouseEnter();
        }

        private void TextLbl_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            GlobalMouseDown();
        }

        private void TextLbl_MouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
            GlobalMouseUp();
        }

        private void TextLbl_MouseLeave(object sender, EventArgs e)
        {
            base.OnMouseLeave(e);
            GlobalMouseLeave();
        }

        private void TextLbl_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            CRButton_OnClick(e);
            GlobalMouseDown();
        }

        private void ButtonImg_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            GlobalMouseEnter();
        }

        private void ButtonImg_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            GlobalMouseDown();
        }

        private void ButtonImg_MouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
            GlobalMouseUp();
        }

        private void ButtonImg_MouseLeave(object sender, EventArgs e)
        {
            base.OnMouseLeave(e);
            GlobalMouseLeave();
        }

        private void ButtonImg_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            CRButton_OnClick(e);
            GlobalMouseDown();
        }

        public event EventHandler OnButtonClick;
        protected void CRButton_OnClick(EventArgs e)
        {
            OnButtonClick?.Invoke(this, e);
        }
    }
}
