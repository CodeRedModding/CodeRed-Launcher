using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CodeRedLauncher.Controls;

namespace CodeRedLauncher
{
    public enum Tabs : byte
    {
        Dashboard,
        News,
        Sessions,
        Settings,
        About,
        Exit
    }

    // Helper class for managing tabs and their buttons outside of custom controls.
    public static class TabManager
    {
        private static ControlTheme _theme = ControlTheme.Dark;
        private static IconTheme _icon = IconTheme.Red;
        private static TabControl _controlTab = null;
        private static Dictionary<Tabs, Pair<CRTab, TabPage>> _boundTabs = new Dictionary<Tabs, Pair<CRTab, TabPage>>();

        public static ControlTheme ControlType
        {
            get { return _theme; }
            set { _theme = value; UpdateTheme(); }
        }

        public static IconTheme IconType
        {
            get { return _icon; }
            set { _icon = value; UpdateTheme(); }
        }

        public static void SetTheme(ControlTheme control, IconTheme icon)
        {
            ControlType = control;
            IconType = icon;
        }

        private static void UpdateTheme()
        {
            bool darkMode = (ControlType == ControlTheme.Dark);

            foreach (var tab in _boundTabs)
            {
                if (tab.Value.Second != null)
                {
                    tab.Value.Second.BackColor = (darkMode ? GPalette.Black : GPalette.GreyWhite);
                }

                if (tab.Value.First != null)
                {
                    tab.Value.First.SetTheme(ControlType, IconType);
                }
            }
        }

        public static void BindControl(TabControl control)
        {
            _controlTab = control;
        }

        public static void BindTab(Tabs id, CRTab tab, TabPage page)
        {
            _boundTabs[id] = new Pair<CRTab, TabPage>(tab, page);
        }

        private static void ResetTabs()
        {
            foreach (var tab in _boundTabs)
            {
                if (tab.Value.First != null)
                {
                    tab.Value.First.TabSelected = false;
                }
            }
        }

        public static void SelectTab(Tabs id)
        {
            if ((_controlTab != null) && _boundTabs.ContainsKey(id))
            {
                ResetTabs();
                Pair<CRTab, TabPage> tabPair = _boundTabs[id];
                tabPair.First.TabSelected = true;
                _controlTab.SelectedTab = tabPair.Second;
            }
        }
    }
}
