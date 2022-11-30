﻿using Microsoft.EntityFrameworkCore;
using Results.Domain.Entities;
using ShoppingList.Data.Connection;
using ShoppingList.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Data.DAO
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
