using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.ReverseEngineered.Models.Mapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.PersonID);

            // Properties
            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Timestamp)
                .IsRequired()
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("Person");
            this.Property(t => t.PersonID).HasColumnName("PersonID");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FirstName).HasColumnName("FirstName");

            //this.MapToStoredProcedures();
        }
    }
}
