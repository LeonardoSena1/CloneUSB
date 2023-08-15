using System.Management;

namespace CloneFolderUSB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SourcelistBoxDrives(null, null);

            DestinationlistBoxDrives(null, null);
        }

        private void SourcelistBoxDrives(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");

            foreach (ManagementObject disk in searcher.Get())
                foreach (ManagementObject partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + disk["DeviceID"] + "'} WHERE AssocClass=Win32_DiskDriveToDiskPartition").Get())
                    foreach (ManagementObject logicalDisk in new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass=Win32_LogicalDiskToPartition").Get())
                        SourceListBoxDrives.Items.Add($"Drive: {logicalDisk["DeviceID"].ToString()}, " +
                            $"Size: {FormatSize(Convert.ToUInt64(logicalDisk["Size"]))}, " +
                            $"Free Space: {FormatSize(Convert.ToUInt64(logicalDisk["freeSpace"]))}");

            ButtonSendSelectedDriveSource.Click += ClickSelectedDriveSource;
            ButtonRefreshSoucer.Click += RefreshCLickSoucer;
        }

        private void ClickSelectedDriveSource(object sender, EventArgs e)
        {
            if (SourceListBoxDrives.SelectedItems.Count != 0)
                DestinationListBoxDrives.Items.Remove(SourceListBoxDrives.SelectedItems[0].ToString());
        }

        private string FormatSize(ulong bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            while (bytes >= 1024 && order < sizes.Length - 1)
            {
                order++;
                bytes /= 1024;
            }

            return $"{bytes:0.##} {sizes[order]}";
        }


        private void DestinationlistBoxDrives(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");

            foreach (ManagementObject disk in searcher.Get())
                foreach (ManagementObject partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + disk["DeviceID"] + "'} WHERE AssocClass=Win32_DiskDriveToDiskPartition").Get())
                    foreach (ManagementObject logicalDisk in new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass=Win32_LogicalDiskToPartition").Get())
                        DestinationListBoxDrives.Items.Add($"Drive: {logicalDisk["DeviceID"].ToString()}, " +
                            $"Size: {FormatSize(Convert.ToUInt64(logicalDisk["Size"]))}, " +
                            $"Free Space: {FormatSize(Convert.ToUInt64(logicalDisk["freeSpace"]))}");

            ButtonRefreshDestination.Click += RefreshCLickDestination;
        }

        private void ClickSelectedDriveDestination(object sender, EventArgs e)
        {

        }

        private void RefreshCLickDestination(object sender, EventArgs e)
        {
            DestinationListBoxDrives.Items.Clear();
            DestinationListBoxDrives.ClearSelected();
            SourceListBoxDrives.ClearSelected();

            this.DestinationlistBoxDrives(null, null);
        }

        private void RefreshCLickSoucer(object sender, EventArgs e)
        {
            SourceListBoxDrives.Items.Clear();
            SourceListBoxDrives.ClearSelected();

            this.SourcelistBoxDrives(null, null);
        }

        private void ClickIniciar(object sender, EventArgs e)
        {
            string soucer = SourceListBoxDrives.Text;
            string destination = DestinationListBoxDrives.Text;

            if (string.IsNullOrEmpty(soucer) || string.IsNullOrEmpty(destination))
                MessageBox.Show("Selecione a origem e o destino corretamente");
            else
            {
                try
                {
                    ButtonSendSelectedDriveSource.Enabled = false;
                    ButtonSendSelectedDriveDestination.Enabled = false;
                    ButtonRefreshDestination.Enabled = false;
                    ButtonRefreshSoucer.Enabled = false;
                    ButtonIniciar.Enabled = false;

                    soucer = soucer.Split(':')[1].Trim() + ":";
                    destination = destination.Split(':')[1].Trim() + ":";

                    if (CheckIfDiskExists(soucer) && CheckIfDiskExists(destination))
                    {
                        progressBar(IsValueMax: true, ValueMax: CountFilesInDirectory(soucer));
                        CopyFolder(soucer, destination);
                        progressBar(Final: true);
                        label2.Visible = true;
                    }
                    else
                        throw new Exception("Disk Local não encontrado");

                    ButtonSendSelectedDriveSource.Enabled = true;
                    ButtonSendSelectedDriveDestination.Enabled = true;
                    ButtonRefreshDestination.Enabled = true;
                    ButtonRefreshSoucer.Enabled = true;
                    ButtonIniciar.Enabled = true;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"Access denied: {ex.Message}");
                    ButtonSendSelectedDriveSource.Enabled = true;
                    ButtonSendSelectedDriveDestination.Enabled = true;
                    ButtonRefreshDestination.Enabled = true;
                    ButtonRefreshSoucer.Enabled = true;
                    ButtonIniciar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ButtonSendSelectedDriveSource.Enabled = true;
                    ButtonSendSelectedDriveDestination.Enabled = true;
                    ButtonRefreshDestination.Enabled = true;
                    ButtonRefreshSoucer.Enabled = true;
                    ButtonIniciar.Enabled = true;
                }
            }
        }

        private void progressBar(int i = 0, bool Final = false, bool IsValueMax = false, int ValueMax = 100)
        {
            if (IsValueMax)
                progressBar2.Maximum = ValueMax;

            progressBar2.Value = i;

            if (Final)
                progressBar2.Value = progressBar2.Maximum;

            Thread.Sleep(20);
            Application.DoEvents();
        }

        void CopyFolder(string sourcePath, string targetPath)
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

        static bool CheckIfDiskExists(string diskName)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
                if (string.Equals(drive.Name.Remove(2), diskName, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        static int CountFilesInDirectory(string directoryPath)
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
    }
}
