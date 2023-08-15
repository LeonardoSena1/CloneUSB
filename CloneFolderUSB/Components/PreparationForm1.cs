using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneFolderUSB.Components
{
    public static class PreparationForm1
    {
        public static Image ResizeImage(Image originalImage, int newWidth, int newHeight)
        {
            // Calcula as novas dimensões mantendo a proporção da imagem original
            float ratioX = (float)newWidth / originalImage.Width;
            float ratioY = (float)newHeight / originalImage.Height;
            float ratio = Math.Min(ratioX, ratioY);

            int destWidth = (int)(originalImage.Width * ratio);
            int destHeight = (int)(originalImage.Height * ratio);

            // Redimensiona a imagem
            Bitmap resizedImage = new Bitmap(destWidth, destHeight);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, destWidth, destHeight);
            }

            return resizedImage;
        }

        public static int CountFilesInDirectory(string directoryPath)
        {
            int fileCount = 0;

            string[] files = Directory.GetFiles(directoryPath);

            fileCount += files.Length;

            string[] subDirectories = Directory.GetDirectories(directoryPath);

            foreach (string subDirectory in subDirectories)
                if (!subDirectory.Contains("System Volume Information"))
                    fileCount += CountFilesInDirectory(subDirectory);

            return fileCount;
        }

        public static bool CheckIfDiskExists(string diskName)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
                if (string.Equals(drive.Name.Remove(2), diskName, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        public static void CopyFolder(string sourcePath, string targetPath)
        {
            int indexProgressBar = 1;
            string[] files = Directory.GetFiles(sourcePath);
            string[] subDirectories = Directory.GetDirectories(sourcePath);

            foreach (string file in files)
            {
                //File.Copy(file, Path.Combine(targetPath, Path.GetFileName(file)).ToString(), true);
                progressBar(indexProgressBar);
                indexProgressBar++;
            }

            foreach (string subDir in subDirectories)
            {
                if (!subDir.Contains("System Volume Information"))
                    CopyFolder(subDir, Path.Combine(targetPath, Path.GetFileName(subDir)));
                progressBar(indexProgressBar);
                indexProgressBar++;
            }
        }
    }
}
