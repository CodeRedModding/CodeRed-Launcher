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
        Purple
    }

    public class IconStore
    {
        private ControlTheme m_controlTheme = ControlTheme.Dark;
        private IconTheme m_iconTheme = IconTheme.White;
        private Dictionary<IconTheme, Image> m_icons = new Dictionary<IconTheme, Image>();

        public ControlTheme Theme
        {
            get
            {
                return m_controlTheme;
            }
            set
            {
                m_controlTheme = value;
            }
        }

        public IconTheme IconTheme
        {
            get
            {
                return m_iconTheme;
            }
            set
            {
                m_iconTheme = value;
            }
        }

        public Color GetIconColor()
        {
            switch (IconTheme)
            {
                case IconTheme.White:
                    return GPalette.White;
                case IconTheme.Black:
                    return GPalette.Black;
                case IconTheme.Red:
                    return GPalette.CodeRed;
                case IconTheme.Purple:
                    return GPalette.CodePurple;
                default:
                    return GPalette.White;
            }
        }

        public bool IsDarkMode()
        {
            return (Theme == ControlTheme.Dark);
        }

        public Image GetIcon()
        {
            return GetIcon(IconTheme);
        }

        public Image GetIcon(IconTheme iconTheme)
        {
            return (m_icons.ContainsKey(iconTheme) ? m_icons[iconTheme] : null);
        }

        public void SetIcon(IconTheme iconTheme, Image image)
        {
            m_icons[iconTheme] = image;
        }
    }

    public class GPalette
    {
        // Primary Colors
        public static readonly Color CodeRed = Color.FromArgb(255, 50, 37);                     // #ff3225
        public static readonly Color CodeRed_Highlight = Color.FromArgb(255, 60, 47);           // #ff3c2f
        public static readonly Color CodeOrange = Color.FromArgb(255, 134, 35);                 // #ff8623
        public static readonly Color CodeOrange_Highlight = Color.FromArgb(255, 149, 50);       // #ff9532
        public static readonly Color CodeYellow = Color.FromArgb(255, 246, 37);                 // #fff625
        public static readonly Color CodeYellow_Highlight = Color.FromArgb(252, 255, 52);       // #ffff34
        public static readonly Color CodeGreen = Color.FromArgb(40, 250, 71);                   // #28fa47
        public static readonly Color CodeGreen_Highlight = Color.FromArgb(55, 255, 86);         // #37ff56
        public static readonly Color CodeBlue = Color.FromArgb(41, 110, 255);                   // #296eff
        public static readonly Color CodeBlue_Highlight = Color.FromArgb(56, 125, 255);         // #387dff
        public static readonly Color CodePurple = Color.FromArgb(209, 44, 107);                 // #d12c6b
        public static readonly Color CodePurple_Highlight = Color.FromArgb(219, 54, 117);       // #db3675
        private static readonly Color CodePurple_Alt = Color.FromArgb(185, 37, 255);            // #b925ff (Unused in the launcher)
        private static readonly Color CodePurple_Alt_Highlight = Color.FromArgb(200, 52, 255);  // #c834ff (Unused in the launcher)
        public static readonly Color CodePink = Color.FromArgb(255, 48, 241);                   // #ff30f1
        public static readonly Color CodePink_Highlight = Color.FromArgb(255, 62, 232);         // #ff3ee8
        // Greyscale
        public static readonly Color PureBlack = Color.FromArgb(20, 22, 24);                    // #141618
        public static readonly Color Black = Color.FromArgb(30, 30, 31);                        // #1e1e1f
        public static readonly Color LightBlack_Highlight = Color.FromArgb(38, 40, 43);         // #26282b
        public static readonly Color LightBlack = Color.FromArgb(40, 42, 45);                   // #282a2d
        public static readonly Color DarkGrey_Highlight = Color.FromArgb(45, 45, 50);           // #2d2d32
        public static readonly Color DarkGrey = Color.FromArgb(50, 50, 55);                     // #323237
        public static readonly Color LightGrey = Color.FromArgb(128, 128, 130);                 // #808082
        public static readonly Color Grey_Highlight = Color.FromArgb(184, 184, 188);            // #b8b8bc
        public static readonly Color Grey = Color.FromArgb(194, 194, 198);                      // #c2c2c6
        public static readonly Color GreyWhite_Highlight = Color.FromArgb(220, 219, 219);       // #dcdbdb
        public static readonly Color GreyWhite = Color.FromArgb(226, 224, 224);                 // #e2e0f4
        public static readonly Color White_Highlight = Color.FromArgb(237, 237, 237);           // #ededed
        public static readonly Color White = Color.FromArgb(242, 242, 242);                     // #f2f2f2
        public static readonly Color PureWhite = Color.FromArgb(255, 255, 255);                 // #ffffff
    }
}