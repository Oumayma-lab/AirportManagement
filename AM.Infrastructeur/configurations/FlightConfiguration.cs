using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructeur.configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {    //configure *-*
            //builder.HasMany(f => f.passengers)
            //       .WithMany(p => p.flights)
            //       .UsingEntity(t => t.ToTable("Reservation"));

            //configure 1-* relationship
            builder.HasOne(f => f.plane)
                  .WithMany(p => p.flights)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
