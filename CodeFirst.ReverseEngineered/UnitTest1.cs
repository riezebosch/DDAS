using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst.ReverseEngineered.Models;
using System.Linq;
using System.Transactions;

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

        [TestMethod]
        public void UpdatePropertyViaDeChangeTracker()
        {
            using (new TransactionScope())
            using (var context = new SchoolContext())
            {
                context.Database.Log = Console.WriteLine;

                var kim = context.People.Find(1);
                Assert.AreEqual("Kim", kim.FirstName);

                context.Entry(kim).Property(p => p.FirstName).CurrentValue = "UPDATE";
                Assert.AreEqual("UPDATE", kim.FirstName);
                Assert.AreEqual("Kim", context.Entry(kim).Property(p => p.FirstName).OriginalValue);

                Assert.IsTrue(context.Entry(kim).Property(p => p.FirstName).IsModified);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void ShowSqlFromQuery()
        {
            using (var context = new SchoolContext())
            {
                var query = from p in context.People.OfType<Instructor>()
                            where p.FirstName == "Kim"
                            select p;

                Console.WriteLine(query);
            }
        }
    }
}
