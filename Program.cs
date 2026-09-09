


using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Smart_Car_Rental_System.Model;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                    case 4:
                        ShowAllFleet();
                        break;

                    case 5:
                        RentCar();
                        break;

                    case 6:
                        ReturnCar();
                        break;
                    case 7:
                        CustomerRentalHistory();
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
                        if (AvailableCars.IsNullOrEmpty())
                        {
                            Console.WriteLine("No available cars found.\n");
                        }
                        else
                        {
                            foreach (var car in AvailableCars)
                            {
                                Console.WriteLine($"Car [CAR-00{car.Id}]-{car.Model} {car.Year} | Condition:{car.Condition} | {car.Status}");
                                Console.WriteLine();
                            }
                        }
                    }

                        public static void ShowAllFleet()
                    {
                        var AvailableCars = _context.Car.ToList();
                        if (AvailableCars.IsNullOrEmpty())
                        {
                            Console.WriteLine("No available cars found.\n");
                        }
                        else
                        {
                            foreach (var car in AvailableCars)
                            {
                                Console.WriteLine($"Car [CAR-00{car.Id}]-{car.Model} {car.Year} | Condition:{car.Condition} | {car.Status}");
                                Console.WriteLine();
                            }
                        }
                    }

                        public static Car FindCarById(int id)
                        {
                            var car = _context.Car.FirstOrDefault(x => x.Id == id);
                            return car;
                        }
                        public static RentCar FindRentCarById(int id)
                        {
                            var car = _context.RentCar.FirstOrDefault(x => x.CarId == id);
                            return car;
                        }

                     public static Customer FindCustomerById(int id)
                        {
                            var customer= _context.Customer.FirstOrDefault(x => x.ID == id);
                            return customer;
                        }

                        public static void RentCar()
                        {
                            Customer c;

                                    while (true) { 
                                    Console.Write("Enter Customer ID: ");
                                    int Cusid = Convert.ToInt32(Console.ReadLine());
                                        c = FindCustomerById(Cusid);
                                        if (c is null)
                                            {
                                                Console.WriteLine("Customer not found.");
                          
                                            }
                                        else
                                        {
                  
                                            break;
                                        }
                                    }
        
                                Console.WriteLine("---------------------------------- ");
                                Console.WriteLine("Available Fleet:");
                                Console.WriteLine("---------------------------------- ");
                                ShowAvailableCars();
                               Car ca;
                                while (true)
                                {
                                    Console.Write("Enter Car ID to rent:");
                                    int Carid = Convert.ToInt32(Console.ReadLine());
                                    ca = FindCarById(Carid);
                                    if (ca is null)
                                    {
                                        Console.WriteLine("Car not found.");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                Console.WriteLine($"Car [CAR-00{ca.Id}] \"{ca.Model} {ca.Year}\" rented by{c.Name}");
                                ca.Status = "rented";
                                RentCar rentcar = new RentCar
                                {
                                    CustomerId = c.ID,
                                    CarId = ca.Id
                                };

                                _context.RentCar.Add(rentcar);
                               _context.SaveChanges();
                               Console.WriteLine($"Due date: {rentcar.Duedate.ToString("dd/MM/yyyy")}\n");
                                CustomerRentalHistory ch = new CustomerRentalHistory
                                {
                                    CarName = ca.Model +" "+ ca.Year,
                                    CarId=ca.Id,
                                    Rented= rentcar.Rentdate,
                                    Due= rentcar.Duedate,
                                    Status="Active",
                                    CustomerId=c.ID
                                };
                                _context.CustomerRentalHistory.Add(ch);

                                _context.SaveChanges();
 

                          }

                        public static DateTime DuedateReturn(int id)
                        {
                          var x = _context.RentCar.SingleOrDefault(x => x.CarId == id);
                          return x.Duedate;
                        }

                        public static void ReturnCar()
                        {
                         RentCar ca;
                         CustomerRentalHistory tr;
                        int CarId;

                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter Car ID:");

                            CarId = Convert.ToInt32(Console.ReadLine());

                            ca = FindRentCarById(CarId);

                            if (ca is null)
                            {
                                Console.WriteLine("Car not found.");
                                continue;
                            }

                            tr = TranscationByIdCar(ca.CarId);

                            if (tr is null || tr.Status != "Active")
                            {
                                Console.WriteLine("This car is not currently rented.");
                                continue;
                            }
                             break;
                        }
                            Car c = FindCarById(ca.CarId);
                            Console.WriteLine($"{c.Model} {c.Year} Returned.");
                            c.Status = "Available";
                           _context.SaveChanges();
                           var date=DuedateReturn(CarId);
                       
                        if (date > DateTime.Now)
                        {
                            Console.WriteLine("Returned on time. No late fee. ");
                            tr.Status = "Returned";
                            tr.Returned = DateTime.Now;
                        }
                        else
                        {
                             var AmountFee = Math.Abs((DateTime.Now - date).Days*150);
                             Fee f = new Fee { CarId = ca.Id, Amount = AmountFee };
                             _context.Fee.Add(f);
                             _context.SaveChanges();
                             Console.WriteLine($"Late return fee: {AmountFee} EGP");
                             tr.Fee = AmountFee;
                             
                        }

                    }

                        public static CustomerRentalHistory TranscationByIdCar(int id)
                    {
                        return _context.CustomerRentalHistory.FirstOrDefault(x => x.CarId == id);

                    }

                        public static void CustomerRentalHistory()
                        {
                         Console.Write("Enter Customer Id: ");
                         int CusId = Convert.ToInt32(Console.ReadLine());
                         if(FindCustomerById(CusId) is null)
                         {
                           Console.WriteLine("Customer not found. ");

                         }
                        else
                        {
                             var x = _context.CustomerRentalHistory.ToList();
                                foreach(var all in x)
                                {
                                 Console.WriteLine("\n");
                                  Console.WriteLine($"--- Transaction #{all.Id} ------------------ ");

                                Console.WriteLine($"Car               :  {all.CarName}");
                                Console.WriteLine($"Car Id            :  CAR-00{all.CarId}");
                                Console.WriteLine($"Rented            :  {all.Rented.ToString("dd//mm/yy")}");
                                Console.WriteLine($"Due               :  {all.Due.ToString("dd//mm/yy")}");
                                Console.WriteLine($"Returned          :  {(all.Returned.HasValue ? all.Returned.Value.ToString("dd/MM/yyyy") : "Not returned yet")}");
                                Console.WriteLine($"Status            :  {all.Status}");
                                Console.WriteLine($"Fee               :  {(all.Fee.HasValue? all.Fee.Value:"None")}");
                                Console.WriteLine("\n");
                              }

                        
                        }

                     }


    }



    }

