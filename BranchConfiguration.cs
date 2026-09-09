using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(x => x.Id)
                .UseIdentityColumn(01, 1);

            builder
                .HasOne(x => x.manager)
                .WithMany(x => x.Branches)
                .HasForeignKey(x => x.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(x=>x.Customers)
                .WithOne(x=>x.branch)
                .HasForeignKey(x=>x.BranchId)
                 .OnDelete(DeleteBehavior.Restrict); 
           
        }
    }
}
