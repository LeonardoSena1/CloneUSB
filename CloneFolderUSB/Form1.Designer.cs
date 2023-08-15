using System.Resources;

namespace CloneFolderUSB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private ResourceManager resourceManager;

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
            this.labelCLonarUsb = new System.Windows.Forms.Label();
            this.labelConcluid = new System.Windows.Forms.Label();
            this.labelOrigem = new System.Windows.Forms.Label();
            this.labelDestino = new System.Windows.Forms.Label();
            this.DireitaEsquerda = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DireitaEsquerda)).BeginInit();
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
            this.DestinationListBoxDrives.Location = new System.Drawing.Point(317, 63);
            this.DestinationListBoxDrives.Name = "DestinationListBoxDrives";
            this.DestinationListBoxDrives.Size = new System.Drawing.Size(235, 124);
            this.DestinationListBoxDrives.TabIndex = 3;
            // 
            // ButtonSendSelectedDriveDestination
            // 
            this.ButtonSendSelectedDriveDestination.Location = new System.Drawing.Point(317, 193);
            this.ButtonSendSelectedDriveDestination.Name = "ButtonSendSelectedDriveDestination";
            this.ButtonSendSelectedDriveDestination.Size = new System.Drawing.Size(75, 23);
            this.ButtonSendSelectedDriveDestination.TabIndex = 4;
            this.ButtonSendSelectedDriveDestination.Text = "Selecionar";
            this.ButtonSendSelectedDriveDestination.UseVisualStyleBackColor = true;
            // 
            // ButtonRefreshDestination
            // 
            this.ButtonRefreshDestination.Location = new System.Drawing.Point(398, 193);
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
            this.ButtonIniciar.Enabled= false;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(106, 250);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(446, 39);
            this.progressBar2.TabIndex = 9;
            // 
            // labelCLonarUsb
            // 
            this.labelCLonarUsb.AutoSize = true;
            this.labelCLonarUsb.BackColor = System.Drawing.Color.White;
            this.labelCLonarUsb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCLonarUsb.Location = new System.Drawing.Point(25, 18);
            this.labelCLonarUsb.Name = "labelCLonarUsb";
            this.labelCLonarUsb.Size = new System.Drawing.Size(157, 17);
            this.labelCLonarUsb.TabIndex = 10;
            this.labelCLonarUsb.Text = "Criar e gravar uma imagem de um drive usb";
            // 
            // labelConcluid
            // 
            this.labelConcluid.AutoSize = true;
            this.labelConcluid.Location = new System.Drawing.Point(280, 292);
            this.labelConcluid.Name = "labelConcluid";
            this.labelConcluid.Size = new System.Drawing.Size(62, 15);
            this.labelConcluid.TabIndex = 11;
            this.labelConcluid.Text = "Concluído";
            this.labelConcluid.Visible = false;
            // 
            // labelOrigem
            // 
            this.labelOrigem.AutoSize = true;
            this.labelOrigem.Location = new System.Drawing.Point(115, 45);
            this.labelOrigem.Name = "labelOrigem";
            this.labelOrigem.Size = new System.Drawing.Size(47, 15);
            this.labelOrigem.TabIndex = 12;
            this.labelOrigem.Text = "Origem";
            // 
            // labelDestino
            // 
            this.labelDestino.AutoSize = true;
            this.labelDestino.Location = new System.Drawing.Point(413, 45);
            this.labelDestino.Name = "labelDestino";
            this.labelDestino.Size = new System.Drawing.Size(47, 15);
            this.labelDestino.TabIndex = 13;
            this.labelDestino.Text = "Destino";
            // 
            // DireitaEsquerda
            // 
            this.DireitaEsquerda.Location = new System.Drawing.Point(270, 108);
            this.DireitaEsquerda.Name = "DireitaEsquerda";
            this.DireitaEsquerda.Size = new System.Drawing.Size(38, 39);
            this.DireitaEsquerda.TabIndex = 14;
            this.DireitaEsquerda.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 343);
            this.Controls.Add(this.DireitaEsquerda);
            this.Controls.Add(this.labelDestino);
            this.Controls.Add(this.labelOrigem);
            this.Controls.Add(this.labelConcluid);
            this.Controls.Add(this.labelCLonarUsb);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.ButtonIniciar);
            this.Controls.Add(this.ButtonRefreshSoucer);
            this.Controls.Add(this.ButtonRefreshDestination);
            this.Controls.Add(this.ButtonSendSelectedDriveDestination);
            this.Controls.Add(this.DestinationListBoxDrives);
            this.Controls.Add(this.ButtonSendSelectedDriveSource);
            this.Controls.Add(this.SourceListBoxDrives);
            this.Name = "Clone usb to usb";
            this.Text = "Copiar Pendrive";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DireitaEsquerda)).EndInit();
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
        private Label labelCLonarUsb;
        private Label labelConcluid;
        private Label labelOrigem;
        private Label labelDestino;
        private PictureBox DireitaEsquerda;
    }
}