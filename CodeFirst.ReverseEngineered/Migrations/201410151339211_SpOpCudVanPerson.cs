namespace CodeFirst.ReverseEngineered.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpOpCudVanPerson : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Instructor_Insert",
                p => new
                    {
                        LastName = p.String(maxLength: 50),
                        FirstName = p.String(maxLength: 50),
                        HireDate = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Person]([LastName], [FirstName])
                      VALUES (@LastName, @FirstName)
                      
                      DECLARE @PersonID int
                      SELECT @PersonID = [PersonID]
                      FROM [dbo].[Person]
                      WHERE @@ROWCOUNT > 0 AND [PersonID] = scope_identity()
                      
                      INSERT [dbo].[Instructor]([PersonID], [HireDate])
                      VALUES (@PersonID, @HireDate)
                      
                      SELECT t0.[PersonID], t0.[Timestamp]
                      FROM [dbo].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[PersonID] = @PersonID"
            );
            
            CreateStoredProcedure(
                "dbo.Instructor_Update",
                p => new
                    {
                        PersonID = p.Int(),
                        LastName = p.String(maxLength: 50),
                        FirstName = p.String(maxLength: 50),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                        HireDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Instructor]
                      SET [HireDate] = @HireDate
                      WHERE ([PersonID] = @PersonID)
                      
                      UPDATE [dbo].[Person]
                      SET [LastName] = @LastName, [FirstName] = @FirstName
                      WHERE (([PersonID] = @PersonID) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      AND @@ROWCOUNT > 0
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[PersonID] = @PersonID"
            );
            
            CreateStoredProcedure(
                "dbo.Instructor_Delete",
                p => new
                    {
                        PersonID = p.Int(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"DELETE [dbo].[Instructor]
                      WHERE ([PersonID] = @PersonID)
                      
                      DELETE [dbo].[Person]
                      WHERE (([PersonID] = @PersonID) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      AND @@ROWCOUNT > 0"
            );
            
            CreateStoredProcedure(
                "dbo.Student_Insert",
                p => new
                    {
                        LastName = p.String(maxLength: 50),
                        FirstName = p.String(maxLength: 50),
                        EnrollmentDate = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Person]([LastName], [FirstName])
                      VALUES (@LastName, @FirstName)
                      
                      DECLARE @PersonID int
                      SELECT @PersonID = [PersonID]
                      FROM [dbo].[Person]
                      WHERE @@ROWCOUNT > 0 AND [PersonID] = scope_identity()
                      
                      INSERT [dbo].[Student]([PersonID], [EnrollmentDate])
                      VALUES (@PersonID, @EnrollmentDate)
                      
                      SELECT t0.[PersonID], t0.[Timestamp]
                      FROM [dbo].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[PersonID] = @PersonID"
            );
            
            CreateStoredProcedure(
                "dbo.Student_Update",
                p => new
                    {
                        PersonID = p.Int(),
                        LastName = p.String(maxLength: 50),
                        FirstName = p.String(maxLength: 50),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                        EnrollmentDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Person]
                      SET [LastName] = @LastName, [FirstName] = @FirstName
                      WHERE (([PersonID] = @PersonID) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      
                      UPDATE [dbo].[Student]
                      SET [EnrollmentDate] = @EnrollmentDate
                      WHERE ([PersonID] = @PersonID)
                      AND @@ROWCOUNT > 0
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[PersonID] = @PersonID"
            );
            
            CreateStoredProcedure(
                "dbo.Student_Delete",
                p => new
                    {
                        PersonID = p.Int(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"DELETE [dbo].[Student]
                      WHERE ([PersonID] = @PersonID)
                      
                      DELETE [dbo].[Person]
                      WHERE (([PersonID] = @PersonID) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      AND @@ROWCOUNT > 0"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Student_Delete");
            DropStoredProcedure("dbo.Student_Update");
            DropStoredProcedure("dbo.Student_Insert");
            DropStoredProcedure("dbo.Instructor_Delete");
            DropStoredProcedure("dbo.Instructor_Update");
            DropStoredProcedure("dbo.Instructor_Insert");
        }
    }
}
