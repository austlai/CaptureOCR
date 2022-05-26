using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CaptureOCR.ViewModels
{
    public class CaptureViewModel : ViewModelBase
    {
        public RegionViewModel MainViewModel { get; }
        public CaptureViewModel()
        {
            MainViewModel = new RegionViewModel();
        }
    }
}
