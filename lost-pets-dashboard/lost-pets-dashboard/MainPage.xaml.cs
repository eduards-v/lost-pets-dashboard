using Models;
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
        Dog dog;
        Cat cat;

        public MainPage()
        {
            Dog = new Dog("German Shepherd", "Max", "Best friend");
            Cat = new Cat( "Japanese Bobtail", "Murzik", "What is that tail?");

            this.InitializeComponent();
        }

        internal Dog Dog
        {
            get
            {
                return dog;
            }

            set
            {
                dog = value;
            }
        }

        internal Cat Cat
        {
            get
            {
                return cat;
            }

            set
            {
                cat = value;
            }
        }


    }
}
