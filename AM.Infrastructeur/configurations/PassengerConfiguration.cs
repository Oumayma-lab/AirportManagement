using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructeur.configurations;
public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.OwnsOne(p => p.FullName, fullName => 
        {
            fullName.Property(n => n.FirstName)
                    .HasColumnName("PassFirstName")
                    .HasMaxLength(30);

            fullName.Property(n => n.Lastname)
                    .HasColumnName("PassLastName")
                    .IsRequired();
        });
    }
}

