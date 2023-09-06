using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    
    public class RankingsController : Controller
    {
        private readonly RickymortyContext _context;

        public RankingsController(RickymortyContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Rankings
        public async Task<IActionResult> Index()
        {
            var rickymortyContext = _context.Rankings.Include(r => r.IdPerNavigation);
            return View(await rickymortyContext.ToListAsync());
        }

        // GET: Rankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rankings == null)
            {
                return NotFound();
            }

            var ranking = await _context.Rankings
                .Include(r => r.IdPerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // GET: Rankings/Create
        public IActionResult Create()
        {
            ViewData["IdPer"] = new SelectList(_context.Personajes, "Id", "Id");
            return View();
        }

        // POST: Rankings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPer,Calificacion")] Ranking ranking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ranking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPer"] = new SelectList(_context.Personajes, "Id", "Id", ranking.IdPer);
            return View(ranking);
        }

        // GET: Rankings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rankings == null)
            {
                return NotFound();
            }

            var ranking = await _context.Rankings.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }
            ViewData["IdPer"] = new SelectList(_context.Personajes, "Id", "Id", ranking.IdPer);
            return View(ranking);
        }

        // POST: Rankings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPer,Calificacion")] Ranking ranking)
        {
            if (id != ranking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ranking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankingExists(ranking.Id))
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
            ViewData["IdPer"] = new SelectList(_context.Personajes, "Id", "Id", ranking.IdPer);
            return View(ranking);
        }

        // GET: Rankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rankings == null)
            {
                return NotFound();
            }

            var ranking = await _context.Rankings
                .Include(r => r.IdPerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rankings == null)
            {
                return Problem("Entity set 'RickymortyContext.Rankings'  is null.");
            }
            var ranking = await _context.Rankings.FindAsync(id);
            if (ranking != null)
            {
                _context.Rankings.Remove(ranking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankingExists(int id)
        {
          return (_context.Rankings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
