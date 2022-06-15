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
    public class membertestsController : Controller
    {
        private readonly AidCareContext _context;

        public membertestsController(AidCareContext context)
        {
            _context = context;
        }

        // GET: membertests
        public async Task<IActionResult> Index()
        {
              return _context.membertest != null ? 
                          View(await _context.membertest.ToListAsync()) :
                          Problem("Entity set 'AidCareContext.membertest'  is null.");
        }

        // GET: membertests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.membertest == null)
            {
                return NotFound();
            }

            var membertest = await _context.membertest
                .FirstOrDefaultAsync(m => m.membertestId == id);
            if (membertest == null)
            {
                return NotFound();
            }

            return View(membertest);
        }

        // GET: membertests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: membertests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("membertestId,FirstName,LastName,DateTime")] membertest membertest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membertest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membertest);
        }

        // GET: membertests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.membertest == null)
            {
                return NotFound();
            }

            var membertest = await _context.membertest.FindAsync(id);
            if (membertest == null)
            {
                return NotFound();
            }
            return View(membertest);
        }

        // POST: membertests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("membertestId,FirstName,LastName,DateTime")] membertest membertest)
        {
            if (id != membertest.membertestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membertest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!membertestExists(membertest.membertestId))
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
            return View(membertest);
        }

        // GET: membertests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.membertest == null)
            {
                return NotFound();
            }

            var membertest = await _context.membertest
                .FirstOrDefaultAsync(m => m.membertestId == id);
            if (membertest == null)
            {
                return NotFound();
            }

            return View(membertest);
        }

        // POST: membertests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.membertest == null)
            {
                return Problem("Entity set 'AidCareContext.membertest'  is null.");
            }
            var membertest = await _context.membertest.FindAsync(id);
            if (membertest != null)
            {
                _context.membertest.Remove(membertest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool membertestExists(int id)
        {
          return (_context.membertest?.Any(e => e.membertestId == id)).GetValueOrDefault();
        }
    }
}
