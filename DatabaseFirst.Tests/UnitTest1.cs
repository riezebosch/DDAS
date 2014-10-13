using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Linq.Expressions;

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
                // Overload wordt blijkbaar genegeerd door EF
                Expression<Func<Person, bool>> filter = 
                    p => p.FirstName.Equals("kim", StringComparison.Ordinal);

                foreach (var person in context.People.Where(filter))
                {
                    Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
                }
            }
        }
    }
}
