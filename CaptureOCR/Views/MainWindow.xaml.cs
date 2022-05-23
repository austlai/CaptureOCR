using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace CaptureOCR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Point startPoint;
        private Point movePoint;
        private Rectangle? rect;
        private bool rectSet;
        public MainWindow()
        {
            InitializeComponent();

            Width = SystemParameters.VirtualScreenWidth;
            Height = SystemParameters.VirtualScreenHeight;
            Left = SystemParameters.VirtualScreenLeft;
            Top = SystemParameters.VirtualScreenTop;
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rectSet == true)
            {
                return;
            }
            else
            {
                if (rect != null)
                    canvas.Children.Remove(rect);

                rect = new Rectangle
                {
                    Stroke = Brushes.LightBlue,
                    StrokeThickness = 2
                };
                Canvas.SetLeft(rect, startPoint.X);
                Canvas.SetTop(rect, startPoint.Y);
                canvas.Children.Add(rect);
                rectSet = false;
            }
        }

        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released || rect == null)
                return;
            if (e.LeftButton == MouseButtonState.Pressed && rectSet == true)
            {
                var pos = e.GetPosition(canvas);
                var x = Math.Min(pos.X, movePoint.X);
                var y = Math.Min(pos.Y, movePoint.Y);
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);

                
                movePoint = e.GetPosition(canvas);
            }
            else
            {
                startPoint = e.GetPosition(canvas);
                var pos = e.GetPosition(canvas);

                var x = Math.Min(pos.X, movePoint.X);
                var y = Math.Min(pos.Y, movePoint.Y);

                var w = Math.Max(pos.X, movePoint.X) - x;
                var h = Math.Max(pos.Y, movePoint.Y) - y;

                rect.Width = w;
                rect.Height = h;

                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rectSet = true;
            //rect = null;
        }
    }
}
