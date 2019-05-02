using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearcatBands.Models
{
    public class Ensemble
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EnsembleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<EnsembleAssignment> EnsembleAssignments { get; set; }
    }
}
