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
            return Count(directoryPath);
        }

        private static int Count(string directoryPath)
        {
            int fileCount = 0;

            string[] files = Directory.GetFiles(directoryPath);

            fileCount += files.Length;

            string[] subDirectories = Directory.GetDirectories(directoryPath);

            foreach (string subDirectory in subDirectories)
                if (!subDirectory.Contains("System Volume Information"))
                    fileCount += Count(subDirectory);
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

        public static string CheckDisponibilidadeClone(string soucer, string destination)
        {
            string IsValid = string.Empty;

            if (soucer.Equals(destination))
                IsValid = "Impossível clonar um dispositivo no mesmo dispositivo.";

            if (!PreparationForm1.CheckIfDiskExists(soucer) && !PreparationForm1.CheckIfDiskExists(destination))
                IsValid = "Disk Local não encontrado";
            else if (GetDriveFreeSpace(destination) >= GetDriveFreeSpace(soucer))
                IsValid = "Espaço Indisponivel na unidade de destino é igual ou maior do que na unidade de origem.";

            return IsValid;
        }

        static long GetDriveFreeSpace(string driveLetter)
        {
            DriveInfo driveInfo = new DriveInfo(driveLetter);
            return driveInfo.AvailableFreeSpace / (1024 * 1024 * 1024);
        }
    }
}
