using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamViewer
{
    public partial class VideoPreviewForm : Form
    {
        private bool asciiMode = false;
        private WebcamManager _webCamManager;
        public VideoPreviewForm()
        {
            InitializeComponent();
        }

        public VideoPreviewForm(bool asciiMode, WebcamManager webCamManager)
        {
            InitializeComponent();
            this.asciiMode = asciiMode;
            if (asciiMode)
            {
                asciiPreview.Visible = true;
                videoPreview.Visible = false;
            }
            else
            {
                asciiPreview.Visible = false;
                videoPreview.Visible = true;
            }
            asciiPreview.Font = new Font("Consolas", 2);
            _webCamManager = webCamManager;
        }

        public void UpdateVideoFrame(Bitmap frame)
        {
            if (videoPreview.InvokeRequired)
            {
                videoPreview.Invoke(new Action(() => videoPreview.Image = frame));
            }
            else
            {
                videoPreview.Image = frame;
            }
        }

        public void UpdateAsciiArt(string asciiArt)
        {
            if (asciiPreview.InvokeRequired)
            {
                asciiPreview.Invoke(new Action(() => asciiPreview.Text = asciiArt));
            }
            else
            {
                asciiPreview.Text = asciiArt;
            }
        }

        public PictureBox GetPictureBox()
        {
            return this.videoPreview;
        }


    }
}
