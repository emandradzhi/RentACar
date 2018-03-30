using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models.Place;
using RentACar.Host.Extensions;
using Microsoft.AspNetCore.Http;

namespace RentACar.Host.Controllers
{
    public class PlacesController : Controller
    {
        private readonly AppDbContext _context;

        public PlacesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Places
        public async Task<IActionResult> Index()
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                return View(await _context.Places.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: Places/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                if (id == null)
                {
                    return NotFound();
                }

                var place = await _context.Places
                    .SingleOrDefaultAsync(m => m.PlaceId == id);
                if (place == null)
                {
                    return NotFound();
                }

                return View(place);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: Places/Create
        public IActionResult Create()
        {
            if (Authorize())
            {
                ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceId,Name,Region,Country")] Place place)
        {
            if (Authorize())
            {
                ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
                if (ModelState.IsValid)
                {
                    _context.Add(place);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(place);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: Places/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                if (id == null)
                {
                    return NotFound();
                }

                var place = await _context.Places.SingleOrDefaultAsync(m => m.PlaceId == id);
                if (place == null)
                {
                    return NotFound();
                }
                return View(place);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceId,Name,Region,Country")] Place place)
        {

            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                if (id != place.PlaceId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(place);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PlaceExists(place.PlaceId))
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
                return View(place);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: Places/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                if (id == null)
                {
                    return NotFound();
                }

                var place = await _context.Places
                    .SingleOrDefaultAsync(m => m.PlaceId == id);
                if (place == null)
                {
                    return NotFound();
                }

                return View(place);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }


        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["UserId"] = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (Authorize())
            {
                var place = await _context.Places.SingleOrDefaultAsync(m => m.PlaceId == id);
                _context.Places.Remove(place);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        private bool PlaceExists(int id)
        {
            return _context.Places.Any(e => e.PlaceId == id);
        }

        private bool Authorize()
        {
            var _userId = HttpContext.Session.GetObjectFromJson<int>("UserId");
            if (_userId == 0)
                return false;
            else
                return true;
        }
    }
}
