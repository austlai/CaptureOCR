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
    public partial class CaptureWindow : Window
    {
        private Point startPoint;
        private Rectangle rect;
        private bool rectSet;
        public CaptureWindow()
        {
            InitializeComponent();
            /*ImageBrush ib = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"C:\Users\Vincent\Desktop\TestImage.jpg", UriKind.Relative))
            };
            canvas.Background = ib;*/
            rect = (Rectangle)canvas.Children[0];
            Width = SystemParameters.VirtualScreenWidth;
            Height = SystemParameters.VirtualScreenHeight;
            Left = SystemParameters.VirtualScreenLeft;
            Top = SystemParameters.VirtualScreenTop;
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rectSet == true && Mouse.DirectlyOver == rect)
            {
                startPoint = e.GetPosition(canvas);
                return;
            }
            else
            {
                if (rect != null)
                    canvas.Children.Remove(rect);

                startPoint = e.GetPosition(canvas);

                rect.Stroke = Brushes.LightBlue;
                rect.StrokeThickness = 2;
                rect.Fill = new SolidColorBrush(Color.FromArgb(0, 255, 0, 132));

                Canvas.SetLeft(rect, startPoint.X);
                Canvas.SetTop(rect, startPoint.Y);
                canvas.Children.Add(rect);
                rectSet = false;
            }
        }

        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
                return;
            if (e.LeftButton == MouseButtonState.Pressed && rectSet == true && Mouse.DirectlyOver == rect)
            {
                Rectangle ding = (Rectangle)Mouse.DirectlyOver;
                ding.StrokeThickness = 20;
                var mp = e.GetPosition(canvas);
                double deltaX = mp.X - startPoint.X;
                double deltaY = mp.Y - startPoint.Y;

                var newX = deltaX + Canvas.GetLeft(rect);
                var newY = deltaY + Canvas.GetTop(rect);

                if (newX < 0)
                    newX = 0;
                else if (newX + rect.ActualWidth > canvas.ActualWidth)
                    newX = canvas.ActualWidth - rect.ActualWidth;

                if (newY < 0)
                    newY = 0;
                else if (newY + rect.ActualHeight > canvas.ActualHeight)
                    newY = canvas.ActualHeight - rect.ActualHeight;

                Canvas.SetLeft(rect, newX);
                Canvas.SetTop(rect, newY);
                startPoint = e.GetPosition(canvas);
            }
            else
            {
                var pos = e.GetPosition(canvas);

                var x = Math.Min(pos.X, startPoint.X);
                var y = Math.Min(pos.Y, startPoint.Y);

                var w = Math.Max(pos.X, startPoint.X) - x;
                var h = Math.Max(pos.Y, startPoint.Y) - y;

                rect.Width = w;
                rect.Height = h;

                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rectSet = true;
        }
    }
}
