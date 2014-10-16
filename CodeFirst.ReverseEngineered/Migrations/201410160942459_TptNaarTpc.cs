namespace CodeFirst.ReverseEngineered.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TptNaarTpc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructor", "PersonID", "dbo.Person");
            DropForeignKey("dbo.Student", "PersonID", "dbo.Person");
            DropIndex("dbo.Instructor", new[] { "PersonID" });
            DropIndex("dbo.Student", new[] { "PersonID" });
            AddColumn("dbo.Instructor", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Instructor", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Instructor", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Student", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Student", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Student", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));

            Sql("MERGE Instructor AS i USING Person AS p ON i.PersonID = p.PersonID WHEN MATCHED THEN UPDATE SET i.FirstName = p.FirstName, i.LastName = p.LastName;");
            Sql("MERGE Student AS i USING Person AS p ON i.PersonID = p.PersonID WHEN MATCHED THEN UPDATE SET i.FirstName = p.FirstName, i.LastName = p.LastName;");

            DropTable("dbo.Person");
            AlterStoredProcedure(
                "dbo.Instructor_Insert",
                p => new
                    {
                        PersonID = p.Int(),
                        LastName = p.String(maxLength: 50),
                        FirstName = p.String(maxLength: 50),
                        HireDate = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Instructor]([PersonID], [LastName], [FirstName], [HireDate])
                      VALUES (@PersonID, @LastName, @FirstName, @HireDate)
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[Instructor] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[PersonID] = @PersonID"
            );
            
            AlterStoredProcedure(
                "dbo.Instructor_Update",
                p => new
                    {
                        PersonID = p.Int(),
                        LastName = p.String(maxLength: 50),
                        FirstName = p.String(maxLength: 50),
                        Timestamp_Original = p.Binary(maxLength: 8),
                        HireDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Instructor]
                      SET [LastName] = @LastName, [FirstName] = @FirstName, [HireDate] = @HireDate
                      WHERE (([PersonID] = @PersonID) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[Instructor] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[PersonID] = @PersonID"
            );
            
            AlterStoredProcedure(
                "dbo.Instructor_Delete",
                p => new
                    {
                        PersonID = p.Int(),
                        Timestamp_Original = p.Binary(maxLength: 8),
                    },
                body:
                    @"DELETE [dbo].[Instructor]
                      WHERE (([PersonID] = @PersonID) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))"
            );
            
            AlterStoredProcedure(
                "dbo.Student_Insert",
                p => new
                    {
                        PersonID = p.Int(),
                        LastName = p.String(maxLength: 50),
                        FirstName = p.String(maxLength: 50),
                        EnrollmentDate = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Student]([PersonID], [LastName], [FirstName], [EnrollmentDate])
                      VALUES (@PersonID, @LastName, @FirstName, @EnrollmentDate)
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[Student] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[PersonID] = @PersonID"
            );
            
            AlterStoredProcedure(
                "dbo.Student_Update",
                p => new
                    {
                        PersonID = p.Int(),
                        LastName = p.String(maxLength: 50),
                        FirstName = p.String(maxLength: 50),
                        Timestamp_Original = p.Binary(maxLength: 8),
                        EnrollmentDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Student]
                      SET [LastName] = @LastName, [FirstName] = @FirstName, [EnrollmentDate] = @EnrollmentDate
                      WHERE (([PersonID] = @PersonID) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[Student] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[PersonID] = @PersonID"
            );
            
            AlterStoredProcedure(
                "dbo.Student_Delete",
                p => new
                    {
                        PersonID = p.Int(),
                        Timestamp_Original = p.Binary(maxLength: 8),
                    },
                body:
                    @"DELETE [dbo].[Student]
                      WHERE (([PersonID] = @PersonID) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.PersonID);
            
            DropColumn("dbo.Student", "Timestamp");
            DropColumn("dbo.Student", "FirstName");
            DropColumn("dbo.Student", "LastName");
            DropColumn("dbo.Instructor", "Timestamp");
            DropColumn("dbo.Instructor", "FirstName");
            DropColumn("dbo.Instructor", "LastName");
            CreateIndex("dbo.Student", "PersonID");
            CreateIndex("dbo.Instructor", "PersonID");
            AddForeignKey("dbo.Student", "PersonID", "dbo.Person", "PersonID");
            AddForeignKey("dbo.Instructor", "PersonID", "dbo.Person", "PersonID");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
