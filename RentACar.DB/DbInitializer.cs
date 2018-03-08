using RentACar.Models;
using System;
using System.Linq;

namespace RentACar.DB
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cars.Any())
            {
                return;
            }
         
            var cars = new Car[]
                {
                new Car{Brand="Mercedes",Model="C200cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsAvailable=false, ImageUrl="non aviailbe", PlaceId=1051
                },
                new Car{Brand="Mercedes",Model="C220cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsAvailable=false, ImageUrl="non aviailbe", PlaceId=1052
                },
                new Car{Brand="Mercedes",Model="C270cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsAvailable=false, ImageUrl="non aviailbe", PlaceId=1053
                },
                new Car{Brand="Mercedes",Model="C320cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsAvailable=false, ImageUrl="non aviailbe", PlaceId=1054
                }
                };
            foreach (var car in cars)
            {
                context.Cars.Add(car);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{CarId=1, PlaceId=1051, FirstName="Emin", LastName="Mandradzhi", PhoneNumber="089888888"},
                new Customer{CarId=2, PlaceId=1052, FirstName="Emine", LastName="Mandradzhi", PhoneNumber="089888888"},
                new Customer{CarId=3, PlaceId=1053, FirstName="Aki", LastName="Mandradzhi", PhoneNumber="089888888"},
                new Customer{CarId=4, PlaceId=1054, FirstName="Asibe", LastName="Mandradzhi", PhoneNumber="089888888"}
            };
            foreach (var cust in customers)
            {
                context.Customers.Add(cust);
            }
            context.SaveChanges();

            var places = new Place[]
           {
                new Place{PlaceId=1051,Country="Bulgaria", Name="CarSpot", Region="Pazardzhik"},
                new Place{PlaceId=1052,Country="Bulgaria", Name="PerfectCar", Region="Plovdiv"},
                new Place{PlaceId=1053,Country="Bulgaria", Name="CarForYou", Region="Sofia"},
                new Place{PlaceId=1054,Country="Bulgaria", Name="YourCar", Region="Bansko"}
           };
            foreach (var place in places)
            {
                context.Places.Add(place);
            }
            context.SaveChanges();

        }
    }
}
