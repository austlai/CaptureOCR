using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CaptureOCR.Models
{
    internal class Region
    {
        private int StartX { get; set; }
        private int StartY { get; set; }
        private int EndX { get; set; }
        private int EndY { get; set; }

        public Region(int startX, int startY, int endX, int endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }
    }
}
