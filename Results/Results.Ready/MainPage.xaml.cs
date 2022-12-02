using Autofac;
using Results.Operations.Data.Entities;
using Results.Ready.ViewModel;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Results.Ready
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel;

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = App.sdk.Resolve<MainViewModel>();     
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var id = (int) e.Parameter;
            //Chamada App Servie ao Account Manager
        }
    }
}
