namespace BearcatBands.Models
{
    public class EnsembleAssignment
    {
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }

        public int EnsembleID { get; set; }
        public Ensemble Ensemble { get; set; }
    }
}
