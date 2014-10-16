namespace CodeFirst.ReverseEngineered.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfficeAssignmentEnCourseNaarInstructor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("StudentGrade", ((char)8).ToString(), "Person");
            AddForeignKey("dbo.StudentGrade", "StudentID", "dbo.Student", "PersonID");
            DropStoredProcedure("dbo.Instructor_Insert");
            DropStoredProcedure("dbo.Instructor_Update");
            DropStoredProcedure("dbo.Instructor_Delete");
            DropStoredProcedure("dbo.Student_Insert");
            DropStoredProcedure("dbo.Student_Update");
            DropStoredProcedure("dbo.Student_Delete");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrade", "StudentID", "dbo.Student");
            AddForeignKey("dbo.StudentGrade", "StudentID", "dbo.Person", "PersonID", cascadeDelete: true);
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
