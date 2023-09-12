using System;

namespace CodeRedLauncher
{
    public static class Assembly
    {
        private static readonly string _title = "CodeRed Launcher";
        private static readonly string _description = "Manages the CodeRed Module for Rocket League.";
        private static readonly string _company = "CodeRedModding";
        private static readonly string _product = "CodeRed Launcher";
        private static readonly string _copyright = "CodeRedModding 2023";
        private static readonly string _license = "MIT License";
        private static readonly string _version = "1.2.3";
        private static readonly bool _termsOfUse = false;
        private static readonly bool _privatePolicy = false;

        public static string GetTitle() { return _title; }
        public static string GetDescription() { return _description; }
        public static string GetCompany() { return _company; }
        public static string GetProduct() { return _product; }
        public static string GetCopyright() { return _copyright; }
        public static string GetLicense() { return _license; }
        public static string GetVersion() { return _version; }
        public static bool UsingTerms() { return _termsOfUse; }
        public static bool UsingPrivacy() { return _privatePolicy; }
    }
}
