﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

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

        [TestMethod]
        public void Lab1Exercise3_PrintAllCoursesWithStudentsAndGrades()
        {
            using (var context = new SchoolEntities())
            {
                foreach (var course in context.Courses)
                {
                    Console.WriteLine(course.Title);
                    foreach (var grade in course.StudentGrades)
                    {
                        if (grade.Student != null)
                        {
                            Console.WriteLine("  {0} {1}: {2}", grade.Student.FirstName, grade.Student.LastName, grade.Grade);
                        }
                        else
                        {
                            Console.WriteLine("Grade without a student: {0}, StudentId: {1}", grade.Grade, grade.StudentID);
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void Lab1Exercise4_UpdateInstructor()
        {
            using (var context = new SchoolEntities())
            {
                var p = context.People.Find(1);
                p.FirstName = "Kim" + DateTime.Now;

                context.SaveChanges();
                
            }
        }

        [TestMethod]
        public void StudentsAndInstructorsDerivedFromPerson()
        {
            using (var context = new SchoolEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                
                foreach (var p in context.
                    People)
                {
                    Console.WriteLine("{0} {1} - {2}", p.FirstName, p.LastName, p.GetType());
                }
            }
        }

        [TestMethod]
        public void OnSiteCourseAndOnlineCourseDerivedFromCourse()
        {
            using (var context = new SchoolEntities())
            {
                foreach (var course in context.Courses.OfType<OnlineCourse>())
                {
                }
            }
        }

        [TestMethod]
        public void OfficeAssignmentBijInstructor()
        {
            using (var context = new SchoolEntities())
            {
                foreach (var instructor in context.People.OfType<Instructor>())
                {
                    Console.WriteLine("{0} {1}: {2}", instructor.FirstName, instructor.LastName, instructor.Location);
                }
            }
        }
    }
}
