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
using RentACar.Models.User;

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

        public IActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginEntryDto entry)
        {
            ViewData["WrongLogin"] = null;

            if (!ModelState.IsValid)
            {
                ViewData["WrongLogin"] = "Incorrect form!";
                return View();
            }
            else
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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterEntryDto entry)
        {
            if (!ModelState.IsValid)
            {

            }
            else
            {
                string password = HashUtils.CreateHashCode(entry.Password);

                User nUser = new User(entry.Username, password, entry.Email, entry.TypeOfUser, entry.PhoneNumber);

                await _userManager.RegisterAsync(nUser);

            }

            return RedirectToAction("Index", "Home");
        }
    }
}