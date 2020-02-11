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

            this.Loaded += (s,o) => drawSolarSystem(solarSystem, sun);

        }


        public void drawSolarSystem(List<SpaceObject> solar_system, Star sun)
        {

            //TODO: DRAW SUN:

            //TODO: DRAW all sub-objects in solar_system

            double screenOffsetX = myCanvas.RenderSize.Width / 2;
            double screenOffsetY = myCanvas.RenderSize.Height / 2;
            foreach (SpaceObject obj in solar_system) {

                obj.updatePosition(100, sun);
                
                //Getting information from obj
                string type = obj.GetType().Name;

                //Transforming to screenSpacePositon
                double[] screenPos = transformSpacePosToScreenPos(obj.position, screenOffsetX, screenOffsetY);

                //Rendering information about object to screen
                TextBox textBox = new TextBox();
                textBox.Text = type + ": "+ obj.name;
                myCanvas.Children.Add(textBox);
                Canvas.SetLeft(textBox, screenPos[0]);
                Canvas.SetTop(textBox, screenPos[1]);
                Ellipse ellipse = new Ellipse();
                SolidColorBrush solidColorBrush = new SolidColorBrush();
                solidColorBrush.Color = Color.FromArgb(255, 255, 0, 1);
                ellipse.Fill = solidColorBrush;
                ellipse.StrokeThickness = 2;
                ellipse.Stroke = Brushes.Black;
                ellipse.Width = obj.radius / 10000;
                ellipse.Height = obj.radius / 10000;
                myCanvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, screenPos[0]);
                Canvas.SetTop(ellipse, screenPos[1]);


            }
        }

        private double[] transformSpacePosToScreenPos(double[] position, double sOX, double sOY)
        {
            double[] screenPos = { sOX + position[0] / 10000, sOY + position[1] / 10000 };
            return screenPos;
        }
    }
}
