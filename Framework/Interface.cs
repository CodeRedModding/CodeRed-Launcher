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
        Settings,
        About,
        Exit
    }

    // Helper class for managing tabs and their buttons outside of custom controls.
    public static class TabManager
    {
        private static ControlTheme m_theme = ControlTheme.Dark;
        private static IconTheme m_icon = IconTheme.Red;
        private static TabControl m_controlTab = null;
        private static Dictionary<Tabs, Pair<CRTab, TabPage>> m_boundTabs = new Dictionary<Tabs, Pair<CRTab, TabPage>>();

        public static ControlTheme ControlType
        {
            get { return m_theme; }
            set { m_theme = value; UpdateTheme(); }
        }

        public static IconTheme IconType
        {
            get { return m_icon; }
            set { m_icon = value; UpdateTheme(); }
        }

        public static void SetTheme(ControlTheme control, IconTheme icon)
        {
            ControlType = control;
            IconType = icon;
        }

        private static void UpdateTheme()
        {
            bool darkMode = (ControlType == ControlTheme.Dark);

            foreach (var tab in m_boundTabs)
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
            m_controlTab = control;
        }

        public static void BindTab(Tabs id, CRTab tab, TabPage page)
        {
            m_boundTabs[id] = new Pair<CRTab, TabPage>(tab, page);
        }

        private static void ResetTabs()
        {
            foreach (var tab in m_boundTabs)
            {
                if (tab.Value.First != null)
                {
                    tab.Value.First.TabSelected = false;
                }
            }
        }

        public static void SelectTab(Tabs id)
        {
            if ((m_controlTab != null) && m_boundTabs.ContainsKey(id))
            {
                ResetTabs();
                Pair<CRTab, TabPage> tabPair = m_boundTabs[id];
                tabPair.First.TabSelected = true;
                m_controlTab.SelectedTab = tabPair.Second;
            }
        }
    }
}