using System;
using System.IO;


namespace Task01
{
    public class DirCopy
    {

        public static void DeleateAllTextFilesInDirectory(string dirName)
        {
            DirectoryInfo dir = new DirectoryInfo(dirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + dirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
  
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string filePath = Path.Combine(dirName, file.Name);
                if (file.Extension.ToUpper().Equals(".TXT"))
                    file.Delete();
            }

            foreach (DirectoryInfo subdir in dirs)
                DeleateAllTextFilesInDirectory(subdir.FullName);
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath);
            }

        }

    }
}
