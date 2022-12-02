using Autofac;
using Results.Ready.ViewModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Results.Ready
{
    public sealed partial class Home : Page
    {
        public HomeViewModel ViewModel;

        public Home()
        {
            this.InitializeComponent();
            ViewModel = App.sdk.Resolve<HomeViewModel>();
        }

        private void SeeExams_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), ViewModel.PatientId);
        }
    }
}
