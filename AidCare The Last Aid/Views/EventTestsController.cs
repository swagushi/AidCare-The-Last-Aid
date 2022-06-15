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
    public class EventTestsController : Controller
    {
        private readonly AidCareContext _context;

        public EventTestsController(AidCareContext context)
        {
            _context = context;
        }

        // GET: EventTests
        public async Task<IActionResult> Index()
        {
              return _context.EventTest != null ? 
                          View(await _context.EventTest.ToListAsync()) :
                          Problem("Entity set 'AidCareContext.EventTest'  is null.");
        }

        // GET: EventTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventTest == null)
            {
                return NotFound();
            }

            var eventTest = await _context.EventTest
                .FirstOrDefaultAsync(m => m.EventTestId == id);
            if (eventTest == null)
            {
                return NotFound();
            }

            return View(eventTest);
        }

        // GET: EventTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventTestId,EventName,EventLocation,DateTime")] EventTest eventTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventTest);
        }

        // GET: EventTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventTest == null)
            {
                return NotFound();
            }

            var eventTest = await _context.EventTest.FindAsync(id);
            if (eventTest == null)
            {
                return NotFound();
            }
            return View(eventTest);
        }

        // POST: EventTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventTestId,EventName,EventLocation,DateTime")] EventTest eventTest)
        {
            if (id != eventTest.EventTestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTestExists(eventTest.EventTestId))
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
            return View(eventTest);
        }

        // GET: EventTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventTest == null)
            {
                return NotFound();
            }

            var eventTest = await _context.EventTest
                .FirstOrDefaultAsync(m => m.EventTestId == id);
            if (eventTest == null)
            {
                return NotFound();
            }

            return View(eventTest);
        }

        // POST: EventTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventTest == null)
            {
                return Problem("Entity set 'AidCareContext.EventTest'  is null.");
            }
            var eventTest = await _context.EventTest.FindAsync(id);
            if (eventTest != null)
            {
                _context.EventTest.Remove(eventTest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventTestExists(int id)
        {
          return (_context.EventTest?.Any(e => e.EventTestId == id)).GetValueOrDefault();
        }
    }
}
