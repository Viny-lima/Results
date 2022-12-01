using Microsoft.EntityFrameworkCore;
using Results.Operations.Data.Entities;
using System.IO;
using Windows.Storage;

namespace Results.Operations.Data.Connection
{
    public class ResultsContext : DbContext
    {

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Exam> Exams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource={Path.Combine(ApplicationData.Current.LocalFolder.Path, "Database.db")}");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PatientExamKeys>()
                          .HasKey(p => new { p.ExamId, p.PatientId});           
                            

            base.OnModelCreating(modelBuilder);
        }
    }
}
