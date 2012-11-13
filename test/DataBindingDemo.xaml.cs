using System;
using System.Collections.Generic;
//using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataBindingDemo : Page
    {
        public DataBindingDemo()
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
            Thickness thick;
            thick.Top = 400;
            TextBlock txt = new TextBlock
            {
                Text = "Binding This Style in C#",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = thick,
                FontSize = 60,
                FontFamily = new FontFamily("Matura MT Script Capitals")
            };
            // Dynamically bind to an existed style.
            // 1. Setup the source.
            PropertyPath pPath = new PropertyPath("Foreground");
            Binding target = new Binding
            {
                ElementName = "topTxt",
                Path = pPath
            };
            // 2. Bind to the source. It is a DependencyObject, so you must use TextBlock.Foreground instead of Foreground.
            txt.SetBinding(TextBlock.ForegroundProperty, target);
            (this.Content as Grid).Children.Add(txt);
        }
    }
}
