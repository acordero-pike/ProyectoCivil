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
    public class ProporcionsController : Controller
    {
        private readonly BomberoContext _context;

        public ProporcionsController(BomberoContext context)
        {
            _context = context;
        }

        // GET: Proporcions
        public async Task<IActionResult> Index()
        {
              return View(await _context.Proporcions.ToListAsync());
        }

        // GET: Proporcions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Proporcions == null)
            {
                return NotFound();
            }

            var proporcion = await _context.Proporcions
                .FirstOrDefaultAsync(m => m.IdProp == id);
            if (proporcion == null)
            {
                return NotFound();
            }

            return View(proporcion);
        }

        // GET: Proporcions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proporcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProp,PTipoProp")] Proporcion proporcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proporcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proporcion);
        }

        // GET: Proporcions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Proporcions == null)
            {
                return NotFound();
            }

            var proporcion = await _context.Proporcions.FindAsync(id);
            if (proporcion == null)
            {
                return NotFound();
            }
            return View(proporcion);
        }

        // POST: Proporcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdProp,PTipoProp")] Proporcion proporcion)
        {
            if (id != proporcion.IdProp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proporcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProporcionExists(proporcion.IdProp))
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
            return View(proporcion);
        }

        // GET: Proporcions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Proporcions == null)
            {
                return NotFound();
            }

            var proporcion = await _context.Proporcions
                .FirstOrDefaultAsync(m => m.IdProp == id);
            if (proporcion == null)
            {
                return NotFound();
            }

            return View(proporcion);
        }

        // POST: Proporcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Proporcions == null)
            {
                return Problem("Entity set 'BomberoContext.Proporcions'  is null.");
            }
            var proporcion = await _context.Proporcions.FindAsync(id);
            if (proporcion != null)
            {
                _context.Proporcions.Remove(proporcion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProporcionExists(string id)
        {
          return _context.Proporcions.Any(e => e.IdProp == id);
        }
    }
}
