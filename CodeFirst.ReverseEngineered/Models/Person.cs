using System;
using System.Collections.Generic;

namespace CodeFirst.ReverseEngineered.Models
{
    public abstract class Person
    {
        public Person()
        {
        }

        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public byte[] Timestamp { get; set; }
    }
}
