using Autofac;
using Results.Operations.Core;
using Results.Operations.Data.Entities;
using Results.Service.Services;
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

namespace Results.AccountManager.Views
{
    public sealed partial class RegisterView : Page
    {
        IPatientService patientService;

        public RegisterView()
        {
            this.InitializeComponent();
            patientService =  App.sdk.Resolve<IPatientService>();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            var patient = new Patient()
            {
                Name = Name.Text,
                Email = Email.Text,
                Password = Password.Text
            };

            patientService.Registered(patient);      
            ClearView();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void ClearView()
        {
            Name.Text = String.Empty;
            Email.Text = String.Empty;
            Password.Text = String.Empty;
        }
    }
}
