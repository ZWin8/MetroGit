using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.Resources.Add("MyFont", new FontFamily("Times New Roman"));
            this.InitializeComponent();
            // Loading static resources. LineraGradientBrush is loaded after InitializeComponets so it has to refer to App.
            LinearGradientBrush LGBrush = App.Current.Resources["MyBrush2"] as LinearGradientBrush;
            TextBlock txt = new TextBlock
            {
                Text = "You left",
                FontFamily = this.Resources["MyFont"] as FontFamily, // Resources is added PRIOR to InitializeComponent.
                FontSize = 60,
                Foreground = LGBrush,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            MainGrid.Children.Add(txt);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void MainGrid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondPage));
        }
    }
}
