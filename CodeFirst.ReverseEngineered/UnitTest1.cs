﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst.ReverseEngineered.Models;
using System.Linq;
using System.Transactions;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading;

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

        /// <summary>
        /// LET OP! Dit is niet zo'n heel nuttige test.
        /// Het laat vooral zien hoe je de context kunt 
        /// mocken als je bijvoorbeeld bij MVC een Action
        /// op een Controller wilt testen zonder dat daarbij
        /// de database wordt benaderd.
        /// </summary>
        [TestMethod]
        public void TestMockingOpDbSet()
        {
            // Voorkomt het aanmaken van een vage database.
            Database.SetInitializer<SchoolContext>(null);

            var data = new List<Person>
            {
                new Instructor 
                {
                    PersonID = 12,
                    FirstName = "Pietje",
                    LastName = "Puk",
                    HireDate = DateTime.Today
                }
            }.AsQueryable();

            // Hiermee laat je de Linq-to-Objects provider gebruiken die op de Queryable implementatie zit van IList.
            var mockSet = new Mock<DbSet<Person>>();
            mockSet.As<IQueryable<Person>>()
                .Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Person>>()
                .Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Person>>()
                .Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Person>>()
                .Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<SchoolContext> { CallBase = true };
            mockContext
                .Setup(c => c.People)
                .Returns(mockSet.Object);
            
            // Nodig om geen database aan te hoeven maken (omdat de initializer al op null staat).
            mockContext.Object.Database.Initialize(false);

            Console.WriteLine(mockContext.Object.GetType());
            Console.WriteLine(mockContext.Object.GetType().BaseType);

            // Hier wordt een override op de base context gebruikt en moet de IDbSet dus virtual zijn
            foreach (var p in mockContext.Object.People)
            {
                Console.WriteLine("{0} {1}", p.FirstName, p.LastName);
            }

            // Maar als je toch al een setter hebt heb je helemaal geen mock context nodig.
            var context = new SchoolContext
            {
                People = mockSet.Object
            };
            foreach (var p in context.People)
            {
                Console.WriteLine("{0} {1}", p.FirstName, p.LastName);
            }

            // Test een delay
            mockContext.Setup(m => m.SaveChanges()).Callback(() => Thread.Sleep(50));
            mockContext.Object.SaveChanges();

            // Test een exception
            mockContext.Setup(m => m.SaveChanges()).Throws<DbUpdateConcurrencyException>();
            try
            {
                mockContext.Object.SaveChanges();
                Assert.Fail("Deze regel wordt alleen bereikt als er hierboven geen exception is opgetreden.");
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns((object[] o) => data.FirstOrDefault());
            var kim = mockContext.Object.People.Find(1);
            Assert.IsNotNull(kim);

            mockContext.Object.GetValidationErrors();

        }
    }
}
