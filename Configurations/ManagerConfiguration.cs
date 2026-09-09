using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    internal class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.Property(x => x.ID)
            .UseIdentityColumn(01, 1);

            builder.HasCheckConstraint("CK_Phone", "Phone LIKE '%[0-9]%'");
            builder.Property(x => x.Hired).HasDefaultValueSql("getdate()");

         
        }
    }
}
