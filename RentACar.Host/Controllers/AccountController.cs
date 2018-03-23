using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Models;
using RentACar.Managers;
using RentACar.Data;
using Microsoft.AspNetCore.Authorization;
using RentACar.Host.DTOs;
using RentACar.Common;
using RentACar.Host.Extensions;

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
        public IActionResult Welcome()
        {
            return View();
        }

        // GET: Account/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginEntryDto entry)
        {
            ViewData["WrongLogin"] = null;
            if (entry.Username == null || entry.Password == null)
            {
                ViewData["WrongLogin"] = "Incorrect form!";
                return View();
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserByUsernameAsync(entry.Username);
                if (user == null)
                {
                    if (!HashUtils.VerifyPassword(entry.Password, user.Password))
                    {
                        ViewData["WrongLogin"] = "Incorrect username or password!";
                        return View(entry);
                       
                    }
                }
                HttpContext.Session.SetObjectAsJson<int>("UserId", user.UserId);
                HttpContext.Session.SetObjectAsJson<string>("UserName", user.Username);
                HttpContext.Session.SetObjectAsJson("TypeOfUser", user.TypeOfUser);

            }

            
            return RedirectToAction("Index", "Manage");
        }


    }
}