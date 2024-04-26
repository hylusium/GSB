using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GSB_GCR.Models;

namespace GSB_GCR.Controllers
{
    public class FamillesController : Controller
    {
        private readonly GSB_GCRContext _context;

        public FamillesController(GSB_GCRContext context)
        {
            _context = context;
        }

        // GET: Familles
        public async Task<IActionResult> Index()
        {
              return _context.Familles != null ? 
                          View(await _context.Familles.ToListAsync()) :
                          Problem("Entity set 'GSB_GCRContext.Familles'  is null.");
        }

        // GET: Familles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Familles == null)
            {
                return NotFound();
            }

            var famille = await _context.Familles.Include(m=>m.Medicaments)
                .FirstOrDefaultAsync(m => m.FamCode == id);
            if (famille == null)
            {
                return NotFound();
            }

            return View(famille);
        }

        // GET: Familles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Familles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FamCode,FamLibelle")] Famille famille)
        {
            if (ModelState.IsValid)
            {
                _context.Add(famille);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(famille);
        }

        // GET: Familles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Familles == null)
            {
                return NotFound();
            }

            var famille = await _context.Familles.FindAsync(id);
            if (famille == null)
            {
                return NotFound();
            }
            return View(famille);
        }

        // POST: Familles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FamCode,FamLibelle")] Famille famille)
        {
            if (id != famille.FamCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(famille);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamilleExists(famille.FamCode))
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
            return View(famille);
        }

        // GET: Familles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Familles == null)
            {
                return NotFound();
            }

            var famille = await _context.Familles
                .FirstOrDefaultAsync(m => m.FamCode == id);
            if (famille == null)
            {
                return NotFound();
            }

            return View(famille);
        }

        // POST: Familles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Familles == null)
            {
                return Problem("Entity set 'GSB_GCRContext.Familles'  is null.");
            }
            var famille = await _context.Familles.FindAsync(id);
            if (famille != null)
            {
                _context.Familles.Remove(famille);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamilleExists(string id)
        {
          return (_context.Familles?.Any(e => e.FamCode == id)).GetValueOrDefault();
        }
    }
}
