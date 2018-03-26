using RentACar.Models.Car;
using RentACar.Models.Place;
using RentACar.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar.Data
{
    public static class DbInitialiser
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
                    RentTo =DateTime.Parse("2005-09-05"), IsTheCarAvailable=Models.Helpers.IsCarAvailable.Available, ImageUrl="https://i.ebayimg.com/images/g/MWIAAOSwqfNXif2~/s-l300.jpg", PlaceId=1051
                }
                };
            foreach (var car in cars)
            {
                context.Cars.Add(car);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User{CarId=1, PlaceId=1051, Username="Test", Password="16jLEh8IFg9/bTZjKCH7wW+3uK/KaxuhS+QOu4AqpZxrIvA8", Email="Mandradzhi@gmail.com",TypeOfUser=Models.Helpers.TypeOfUser.Admin, PhoneNumber="089888888"}
                
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var places = new Place[]
           {
                new Place{PlaceId=1051,Country="Bulgaria", Name="CarSpot", Region="Pazardzhik"}
           };
            foreach (var place in places)
            {
                context.Places.Add(place);
            }
            context.SaveChanges();

        }
    }
}
