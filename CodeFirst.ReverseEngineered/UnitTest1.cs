using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst.ReverseEngineered.Models;
using System.Linq;

namespace CodeFirst.ReverseEngineered
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInstructor()
        {
            using (var context = new SchoolContext())
            {
                Assert.IsInstanceOfType(context.People.Single(p => p.FirstName == "Fadi"), typeof(Instructor));
            }
        }

        [TestMethod]
        public void TestStudent()
        {
            using (var context = new SchoolContext())
            {
                Assert.IsInstanceOfType(context.People.Single(p => p.FirstName == "Peggy"), typeof(Student));
            }
        }
    }
}
