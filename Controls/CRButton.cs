using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Black and White
            public static readonly Color BorderColor1 = Color.FromArgb(185, 185, 185);
            public static readonly Color BackgroundColor1 = Color.FromArgb(235, 235, 235);
            public static readonly Color HoverColor1 = Color.FromArgb(245, 245, 245);
            public static readonly Color ClickColor1 = Color.FromArgb(215, 215, 215);
        }

        public enum ButtonStyles : byte
        {
            STYLE_COLORED,
            STYLE_BLACK_WHITE
        }

        private ButtonStyles ButtonStyle = ButtonStyles.STYLE_COLORED;
        private Image ButtonImage = null;
        private string ButtonText = "Button";

        public ButtonStyles DisplayStyle
        {
            get { return ButtonStyle; }
            set { ButtonStyle = value; UpdateStyle(); Invalidate(); }
        }

        public Image DisplayImage
        {
            get { return ButtonImage; }
            set { ButtonImage = value; UpdateStyle(); Invalidate(); }
        }

        public string DisplayText
        {
            get { return ButtonText; }
            set { ButtonText = value; TextLbl.Text = ButtonText; UpdateStyle(); Invalidate(); }
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
                ButtonImg.BackgroundImage = ButtonImage;
                TextLbl.ForeColor = Palette.FontLight;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_BLACK_WHITE)
            {
                this.BackColor = Palette.BorderColor1;
                TextLbl.ForeColor = Palette.FontDark;
            }
        }

        private void GlobalMouseEnter()
        {
            if (ButtonStyle == ButtonStyles.STYLE_COLORED)
            {
                BackgroundPnl.BackColor = Palette.HoverColor0;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_BLACK_WHITE)
            {
                BackgroundPnl.BackColor = Palette.HoverColor1;
            }
        }

        private void GlobalMouseDown()
        {
            if (ButtonStyle == ButtonStyles.STYLE_COLORED)
            {
                BackgroundPnl.BackColor = Palette.ClickColor0;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_BLACK_WHITE)
            {
                BackgroundPnl.BackColor = Palette.ClickColor1;
            }
        }

        private void GlobalMouseUp()
        {
            if (ButtonStyle == ButtonStyles.STYLE_COLORED)
            {
                BackgroundPnl.BackColor = Palette.HoverColor0;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_BLACK_WHITE)
            {
                BackgroundPnl.BackColor = Palette.HoverColor1;
            }
        }

        private void GlobalMouseLeave()
        {
            if (ButtonStyle == ButtonStyles.STYLE_COLORED)
            {
                BackgroundPnl.BackColor = Palette.BackgroundColor0;
            }
            else if (ButtonStyle == ButtonStyles.STYLE_BLACK_WHITE)
            {
                BackgroundPnl.BackColor = Palette.BackgroundColor1;
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
            this.OnClick(e);
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
            this.OnClick(e);
            GlobalMouseDown();
        }
    }
}
