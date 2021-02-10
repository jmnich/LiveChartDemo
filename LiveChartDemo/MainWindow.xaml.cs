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
using LiveCharts;
using LiveCharts.Wpf;

namespace LiveChartDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            chart.LegendLocation = LegendLocation.Right;

            chart.Series.Add(new LineSeries
            {
                Title = "Węgiel",
                Values = new ChartValues<double> { 2, 3, 4, 5, 6, 7, 8},
                StrokeThickness = 4,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(20),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 69)),
                Fill = System.Windows.Media.Brushes.Transparent,
                LineSmoothness = 0,
                PointGeometry = null
            });
            
            chart.Series.Add(new LineSeries
            {
                Title = "Drewno",
                Values = new ChartValues<double> { 5, 3, 5, 7, 3, 9 },
                StrokeThickness = 2,
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(28, 142, 196)),
                Fill = System.Windows.Media.Brushes.Transparent,
                LineSmoothness = 1,
                PointGeometrySize = 15
            });

            chart.AxisX.Add(new Axis());
            chart.AxisY.Add(new Axis());
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            var data = chart.Series[0] as LineSeries;

            foreach (var p in data.ChartPoints)
            {
                var asPixels = chart.ConvertToPixels(p.AsPoint());
                Console.WriteLine($"Point {p.AsPoint()}   PIX {asPixels.X} {asPixels.Y}");


                Line line = new Line();
                line.Stroke = Brushes.Black;

                line.X1 = asPixels.X;
                line.X2 = asPixels.X; 
                line.Y1 = asPixels.Y - 0;
                line.Y2 = asPixels.Y + 10;
                line.StrokeThickness = 3;

                line.SnapsToDevicePixels = true;
                line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

                Canvas.Children.Add(line);
            }
        }
    }
}
