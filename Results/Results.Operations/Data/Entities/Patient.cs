using System;
using System.Collections.Generic;
using System.Text;

namespace Results.Operations.Data.Entities
{
    public class Patient : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IList<PatientExamKeys> Exams { get; internal set; }

        public Patient()
        {
            this.Exams = new List<PatientExamKeys>();
        }

    }
}
