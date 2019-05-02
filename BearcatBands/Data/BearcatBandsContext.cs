using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BearcatBands.Models
{
    public class BearcatBandsContext : DbContext
    {
        public BearcatBandsContext (DbContextOptions<BearcatBandsContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Ensemble> Ensembles { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<EnsembleAssignment> EnsembleAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
            modelBuilder.Entity<Ensemble>().ToTable("Ensembles");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");

            modelBuilder.Entity<EnsembleAssignment>().ToTable("EnsembleAssignments");
            // Specify EnsembleAssignment to use a *composite PK*
            modelBuilder.Entity<EnsembleAssignment>().HasKey(ensAsm => new { ensAsm.EnsembleID, ensAsm.InstructorID }); 
        }
    }
}
