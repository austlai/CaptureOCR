using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaptureOCR.ViewModels
{
    public class RegionViewModel : ViewModelBase
    {
        private int _height;
        private int _width;
        private int _left;
        private int _top;
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }
        public int Left
        {
            get { return _left; }
            set
            {
                _left = value;
                OnPropertyChanged(nameof(Left));
            }
        }
        public int Top
        {
            get { return _top; }
            set
            {
                _top = value;
                OnPropertyChanged(nameof(Top));
            }
        }

        public ICommand SaveRegionCommand { get; }
        public RegionViewModel()
        {

        }
    }
}
