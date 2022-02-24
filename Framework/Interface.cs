using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CodeRedLauncher.Controls;

namespace CodeRedLauncher
{
    public enum Tabs : byte
    {
        TAB_DASHBOARD,
        TAB_NEWS,
        TAB_TRACKER,
        TAB_TEXTURES,
        TAB_SCRIPTS,
        TAB_SETTINGS,
        TAB_ABOUT
    }

    // Helper class for managing tabs and their button status outside of custom controls.
    public static class Interface
    {
        private static TabControl ControlTab = null;
        private static Dictionary<Tabs, Pair<CRTab, TabPage>> TabCache = new Dictionary<Tabs, Pair<CRTab, TabPage>>();

        public static void BindControl(TabControl control)
        {
            ControlTab = control;
        }

        public static void BindTab(Tabs id, CRTab tab, TabPage page)
        {
            TabCache.Add(id, new Pair<CRTab, TabPage>(tab, page));
        }

        private static void ResetTabs()
        {
            foreach (var tab in TabCache)
            {
                tab.Value.First.Selected = false;
            }
        }

        public static void SelectTab(Tabs id)
        {
            if (TabCache.ContainsKey(id))
            {
                ResetTabs();
                Pair<CRTab, TabPage> tabPair = TabCache[id];
                tabPair.First.Selected = true;
                ControlTab.SelectedTab = tabPair.Second;
            }
        }
    }
}
