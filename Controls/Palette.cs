using System;
using System.Collections.Generic;
using System.Drawing;

namespace CodeRedLauncher.Controls
{
    public enum ControlTheme : byte
    {
        Dark,
        Light
    }

    public enum IconTheme : byte
    {
        White,
        Black,
        Red,
        Purple,
        Blue
    }

    public class IconStore
    {
        private ControlTheme _controlTheme = ControlTheme.Dark;
        private IconTheme _iconTheme = IconTheme.White;
        private Dictionary<IconTheme, Image> _icons = new Dictionary<IconTheme, Image>();

        public ControlTheme Control
        {
            get { return _controlTheme; }
            set { _controlTheme = value; }
        }

        public IconTheme Theme
        {
            get { return _iconTheme; }
            set { _iconTheme = value; }
        }

        public Color GetColor()
        {
            switch (Theme)
            {
                case IconTheme.White:
                    return GPalette.White;
                case IconTheme.Black:
                    return GPalette.Black;
                case IconTheme.Red:
                    return GPalette.CodeRed;
                case IconTheme.Purple:
                    return GPalette.CodePurple;
                case IconTheme.Blue:
                    return GPalette.CodeBlue;
                default:
                    return GPalette.White;
            }
        }

        public Image? GetThemeIcon()
        {
            return GetIcon(Theme);
        }

        public Image? GetIcon(IconTheme type)
        {
            return (_icons.ContainsKey(type) ? _icons[type] : null);
        }

        public void SetIcon(IconTheme type, Image icon)
        {
            _icons[type] = icon;
        }
    }

    public class GPalette
    {
        // Primary Colors
        public static readonly Color CodeRed = Color.FromArgb(255, 50, 37);
        public static readonly Color CodeRed_Highlight = Color.FromArgb(252, 82, 71);
        public static readonly Color CodePurple = Color.FromArgb(209, 44, 107);
        public static readonly Color CodePurple_Highlight = Color.FromArgb(217, 63, 122);
        public static readonly Color CodeBlue = Color.FromArgb(64, 64, 173);
        public static readonly Color CodeBlue_Highlight = Color.FromArgb(80, 80, 191);
        // Greyscales
        public static readonly Color Black = Color.FromArgb(30, 31, 34);
        public static readonly Color PureBlack = Color.FromArgb(20, 21, 24);
        public static readonly Color LightBlack = Color.FromArgb(42, 45, 49);
        public static readonly Color DarkGrey = Color.FromArgb(50, 51, 56);
        public static readonly Color LightGrey = Color.FromArgb(128, 132, 142);
        public static readonly Color Grey = Color.FromArgb(193, 198, 204);
        public static readonly Color GreyWhite = Color.FromArgb(226, 226, 226);
        public static readonly Color White = Color.FromArgb(242, 243, 245);
        public static readonly Color PureWhite = Color.FromArgb(255, 255, 255);
    }
}