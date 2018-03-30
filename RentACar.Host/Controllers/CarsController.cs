using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models.Car;
using Microsoft.AspNetCore.Authorization;
using RentACar.Host.Extensions;
using RentACar.Models;
using RentACar.Managers;

namespace RentACar.Host.Controllers
{
    public class CarsController : Controller
    {
        private readonly AppDbContext _context;
        private IUser _userManager = new UserManager();

        public CarsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                return View(await _context.Cars.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            { 
                if (id == null)
                {
                    return NotFound();
                }

                var car = await _context.Cars
                    .SingleOrDefaultAsync(m => m.CarId == id);
                if (car == null)
                {
                    return NotFound();
                }

                return View(car);
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }
        public IActionResult Create()
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");

            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,Brand,Model,RentFrom,RentTo,ImageUrl,IsTheCarAvailable,PlaceId")] Car car)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                if (ModelState.IsValid)
                {
                    _context.Add(car);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(car);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
       
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.SingleOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,Brand,Model,RentFrom,RentTo,ImageUrl,IsTheCarAvailable,PlaceId")] Car car)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                if (id != car.CarId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(car);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CarExists(car.CarId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(car);
                }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                if (id == null)
                {
                    return NotFound();
                }

                var car = await _context.Cars
                    .SingleOrDefaultAsync(m => m.CarId == id);
                if (car == null)
                {
                    return NotFound();
                }

                return View(car);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
            var car = await _context.Cars.SingleOrDefaultAsync(m => m.CarId == id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        private bool CarExists(int id)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            return _context.Cars.Any(e => e.CarId == id);
        }

        public bool Authorize()
        {
            var _userId = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (_userId == 0)
                return false;
            else
                return true;
        }
    }
}
