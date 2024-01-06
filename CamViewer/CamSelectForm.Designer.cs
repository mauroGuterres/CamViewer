namespace CamViewer
{
    partial class CamSelectForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnModoVideo = new System.Windows.Forms.Button();
            this.btnModoAscii = new System.Windows.Forms.Button();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnModoVideo
            // 
            this.btnModoVideo.Location = new System.Drawing.Point(2, 66);
            this.btnModoVideo.Name = "btnModoVideo";
            this.btnModoVideo.Size = new System.Drawing.Size(183, 111);
            this.btnModoVideo.TabIndex = 1;
            this.btnModoVideo.Text = "Modo Vídeo";
            this.btnModoVideo.UseVisualStyleBackColor = true;
            this.btnModoVideo.Click += new System.EventHandler(this.btnModoVideo_Click);
            // 
            // btnModoAscii
            // 
            this.btnModoAscii.Location = new System.Drawing.Point(191, 66);
            this.btnModoAscii.Name = "btnModoAscii";
            this.btnModoAscii.Size = new System.Drawing.Size(193, 111);
            this.btnModoAscii.TabIndex = 2;
            this.btnModoAscii.Text = "Modo Ascii";
            this.btnModoAscii.UseVisualStyleBackColor = true;
            this.btnModoAscii.Click += new System.EventHandler(this.btnModoAscii_Click);
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(366, 21);
            this.comboBoxCameras.TabIndex = 3;
            this.comboBoxCameras.SelectedIndexChanged += new System.EventHandler(this.comboBoxCameras_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 189);
            this.Controls.Add(this.comboBoxCameras);
            this.Controls.Add(this.btnModoAscii);
            this.Controls.Add(this.btnModoVideo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModoVideo;
        private System.Windows.Forms.Button btnModoAscii;
        private System.Windows.Forms.ComboBox comboBoxCameras;
    }
}

