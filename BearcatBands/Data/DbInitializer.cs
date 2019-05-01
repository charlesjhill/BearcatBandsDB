using BearcatBands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearcatBands.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BearcatBandsContext context)
        {
            // context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return; // Don't do anything if the DB has data
            }

            // Populate with Students
            var students = new Student[]
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            // Add Ensembles
            var ensembles = new Ensemble[]
            {
                new Ensemble{EnsembleID=1050,Title="Marching Band",Credits=3},
                new Ensemble{EnsembleID=4022,Title="Jazz Band",Credits=3},
                new Ensemble{EnsembleID=4041,Title="Advanced Jazz Band",Credits=3},
                new Ensemble{EnsembleID=1045,Title="Concert Band",Credits=4},
                new Ensemble{EnsembleID=3141,Title="Advanced Concert Band",Credits=4},
                new Ensemble{EnsembleID=2021,Title="Percussion Ensemble",Credits=3},
                new Ensemble{EnsembleID=2042,Title="Winter Guard",Credits=4}
            };
            foreach (Ensemble e in ensembles)
            {
                context.Ensembles.Add(e);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,EnsembleID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,EnsembleID=4022,Grade=Grade.C},
                new Enrollment{StudentID=1,EnsembleID=4041,Grade=Grade.B},
                new Enrollment{StudentID=2,EnsembleID=1045,Grade=Grade.B},
                new Enrollment{StudentID=2,EnsembleID=3141,Grade=Grade.F},
                new Enrollment{StudentID=2,EnsembleID=2021,Grade=Grade.F},
                new Enrollment{StudentID=3,EnsembleID=1050},
                new Enrollment{StudentID=4,EnsembleID=1050},
                new Enrollment{StudentID=4,EnsembleID=4022,Grade=Grade.F},
                new Enrollment{StudentID=5,EnsembleID=4041,Grade=Grade.C},
                new Enrollment{StudentID=6,EnsembleID=1045},
                new Enrollment{StudentID=7,EnsembleID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }

    }
}
