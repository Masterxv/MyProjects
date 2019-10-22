﻿using System;
using System.IO;

namespace CommonInfo
{
    class FileInformation
    {
        public FileInformation(string path)
        {
            this.Path = path;
            fileInfo();
        }
        private string Path { get; set; }
        void fileInfo()
        {
            FileInfo fi = new FileInfo(Path);
            Console.WriteLine
                (
                "\nExtension: " + fi.Extension +
                "\nPath: " + fi.FullName +
                "\nCreation Time: " + fi.CreationTime +
                "\nLastAccessTime: " + fi.LastAccessTime +
                "\nLastWriteTime: " + fi.LastWriteTime +
                "\nSize: " + fi.Length / 1024 / 1024 + " Mb | " + fi.Length / 1024 +
                " Kb | " + fi.Length +
                " Byte"
                );
        }
    }
}
