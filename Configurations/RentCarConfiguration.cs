using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    internal class RentCarConfiguration : IEntityTypeConfiguration<RentCar>
    {
        public void Configure(EntityTypeBuilder<RentCar> builder)
        {
            builder.Property(x => x.Rentdate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Duedate).HasComputedColumnSql("DATEADD(DAY, 14, [Rentdate])");
        }
    }
}
