using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    internal class Fee
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public decimal Amount { get; set; }

        public Car Car { get; set; }
    }
}
