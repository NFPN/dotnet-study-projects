using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DirectoryStuff
{
    /// <summary>
    /// This program will MOVE all files from target directory subdirectories to target directory
    /// Basically move all files to set root folder
    /// All files will be renamed as File1, File2 etc..
    /// Extensions will remain the same
    /// </summary>
    internal class Program
    {
        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct WIN32_FIND_DATA
        {
            public uint dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll")]
        private static extern bool FindClose(IntPtr hFindFile);

        private static string targetFolder = @"C:\folder\name";
        private static long count = 0;
        private static bool deleteEmtpy = true;

        private static void Main(string[] args)
        {
            if (Directory.Exists(targetFolder))
            {
                ProcessDirectory(targetFolder);
                if (deleteEmtpy == true)
                    ProcessDirectory(targetFolder);
            }
        }

        public static void ProcessDirectory(string targetDirectory)
        {
            if (IsDirectoryEmtpy(targetDirectory))
            {
                Directory.Delete(targetDirectory);
                return;
            }

            var fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                if (targetDirectory != targetFolder)
                    ProcessFile(fileName);

            var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public static void ProcessFile(string sourceFile)
        {
            var extension = Path.GetExtension(sourceFile);
            var destFile = $@"{targetFolder}\File{count:D6}{extension}";

            while (File.Exists(destFile))
                destFile = $@"{targetFolder}\File{count++:D6}{extension}";

            File.Copy(sourceFile, destFile);
            File.Delete(sourceFile);
            count++;
        }

        public static bool IsDirectoryEmtpy(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(path);

            if (Directory.Exists(path))
            {
                if (path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    path += "*";
                else
                    path += Path.DirectorySeparatorChar + "*";

                var findHandle = FindFirstFile(path, out WIN32_FIND_DATA findData);

                if (findHandle != INVALID_HANDLE_VALUE)
                {
                    try
                    {
                        bool empty = true;
                        do
                        {
                            if (findData.cFileName != "." && findData.cFileName != "..")
                                empty = false;
                        } while (empty && FindNextFile(findHandle, out findData));

                        return empty;
                    }
                    finally
                    {
                        FindClose(findHandle);
                    }
                }

                throw new Exception("Failed to get directory first file",
                    Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));
            }
            throw new DirectoryNotFoundException();
        }
    }
}
