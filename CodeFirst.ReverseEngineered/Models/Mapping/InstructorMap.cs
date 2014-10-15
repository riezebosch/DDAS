using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace CodeFirst.ReverseEngineered.Models.Mapping
{
    public class InstructorMap : EntityTypeConfiguration<Instructor>
    {
        public InstructorMap()
        {
            base.ToTable("Instructor");
            base.Property(t => t.HireDate).HasColumnName("HireDate");
            base.Property(p => p.HireDate).IsRequired();
        }
    }
}
