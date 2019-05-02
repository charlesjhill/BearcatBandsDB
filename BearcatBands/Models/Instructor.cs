using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearcatBands.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required, Display(Name = "Last Name"), StringLength(50)]
        public string LastName { get; set; }

        [Required, Column("FirstName"), Display(Name = "First Name"), StringLength(50)]
        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => LastName + ", " + FirstMidName;

        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public ICollection<EnsembleAssignment> EnsembleAssignments { get; set; }
    }
}
