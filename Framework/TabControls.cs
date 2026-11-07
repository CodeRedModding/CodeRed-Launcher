using CodeRedLauncher.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher
{
    public enum TabIds : byte
    {
        None,
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
        private static TabIds m_activeTab = TabIds.None;
        private static TabControl m_tabControl = null;
        private static Dictionary<TabIds, Pair<CRTab, TabPage>> m_boundTabs = new Dictionary<TabIds, Pair<CRTab, TabPage>>();

        public static bool IsDarkMode()
        {
            return (Theme == ControlTheme.Dark);
        }

        public static ControlTheme Theme
        {
            get
            {
                return m_theme;
            }
            set
            {
                m_theme = value;
                OnThemeUpdated();
            }
        }

        public static void BindControl(TabControl tabControl)
        {
            m_tabControl = tabControl;
        }

        public static void BindTab(TabIds tabId, CRTab tab, TabPage page)
        {
            m_boundTabs[tabId] = new Pair<CRTab, TabPage>(tab, page);
        }

        public static void SelectTab(TabIds tabId)
        {
            if ((m_activeTab != tabId) && (m_tabControl != null) && m_boundTabs.ContainsKey(tabId))
            {
                DeselectAllTabs();
                m_activeTab = tabId;
                m_boundTabs[tabId].First.TabActive = true;
                m_tabControl.SelectedTab = m_boundTabs[tabId].Second;
            }
        }

        private static void DeselectAllTabs()
        {
            if (m_activeTab != TabIds.None)
            {
                foreach (var tab in m_boundTabs)
                {
                    if (tab.Value.First != null)
                    {
                        tab.Value.First.TabActive = false;
                    }
                }

                m_activeTab = TabIds.None;
            }
        }

        private static void OnThemeUpdated()
        {
            foreach (var tab in m_boundTabs)
            {
                if (tab.Value.First != null)
                {
                    tab.Value.First.Theme = Theme;
                }

                if (tab.Value.Second != null)
                {
                    tab.Value.Second.BackColor = (IsDarkMode() ? GPalette.Black : GPalette.GreyWhite);
                }
            }
        }
    }
}