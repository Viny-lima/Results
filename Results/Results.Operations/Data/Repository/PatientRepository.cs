using Results.Operations.Core;
using Results.Operations.Data.Entities;
using Results.Operations.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Results.Operations.Data.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IPatientDAO patientDAO;

        public PatientRepository(IPatientDAO patientDAO)
        {
            this.patientDAO = patientDAO;
        }

        public async Task<Patient> Add(Patient patient)
        {
            await patientDAO.Create(patient);
            var list = await patientDAO.ReadAll();
            var patientAdd = list.Last();
            return patientAdd;
        }

        public async Task Delete(Patient patient)
        {
            await patientDAO.Delete(patient);
        }        

        public async Task<IList<Patient>> FindAll()
        {
            return await patientDAO.ReadAll();
        }

        public async Task<Patient> FindById(int id)
        {
            try
            {
                return await patientDAO.Read(id);
            }
            catch
            {
                throw new ArgumentException($"patient of Id {id} does not exist or is negative !");
            }
        }

        public async Task Update(Patient patient)
        {
            await patientDAO.Update(patient);
        }

        public void Dispose()
        {
            patientDAO.Dispose();
        }
    }
}
