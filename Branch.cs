using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    internal class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Hours { get; set; }
        public int ManagerId { get; set; }

        public Manager manager { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Car> Cars { get; set; }
    }
}
