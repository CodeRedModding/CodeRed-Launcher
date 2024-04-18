﻿using System;
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
        private ControlTheme m_controlTheme = ControlTheme.Dark;
        private IconTheme m_iconTheme = IconTheme.White;
        private Dictionary<IconTheme, Image> m_icons = new Dictionary<IconTheme, Image>();

        public ControlTheme Control
        {
            get { return m_controlTheme; }
            set { m_controlTheme = value; }
        }

        public IconTheme Theme
        {
            get { return m_iconTheme; }
            set { m_iconTheme = value; }
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
            return (m_icons.ContainsKey(type) ? m_icons[type] : null);
        }

        public void SetIcon(IconTheme type, Image icon)
        {
            m_icons[type] = icon;
        }
    }

    public class GPalette
    {
        // Primary Colors
        public static readonly Color CodeRed = Color.FromArgb(255, 50, 37);                     // #ff3225
        public static readonly Color CodeRed_Highlight = Color.FromArgb(252, 82, 71);           // #fc5247
        public static readonly Color CodeOrange = Color.FromArgb(255, 130, 37);                 // #ff8225
        public static readonly Color CodeOrange_Highlight = Color.FromArgb(252, 148, 71);       // #fc9447
        public static readonly Color CodeYellow = Color.FromArgb(255, 246, 37);                 // #fff625
        public static readonly Color CodeYellow_Highlight = Color.FromArgb(252, 244, 71);       // #fcF447
        public static readonly Color CodeGreen = Color.FromArgb(37, 255, 94);                   // #25FF5E
        public static readonly Color CodeGreen_Highlight = Color.FromArgb(70, 255, 118);        // #46FF76
        public static readonly Color CodeBlue = Color.FromArgb(37, 100, 255);                   // #2564ff
        public static readonly Color CodeBlue_Highlight = Color.FromArgb(71, 124, 252);         // #477cfc
        public static readonly Color CodePurple = Color.FromArgb(209, 44, 107);                 // #d12c6b (Used by the lightmode UI)
        public static readonly Color CodePurple_Highlight = Color.FromArgb(217, 63, 122);       // #d93f7a (Used by the lightmode UI)
        private static readonly Color CodePurple_Alt = Color.FromArgb(185, 37, 255);            // #b925ff (Unused in the launcher)
        private static readonly Color CodePurple_Alt_Highlight = Color.FromArgb(193, 71, 252);  // #c147fc (Unused in the launcher)
        public static readonly Color CodePink = Color.FromArgb(255, 37, 234);                   // #ff25ea
        public static readonly Color CodePink_Highlight = Color.FromArgb(252, 71, 236);         // #fc47ec
        // Greyscale
        public static readonly Color PureBlack = Color.FromArgb(20, 22, 24);                    // #141618
        public static readonly Color Black = Color.FromArgb(30, 30, 31);                        // #1e1e1f
        public static readonly Color LightBlack = Color.FromArgb(40, 42, 45);                   // #282a2d
        public static readonly Color DarkGrey = Color.FromArgb(50, 50, 55);                     // #323237
        public static readonly Color LightGrey = Color.FromArgb(128, 128, 130);                 // #808082
        public static readonly Color Grey = Color.FromArgb(194, 194, 198);                      // #c2c2c6
        public static readonly Color GreyWhite = Color.FromArgb(226, 224, 224);                 // #e2e0f4
        public static readonly Color White = Color.FromArgb(242, 242, 242);                     // #f2f2f2
        public static readonly Color PureWhite = Color.FromArgb(255, 255, 255);                 // #ffffff
    }
}