namespace CodeFirst.ReverseEngineered.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentGradeNaarStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentGrade", "StudentID", "dbo.Person");
            Sql("DELETE FROM StudentGrade WHERE StudentID NOT IN (Select PersonID FROM Student)");

            AddForeignKey("dbo.StudentGrade", "StudentID", "dbo.Student", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrade", "StudentID", "dbo.Student");
            AddForeignKey("dbo.StudentGrade", "StudentID", "dbo.Person", "PersonID", cascadeDelete: true);
        }
    }
}
