using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
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
            // Path Demonstration
            LineSegment lineSeg1 = new LineSegment();
            lineSeg1.Point = new Point(500, 500);
            LineSegment lineSeg2 = new LineSegment();
            lineSeg2.Point = new Point(0, 500);
            ArcSegment arcSeg = new ArcSegment();
            arcSeg.Point = new Point(0, 0);
            arcSeg.Size = new Size(250, 250);
            arcSeg.IsLargeArc = true;
            BezierSegment bzSeg = new BezierSegment();
            bzSeg.Point1 = new Point(125, 125);
            bzSeg.Point2 = new Point(375, 375);
            bzSeg.Point3 = new Point(500, 250);
            

// Add Segment to PathSegmentCollention
            PathSegmentCollection myPathSegCol1 = new PathSegmentCollection();
            myPathSegCol1.Add(lineSeg1);
            PathSegmentCollection myPathSegCol2 = new PathSegmentCollection();
            myPathSegCol2.Add(lineSeg2);
            PathSegmentCollection myPathSegCol3 = new PathSegmentCollection();
            myPathSegCol3.Add(arcSeg);
            PathSegmentCollection myPathSegCol4 = new PathSegmentCollection();
            myPathSegCol4.Add(bzSeg);

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
            PathFigure myPathFig3 = new PathFigure
            {
                StartPoint = new Point(0, -0.1),
                Segments = myPathSegCol3
            };
            PathFigure myPathFig4 = new PathFigure
            {
                StartPoint = new Point(0, 250),
                Segments = myPathSegCol4
            };

// Add Figures to Geometry
            PathGeometry myPathGeo1 = new PathGeometry();
            myPathGeo1.Figures.Add(myPathFig1);
            myPathGeo1.Figures.Add(myPathFig2);
            PathGeometry myPathGeo2 = new PathGeometry();
            myPathGeo2.Figures.Add(myPathFig3);
            PathGeometry myPathGeo3 = new PathGeometry();
            myPathGeo3.Figures.Add(myPathFig4);

// Add Geometry to Path
            Path myPath1 = new Path
            {
                Stroke = new SolidColorBrush(Colors.Cyan),
                StrokeThickness = 12,
                StrokeLineJoin = PenLineJoin.Round,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Data = myPathGeo1,
                Stretch = Stretch.Uniform
            };
            Path myPath2 = new Path
            {
                Stroke = new SolidColorBrush(Colors.Crimson),
                StrokeThickness = 12,
                StrokeLineJoin = PenLineJoin.Round,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Data = myPathGeo2,
                Stretch = Stretch.Uniform
            };
            Path myPath3 = new Path
            {
                Stroke = new SolidColorBrush(Colors.Crimson),
                StrokeThickness = 12,
                StrokeLineJoin = PenLineJoin.Round,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Data = myPathGeo3,
                Stretch = Stretch.Uniform
            };
// Another way, read from XAML.
            Path tempPath = XamlReader.Load("<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' Stroke='Blue' Data='M 0 0 Q 10 10 20 0'/>") as Path;
            Geometry geo = tempPath.Data;
            tempPath.Data = null;           // YOu can NOT use the data for another path before the original one is empty!!
            Path myPath4 = new Path
            {
                Stroke = new SolidColorBrush(Colors.Coral),
                StrokeThickness = 12,
                StrokeLineJoin = PenLineJoin.Round,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Uniform,
                Data = geo
            };
            
            ThirdPgGrid.Children.Add(myPath1);
            ThirdPgGrid.Children.Add(myPath2);
            ThirdPgGrid.Children.Add(myPath3);
            ThirdPgGrid.Children.Add(myPath4);
        }

        private void Page_DoubleTapped_1(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StyleDemo));
        }
    }
}
