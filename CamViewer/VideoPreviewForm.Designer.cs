namespace CamViewer
{
    partial class VideoPreviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoPreview = new System.Windows.Forms.PictureBox();
            this.asciiPreview = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.videoPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // videoPreview
            // 
            this.videoPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPreview.Location = new System.Drawing.Point(0, 0);
            this.videoPreview.Name = "videoPreview";
            this.videoPreview.Size = new System.Drawing.Size(431, 298);
            this.videoPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.videoPreview.TabIndex = 0;
            this.videoPreview.TabStop = false;
            // 
            // asciiPreview
            // 
            this.asciiPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asciiPreview.Location = new System.Drawing.Point(0, 0);
            this.asciiPreview.Name = "asciiPreview";
            this.asciiPreview.Size = new System.Drawing.Size(431, 298);
            this.asciiPreview.TabIndex = 1;
            this.asciiPreview.Text = "";
            this.asciiPreview.Visible = false;
            // 
            // VideoPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 298);
            this.Controls.Add(this.asciiPreview);
            this.Controls.Add(this.videoPreview);
            this.Name = "VideoPreviewForm";
            this.Text = "VideoPreviewForm";
            ((System.ComponentModel.ISupportInitialize)(this.videoPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox videoPreview;
        private System.Windows.Forms.RichTextBox asciiPreview;
    }
}