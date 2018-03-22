using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Managers;
using RentACar.Data;

namespace RentACar.Host.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _context = new AppDbContext();
        private IUser _userManager = new UserManager();

        
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

       
    }
}