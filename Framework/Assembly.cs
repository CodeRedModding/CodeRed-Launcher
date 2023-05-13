using System;

namespace CodeRedLauncher
{
    public static class Assembly
    {
        private static readonly string Title = "CodeRed Launcher";
        private static readonly string Description = "Manages the CodeRed Module for Rocket League.";
        private static readonly string Company = "https://github.com/CodeRedModding/";
        private static readonly string Repository = (Company + "CodeRed-Launcher/");
        private static readonly string Product = "CodeRed Launcher";
        private static readonly string Copyright = "Rocket Planet Services Inc.";
        private static readonly string License = "MIT License";
        private static readonly string Version = "1.1.7";

        public static string GetTitle() { return Title; }
        public static string GetDescription() { return Description; }
        public static string GetCompany() { return Company; }
        public static string GetRepository() { return Repository; }
        public static string GetProduct() { return Product; }
        public static string GetCopyright() { return Copyright; }
        public static string GetLicense() { return License; }
        public static string GetVersion() { return Version; }
    }
}
