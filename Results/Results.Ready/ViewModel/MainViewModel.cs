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
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<Exam> ListExams;

        public MainViewModel()
        {
            ListExams = new ObservableCollection<Exam>()
            {
                new Exam()
                {
                    Name = "Hello",
                    Description = "World",
                    Data = DateTime.Now
                },
                new Exam()
                {
                    Name = "Hello",
                    Description = "World",
                    Data = DateTime.Now
                },
                new Exam()
                {
                    Name = "Hello",
                    Description = "World",
                    Data = DateTime.Now
                }
            };            
        }
        public void LoadListExams()
        {
            var listDatabase = new List<Exam>();

            ListExams.Clear();

            foreach (var item in listDatabase)
            {
                ListExams.Add(item);
            }
        }
    }
}
