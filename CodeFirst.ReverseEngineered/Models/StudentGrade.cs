using System;
using System.Collections.Generic;

namespace CodeFirst.ReverseEngineered.Models
{
    public partial class StudentGrade
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public virtual int StudentID { get; set; }
        public Nullable<decimal> Grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
