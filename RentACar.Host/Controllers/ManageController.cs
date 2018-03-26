using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models.Helpers;
using RentACar.Host.Extensions;

namespace RentACar.Host.Controllers
{
    public class ManageController : Controller
    {

        private int _userId;
        private string _username;
        private TypeOfUser _typeOfUser;

        public IActionResult Index()
        {
            _userId = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (_userId == 0) return RedirectToAction("AccessDenied", "Home");
            _username = HttpContext.Session.GetObjectFromJson<string>("UserName");
            _typeOfUser = HttpContext.Session.GetObjectFromJson<TypeOfUser>("TypeOfUser");
            ViewData["UserId"] = _userId;
            ViewData["Username"] = _username;
            ViewData["TypeOfUser"] = _typeOfUser;
            return View();
        }
        public IActionResult WrongLogin()
        {
            return View();
        }
    }
}