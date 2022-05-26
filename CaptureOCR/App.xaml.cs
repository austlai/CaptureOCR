using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CaptureOCR.Models;
using CaptureOCR.ViewModels;
using System.Diagnostics;

namespace CaptureOCR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Capture startupImg = new();
            startupImg.GetScreen();

            MainWindow = new CaptureWindow()
            {
                DataContext = new CaptureViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);

        }
    }
}
