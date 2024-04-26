using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GSB_GCR.Models;
using Microsoft.AspNetCore.Authorization;

namespace GSB_GCR.Controllers
{
    [Authorize]
    public class PraticiensController : Controller
    {
        private readonly GSB_GCRContext _context;

        public PraticiensController(GSB_GCRContext context)
        {
            _context = context;
        }

        // GET: Praticiens
        public async Task<IActionResult> Index()
        {
            var gSB_GCRContext = _context.Praticiens.Include(p => p.TypCodeNavigation);
            return View(await gSB_GCRContext.ToListAsync());
        }

        // GET: Praticiens/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.Praticiens == null)
            {
                return NotFound();
            }

            var praticien = await _context.Praticiens
                .Include(p => p.TypCodeNavigation)
                .FirstOrDefaultAsync(m => m.PraNum == id);
            if (praticien == null)
            {
                return NotFound();
            }

            return View(praticien);
        }

        // GET: Praticiens/Create
        public IActionResult Create()
        {
            ViewData["TypCode"] = new SelectList(_context.TypePraticiens, "TypCode", "TypCode");
            return View();
        }

        // POST: Praticiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PraNum,PraNom,PraPrenom,PraAdresse,PraCp,PraVille,PraCoefnotoriete,TypCode,SsmaTimeStamp")] Praticien praticien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(praticien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypCode"] = new SelectList(_context.TypePraticiens, "TypCode", "TypCode", praticien.TypCode);
            return View(praticien);
        }

        // GET: Praticiens/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null || _context.Praticiens == null)
            {
                return NotFound();
            }

            var praticien = await _context.Praticiens.FindAsync(id);
            if (praticien == null)
            {
                return NotFound();
            }
            ViewData["TypCode"] = new SelectList(_context.TypePraticiens, "TypCode", "TypCode", praticien.TypCode);
            return View(praticien);
        }

        // POST: Praticiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("PraNum,PraNom,PraPrenom,PraAdresse,PraCp,PraVille,PraCoefnotoriete,TypCode,SsmaTimeStamp")] Praticien praticien)
        {
            if (id != praticien.PraNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(praticien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PraticienExists(praticien.PraNum))
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
            ViewData["TypCode"] = new SelectList(_context.TypePraticiens, "TypCode", "TypCode", praticien.TypCode);
            return View(praticien);
        }

        // GET: Praticiens/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.Praticiens == null)
            {
                return NotFound();
            }

            var praticien = await _context.Praticiens
                .Include(p => p.TypCodeNavigation)
                .FirstOrDefaultAsync(m => m.PraNum == id);
            if (praticien == null)
            {
                return NotFound();
            }

            return View(praticien);
        }

        // POST: Praticiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.Praticiens == null)
            {
                return Problem("Entity set 'GSB_GCRContext.Praticiens'  is null.");
            }
            var praticien = await _context.Praticiens.FindAsync(id);
            if (praticien != null)
            {
                _context.Praticiens.Remove(praticien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PraticienExists(short id)
        {
          return (_context.Praticiens?.Any(e => e.PraNum == id)).GetValueOrDefault();
        }
    }
}
