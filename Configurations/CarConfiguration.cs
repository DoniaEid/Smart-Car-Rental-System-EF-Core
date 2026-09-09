using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        void IEntityTypeConfiguration<Car>.Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(001, 1);
            builder
                .HasOne(x => x.branch)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(x=>x.RentCar)
                .WithOne(x=>x.car)
                .HasForeignKey(x=>x.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(x=>x.Fee)
                .WithOne(x=>x.Car)
                .HasForeignKey(x=>x.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
