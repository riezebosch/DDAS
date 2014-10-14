using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CodeFirst
{
    public class SnookerContext : DbContext
    {
        public IDbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Game>()
                .HasKey(e => e.Id)
                .Property(e => e.Location)
                .IsRequired()
                .HasColumnName("LoCaTiOn");
        }
    }
}
