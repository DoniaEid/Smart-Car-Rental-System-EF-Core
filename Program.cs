


using Microsoft.EntityFrameworkCore;

namespace Smart_Car_Rental_System
{
    internal class Program
    {
        static AppDbContext _context = new AppDbContext();

        static void Main(string[] args)
        {
            Console.WriteLine("CAR RENTAL SYSTEM - MAIN MENU");
            Console.WriteLine("----------------------------------");
            while (true)
            {
                Menu();
                Console.Write("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        BranchInformation();
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Registered Users");
                        Console.WriteLine("----------------------------------");
                        ShowAllUser();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Available Fleet:");
                        Console.WriteLine("----------------------------------");
                        ShowAvailableCars();
                        break;

                }
            }
        }
        public static void Menu()
        {
            Console.WriteLine("1.Branch Information");
            Console.WriteLine("2.Show All Users");
            Console.WriteLine("3.Show Available Cars");
            Console.WriteLine("4.Show All Fleet ");
            Console.WriteLine("5.Rent a Car ");
            Console.WriteLine("6.Return a Car ");
            Console.WriteLine("7.Customer Rental History");
            Console.WriteLine("8.Register New Customer ");
            Console.WriteLine("0. Exit ");


        }
        public static void BranchInformation()
        {
            Console.WriteLine("RENTAL BRANCH INFO ");
            Console.WriteLine("----------------------------------");
            var branches = _context.Branch
                         .AsNoTracking()
                         .Select(x =>
                             new
                             {
                                 Id = x.Id,
                                 Name = x.Name,
                                 Address = x.Address,
                                 Phone = x.Phone,
                                 Hours = x.Hours,
                                 Manager = x.manager.Name,
                                 TotalCustomers = x.Customers.Count(),
                                 TotalVehicles = x.Cars.Count()
                             }
                         )
                         .ToList();
            
                        foreach(var b in branches)
                        {
                            Console.WriteLine($"ID              : BR-{b.Id}");
                            Console.WriteLine($"Name            : {b.Name}");
                            Console.WriteLine($"Address         : {b.Address}");
                            Console.WriteLine($"Phone           : {b.Phone}");
                            Console.WriteLine($"Hours           : {b.Hours}");
                            Console.WriteLine($"Manager         : {b.Manager}");
                            Console.WriteLine($"Total Customers : {b.TotalCustomers}");
                            Console.WriteLine($"Total Vehicles  : {b.TotalVehicles}");
                            Console.WriteLine("----------------------------------");
                        }
                   }

                    public static void ShowAllUser()
                    {
                        AllManagers();
                        AllCustomers();
                    }

                    public static void AllCustomers()
                    {
                    var Customers = _context.Customer
                        .AsNoTracking()
                        .Select(x => new
                        {
                            x.ID,
                            x.Name,
                            x.Phone,
                            x.Email,
                            x.Joined,
                            TotalRentals = x.RentCar.Count()
                        })
                     .ToList();
                      foreach (var m in Customers)
                            {
                                Console.WriteLine("--- Customer PROFILE --- ");
                                Console.WriteLine($"ID: CUST-00{m.ID}|");
                                Console.WriteLine($"Name: {m.Name}|");
                                Console.WriteLine($"Phone:{m.Phone}|");
                                Console.WriteLine($"Email: ${m.Email}");
                                Console.WriteLine($"Joined: {m.Joined.ToString("dd/MM/yyyy")}");
                                Console.WriteLine($"Active Rentals: {m.TotalRentals}");
                                Console.WriteLine();

                            }
                        }

                    public static void AllManagers()
                    {
                       var Managers = _context.Manager.AsNoTracking().ToList();
                        foreach(var m in Managers)
                        {
                            Console.WriteLine("--- MANAGER PROFILE --- ");
                            Console.WriteLine($"ID: MGR-0{m.ID}|");
                            Console.WriteLine($"Name: {m.Name}|");
                            Console.WriteLine($"Phone:{m.Phone}|");
                            Console.WriteLine($"Salary: ${m.Salary}");
                            Console.WriteLine(m.Hired.ToString("dd/MM/yyyy"));
                            Console.WriteLine();
                      }
                    }
                    public static void ShowAvailableCars()
                    {
                       var AvailableCars = _context.Car.Where(x => x.Status == "Available").ToList();
                       foreach(var car in AvailableCars)
                        {
                              Console.WriteLine($"Car [CAR-00{car.Id}]-{car.Model} {car.Year} | Condition:{car.Condition} | {car.Status}");
                              Console.WriteLine();
                        }



                    }



    }
}
