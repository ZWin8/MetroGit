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
    public sealed partial class ThirdPage : Page
    {
        public ThirdPage()
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

            LineSegment lineSeg1 = new LineSegment();
            lineSeg1.Point = new Point(500, 500);
            LineSegment lineSeg2 = new LineSegment();
            lineSeg2.Point = new Point(0, 500);


// Add Segment to PathSegmentCollention
            PathSegmentCollection myPathSegCol1 = new PathSegmentCollection();
            myPathSegCol1.Add(lineSeg1);
            PathSegmentCollection myPathSegCol2 = new PathSegmentCollection();
            myPathSegCol2.Add(lineSeg2);

// Add Segment Collection to Figure
            PathFigure myPathFig1 = new PathFigure
            {
                StartPoint = new Point(0, 0),
                Segments = myPathSegCol1
            };
            PathFigure myPathFig2 = new PathFigure
            {
                StartPoint = new Point(500, 0),
                Segments = myPathSegCol2
            };

// Add Figures to Geometry
            PathGeometry myPathGeo = new PathGeometry();
            myPathGeo.Figures.Add(myPathFig1);
            myPathGeo.Figures.Add(myPathFig2);

// Add Geometry to Path
            Path myPath = new Path
            {
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 12,
                StrokeLineJoin = PenLineJoin.Round,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Data = myPathGeo
            };
            

            ThirdPgGrid.Children.Add(myPath);
        }
    }
}
