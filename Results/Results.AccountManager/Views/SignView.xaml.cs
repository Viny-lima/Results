using Autofac;
using Results.Operations.Core;
using Results.Operations.Data.Entities;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignView : Page
    {
        IPatientService patientService;

        public SignView()
        {
            this.InitializeComponent();
            patientService = App.sdk.Resolve<IPatientService>();
        }

        private async void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            var email = Email.Text;
            var password = Password.Text;

            var patient = await patientService.Login(email, password);

            if (patient != null)
            {
                ClearView();
                Alert.Visibility = Visibility.Collapsed;

                Frame.Navigate(typeof(CompletedView), patient);
            }
            else
            {
                ClearView();
                Alert.Visibility = Visibility.Visible;
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void ClearView()
        {
            Email.Text = String.Empty;
            Password.Text = String.Empty;
        }

    }
}
