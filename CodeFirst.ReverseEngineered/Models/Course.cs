using System;
using System.Collections.Generic;

namespace CodeFirst.ReverseEngineered.Models
{
    public partial class Course
    {
        public Course()
        {
            this.StudentGrades = new List<StudentGrade>();
            //this.Instructors = new List<Instructor>();
        }

        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public virtual OnlineCourse OnlineCourse { get; set; }
        public virtual OnsiteCourse OnsiteCourse { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}
