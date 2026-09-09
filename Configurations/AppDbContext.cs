using Microsoft.EntityFrameworkCore;
using Smart_Car_Rental_System.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
   public class AppDbContext:DbContext
    {
       public DbSet<Branch> Branch{ get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<RentCar> RentCar { get; set; }
        public DbSet<Fee>Fee { get; set; }
        public DbSet<CustomerRentalHistory> CustomerRentalHistory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-4QTL2SH\\SQLEXPRESS;Initial Catalog=Smart_Car_Rental;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
