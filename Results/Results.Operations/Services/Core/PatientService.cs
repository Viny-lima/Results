using Results.Operations.Core;
using Results.Operations.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Results.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository repository;

        public PatientService(IPatientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Patient> Login(string email, string password)
        {
            var patient = repository.FindAll().Result.ToList()
                                       .FirstOrDefault(p => p.Email == email && p.Password == password);

            return await Task.FromResult(patient);
        }

        public async Task<List<Patient>> FindAll()
        {
            var listAsync = repository.FindAll().Result.ToList();

            return await Task.FromResult(listAsync);
        }


        public Task<Patient> FindById(int id) => repository.FindById(id);

        public Task<Patient> Registered(Patient patient) => repository.Add(patient);

        public Task Update(Patient patient) => repository.Update(patient);

        public Task Delete(Patient patient) => repository.Delete(patient);

        public void Dispose() => repository.Dispose();

    }
}
