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

            if (context.Users.Any())
            {
                return;
            }
         
            var cars = new Car[]
                {
                new Car{Brand="Mercedes",Model="C200cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsTheCarAvailable=Models.Helpers.IsCarAvailable.Available, ImageUrl="non aviailbe", PlaceId=1051
                },
                new Car{Brand="Mercedes",Model="C220cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsTheCarAvailable=Models.Helpers.IsCarAvailable.NonAvailable, ImageUrl="non aviailbe", PlaceId=1052
                },
                new Car{Brand="Mercedes",Model="C270cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsTheCarAvailable=Models.Helpers.IsCarAvailable.Available, ImageUrl="non aviailbe", PlaceId=1053
                },
                new Car{Brand="Mercedes",Model="C320cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsTheCarAvailable=Models.Helpers.IsCarAvailable.Available, ImageUrl="non aviailbe", PlaceId=1054
                }
                };
            foreach (var car in cars)
            {
                context.Cars.Add(car);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User{CarId=1, PlaceId=1051, Username="Emin", Email="Mandradzhi@gmail.com",TypeOfUser=Models.Helpers.TypeOfUser.Admin, PhoneNumber="089888888"},
                new User{CarId=2, PlaceId=1052, Username="Emine", Email="Mandradzhi@gmail.com",TypeOfUser=Models.Helpers.TypeOfUser.Customer, PhoneNumber="089888888"},
                new User{CarId=3, PlaceId=1053, Username="Aki", Email="Mandradzhi@gmail.com", TypeOfUser=Models.Helpers.TypeOfUser.Customer,PhoneNumber="089888888"},
                new User{CarId=4, PlaceId=1054, Username="Asibe", Email="Mandradzhi@gmail.com", TypeOfUser=Models.Helpers.TypeOfUser.Customer,PhoneNumber="089888888"}
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
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
