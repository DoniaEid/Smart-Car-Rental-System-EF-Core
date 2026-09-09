using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Car_Rental_System
{
    internal class Manager
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public DateTime Hired { get; set; }

        public List<Branch> Branches { get; set; }
    }
}

