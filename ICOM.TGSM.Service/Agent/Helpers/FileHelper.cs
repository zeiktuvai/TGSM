﻿namespace ICOM.TGSM.Service.Agent.Helpers
{
    public static class FileHelper
    {
        public static bool CheckDirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public static DirectoryInfo CreateDirectory(string path)
        {
            return Directory.CreateDirectory(path);
        }

        public static bool CheckFileExists(string file)
        {
            return File.Exists(file);
        }

        public static string GetFilePath(string path, string fileName)
        {
            return Path.GetFullPath(fileName, path);
        }

        public static string FindFile(string path, string searchString)
        {
            var files = Directory.GetFiles(path, searchString);
            if (files.Length > 0)
            {
                return files[0];
            }

            return "";
        }

        public static string GetFileRootPath(string path)
        {
            return Path.GetDirectoryName(path) ?? "";
        }
    }
}
