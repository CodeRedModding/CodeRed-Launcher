using System;
using System.IO;
using System.Collections.Generic;

namespace CodeRedLauncher.Architecture
{
    // This is a custom class I made just so I could use something that was similar to "std::filesystem::path" which I am more familiar with.
    // Unnecessary but I like working with it anyway because of the "append" function and divide operator overloads, there is room for improvement in some areas for sure but I don't care.
    public class Path
    {
        private string? IndirectPath { get; set; } = null;

        private void Initialize(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                IndirectPath = str;
                IndirectPath = IndirectPath.Replace("\\\\", "\\");
            }
        }

        public Path()
        {
            IndirectPath = null;
        }

        public Path(string str)
        {
            Initialize(str);
        }

        public string? GetPath()
        {
            return IndirectPath;
        }

        public bool IsFile()
        {
            return File.Exists(IndirectPath);
        }

        public bool Exists()
        {
            return (IsFile() ? File.Exists(GetPath()) : Directory.Exists(GetPath()));
        }

        // Modifies the current path with the given string. If you wish to return/add on to the path by creating a new one instead of modifying it, see down below for the divide operator overload.
        public Path Append(string str)
        {
            if (!String.IsNullOrEmpty(IndirectPath))
            {
                if (IndirectPath[IndirectPath.Length - 1] == '\\')
                {
                    IndirectPath += str;
                }
                else
                {
                    IndirectPath += "\\" + str;
                }
            }
            else
            {
                IndirectPath = str;
            }

            Initialize(IndirectPath);
            return this;
        }

        // Sets and overwrites the current directory/file information.
        public Path Set(string str)
        {
            Initialize(str);
            return this;
        }

        public Path Set(Path other)
        {
            Initialize(other.GetPath());
            return this;
        }

        // Returns a new path initialized by substringing the current paths...path.
        // If the paths parent path isn't a valid path the current paths path will return as a new path instead (hehe).
        public Path Parent()
        {
            string parentPath = IndirectPath;

            if (!String.IsNullOrEmpty(parentPath))
            {
                Int32 parentStart = parentPath.LastIndexOf("\\");
                string tempPath = parentPath.Substring(parentStart, parentPath.Length - parentStart);
                parentPath = parentPath.Replace(tempPath, "");

                if (!Directory.Exists(parentPath))
                {
                    parentPath = GetPath();
                }
            }

            return new Path(parentPath);
        }

        // Returns only the paths to files in the current directory, "bIncludeSubdirectories" will include all files in sub directories which is false by default.
        public List<Path> GetFiles(bool bIncludeSubdirectories = false)
        {
            List<Path> returnList = new List<Path>();

            if (Exists())
            {
                string[] filePaths = (bIncludeSubdirectories ? Directory.GetFiles(GetPath(), "*", SearchOption.AllDirectories) : Directory.GetFiles(GetPath(), "*", SearchOption.TopDirectoryOnly));

                foreach (string file in filePaths)
                {
                    if (File.Exists(file))
                    {
                        returnList.Add(new Path(file));
                    }
                }
            }

            return returnList;
        }

        // Returns only paths to directories and not files in the current directory, includes sub directories.
        public List<Path> GetDirectories()
        {
            List<Path> returnList = new List<Path>();

            if (Exists())
            {
                string[] directoryPaths = Directory.GetDirectories(GetPath());

                foreach (string directory in directoryPaths)
                {
                    if (Directory.Exists(directory))
                    {
                        returnList.Add(new Path(directory));
                    }
                }
            }

            return returnList;
        }

        // Returns a NEW path object with a given string, unlike the "append" function this does not modify the input path in any way, example: Path newPath = givenPath / "Debug";
        // Let's say givenPath is equal to "C:\", this operator returns a new path which will be equal to "C:\Debug", auto-formatting the slashes for you.
        public static Path operator /(Path a, string b)
        {
            Path newPath = new Path();
            newPath.Set(a);
            b = b.Replace("/", "\\");
            newPath.Append(b);
            return newPath;
        }
    }
}
