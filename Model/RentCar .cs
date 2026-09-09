using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    public class RentCar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId{ get; set; }
        public DateTime Duedate { get; set; }
        public DateTime Rentdate { get; set; }

        public Customer customer { get; set; }
        public Car car{ get; set; }

    }
}
