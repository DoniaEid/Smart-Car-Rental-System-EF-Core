using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Car_Rental_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System.Configurations
{
    public class CustomerRentalHistoryConfiguration : IEntityTypeConfiguration<CustomerRentalHistory>
    {
        public void Configure(EntityTypeBuilder<CustomerRentalHistory> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(1001, 1);
        }
    }
}
