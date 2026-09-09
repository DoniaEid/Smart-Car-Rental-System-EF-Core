using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.ID)
              .UseIdentityColumn(001, 1);

            builder.HasCheckConstraint("CK_Email", "Email LIKE '%@%' AND Email LIKE '%.%'");
            builder.HasCheckConstraint("CK_Phone", "Phone LIKE '%[0-9]%'");

            builder.Property(x => x.Email).HasDefaultValue("N/A");
            builder
                .HasMany(x => x.RentCar)
                .WithOne(x => x.customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Joined).HasDefaultValueSql("getdate()");

        }
    }
}
