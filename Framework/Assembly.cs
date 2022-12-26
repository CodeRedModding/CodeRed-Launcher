using System;

namespace CodeRedLauncher
{
    public static class Assembly
    {
        private static readonly string Title = "CodeRedLauncher";
        private static readonly string Description = "Manages CodeRed for Rocket League.";
        private static readonly string Company = "https://github.com/CodeRedModding/";
        private static readonly string Repository = Company + "CodeRed-Launcher/";
        private static readonly string Product = "CodeRedLauncher";
        private static readonly string Copyright = "Copyright © CodeRedModding 2022";
        private static readonly string License = "MIT License";
        private static readonly string Version = "1.0.7";

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
