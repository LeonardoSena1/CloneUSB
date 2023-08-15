namespace CloneFolderUSB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBoxDrives = new System.Windows.Forms.ListBox();
            this.SendSelectedDrive = new System.Windows.Forms.Button();
            this.RefreshDriver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxDrives
            // 
            this.checkedListBoxDrives.FormattingEnabled = true;
            this.checkedListBoxDrives.ItemHeight = 15;
            this.checkedListBoxDrives.Location = new System.Drawing.Point(25, 30);
            this.checkedListBoxDrives.Name = "checkedListBoxDrives";
            this.checkedListBoxDrives.Size = new System.Drawing.Size(543, 124);
            this.checkedListBoxDrives.TabIndex = 0;
            this.Load += new System.EventHandler(this.listBoxDrives);
            // 
            // SendSelectedDrive
            // 
            this.SendSelectedDrive.Location = new System.Drawing.Point(25, 160);
            this.SendSelectedDrive.Name = "SendSelectedDrive";
            this.SendSelectedDrive.Size = new System.Drawing.Size(75, 23);
            this.SendSelectedDrive.TabIndex = 1;
            this.SendSelectedDrive.Text = "Selecionar";
            this.SendSelectedDrive.UseVisualStyleBackColor = true;
            // 
            // RefreshDriver
            // 
            this.RefreshDriver.Location = new System.Drawing.Point(465, 160);
            this.RefreshDriver.Name = "RefreshDriver";
            this.RefreshDriver.Size = new System.Drawing.Size(103, 23);
            this.RefreshDriver.TabIndex = 2;
            this.RefreshDriver.Text = "Atualizar Drivers";
            this.RefreshDriver.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.RefreshDriver);
            this.Controls.Add(this.SendSelectedDrive);
            this.Controls.Add(this.checkedListBoxDrives);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox checkedListBoxDrives;
        private Button SendSelectedDrive;
        private Button RefreshDriver;
    }
}