using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.PlatformUI;
using Results.Operations.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Results.Ready.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        private string _menssage;
        public string Menssage
        {
            get { return _menssage; }
            set
            {
                SetProperty(ref _menssage, value);
            }
        }

        private string _isSeeExams;
        public string IsSeeExams
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
        }

    }
}
