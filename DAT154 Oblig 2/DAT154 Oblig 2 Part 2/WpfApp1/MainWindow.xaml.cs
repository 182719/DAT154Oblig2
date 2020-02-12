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
        private bool ShowTextBool;
        private List<SpaceObject> solarSystem;
        public MainWindow()
        {
            InitializeComponent();

			Star sun = new Star("Sun", "Yellow", 1390000, 0, 0, (27 * 24), null);
			sun.position[0] = 0;
			sun.position[1] = 0;
            SolarSystem solar_system = new SolarSystem();
            this.solarSystem = solar_system.getSolarSystem();
            //drawSolarSystem(solarSystem);

            this.Loaded += (s,o) => drawSolarSystem(solarSystem, sun, 10000);
            SizeChanged += (s, o) => drawSolarSystem(solarSystem, sun, 10000);

        }


        public void drawSolarSystem(List<SpaceObject> solar_system, SpaceObject sun, int scale)
        {
            ClearCanvasSpaceObj();


            //solar_system.Insert(0, sun);


            //TODO: DRAW all sub-objects in solar_system

            double screenOffsetX = myCanvas.RenderSize.Width / 2;
            double screenOffsetY = myCanvas.RenderSize.Height / 2;
            //TODO: DRAW SUN:
            double[] screenPos1 = transformSpacePosToScreenPos(sun.position, screenOffsetX, screenOffsetY, scale);

            Ellipse ellipse1 = new Ellipse();
            SolidColorBrush solidColorBrush1 = new SolidColorBrush();
            solidColorBrush1.Color = Color.FromArgb(255, 255, 0, 1);
            ellipse1.Fill = solidColorBrush1;
            ellipse1.StrokeThickness = 2;
            ellipse1.Stroke = Brushes.Black;
            ellipse1.Width = sun.radius / scale;
            ellipse1.Height = sun.radius / scale;
            ellipse1.MouseUp += zoomInOnObject;
            Canvas.SetLeft(ellipse1, screenPos1[0] - (ellipse1.Width / 2));
            Canvas.SetTop(ellipse1, screenPos1[1] - (ellipse1.Height / 2));
            myCanvas.Children.Add(ellipse1);

            foreach (SpaceObject obj in solar_system) {

                obj.updatePosition(100, sun);
                
                //Getting information from obj
                string type = obj.GetType().Name;

                //Transforming to screenSpacePositon
                double[] screenPos = transformSpacePosToScreenPos(obj.position, screenOffsetX, screenOffsetY, scale);

                //Rendering information about object to screen

                if(ShowTextBool)
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = type + ": "+ obj.name;
                    myCanvas.Children.Add(textBox);
                    Canvas.SetLeft(textBox, screenPos[0]);
                    Canvas.SetTop(textBox, screenPos[1]);
                }

                Ellipse ellipse = new Ellipse();
                ellipse.Tag = obj.name;
                SolidColorBrush solidColorBrush = new SolidColorBrush();
                solidColorBrush.Color = Color.FromArgb(255, 255, 0, 1);
                ellipse.Fill = solidColorBrush;
                ellipse.StrokeThickness = 2;
                ellipse.Stroke = Brushes.Black;
                ellipse.Width = obj.radius / scale;
                ellipse.Height = obj.radius / scale;
                ellipse.MouseUp += zoomInOnObject;
                myCanvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, screenPos[0] - (ellipse.Width / 2));
                Canvas.SetTop(ellipse, screenPos[1] - (ellipse.Height / 2));
            }
        }

        private void ClearCanvasSpaceObj()
        {
            for (int i = myCanvas.Children.Count - 1; i >= 0; i += -1)
            {
                UIElement Child = myCanvas.Children[i];
                if (Child is TextBox || Child is Ellipse)
                    myCanvas.Children.Remove(Child);
            }
        }

        private double[] transformSpacePosToScreenPos(double[] position, double sOX, double sOY, int scale)
        { 
            double[] screenPos = { sOX + position[0] / scale, sOY + position[1] / scale };
            return screenPos;
        }
        private void HandleTextCheck(object sender, RoutedEventArgs e)
        {
            ShowTextBool = true;
        }

        private void HandleTextUnchecked(object sender, RoutedEventArgs e)
        {
            ShowTextBool = false;
        }


        void zoomInOnObject(object sender, RoutedEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                SpaceObject current_object = null;
                foreach(SpaceObject so in solarSystem)
                {
                    if(so.name == (String)ellipse.Tag)
                    {
                        current_object = so;
                    }
                }

                if (current_object != null)
                {
                    if (current_object.moonList != null)
                    {
                        myCanvas.Children.Clear();
                        //current_object.moonList.Insert(0, current_object);
                        drawSolarSystem(current_object.moonList, current_object, 20);
                    }
                }
            }
        }
    }
}
