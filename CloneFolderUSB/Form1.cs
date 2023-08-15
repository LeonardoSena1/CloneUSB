using CloneFolderUSB.Components;
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
            this.Icon = new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources\\Img\\usb-drive.ico"));
            this.DireitaEsquerda.Image =
                PreparationForm1.ResizeImage(Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources\\Img\\direita-e-esquerda.png")),
                DireitaEsquerda.Width, DireitaEsquerda.Height);

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
            ButtonSendSelectedDriveDestination.Click += ClickSelectedDriveDestination;
        }

        private void ClickSelectedDriveDestination(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SourceListBoxDrives.Text))
                MessageBox.Show("Selecione primeiro a origem");
            else if (string.IsNullOrEmpty(DestinationListBoxDrives.Text))
                MessageBox.Show("Selecione corretamente o destino");
            else
                ButtonIniciar.Enabled = true;
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
            DestinationListBoxDrives.ClearSelected();

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
                    IsShowButtons(false);

                    soucer = soucer.Split(':')[1].Trim() + ":";
                    destination = destination.Split(':')[1].Trim() + ":";

                    if (soucer.Equals(destination))
                        throw new Exception("Impossível clonar um dispositivo no mesmo dispositivo.");

                    if (PreparationForm1.CheckIfDiskExists(soucer) && PreparationForm1.CheckIfDiskExists(destination))
                    {
                        progressBar(IsValueMax: true, ValueMax: PreparationForm1.CountFilesInDirectory(soucer));
                        CopyFolder(soucer, destination);
                        progressBar(Final: true);
                        labelConcluid.Visible = true;
                    }
                    else
                        throw new Exception("Disk Local não encontrado");

                    IsShowButtons(true);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"Access denied: {ex.Message}");
                    IsShowButtons(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    IsShowButtons(true);
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

        private void IsShowButtons(bool Show)
        {
            ButtonSendSelectedDriveSource.Enabled = Show;
            ButtonSendSelectedDriveDestination.Enabled = Show;
            ButtonRefreshDestination.Enabled = Show;
            ButtonRefreshSoucer.Enabled = Show;
            ButtonIniciar.Enabled = Show;
        }
    }
}