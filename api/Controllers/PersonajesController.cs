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
    [Authorize]
    public class PersonajesController : Controller
    {
        private readonly RickymortyContext _context;

        public PersonajesController(RickymortyContext context)
        {
            _context = context;
        }

        // GET: Personajes
        public async Task<IActionResult> Index()
        {
              return _context.Personajes != null ? 
                          View(await _context.Personajes.ToListAsync()) :
                          Problem("Entity set 'RickymortyContext.Personajes'  is null.");
        }

        // GET: Personajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personajes == null)
            {
                return NotFound();
            }

            var personaje = await _context.Personajes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaje == null)
            {
                return NotFound();
            }

            return View(personaje);
        }

        // GET: Personajes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Genero,Especie")] Personaje personaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personaje);
        }

        // GET: Personajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personajes == null)
            {
                return NotFound();
            }

            var personaje = await _context.Personajes.FindAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }
            return View(personaje);
        }

        // POST: Personajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Genero,Especie")] Personaje personaje)
        {
            if (id != personaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonajeExists(personaje.Id))
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
            return View(personaje);
        }

        // GET: Personajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personajes == null)
            {
                return NotFound();
            }

            var personaje = await _context.Personajes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaje == null)
            {
                return NotFound();
            }

            return View(personaje);
        }

        // POST: Personajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personajes == null)
            {
                return Problem("Entity set 'RickymortyContext.Personajes'  is null.");
            }
            var personaje = await _context.Personajes.FindAsync(id);
            if (personaje != null)
            {
                _context.Personajes.Remove(personaje);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonajeExists(int id)
        {
          return (_context.Personajes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
