using System;

namespace CodeRedLauncher
{
    public static class Assembly
    {
        private static readonly string _title = "CodeRed Launcher";
        private static readonly string _description = "Manages and injects the CodeRed module for Rocket League. ";
        private static readonly string _product = "CodeRedLauncher";
        private static readonly string _copyright = "CodeRedModding 2024";
        private static readonly string _version = "1.3.3";
        private static readonly bool _termsOfUse = false;
        private static readonly bool _privatePolicy = false;

        public static string GetTitle() { return _title; }
        public static string GetDescription() { return _description; }
        public static string GetProduct() { return _product; }
        public static string GetCopyright() { return _copyright; }
        public static string GetVersion() { return _version; }
        public static bool UsingTerms() { return _termsOfUse; }
        public static bool UsingPrivacy() { return _privatePolicy; }
    }
}