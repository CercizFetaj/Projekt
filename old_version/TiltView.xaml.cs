/*using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using System.Threading;
using System.IO;
using System.Windows.Input;
using System.Windows.Controls;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TiltView : Window
    {

        /// <summary>
        /// Define the Kinect Sensor Runtime
        /// </summary>

        KinectSensor kinectSensor = KinectSensor.KinectSensors[0];
      
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public TiltView()
        {
            InitializeComponent();
            kinectSensor.DepthStream.Enable();
            kinectSensor.ColorStream.Enable();
            kinectSensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(kinectSensor_AllFramesReady);
            kinectSensor.Start();
        }

        void kinectSensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            using (ColorImageFrame currentFrame = e.OpenColorImageFrame())
            {
                if (currentFrame != null)
                {
                    byte[] pixelData = new byte[currentFrame.PixelDataLength];
                    currentFrame.CopyPixelDataTo(pixelData);
                    BitmapSource bitMapSource = BitmapImage.Create(currentFrame.Width,
                        currentFrame.Height, 96, 96, PixelFormats.Bgr32, null,
                        pixelData, currentFrame.Width * currentFrame.BytesPerPixel);
                    this.streamingVideoImage.Source = bitMapSource;
                }
            }
        }
        private void downButton_Click(object sender, RoutedEventArgs e)
        {

            if (kinectSensor.ElevationAngle > kinectSensor.MinElevationAngle + 5)
            {
                kinectSensor.ElevationAngle = kinectSensor.ElevationAngle - 5;
               
                this.msg.Text = "Down: " + kinectSensor.ElevationAngle + "°";
            }
            XOutTheStreamingImage();
            Thread.Sleep(100);
        }
        private void XOutTheStreamingImage()
        {
            this.InvalidateVisual();
            BitmapImage xImage = new BitmapImage();

            this.streamingVideoImage.Source = xImage;
            this.InvalidateVisual();
        }
        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            kinectSensor.AllFramesReady -= new EventHandler<AllFramesReadyEventArgs>(kinectSensor_AllFramesReady);
            XOutTheStreamingImage();
            if (kinectSensor.ElevationAngle < kinectSensor.MaxElevationAngle - 5)
            {
                kinectSensor.ElevationAngle = kinectSensor.ElevationAngle + 5;
                //MessageBox.Show("Value" + kinectSensor.ElevationAngle);
                this.msg.Text = "Up: " + kinectSensor.ElevationAngle + "°";
            }
            Thread.Sleep(100);
            kinectSensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(kinectSensor_AllFramesReady);
        }

        private void middle_clickButton(object sender, RoutedEventArgs e)
        {
            //kinectSensor.AllFramesReady -= new EventHandler<AllFramesReadyEventArgs>(kinectSensor_AllFramesReady);

            XOutTheStreamingImage();

            if (kinectSensor.ElevationAngle.Equals(kinectSensor.ElevationAngle))
            {
                kinectSensor.ElevationAngle = (kinectSensor.MaxElevationAngle + kinectSensor.MinElevationAngle);
                //MessageBox.Show("Value" + kinectSensor.ElevationAngle);
                this.msg.Text = "Middle: " + kinectSensor.ElevationAngle + "°";
            }


            Thread.Sleep(100);

            //kinectSensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(kinectSensor_AllFramesReady);
        }
        public static void Windowshow()
        {

            TiltView viewer = new TiltView();
            viewer.Show();
            
        }
        private void write_on_win(String data)
        {

            try
            {
                int temp = int.Parse(data);
                XOutTheStreamingImage();
                if (temp <= kinectSensor.MinElevationAngle)
                {
                    temp = kinectSensor.MinElevationAngle;
                }
                if (temp >= kinectSensor.MaxElevationAngle)
                {
                    temp = kinectSensor.MaxElevationAngle;

                }

                kinectSensor.ElevationAngle = temp;


            }
            catch (Exception)
            {
                write_win.AppendText("Error!");
            }
        }
      

        private void okbutton_Click(object sender, RoutedEventArgs e)
        {
            

            write_on_win(write_win.Text);
            msg.Text = " Deegres: " + kinectSensor.ElevationAngle + "°";
            
        }
    }
        
    }*/

        
