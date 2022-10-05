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

    public class CompañiumController : Controller
    {
        private readonly BomberoContext _context;

        public CompañiumController(BomberoContext context)
        {
            _context = context;
        }

        // GET: Compañium
        public async Task<IActionResult> Index()
        {
              return View(await _context.Compañia.ToListAsync());
        }

        // GET: Compañium/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Compañia == null)
            {
                return NotFound();
            }

            var compañium = await _context.Compañia
                .FirstOrDefaultAsync(m => m.IdCompañia == id);
            if (compañium == null)
            {
                return NotFound();
            }

            return View(compañium);
        }

        // GET: Compañium/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compañium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompañia,Nombre,Descripcion")] Compañium compañium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compañium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compañium);
        }

        // GET: Compañium/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Compañia == null)
            {
                return NotFound();
            }

            var compañium = await _context.Compañia.FindAsync(id);
            if (compañium == null)
            {
                return NotFound();
            }
            return View(compañium);
        }

        // POST: Compañium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCompañia,Nombre,Descripcion")] Compañium compañium)
        {
            if (id != compañium.IdCompañia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compañium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompañiumExists(compañium.IdCompañia))
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
            return View(compañium);
        }

        // GET: Compañium/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Compañia == null)
            {
                return NotFound();
            }

            var compañium = await _context.Compañia
                .FirstOrDefaultAsync(m => m.IdCompañia == id);
            if (compañium == null)
            {
                return NotFound();
            }

            return View(compañium);
        }

        // POST: Compañium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Compañia == null)
            {
                return Problem("Entity set 'BomberoContext.Compañia'  is null.");
            }
            var compañium = await _context.Compañia.FindAsync(id);
            if (compañium != null)
            {
                _context.Compañia.Remove(compañium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompañiumExists(string id)
        {
          return _context.Compañia.Any(e => e.IdCompañia == id);
        }
    }
}
