using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             
            double x, y;
            Random ran = new Random();
            for (x = -1000; x < 1000; x+=5)
            {
                y =  ran.Next(1,3) * Math.Tan(ran.Next(5, 10) * Math.Cos(x));
                ScdPg_PLine.Points.Add(new Point(683 + x, 384 + y));
            }
            Uri uri = new Uri("ms-appx:///Assets/thunder.jpg");         // "ms-appx:///" is needed!! 
            BitmapImage bitmap = new BitmapImage(uri);
            ImageBrush imgBrush = new ImageBrush
            {
                ImageSource = bitmap,
                Stretch = Windows.UI.Xaml.Media.Stretch.UniformToFill,
            };
            ScdPg_PLine.Stroke = imgBrush;
        }

        private void Page_DoubleTapped_1(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ThirdPage));
        }
    }
}
