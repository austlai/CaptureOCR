using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Drawing.Imaging;

namespace CaptureOCR.Models
{
    internal class Capture
    {
        public Bitmap _screen;


        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }
        public int ScreenLeft { get; private set; }
        public int ScreenTop { get; private set; }
        public Capture()
        {

            ScreenWidth = Convert.ToInt32(SystemParameters.VirtualScreenWidth);
            ScreenHeight = Convert.ToInt32(SystemParameters.VirtualScreenHeight);
            ScreenLeft = Convert.ToInt32(SystemParameters.VirtualScreenLeft);
            ScreenTop = Convert.ToInt32(SystemParameters.VirtualScreenTop);

            _screen = new Bitmap(ScreenWidth, ScreenHeight);
        }

        public void GetScreen()
        {
            Graphics g = Graphics.FromImage(_screen);
                
            g.CopyFromScreen(ScreenLeft, ScreenTop, 0, 0, _screen.Size);
                
            _screen.Save("C:\\Users\\Vincent\\Desktop\\TestImage.jpg", ImageFormat.Png);
        }
    }
}

