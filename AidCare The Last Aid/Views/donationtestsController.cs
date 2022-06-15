using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AidCare_The_Last_Aid.Areas.Identity.Data;
using AidCare_The_Last_Aid.Models;

namespace AidCare_The_Last_Aid.Views
{
    public class donationtestsController : Controller
    {
        private readonly AidCareContext _context;

        public donationtestsController(AidCareContext context)
        {
            _context = context;
        }

        // GET: donationtests
        public async Task<IActionResult> Index()
        {
              return _context.donationtest != null ? 
                          View(await _context.donationtest.ToListAsync()) :
                          Problem("Entity set 'AidCareContext.donationtest'  is null.");
        }

        // GET: donationtests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.donationtest == null)
            {
                return NotFound();
            }

            var donationtest = await _context.donationtest
                .FirstOrDefaultAsync(m => m.donationtestId == id);
            if (donationtest == null)
            {
                return NotFound();
            }

            return View(donationtest);
        }

        // GET: donationtests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: donationtests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("donationtestId,donationDescription,DonationAmount")] donationtest donationtest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donationtest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donationtest);
        }

        // GET: donationtests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.donationtest == null)
            {
                return NotFound();
            }

            var donationtest = await _context.donationtest.FindAsync(id);
            if (donationtest == null)
            {
                return NotFound();
            }
            return View(donationtest);
        }

        // POST: donationtests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("donationtestId,donationDescription,DonationAmount")] donationtest donationtest)
        {
            if (id != donationtest.donationtestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donationtest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!donationtestExists(donationtest.donationtestId))
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
            return View(donationtest);
        }

        // GET: donationtests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.donationtest == null)
            {
                return NotFound();
            }

            var donationtest = await _context.donationtest
                .FirstOrDefaultAsync(m => m.donationtestId == id);
            if (donationtest == null)
            {
                return NotFound();
            }

            return View(donationtest);
        }

        // POST: donationtests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.donationtest == null)
            {
                return Problem("Entity set 'AidCareContext.donationtest'  is null.");
            }
            var donationtest = await _context.donationtest.FindAsync(id);
            if (donationtest != null)
            {
                _context.donationtest.Remove(donationtest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool donationtestExists(int id)
        {
          return (_context.donationtest?.Any(e => e.donationtestId == id)).GetValueOrDefault();
        }
    }
}
