using Smart_Car_Rental_System.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Smart_Car_Rental_System
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Joined { get; set; }
        public string ?Email { get; set; }
        public int BranchId { get; set; }


        public Branch branch { get; set; }
        public List<RentCar> RentCar { get; set; }
        public List<CustomerRentalHistory> CustomerRentalHistory { get; set; }
    }
}
