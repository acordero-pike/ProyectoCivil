using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bomberos.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bomberos.Controllers
{
    [Authorize]

    public class ClaseFuegoesController : Controller
    {
        private readonly BomberoContext _context;

        public ClaseFuegoesController(BomberoContext context)
        {
            _context = context;
        }

        // GET: ClaseFuegoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.ClaseFuegos.ToListAsync());
        }

        // GET: ClaseFuegoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ClaseFuegos == null)
            {
                return NotFound();
            }

            var claseFuego = await _context.ClaseFuegos
                .FirstOrDefaultAsync(m => m.IdCf == id);
            if (claseFuego == null)
            {
                return NotFound();
            }

            return View(claseFuego);
        }

        // GET: ClaseFuegoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClaseFuegoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCf,CfClasefuego")] ClaseFuego claseFuego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claseFuego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(claseFuego);
        }

        // GET: ClaseFuegoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ClaseFuegos == null)
            {
                return NotFound();
            }

            var claseFuego = await _context.ClaseFuegos.FindAsync(id);
            if (claseFuego == null)
            {
                return NotFound();
            }
            return View(claseFuego);
        }

        // POST: ClaseFuegoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCf,CfClasefuego")] ClaseFuego claseFuego)
        {
            if (id != claseFuego.IdCf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claseFuego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaseFuegoExists(claseFuego.IdCf))
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
            return View(claseFuego);
        }

        // GET: ClaseFuegoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ClaseFuegos == null)
            {
                return NotFound();
            }

            var claseFuego = await _context.ClaseFuegos
                .FirstOrDefaultAsync(m => m.IdCf == id);
            if (claseFuego == null)
            {
                return NotFound();
            }

            return View(claseFuego);
        }

        // POST: ClaseFuegoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ClaseFuegos == null)
            {
                return Problem("Entity set 'BomberoContext.ClaseFuegos'  is null.");
            }
            var claseFuego = await _context.ClaseFuegos.FindAsync(id);
            if (claseFuego != null)
            {
                _context.ClaseFuegos.Remove(claseFuego);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaseFuegoExists(string id)
        {
          return _context.ClaseFuegos.Any(e => e.IdCf == id);
        }
    }
}
