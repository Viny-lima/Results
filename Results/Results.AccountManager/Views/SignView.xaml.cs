using Autofac;
using Results.Operations.Core;
using Results.Operations.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
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
        Patient patient;
        AppServiceConnection readyConnection;

        public SignView()
        {
            this.InitializeComponent();
            patientService = App.sdk.Resolve<IPatientService>();
        }

        private async void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            var email = Email.Text;
            var password = Password.Text;

            patient = await patientService.Login(email, password);

            if (patient != null) await OnSignIn();
        }

        private async Task OnSignIn()
        {
            //Initialize Connection
            if (readyConnection == null)
            {
                this.readyConnection= new AppServiceConnection();
                this.readyConnection.AppServiceName = "com.results.readyappservice";
                this.readyConnection.PackageFamilyName = Package.Current.Id.FamilyName;

                var status = await this.readyConnection.OpenAsync();

                if (status != AppServiceConnectionStatus.Success)
                {
                    Alert.Text = "Failed to connect";
                    Alert.Visibility = Visibility.Visible;
                    this.readyConnection = null;
                    return;
                }
            }

            //Call the Service
            var message = new ValueSet
            {
                { "Command", "Sign" },
                { "ID", patient.ID }
            };

            AppServiceResponse response = await this.readyConnection.SendMessageAsync(message);

            if (response.Status == AppServiceResponseStatus.Success)
            {
                ClearView();
                Alert.Visibility = Visibility.Collapsed;
                Frame.Navigate(typeof(CompletedView), patient);
            }
            else
            {
                ClearView();
                Alert.Text = "Failed to connect";
                Alert.Visibility = Visibility.Visible;
                patient = null;
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
