using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirst.ReverseEngineered.Models
{
    public class Student : Person
    {
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
    }
}
