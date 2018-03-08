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
                    RentTo =DateTime.Parse("2005-09-05"), IsCarAvailable=Models.Helpers.IsCarAvailable.Available, ImageUrl="https://www.google.bg/imgres?imgurl=https%3A%2F%2Fbg.autodata24.com%2Fi%2Fmercedes-benz%2Fc-klasse%2Fc-klasse-w203%2Flarge%2F9ab22ed5057fe5d64de00dc8577c327d.jpg&imgrefurl=https%3A%2F%2Fbg.autodata24.com%2Fmercedes-benz%2Fc-klasse%2Fc-klasse-w203%2Fdetails&docid=iY2X3ontL0S5-M&tbnid=jSfUs01aWX9MsM%3A&vet=10ahUKEwiz05752dzZAhWmK8AKHQcgAa4QMwg8KAAwAA..i&w=720&h=520&bih=974&biw=1920&q=c200%20cdi%20w203&ved=0ahUKEwiz05752dzZAhWmK8AKHQcgAa4QMwg8KAAwAA&iact=mrc&uact=8", PlaceId=1051
                },
                new Car{Brand="Mercedes",Model="C220cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsCarAvailable=Models.Helpers.IsCarAvailable.NonAvailable, ImageUrl="non aviailbe", PlaceId=1052
                },
                new Car{Brand="Mercedes",Model="C270cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsCarAvailable=Models.Helpers.IsCarAvailable.Available, ImageUrl="non aviailbe", PlaceId=1053
                },
                new Car{Brand="Mercedes",Model="C320cdi", RentFrom=DateTime.Parse("2005-09-01"),
                    RentTo =DateTime.Parse("2005-09-05"), IsCarAvailable=Models.Helpers.IsCarAvailable.Available, ImageUrl="non aviailbe", PlaceId=1054
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
