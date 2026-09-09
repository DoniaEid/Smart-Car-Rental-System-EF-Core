using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Smart_Car_Rental_System
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.ID)
              .UseIdentityColumn(1, 1);

            builder.HasCheckConstraint("C_check", "Email = 'N/A' OR(Email LIKE '%@%' AND Email LIKE '%.%')");

            builder.HasCheckConstraint("CK_Phone", "Phone LIKE '%[0-9]%'");

            builder.Property(x => x.Email).HasDefaultValue("N/A");

            builder
                .HasMany(x => x.RentCar)
                .WithOne(x => x.customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Joined).HasDefaultValueSql("getdate()");
            builder
                .HasMany(x => x.CustomerRentalHistory)
                .WithOne(x => x.customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
