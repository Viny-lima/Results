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
    public sealed partial class RegisterExamas : Page
    {
        IPatientService patientService;
        public Patient Patient { get; set; }
        public Exam Exam { get; set; }

        public RegisterExamas()
        {
            this.InitializeComponent();
            patientService = App.sdk.Resolve<IPatientService>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Patient = (Patient)e.Parameter;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {

            Exam = new Exam() 
            { 
                Name = Name.Text,
                Description= Description.Text,
                Data = DateTime.Now,
            };

            var relation = new PatientExamKeys()
            {
                Patient = this.Patient,
                PatientId = Patient.ID,
                Exam = this.Exam,
                ExamId = Exam.ID,
            };

            this.Patient.Exams.Add(relation);
            patientService.Update(Patient);

            ClearView();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void ClearView()
        {
            Exam = new Exam() { Data = DateTime.Now };
            Name.Text = String.Empty;
            Description.Text = String.Empty;
        }

    }
}
