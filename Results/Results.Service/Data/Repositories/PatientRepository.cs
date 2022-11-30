using Results.Domain.Entities;
using Results.Domain.Interfaces;
using ShoppingList.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Data.Repositories
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

        public async Task Delete(Patient product)
        {
            await patientDAO.Delete(product);
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
