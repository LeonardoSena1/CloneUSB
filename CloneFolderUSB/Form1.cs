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

        private void listBoxDrives(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");

            foreach (ManagementObject disk in searcher.Get())
            {
                foreach (ManagementObject partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + disk["DeviceID"] + "'} WHERE AssocClass=Win32_DiskDriveToDiskPartition").Get())
                {
                    foreach (ManagementObject logicalDisk in new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass=Win32_LogicalDiskToPartition").Get())
                    {
                        checkedListBoxDrives.Items.Add($"Drive: {logicalDisk["DeviceID"].ToString()}, " +
                            $"Volume Name: {logicalDisk["VolumeName"].ToString()}, " +
                            $"File System: {logicalDisk["FileSystem"].ToString()}, " +
                            $"Size: {FormatSize(Convert.ToUInt64(logicalDisk["Size"]))}, " +
                            $"Free Space: {FormatSize(Convert.ToUInt64(logicalDisk["freeSpace"]))}");
                    }
                }
            }

            SendSelectedDrive.Click += ClickSelectedDrive;
            RefreshDriver.Click += RefreshAllDriver;
        }

        private void ClickSelectedDrive(object sender, EventArgs e)
        {
            // Iterar sobre os itens selecionados no CheckedListBox
            foreach (object selectedItem in checkedListBoxDrives.SelectedItems)
            {
                string selectedDrive = selectedItem.ToString();

                // Aqui você pode lidar com a lógica do evento para cada driver selecionado
                // Por exemplo, exibir uma mensagem ou executar alguma ação com o driver selecionado
                MessageBox.Show($"Driver selecionado: {selectedDrive}");
            }
        }

        private void RefreshAllDriver(object sender, EventArgs e)
        {
            checkedListBoxDrives.ClearSelected();
            checkedListBoxDrives.Items.Clear();

            this.listBoxDrives(null, null);
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

    }
}
