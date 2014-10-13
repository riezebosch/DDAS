using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseFirst.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new SchoolEntities())
            {
                foreach (var person in context.People)
                {
                    Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
                }
            }
        }
    }
}
