using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentACar.Host.Models;
using Microsoft.AspNetCore.Http;
using RentACar.Host.Extensions;

namespace RentACar.Host.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            return View();
        }
        
        public IActionResult Contact()
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            ViewData["Message"] = "For issues report please feel free to contact me";

            return View();
        }

        public IActionResult Error()
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
