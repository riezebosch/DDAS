using CodeFirst.ReverseEngineered.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Mvc.Models
{
    public class InstructorConcurrencyResolve
    {
        public Instructor Current { get; set; }
        public Instructor Database { get; set; }
    }
}