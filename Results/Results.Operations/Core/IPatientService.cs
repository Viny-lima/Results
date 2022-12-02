using Results.Operations.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Results.Operations.Core
{
    public interface IPatientService : IService<Patient>
    {
        Task<Patient> Login(string email, string password);
    }
}
