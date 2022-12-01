using Microsoft.EntityFrameworkCore;
using Results.Operations.Data.Connection;
using Results.Operations.Data.Entities;
using Results.Operations.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Results.Operations.Data.DAO
{
    public class PatientDAOEntity : IPatientDAO
    {
        private readonly ResultsContext _context;

        public PatientDAOEntity()
        {
            this._context = new ResultsContext();
            _context.Database.EnsureCreated();
        }

        public async Task Create(Patient patient)
        {
            await _context.Set<Patient>().AddAsync(patient);
            await _context.SaveChangesAsync();
        }        

        public async Task<Patient> Read(int id)
        {
            return await _context.Set<Patient>().FindAsync(id);
        }

        public async Task<List<Patient>> ReadAll()
        {
            return await _context.Set<Patient>().ToListAsync();
        }

        public async Task Update(Patient patient)
        {
            _context.Set<Patient>().Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Patient patient)
        {           
            _context.Set<Patient>().Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
