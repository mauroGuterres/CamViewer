
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace CamViewer
{
    public partial class CamSelectForm : Form
    {

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private WebcamManager webcamManager;
        private bool asciiMode = false;
        private VideoPreviewForm previewForm;
        private string MonikerString;
        public CamSelectForm()
        {
            InitializeComponent();
            PopulateWebcamList();
            //InitializeWebcam();
        }

        private void InitializeWebcam()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
                throw new ApplicationException("No webcam found");

            //videoSource = new VideoCaptureDevice(videoDevices[1].MonikerString);
            webcamManager = new WebcamManager(MonikerString);
            webcamManager.OnFrameCaptured += ProcessFrame;
        }



        private Bitmap ResizeBitmap(Bitmap frame, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.DrawImage(frame, 0, 0, width, height);
            }
            return resized;
        }

        private Size CalculateResizedDimensions(Bitmap frame, int maxWidth, int maxHeight)
        {
            int originalWidth = frame.Width;
            int originalHeight = frame.Height;
            float ratio = Math.Min((float)maxWidth / originalWidth, (float)maxHeight / originalHeight);

            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            return new Size(newWidth, newHeight);
        }

        private string ConvertToAscii(Bitmap image)
        {
            int scaleFactor = 8; // Increased scale factor for greater reduction
            Bitmap resizedImage = ResizeBitmap(image, image.Width / scaleFactor, image.Height / scaleFactor);

            char[] asciiArt = new char[resizedImage.Width * resizedImage.Height + resizedImage.Height];
            int index = 0;
            for (int y = 0; y < resizedImage.Height; y++)
            {
                for (int x = 0; x < resizedImage.Width; x++)
                {
                    Color pixelColor = resizedImage.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    asciiArt[index++] = GetAsciiChar(grayValue);
                }
                asciiArt[index++] = '\n'; // New line at the end of each row
            }

            resizedImage.Dispose();
            return new string(asciiArt);
        }

        private char GetAsciiChar(int grayValue)
        {
            string asciiChars = "@%#*+=-:. ";
            int index = grayValue * (asciiChars.Length - 1) / 255;
            return asciiChars[index];
        }

        private void ProcessFrame(Bitmap frame)
        {
            try
            {
                if (asciiMode)
                {
                    string ascii = ConvertToAscii(frame);
                    previewForm?.UpdateAsciiArt(ascii);
                }
                else
                {
                    PictureBox pic = previewForm?.GetPictureBox();
                    Size newSize = CalculateResizedDimensions(frame, pic.Width, pic.Height);
                    Bitmap resizedFrame = ResizeBitmap(frame, newSize.Width, newSize.Height);

                    previewForm?.UpdateVideoFrame(resizedFrame);
                }

            }
            catch (Exception e)
            {
                webcamManager.Stop();
            }

        }

        private void btnModoVideo_Click(object sender, EventArgs e)
        {
            InitializeWebcam();
            asciiMode = false;
            previewForm = new VideoPreviewForm(asciiMode, webcamManager);
            previewForm.Show();
            webcamManager.Start();
        }

        private void PopulateWebcamList()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            comboBoxCameras.Items.Clear();

            foreach (FilterInfo device in videoDevices)
            {
                comboBoxCameras.Items.Add(device.Name);
            }

            if (comboBoxCameras.Items.Count > 0)
                comboBoxCameras.SelectedIndex = 0; // Select the first camera by default
        }


        private void btnModoAscii_Click(object sender, EventArgs e)
        {
            InitializeWebcam();
            asciiMode = true;
            previewForm = new VideoPreviewForm(asciiMode, webcamManager);
            previewForm.Show();
            webcamManager.Start();
        }


        private void comboBoxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count == 0)
                return;

            int selectedCameraIndex = comboBoxCameras.SelectedIndex;
            if (selectedCameraIndex < 0 || selectedCameraIndex >= videoDevices.Count)
                return;

            // Stop the current webcam
            //webcamManager?.Stop();

            // Start the new webcam
            this.MonikerString = videoDevices[selectedCameraIndex].MonikerString;
            /*webcamManager = new WebcamManager(monikerString);
            webcamManager.OnFrameCaptured += ProcessFrame;
            webcamManager.Start();*/


        }
    }
}
