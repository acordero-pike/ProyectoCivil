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

public class EstacionsController : Controller
    {
        private readonly BomberoContext _context;

        public EstacionsController(BomberoContext context)
        {
            _context = context;
        }

        // GET: Estacions
        public async Task<IActionResult> Index()
        {
              return View(await _context.Estacions.ToListAsync());
        }

        // GET: Estacions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Estacions == null)
            {
                return NotFound();
            }

            var estacion = await _context.Estacions
                .FirstOrDefaultAsync(m => m.IdEstacion == id);
            if (estacion == null)
            {
                return NotFound();
            }

            return View(estacion);
        }

        // GET: Estacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstacion,Nombre,Descripcion")] Estacion estacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estacion);
        }

        // GET: Estacions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Estacions == null)
            {
                return NotFound();
            }

            var estacion = await _context.Estacions.FindAsync(id);
            if (estacion == null)
            {
                return NotFound();
            }
            return View(estacion);
        }

        // POST: Estacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdEstacion,Nombre,Descripcion")] Estacion estacion)
        {
            if (id != estacion.IdEstacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacionExists(estacion.IdEstacion))
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
            return View(estacion);
        }

        // GET: Estacions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Estacions == null)
            {
                return NotFound();
            }

            var estacion = await _context.Estacions
                .FirstOrDefaultAsync(m => m.IdEstacion == id);
            if (estacion == null)
            {
                return NotFound();
            }

            return View(estacion);
        }

        // POST: Estacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Estacions == null)
            {
                return Problem("Entity set 'BomberoContext.Estacions'  is null.");
            }
            var estacion = await _context.Estacions.FindAsync(id);
            if (estacion != null)
            {
                _context.Estacions.Remove(estacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstacionExists(string id)
        {
          return _context.Estacions.Any(e => e.IdEstacion == id);
        }
    }
}
