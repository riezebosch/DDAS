using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CodeFirst.ReverseEngineered.Models.Mapping;

namespace CodeFirst.ReverseEngineered.Models
{
    public partial class SchoolContext : DbContext
    {
        static SchoolContext()
        {
            Database.SetInitializer<SchoolContext>(null);
        }

        public SchoolContext() : base("Name=SchoolContext")
        {

        }

        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Department> Departments { get; set; }
        public IDbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public IDbSet<OnlineCourse> OnlineCourses { get; set; }
        public IDbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public virtual IDbSet<Person> People { get; set; }
        public IDbSet<StudentGrade> StudentGrades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new OfficeAssignmentMap());
            modelBuilder.Configurations.Add(new OnlineCourseMap());
            modelBuilder.Configurations.Add(new OnsiteCourseMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new StudentGradeMap());
            modelBuilder.Configurations.Add(new InstructorMap());

            modelBuilder.Entity<Student>().Property(s => s.EnrollmentDate).IsRequired();
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
