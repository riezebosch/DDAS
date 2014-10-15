using System;
using System.Collections.Generic;

namespace CodeFirst.ReverseEngineered.Models
{
    public abstract class Person
    {
        public Person()
        {
            this.StudentGrades = new List<StudentGrade>();
            this.Courses = new List<Course>();
        }

        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public byte[] Timestamp { get; set; }
    }
}
