using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System.Model
{
    public class CustomerRentalHistory
    {

        public int Id { get; set; }

        public string CarName { get; set; }

        public int CarId { get; set; }

        public DateTime Rented { get; set; }

        public DateTime Due { get; set; }

        public DateTime? Returned { get; set; }

        public string Status { get; set; }

        public double Fee { get; set; }
        public int CustomerId{ get; set; }

        public Customer customer { get; set; }

    }
}
