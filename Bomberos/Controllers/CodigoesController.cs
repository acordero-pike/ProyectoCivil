using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bomberos.Models;

namespace Bomberos.Controllers
{
    public class CodigoesController : Controller
    {
        private readonly BomberoContext _context;

        public CodigoesController(BomberoContext context)
        {
            _context = context;
        }

        // GET: Codigoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Codigos.ToListAsync());
        }

        // GET: Codigoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Codigos == null)
            {
                return NotFound();
            }

            var codigo = await _context.Codigos
                .FirstOrDefaultAsync(m => m.Uuid == id);
            if (codigo == null)
            {
                return NotFound();
            }

            return View(codigo);
        }

        // GET: Codigoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Codigoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Uuid,Codigo1,Descripcion")] Codigo codigo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codigo);
        }

        // GET: Codigoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Codigos == null)
            {
                return NotFound();
            }

            var codigo = await _context.Codigos.FindAsync(id);
            if (codigo == null)
            {
                return NotFound();
            }
            return View(codigo);
        }

        // POST: Codigoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Uuid,Codigo1,Descripcion")] Codigo codigo)
        {
            if (id != codigo.Uuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodigoExists(codigo.Uuid))
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
            return View(codigo);
        }

        // GET: Codigoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Codigos == null)
            {
                return NotFound();
            }

            var codigo = await _context.Codigos
                .FirstOrDefaultAsync(m => m.Uuid == id);
            if (codigo == null)
            {
                return NotFound();
            }

            return View(codigo);
        }

        // POST: Codigoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                if (_context.Codigos == null)
                {
                    return Problem("Entity set 'BomberoContext.Codigos'  is null.");
                }
                var codigo = await _context.Codigos.FindAsync(id);
                if (codigo != null)
                {
                    _context.Codigos.Remove(codigo);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { data = "Error al eliminar Codigo de Servicio!!", data2 = "Este campo esta siendo utilizado" });

            }
        }

        private bool CodigoExists(string id)
        {
          return _context.Codigos.Any(e => e.Uuid == id);
        }
    }
}
