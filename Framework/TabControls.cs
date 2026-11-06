using CodeRedLauncher.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

        public static ControlTheme Theme
        {
            get
            {
                return m_theme;
            }
            set
            {
                m_theme = value;
                m_icon = ((value == ControlTheme.Dark) ? IconTheme.Red : IconTheme.Purple);
                OnThemeUpdated();
            }
        }

        public static IconTheme IconType
        {
            get
            {
                return m_icon;
            }
            set
            {
                m_icon = value;
                OnThemeUpdated();
            }
        }

        public static void BindControl(TabControl control)
        {
            m_controlTab = control;
        }

        public static void BindTab(Tabs tabId, CRTab tab, TabPage page)
        {
            m_boundTabs[tabId] = new Pair<CRTab, TabPage>(tab, page);
        }

        private static void ResetTabs()
        {
            foreach (var tab in m_boundTabs)
            {
                if (tab.Value.First != null)
                {
                    tab.Value.First.TabActive = false;
                }
            }
        }

        public static void SelectTab(Tabs tabId)
        {
            if ((m_controlTab != null) && m_boundTabs.ContainsKey(tabId))
            {
                ResetTabs();
                m_boundTabs[tabId].First.TabActive = true;
                m_controlTab.SelectedTab = m_boundTabs[tabId].Second;
            }
        }

        private static void OnThemeUpdated()
        {
            foreach (var tab in m_boundTabs)
            {
                if (tab.Value.Second != null)
                {
                    tab.Value.Second.BackColor = ((Theme == ControlTheme.Dark) ? GPalette.Black : GPalette.GreyWhite);
                }

                if (tab.Value.First != null)
                {
                    tab.Value.First.Theme = Theme;
                }
            }
        }
    }
}