using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace CaptureOCR.Models
{
    public class Region
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }

        public Region(int width, int height, int top, int left)
        {
            Width = width;
            Height = height;
            Top = top;
            Left = left;
        }
    }
}
