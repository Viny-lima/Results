using Results.Operations.Data.Entities;
using Results.Ready.ViewModel;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Results.Ready
{
    public sealed partial class MainPage : Page
    {

        public MainViewModel ViewModel;
        public IList<Exam> Exams { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
