using Results.Domain.Entities;
using System;

namespace Results.Service.Data.Entities
{
    public class PatientExamKeys
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PatientExamKeys dB &&
                Exam.ID == dB.Exam.ID &&
                Patient.ID == dB.Patient.ID;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Exam.ID);

            return hash.ToHashCode();
        }
    }
}