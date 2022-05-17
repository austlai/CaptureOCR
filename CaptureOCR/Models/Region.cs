using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace CaptureOCR.Models
{
    internal class Region
    {
        private int _width;
        private int _height;
        private int _top;
        private int _left;

        // Should throw expections for invalid Width/Height/Top/Left
        public int Width 
        { 
            get { return _width; }
            set
            {
                if (value <= 0 || value > SystemParameters.VirtualScreenWidth)
                {
                    _width = value;
                }
                else
                {
                    _width = -1;
                }
            }
        }
        public int Height
        { 
            get { return _height; } 
            set
            {
                if (value <= 0 || value > SystemParameters.VirtualScreenHeight)
                {
                    _height = value;
                }
                else
                {
                    _height= -1;
                }
            }
        }
        public int Top
        {
            get { return _top; }
            set
            {
                if (value <= 0 || value > SystemParameters.VirtualScreenTop)
                {
                    _top = value;
                }
                else
                {
                    _top = -1;
                }
            }
        }
        public int Left
        {
            get { return _left; }
            set
            {
                if (value <= 0 || value > SystemParameters.VirtualScreenLeft)
                {
                    _left = value;
                }
                else
                {
                    _left = -1;
                }
            }
        }

        public Region(int width, int height, int top, int left)
        {
            //width = StartX < EndX ? EndX - StartX : StartX - EndX;
            //height = StartY < EndY ? EndY - StartY : StartY - EndY;
            Width = width;
            Height = height;
            Top = top;
            Left = left;
        }
    }
}
