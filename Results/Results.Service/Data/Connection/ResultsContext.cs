using Microsoft.EntityFrameworkCore;
using Results.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.Storage;

namespace ShoppingList.Data.Connection
{
    public class ResultsContext : DbContext
    {

        public DbSet<Patient> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource={Path.Combine(ApplicationData.Current.LocalFolder.Path, "Database.db")}");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Create Table
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");
                entity.HasKey(p => p.ID);
                entity.Property(p => p.Name);
                entity.Property(p => p.Email);
                entity.Property(p => p.Password);
                entity.Property(p => p.Exams);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
