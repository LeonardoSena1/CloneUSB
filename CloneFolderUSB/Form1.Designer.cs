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
            this.SourceListBoxDrives = new System.Windows.Forms.ListBox();
            this.ButtonSendSelectedDriveSource = new System.Windows.Forms.Button();
            this.DestinationListBoxDrives = new System.Windows.Forms.ListBox();
            this.ButtonSendSelectedDriveDestination = new System.Windows.Forms.Button();
            this.ButtonRefreshDestination = new System.Windows.Forms.Button();
            this.ButtonRefreshSoucer = new System.Windows.Forms.Button();
            this.ButtonIniciar = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SourceListBoxDrives
            // 
            this.SourceListBoxDrives.FormattingEnabled = true;
            this.SourceListBoxDrives.ItemHeight = 15;
            this.SourceListBoxDrives.Location = new System.Drawing.Point(25, 63);
            this.SourceListBoxDrives.Name = "SourceListBoxDrives";
            this.SourceListBoxDrives.Size = new System.Drawing.Size(235, 124);
            this.SourceListBoxDrives.TabIndex = 0;
            // 
            // ButtonSendSelectedDriveSource
            // 
            this.ButtonSendSelectedDriveSource.Location = new System.Drawing.Point(25, 193);
            this.ButtonSendSelectedDriveSource.Name = "ButtonSendSelectedDriveSource";
            this.ButtonSendSelectedDriveSource.Size = new System.Drawing.Size(75, 23);
            this.ButtonSendSelectedDriveSource.TabIndex = 1;
            this.ButtonSendSelectedDriveSource.Text = "Selecionar";
            this.ButtonSendSelectedDriveSource.UseVisualStyleBackColor = true;
            // 
            // DestinationListBoxDrives
            // 
            this.DestinationListBoxDrives.FormattingEnabled = true;
            this.DestinationListBoxDrives.ItemHeight = 15;
            this.DestinationListBoxDrives.Location = new System.Drawing.Point(299, 63);
            this.DestinationListBoxDrives.Name = "DestinationListBoxDrives";
            this.DestinationListBoxDrives.Size = new System.Drawing.Size(235, 124);
            this.DestinationListBoxDrives.TabIndex = 3;
            // 
            // ButtonSendSelectedDriveDestination
            // 
            this.ButtonSendSelectedDriveDestination.Location = new System.Drawing.Point(299, 193);
            this.ButtonSendSelectedDriveDestination.Name = "ButtonSendSelectedDriveDestination";
            this.ButtonSendSelectedDriveDestination.Size = new System.Drawing.Size(75, 23);
            this.ButtonSendSelectedDriveDestination.TabIndex = 4;
            this.ButtonSendSelectedDriveDestination.Text = "Selecionar";
            this.ButtonSendSelectedDriveDestination.UseVisualStyleBackColor = true;
            // 
            // ButtonRefreshDestination
            // 
            this.ButtonRefreshDestination.Location = new System.Drawing.Point(380, 193);
            this.ButtonRefreshDestination.Name = "ButtonRefreshDestination";
            this.ButtonRefreshDestination.Size = new System.Drawing.Size(75, 23);
            this.ButtonRefreshDestination.TabIndex = 5;
            this.ButtonRefreshDestination.Text = "Atualizar";
            this.ButtonRefreshDestination.UseVisualStyleBackColor = true;
            // 
            // ButtonRefreshSoucer
            // 
            this.ButtonRefreshSoucer.Location = new System.Drawing.Point(106, 193);
            this.ButtonRefreshSoucer.Name = "ButtonRefreshSoucer";
            this.ButtonRefreshSoucer.Size = new System.Drawing.Size(75, 23);
            this.ButtonRefreshSoucer.TabIndex = 7;
            this.ButtonRefreshSoucer.Text = "Atualizar";
            this.ButtonRefreshSoucer.UseVisualStyleBackColor = true;
            // 
            // ButtonIniciar
            // 
            this.ButtonIniciar.Location = new System.Drawing.Point(25, 259);
            this.ButtonIniciar.Name = "ButtonIniciar";
            this.ButtonIniciar.Size = new System.Drawing.Size(75, 23);
            this.ButtonIniciar.TabIndex = 8;
            this.ButtonIniciar.Text = "Iniciar";
            this.ButtonIniciar.UseVisualStyleBackColor = true;
            this.ButtonIniciar.Click += new System.EventHandler(this.ClickIniciar);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(106, 250);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(428, 39);
            this.progressBar2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Clonar um USB para o outro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Concluído";
            this.label2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 346);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.ButtonIniciar);
            this.Controls.Add(this.ButtonRefreshSoucer);
            this.Controls.Add(this.ButtonRefreshDestination);
            this.Controls.Add(this.ButtonSendSelectedDriveDestination);
            this.Controls.Add(this.DestinationListBoxDrives);
            this.Controls.Add(this.ButtonSendSelectedDriveSource);
            this.Controls.Add(this.SourceListBoxDrives);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox SourceListBoxDrives;
        private ListBox DestinationListBoxDrives;
        private Button ButtonSendSelectedDriveSource;
        private Button ButtonSendSelectedDriveDestination;
        private Button ButtonRefreshDestination;
        private Button ButtonRefreshSoucer;
        private Button ButtonIniciar;
        private ProgressBar progressBar2;
        private Label label1;
        private Label label2;
    }
}