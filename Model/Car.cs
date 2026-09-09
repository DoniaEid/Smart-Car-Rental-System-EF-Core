using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
        public int BranchId { get; set; }

        public Branch branch { get; set; }
        public List<RentCar> RentCar { get; set; }
        public List<Fee> Fee { get; set; }

    }
}
