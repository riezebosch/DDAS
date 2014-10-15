namespace CodeFirst.ReverseEngineered.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VanTptNaarTph : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Person", t => t.PersonID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Person", t => t.PersonID)
                .Index(t => t.PersonID);

            Sql("INSERT INTO dbo.Student (PersonId, EnrollmentDate) SELECT PersonId, EnrollmentDate FROM dbo.Person WHERE EnrollmentDate IS NOT NULL");
            Sql("INSERT INTO dbo.Instructor (PersonId, HireDate) SELECT PersonId, HireDate FROM dbo.Person WHERE HireDate IS NOT NULL");

            DropColumn("dbo.Person", "HireDate");
            DropColumn("dbo.Person", "EnrollmentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "EnrollmentDate", c => c.DateTime());
            AddColumn("dbo.Person", "HireDate", c => c.DateTime());
            DropForeignKey("dbo.Student", "PersonID", "dbo.Person");
            DropForeignKey("dbo.Instructor", "PersonID", "dbo.Person");
            DropIndex("dbo.Student", new[] { "PersonID" });
            DropIndex("dbo.Instructor", new[] { "PersonID" });
            DropTable("dbo.Student");
            DropTable("dbo.Instructor");
        }
    }
}
