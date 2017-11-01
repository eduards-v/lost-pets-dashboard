
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace lost_pets_dashboard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
           

            this.InitializeComponent();
        }

    

        private void HamburgerButton_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            if (!Content_Panel.Children.Contains(defaultContent))
            {
                Content_Panel.Children.Clear();
                Content_Panel.Children.Add(defaultContent);// override object.Equals
            }


        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            //if (!Content_Panel.Children.Contains())
            //{

            //}
            Content_Panel.Children.Clear();

            Content_Panel.Children.Add(CreateContent(MenuButton2.Name));
        }

        private StackPanel CreateContent(string menu_opt)
        {
            StackPanel sp = new StackPanel();
            sp.HorizontalAlignment = HorizontalAlignment.Center;
            sp.VerticalAlignment = VerticalAlignment.Center;
            TextBlock textBlock = new TextBlock();
            textBlock.Text = string.Concat(menu_opt, " was selected!");
            textBlock.FontSize = 30;
            textBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.White);

            sp.Children.Add(textBlock);

            return sp;
        }
    }
}
