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
using SpaceSim;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

			Star sun = new Star("Sun", "Yellow", 1390000, 0, 0, (27 * 24));
			sun.position[0] = 0;
			sun.position[1] = 0;
            SolarSystem solar_system = new SolarSystem(sun);
            List<SpaceObject> solarSystem = solar_system.getSolarSystem();
            //drawSolarSystem(solarSystem);

            this.Loaded += (s,o) => drawSolarSystem(solarSystem);

        }


        public void drawSolarSystem(List<SpaceObject> solar_system)
        {

            // Create a red Ellipse.
            Ellipse myEllipse = new Ellipse();

            // Create a SolidColorBrush with a red color to fill the 
            // Ellipse with.
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();

            // Describes the brush's color using RGB values. 
            // Each value has a range of 0-255.
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Black;

            // Set the width and height of the Ellipse.
            myEllipse.Width = 200;
            myEllipse.Height = 100;

            // Add the Ellipse to the StackPanel.

            double x = myCanvas.RenderSize.Width / 2 - myEllipse.Width / 2;
            double y = myCanvas.RenderSize.Height / 2;
            myCanvas.Children.Add(myEllipse);

            
            Canvas.SetLeft(myEllipse, x);

            
        }
    }
}
