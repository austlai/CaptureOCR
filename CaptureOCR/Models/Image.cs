using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CaptureOCR.Models
{
    internal class Image
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public string? DataOCR { get; set; }
    }
}
