using System.Management;
using System.Windows.Forms;

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
            SourcelistBoxDrives(null,null);

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
                            $"Volume Name: {logicalDisk["VolumeName"].ToString()}, " +
                            $"File System: {logicalDisk["FileSystem"].ToString()}, " +
                            $"Size: {FormatSize(Convert.ToUInt64(logicalDisk["Size"]))}, " +
                            $"Free Space: {FormatSize(Convert.ToUInt64(logicalDisk["freeSpace"]))}");

            ButtonSendSelectedDriveSource.Click += ClickSelectedDriveSource;
            ButtonRefreshSoucer.Click += RefreshCLickSoucer;
        }

        private void ClickSelectedDriveSource(object sender, EventArgs e)
        {
            string selectedDrive = SourceListBoxDrives.SelectedItems[0].ToString();

            DestinationListBoxDrives.Items.Remove(selectedDrive);
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
                            $"Volume Name: {logicalDisk["VolumeName"].ToString()}, " +
                            $"File System: {logicalDisk["FileSystem"].ToString()}, " +
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
            progressBar2_Click();
        }

        private void progressBar2_Click()
        {
            int maxValue = 100;

            for (int i = 0; i <= maxValue; i++)
            {
                progressBar2.Value = i;
                Thread.Sleep(50); 

                Application.DoEvents();
            }
        }
    }
}
