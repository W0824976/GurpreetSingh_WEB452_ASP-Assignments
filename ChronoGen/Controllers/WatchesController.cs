using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChronoGen.Data;
using ChronoGen.Models;

namespace ChronoGen.Controllers
{
    public class WatchesController : Controller
    {
        private readonly ChronoGenContext _context;

        public WatchesController(ChronoGenContext context)
        {
            _context = context;
        }

        // GET: Watches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Watch.ToListAsync());
        }

        // GET: Watches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = await _context.Watch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watch == null)
            {
                return NotFound();
            }

            return View(watch);
        }

        // GET: Watches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Watches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WatchName,DesignerName,Material,Size,ReleaseDate,Price,CustomerReview")] Watch watch)
        {
            if (ModelState.IsValid)
            {
                double customerReview = watch.CustomerReview;                //Get rating based on customer review
                if (customerReview <= 1.5)
                {
                    watch.Rating = "Below Average";
                }
                else if (customerReview >= 1.5 && customerReview <= 3)
                {
                    watch.Rating = " Average";
                }
                else
                {
                    watch.Rating = "Excellent";
                }
                _context.Add(watch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(watch);
        }

        // GET: Watches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = await _context.Watch.FindAsync(id);
            if (watch == null)
            {
                return NotFound();
            }
            return View(watch);
        }

        // POST: Watches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WatchName,DesignerName,Material,Size,ReleaseDate,Price,CustomerReview,Rating")] Watch watch)
        {
            if (id != watch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                double customerReview = watch.CustomerReview;            //Get rating based on customer review
                if (customerReview <= 1.5)
                {
                    watch.Rating = "Below Average";
                }
                else if (customerReview >= 1.5 && customerReview <= 3.9)
                {
                    watch.Rating = " Average";
                }
                else
                {
                    watch.Rating = "Excellent";
                }
                try
                {
                    _context.Update(watch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchExists(watch.Id))
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
            return View(watch);
        }

        // GET: Watches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watch = await _context.Watch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watch == null)
            {
                return NotFound();
            }

            return View(watch);
        }

        // POST: Watches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var watch = await _context.Watch.FindAsync(id);
            _context.Watch.Remove(watch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatchExists(int id)
        {
            return _context.Watch.Any(e => e.Id == id);
        }
    }
}
