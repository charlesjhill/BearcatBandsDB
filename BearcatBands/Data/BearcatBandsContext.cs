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
    }
}
