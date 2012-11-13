using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class StyleDemo : Page
    {
        public StyleDemo()
        {
            Style style2 = new Style(typeof(TextBlock));
            style2.Setters.Add(new Setter(TextBlock.FontFamilyProperty,new FontFamily("Chiller")));
            style2.Setters.Add(new Setter(TextBlock.FontSizeProperty, 50));
            style2.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Bottom));
            style2.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center));

            Style fromStyle2 = new Style(typeof(TextBlock));
            fromStyle2.BasedOn = style2;
            fromStyle2.Setters.Add(new Setter(TextBlock.MarginProperty,"0 0 0 100"));

            this.Resources.Add("MyTxtStyle2", style2);
            this.Resources.Add("FromMyTxtStyle2", fromStyle2);
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Style created in XAML
            TextBlock txt = new TextBlock
            {
                Style = App.Current.Resources["MyTxtStyle"] as Style,
                Text = "XAML style resources applied.",
                FontFamily  = new FontFamily("Lucida Calligraphy")  // Notice this line override the style in MyTxtStyle.
            };

            // Style created in C#
            TextBlock txt2 = new TextBlock
            {
                Style = this.Resources["MyTxtStyle2"] as Style,
                Text = "Code generated style resources applied."
            };

            // Style created in C# derived from another style
            TextBlock txt3 = new TextBlock
            {
                Style = this.Resources["FromMyTxtStyle2"] as Style,
                Text = "Code generated derived style resources applied."
            };

            (this.Content as Grid).Children.Add(txt);
            (this.Content as Grid).Children.Add(txt2);
            (this.Content as Grid).Children.Add(txt3);
        }

        private void Page_DoubleTapped_1(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DataBindingDemo));
        }
    }
}
