using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace CaptureOCR.Models
{
    internal class Image
    {
        public Region _screenRegion;
        public Bitmap _screenCapture;
        public string? DataOCR { get; set; }

        public Image(Region ScreenRegion)
        {
            _screenRegion = ScreenRegion;

            _screenCapture = new Bitmap(_screenRegion.Width, _screenRegion.Height);
   
            Graphics g = Graphics.FromImage(_screenCapture);

            g.CopyFromScreen(_screenRegion.Left, _screenRegion.Top, 0, 0, _screenCapture.Size);
        }
    }
}
