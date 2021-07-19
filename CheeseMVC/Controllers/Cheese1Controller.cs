using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheeseMVC.Models;

namespace CheeseMVC.Controllers
{
    public class Cheese1Controller : Controller
    {
        private readonly ApplicationDBContext _context;

        public Cheese1Controller(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Cheese1
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Cheese.Include(c => c.Category);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Cheese1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheese = await _context.Cheese
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cheese == null)
            {
                return NotFound();
            }

            return View(cheese);
        }

        // GET: Cheese1/Create
        public IActionResult Create()
        {
           
            ViewData["CategoryID"] = new SelectList(_context.CheeseCategory, "ID", "ID");
            return View();
        }

        // POST: Cheese1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CategoryID")] Cheese cheese)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cheese);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.CheeseCategory, "ID", "ID", cheese.CategoryID);
            return View(cheese);
        }

        // GET: Cheese1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheese = await _context.Cheese.FindAsync(id);
            if (cheese == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.CheeseCategory, "ID", "ID", cheese.CategoryID);
            return View(cheese);
        }

        // POST: Cheese1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CategoryID")] Cheese cheese)
        {
            if (id != cheese.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cheese);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheeseExists(cheese.ID))
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
            ViewData["CategoryID"] = new SelectList(_context.CheeseCategory, "ID", "ID", cheese.CategoryID);
            return View(cheese);
        }

        // GET: Cheese1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheese = await _context.Cheese
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cheese == null)
            {
                return NotFound();
            }

            return View(cheese);
        }

        // POST: Cheese1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cheese = await _context.Cheese.FindAsync(id);
            _context.Cheese.Remove(cheese);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheeseExists(int id)
        {
            return _context.Cheese.Any(e => e.ID == id);
        }
    }
}
