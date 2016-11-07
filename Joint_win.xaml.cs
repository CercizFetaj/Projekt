
using System.Windows;

using Microsoft.Kinect;
using System.Windows.Controls;
using System;


using System.Windows.Media;
using System.Windows.Media.Imaging;

using System.Threading;


namespace Microsoft.Samples.Kinect.SkeletonBasics
{

    /// <summary>
    /// Interaction logic for Joint_win.xaml
    /// </summary>

    
    public partial class Joint_win : Window

    {
        KinectSensor kinectSensor = KinectSensor.KinectSensors[0];
        static Joint_win view = new Joint_win();
        public Joint_win()
        {
            InitializeComponent();
            kinectSensor.DepthStream.Enable();
            kinectSensor.ColorStream.Enable();
            kinectSensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(kinectSensor_AllFramesReady);
            kinectSensor.Start();
            
        }
        public static void show_on_win()
        {
            view.Show();
            
            

        }
        public static void close_win()
        {

            view.Close();  


        }
        private void Scroller_Scroll(object sender, EventArgs e)
        {
            ScrollViewer viewer = new ScrollViewer();
            viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        }

        private void Viewbutton_Click(object sender, RoutedEventArgs e)
        {
            textbox1.AppendText(SkeletonOutput.jointToString(SkeletonConstants.tracker.getLastSkeleton().Joints[JointType.Spine], (int)JointType.Spine) +"\n");
            textbox1.AppendText(SkeletonConstants.tracker.getLastCoordinate(JointType.Spine, SkeletonConstants.Coordinate.Z) + "\n");
        }

        /// <summary>
        /// Define the Kinect Sensor Runtime
        /// </summary>

        

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
       
           
        

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

}

        

    



