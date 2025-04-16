using System;

namespace CodeRedLauncher
{
    public static class Assembly
    {
        private static readonly string m_title = "CodeRed Launcher";
        private static readonly string m_description = "Manages and injects the CodeRed module for Rocket League.";
        private static readonly string m_product = "CodeRedLauncher";
        private static readonly string m_copyright = "CodeRedModding 2025";
        private static readonly string m_version = "1.4.3";
        private static readonly bool m_termsOfUse = false;
        private static readonly bool m_privatePolicy = false;

        public static string GetTitle() { return m_title; }
        public static string GetDescription() { return m_description; }
        public static string GetProduct() { return m_product; }
        public static string GetCopyright() { return m_copyright; }
        public static string GetVersion() { return m_version; }
        public static bool UsingTerms() { return m_termsOfUse; }
        public static bool UsingPrivacy() { return m_privatePolicy; }
    }
}