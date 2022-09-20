//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Infrastructure.MappingViews;

[assembly: DbMappingViewCacheTypeAttribute(
    typeof(CodeFirst.ReverseEngineered.Models.SchoolContext),
    typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySetseb0230ca609faa820ab1c6a117295d9540df1bdb3d95e9a4597e4bc1865c538b))]

namespace Edm_EntityMappingGeneratedViews
{
    using System;
    using System.CodeDom.Compiler;
    using System.Data.Entity.Core.Metadata.Edm;

    /// <summary>
    /// Implements a mapping view cache.
    /// </summary>
    [GeneratedCode("Entity Framework Power Tools", "0.9.0.0")]
    internal sealed class ViewsForBaseEntitySetseb0230ca609faa820ab1c6a117295d9540df1bdb3d95e9a4597e4bc1865c538b : DbMappingViewCache
    {
        /// <summary>
        /// Gets a hash value computed over the mapping closure.
        /// </summary>
        public override string MappingHashValue
        {
            get { return "eb0230ca609faa820ab1c6a117295d9540df1bdb3d95e9a4597e4bc1865c538b"; }
        }

        /// <summary>
        /// Gets a view corresponding to the specified extent.
        /// </summary>
        /// <param name="extent">The extent.</param>
        /// <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        public override DbMappingView GetView(EntitySetBase extent)
        {
            if (extent == null)
            {
                throw new ArgumentNullException("extent");
            }

            var extentName = extent.EntityContainer.Name + "." + extent.Name;

            if (extentName == "CodeFirstDatabase.Course")
            {
                return GetView0();
            }

            if (extentName == "CodeFirstDatabase.Department")
            {
                return GetView1();
            }

            if (extentName == "CodeFirstDatabase.OnlineCourse")
            {
                return GetView2();
            }

            if (extentName == "CodeFirstDatabase.OnsiteCourse")
            {
                return GetView3();
            }

            if (extentName == "CodeFirstDatabase.Person")
            {
                return GetView4();
            }

            if (extentName == "CodeFirstDatabase.Instructor")
            {
                return GetView5();
            }

            if (extentName == "CodeFirstDatabase.Student")
            {
                return GetView6();
            }

            if (extentName == "CodeFirstDatabase.OfficeAssignment")
            {
                return GetView7();
            }

            if (extentName == "CodeFirstDatabase.StudentGrade")
            {
                return GetView8();
            }

            if (extentName == "CodeFirstDatabase.CoursePerson")
            {
                return GetView9();
            }

            if (extentName == "SchoolContext.Courses")
            {
                return GetView10();
            }

            if (extentName == "SchoolContext.Departments")
            {
                return GetView11();
            }

            if (extentName == "SchoolContext.OnlineCourses")
            {
                return GetView12();
            }

            if (extentName == "SchoolContext.OnsiteCourses")
            {
                return GetView13();
            }

            if (extentName == "SchoolContext.People")
            {
                return GetView14();
            }

            if (extentName == "SchoolContext.OfficeAssignments")
            {
                return GetView15();
            }

            if (extentName == "SchoolContext.StudentGrades")
            {
                return GetView16();
            }

            if (extentName == "SchoolContext.Course_People")
            {
                return GetView17();
            }

            return null;
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Course.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView0()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Course
        [CodeFirstDatabaseSchema.Course](T1.Course_CourseID, T1.Course_Title, T1.Course_Credits, T1.Course_DepartmentID)
    FROM (
        SELECT 
            T.CourseID AS Course_CourseID, 
            T.Title AS Course_Title, 
            T.Credits AS Course_Credits, 
            T.DepartmentID AS Course_DepartmentID, 
            True AS _from0
        FROM SchoolContext.Courses AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Department.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView1()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Department
        [CodeFirstDatabaseSchema.Department](T1.Department_DepartmentID, T1.Department_Name, T1.Department_Budget, T1.Department_StartDate, T1.Department_Administrator)
    FROM (
        SELECT 
            T.DepartmentID AS Department_DepartmentID, 
            T.Name AS Department_Name, 
            T.Budget AS Department_Budget, 
            T.StartDate AS Department_StartDate, 
            T.Administrator AS Department_Administrator, 
            True AS _from0
        FROM SchoolContext.Departments AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.OnlineCourse.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView2()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing OnlineCourse
        [CodeFirstDatabaseSchema.OnlineCourse](T1.OnlineCourse_CourseID, T1.OnlineCourse_URL)
    FROM (
        SELECT 
            T.CourseID AS OnlineCourse_CourseID, 
            T.URL AS OnlineCourse_URL, 
            True AS _from0
        FROM SchoolContext.OnlineCourses AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.OnsiteCourse.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView3()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing OnsiteCourse
        [CodeFirstDatabaseSchema.OnsiteCourse](T1.OnsiteCourse_CourseID, T1.OnsiteCourse_Location, T1.OnsiteCourse_Days, T1.OnsiteCourse_Time)
    FROM (
        SELECT 
            T.CourseID AS OnsiteCourse_CourseID, 
            T.Location AS OnsiteCourse_Location, 
            T.Days AS OnsiteCourse_Days, 
            T.Time AS OnsiteCourse_Time, 
            True AS _from0
        FROM SchoolContext.OnsiteCourses AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Person.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView4()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Person
        [CodeFirstDatabaseSchema.Person](T1.Person_PersonID, T1.Person_LastName, T1.Person_FirstName, T1.Person_Timestamp)
    FROM (
        SELECT 
            T.PersonID AS Person_PersonID, 
            T.LastName AS Person_LastName, 
            T.FirstName AS Person_FirstName, 
            T.Timestamp AS Person_Timestamp, 
            True AS _from0
        FROM SchoolContext.People AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Instructor.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView5()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Instructor
        [CodeFirstDatabaseSchema.Instructor](T1.Instructor_PersonID, T1.Instructor_HireDate)
    FROM (
        SELECT 
            T.PersonID AS Instructor_PersonID, 
            TREAT(T AS [CodeFirst.ReverseEngineered.Models.Instructor]).HireDate AS Instructor_HireDate, 
            True AS _from0
        FROM SchoolContext.People AS T
        WHERE T IS OF (ONLY [CodeFirst.ReverseEngineered.Models.Instructor])
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.Student.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView6()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Student
        [CodeFirstDatabaseSchema.Student](T1.Student_PersonID, T1.Student_EnrollmentDate)
    FROM (
        SELECT 
            T.PersonID AS Student_PersonID, 
            TREAT(T AS [CodeFirst.ReverseEngineered.Models.Student]).EnrollmentDate AS Student_EnrollmentDate, 
            True AS _from0
        FROM SchoolContext.People AS T
        WHERE T IS OF (ONLY [CodeFirst.ReverseEngineered.Models.Student])
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.OfficeAssignment.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView7()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing OfficeAssignment
        [CodeFirstDatabaseSchema.OfficeAssignment](T1.OfficeAssignment_InstructorID, T1.OfficeAssignment_Location, T1.OfficeAssignment_Timestamp)
    FROM (
        SELECT 
            T.InstructorID AS OfficeAssignment_InstructorID, 
            T.Location AS OfficeAssignment_Location, 
            T.Timestamp AS OfficeAssignment_Timestamp, 
            True AS _from0
        FROM SchoolContext.OfficeAssignments AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.StudentGrade.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView8()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing StudentGrade
        [CodeFirstDatabaseSchema.StudentGrade](T1.StudentGrade_EnrollmentID, T1.StudentGrade_CourseID, T1.StudentGrade_StudentID, T1.StudentGrade_Grade)
    FROM (
        SELECT 
            T.EnrollmentID AS StudentGrade_EnrollmentID, 
            T.CourseID AS StudentGrade_CourseID, 
            T.StudentID AS StudentGrade_StudentID, 
            T.Grade AS StudentGrade_Grade, 
            True AS _from0
        FROM SchoolContext.StudentGrades AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for CodeFirstDatabase.CoursePerson.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView9()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing CoursePerson
        [CodeFirstDatabaseSchema.CoursePerson](T1.CoursePerson_CourseID, T1.CoursePerson_PersonID)
    FROM (
        SELECT 
            Key(T.Course_People_Source).CourseID AS CoursePerson_CourseID, 
            Key(T.Course_People_Target).PersonID AS CoursePerson_PersonID, 
            True AS _from0
        FROM SchoolContext.Course_People AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for SchoolContext.Courses.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView10()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Courses
        [CodeFirst.ReverseEngineered.Models.Course](T1.Course_CourseID, T1.Course_Title, T1.Course_Credits, T1.Course_DepartmentID)
    FROM (
        SELECT 
            T.CourseID AS Course_CourseID, 
            T.Title AS Course_Title, 
            T.Credits AS Course_Credits, 
            T.DepartmentID AS Course_DepartmentID, 
            True AS _from0
        FROM CodeFirstDatabase.Course AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for SchoolContext.Departments.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView11()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Departments
        [CodeFirst.ReverseEngineered.Models.Department](T1.Department_DepartmentID, T1.Department_Name, T1.Department_Budget, T1.Department_StartDate, T1.Department_Administrator)
    FROM (
        SELECT 
            T.DepartmentID AS Department_DepartmentID, 
            T.Name AS Department_Name, 
            T.Budget AS Department_Budget, 
            T.StartDate AS Department_StartDate, 
            T.Administrator AS Department_Administrator, 
            True AS _from0
        FROM CodeFirstDatabase.Department AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for SchoolContext.OnlineCourses.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView12()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing OnlineCourses
        [CodeFirst.ReverseEngineered.Models.OnlineCourse](T1.OnlineCourse_CourseID, T1.OnlineCourse_URL)
    FROM (
        SELECT 
            T.CourseID AS OnlineCourse_CourseID, 
            T.URL AS OnlineCourse_URL, 
            True AS _from0
        FROM CodeFirstDatabase.OnlineCourse AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for SchoolContext.OnsiteCourses.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView13()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing OnsiteCourses
        [CodeFirst.ReverseEngineered.Models.OnsiteCourse](T1.OnsiteCourse_CourseID, T1.OnsiteCourse_Location, T1.OnsiteCourse_Days, T1.OnsiteCourse_Time)
    FROM (
        SELECT 
            T.CourseID AS OnsiteCourse_CourseID, 
            T.Location AS OnsiteCourse_Location, 
            T.Days AS OnsiteCourse_Days, 
            T.Time AS OnsiteCourse_Time, 
            True AS _from0
        FROM CodeFirstDatabase.OnsiteCourse AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for SchoolContext.People.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView14()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing People
        CASE
            WHEN T5._from1 THEN [CodeFirst.ReverseEngineered.Models.Instructor](T5.Person_PersonID, T5.Person_LastName, T5.Person_FirstName, T5.Person_Timestamp, T5.Instructor_HireDate)
            ELSE [CodeFirst.ReverseEngineered.Models.Student](T5.Person_PersonID, T5.Person_LastName, T5.Person_FirstName, T5.Person_Timestamp, T5.Student_EnrollmentDate)
        END
    FROM (
        SELECT T3.Person_PersonID, T4.Person_LastName, T4.Person_FirstName, T4.Person_Timestamp, T3.Instructor_HireDate, T3.Student_EnrollmentDate, T4._from0, T3._from1, T3._from2
        FROM  ( (
                SELECT 
                    T.PersonID AS Person_PersonID, 
                    T.HireDate AS Instructor_HireDate, 
                    CAST(NULL AS [Edm.DateTime]) AS Student_EnrollmentDate, 
                    True AS _from1, 
                    False AS _from2
                FROM CodeFirstDatabase.Instructor AS T)
                UNION ALL (
                SELECT 
                    T.PersonID AS Person_PersonID, 
                    CAST(NULL AS [Edm.DateTime]) AS Instructor_HireDate, 
                    T.EnrollmentDate AS Student_EnrollmentDate, 
                    False AS _from1, 
                    True AS _from2
                FROM CodeFirstDatabase.Student AS T)) AS T3
            INNER JOIN (
            SELECT 
                T.PersonID AS Person_PersonID, 
                T.LastName AS Person_LastName, 
                T.FirstName AS Person_FirstName, 
                T.Timestamp AS Person_Timestamp, 
                True AS _from0
            FROM CodeFirstDatabase.Person AS T) AS T4
            ON T3.Person_PersonID = T4.Person_PersonID
    ) AS T5");
        }

        /// <summary>
        /// Gets the view for SchoolContext.OfficeAssignments.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView15()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing OfficeAssignments
        [CodeFirst.ReverseEngineered.Models.OfficeAssignment](T1.OfficeAssignment_InstructorID, T1.OfficeAssignment_Location, T1.OfficeAssignment_Timestamp)
    FROM (
        SELECT 
            T.InstructorID AS OfficeAssignment_InstructorID, 
            T.Location AS OfficeAssignment_Location, 
            T.Timestamp AS OfficeAssignment_Timestamp, 
            True AS _from0
        FROM CodeFirstDatabase.OfficeAssignment AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for SchoolContext.StudentGrades.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView16()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing StudentGrades
        [CodeFirst.ReverseEngineered.Models.StudentGrade](T1.StudentGrade_EnrollmentID, T1.StudentGrade_CourseID, T1.StudentGrade_StudentID, T1.StudentGrade_Grade)
    FROM (
        SELECT 
            T.EnrollmentID AS StudentGrade_EnrollmentID, 
            T.CourseID AS StudentGrade_CourseID, 
            T.StudentID AS StudentGrade_StudentID, 
            T.Grade AS StudentGrade_Grade, 
            True AS _from0
        FROM CodeFirstDatabase.StudentGrade AS T
    ) AS T1");
        }

        /// <summary>
        /// Gets the view for SchoolContext.Course_People.
        /// </summary>
        /// <returns>The mapping view.</returns>
        private static DbMappingView GetView17()
        {
            return new DbMappingView(@"
    SELECT VALUE -- Constructing Course_People
        [CodeFirst.ReverseEngineered.Models.Course_People](T3.[Course_People.Course_People_Source], T3.[Course_People.Course_People_Target])
    FROM (
        SELECT -- Constructing Course_People_Source
            CreateRef(SchoolContext.Courses, row(T2.[Course_People.Course_People_Source.CourseID]), [CodeFirst.ReverseEngineered.Models.Course]) AS [Course_People.Course_People_Source], 
            T2.[Course_People.Course_People_Target]
        FROM (
            SELECT -- Constructing Course_People_Target
                T1.[Course_People.Course_People_Source.CourseID], 
                CreateRef(SchoolContext.People, row(T1.[Course_People.Course_People_Target.PersonID]), [CodeFirst.ReverseEngineered.Models.Person]) AS [Course_People.Course_People_Target]
            FROM (
                SELECT 
                    T.CourseID AS [Course_People.Course_People_Source.CourseID], 
                    T.PersonID AS [Course_People.Course_People_Target.PersonID], 
                    True AS _from0
                FROM CodeFirstDatabase.CoursePerson AS T
            ) AS T1
        ) AS T2
    ) AS T3");
        }
    }
}