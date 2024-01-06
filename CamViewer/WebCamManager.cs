using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamViewer
{
    public class WebcamManager
    {
        public delegate void FrameCapturedHandler(Bitmap frame);
        public event FrameCapturedHandler OnFrameCaptured;

        private VideoCaptureDevice videoSource;

        public WebcamManager(string monikerString)
        {
            videoSource = new VideoCaptureDevice(monikerString);
            videoSource.NewFrame += (sender, eventArgs) =>
            {
                Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
                OnFrameCaptured?.Invoke(frame);
            };
        }

        public void Start()
        {
            videoSource.Start();
        }

        public void Stop()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
        }
    }

}
