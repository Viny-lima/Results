using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.PlatformUI;
using Results.Notifier.Events;
using Results.Operations.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Results.Ready.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        private int _patientId;
        public int PatientId
        {
            get { return _patientId; }
            set
            {
                SetProperty(ref _patientId, value);
            }
        }

        private string _menssage;
        public string Menssage
        {
            get { return _menssage; }
            set
            {
                SetProperty(ref _menssage, value);
            }
        }

        private bool _isSeeExams;
        public bool IsSeeExams
        {
            get { return _isSeeExams; }
            set
            {
                SetProperty(ref _isSeeExams, value);
            }
        }


        public HomeViewModel()
        {
            Menssage = "Execute Login in Results.AccountManager";
            NotifierResultEvent.SingEvent += OnSign;
        }

        private void OnSign(int id)
        {
            IsSeeExams = true;
            PatientId = id;
        }

    }
}
