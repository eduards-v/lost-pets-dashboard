using lost_pets_dashboard.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace lost_pets_dashboard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage2 : Page
    {

        // Give a handle on Dashboard View Model. 
        // This way encapsulating details of what data to get from service
        // All the dashboard have to know is a caller class name to pick appropriate data
        // Page has to know only the types to display (Types from ViewModels package)

        internal DashboardVM InitDashboardView
        {
            get
            {
                // Get singleton instance and pass it a class name as string
                return DashboardVM.GetInstance(nameof(TestPage2));
            }
        }

        private DashboardVM DashboardView
        {
            get
            {
                return DashboardVM.Instance;
            }
        }

        public TestPage2()
        {
            this.InitializeComponent();
        }

        // Menu expand event
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TestPage1));
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            // leave empty, we  are on this page
        }
    }
}
