using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearcatBands.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public Grade? Grade { get; set; }

        public int EnsembleID { get; set; }
        public Ensemble Ensemble { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
