﻿using System;
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
        private List<SpaceObject> currentList;
        private SpaceObject parent;
        private int scale;

        public MainWindow()
        {
            InitializeComponent();

			Star sun = new Star("Sun", "Yellow", 1390000, 0, 0, (27 * 24), null);
			sun.position[0] = 0;
			sun.position[1] = 0;
            SolarSystem solar_system = new SolarSystem();
            this.solarSystem = solar_system.getSolarSystem();
            currentList = solarSystem;
            parent = sun;
            this.scale = 10000;
            //drawSolarSystem(solarSystem);


            this.Loaded += (s,o) => drawSolarSystem(solarSystem, sun);
            SizeChanged += (s, o) => drawSolarSystem(currentList, parent);

        }


        public void drawSolarSystem(List<SpaceObject> solar_system, SpaceObject center_planet)
        {
            ClearCanvasSpaceObj();


            //solar_system.Insert(0, sun);


            //TODO: DRAW all sub-objects in solar_system
            center_planet.position = new double[] { 0, 0 }; 

            double screenOffsetX = myCanvas.RenderSize.Width / 2;
            double screenOffsetY = myCanvas.RenderSize.Height / 2;
            //TODO: DRAW SUN:
            double[] screenPos1 = transformSpacePosToScreenPos(center_planet.position, screenOffsetX, screenOffsetY);

            drawText(center_planet, screenPos1);

            Ellipse ellipse1 = new Ellipse();
            SolidColorBrush solidColorBrush1 = new SolidColorBrush();
            solidColorBrush1.Color = Color.FromArgb(255, 255, 0, 1);
            ellipse1.Fill = solidColorBrush1;
            ellipse1.StrokeThickness = 2;
            ellipse1.Stroke = Brushes.Black;
            ellipse1.Width = center_planet.radius / scale;
            ellipse1.Height = center_planet.radius / scale;
            ellipse1.MouseUp += zoomInOnObject;
            Canvas.SetLeft(ellipse1, screenPos1[0] - (ellipse1.Width / 2));
            Canvas.SetTop(ellipse1, screenPos1[1] - (ellipse1.Height / 2));
            myCanvas.Children.Add(ellipse1);

            foreach (SpaceObject obj in solar_system) {

                obj.updatePosition(100, center_planet);
                
                //Getting information from obj
                //string type = obj.GetType().Name;

                //Transforming to screenSpacePositon
                double[] screenPos = transformSpacePosToScreenPos(obj.position, screenOffsetX, screenOffsetY);

                //Rendering information about object to screen


                drawText(obj, screenPos);

                Ellipse ellipse = new Ellipse();
                ellipse.Tag = obj.name;
                SolidColorBrush solidColorBrush = new SolidColorBrush();
                solidColorBrush.Color = Color.FromArgb(255, 255, 0, 1);
                ellipse.Fill = solidColorBrush;
                ellipse.StrokeThickness = 2;
                ellipse.Stroke = Brushes.Black;
                ellipse.Width = obj.radius / this.scale;
                ellipse.Height = obj.radius / this.scale;
                ellipse.MouseUp += zoomInOnObject;
                myCanvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, screenPos[0] - (ellipse.Width / 2));
                Canvas.SetTop(ellipse, screenPos[1] - (ellipse.Height / 2));
            }
        }

        private void drawText(SpaceObject obj, double[] screenPos)
        {
            if (ShowTextBool)
            {
                TextBox textBox = new TextBox();
                textBox.Text = obj.GetType().Name + ": " + obj.name;
                Panel.SetZIndex(textBox, 1);
                myCanvas.Children.Add(textBox);
                Canvas.SetLeft(textBox, screenPos[0]);
                Canvas.SetTop(textBox, screenPos[1]);
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

        private double[] transformSpacePosToScreenPos(double[] position, double sOX, double sOY)
        { 
            double[] screenPos = { sOX + position[0] / this.scale, sOY + position[1] / this.scale };
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
                        this.parent = current_object;
                        this.currentList = current_object.moonList;
                        this.scale = 500;
                        drawSolarSystem(currentList, parent);
                    }
                }
            }
        }
    }
}
