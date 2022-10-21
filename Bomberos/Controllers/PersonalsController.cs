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
    public class PersonalsController : Controller
    {
        private readonly BomberoContext _context;

        public PersonalsController(BomberoContext context)
        {
            _context = context;
        }

        // GET: Personals
        public async Task<IActionResult> Index()
        {
              return View(await _context.Personals.ToListAsync());
        }

        // GET: Personals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals
                .FirstOrDefaultAsync(m => m.IdPersonal == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // GET: Personals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonal,Nombres,Apellidos,Telefono,Direccion,Puesto")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personal);
        }

        // GET: Personals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }
            return View(personal);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPersonal,Nombres,Apellidos,Telefono,Direccion,Puesto")] Personal personal)
        {
            if (id != personal.IdPersonal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalExists(personal.IdPersonal))
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
            return View(personal);
        }

        // GET: Personals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals
                .FirstOrDefaultAsync(m => m.IdPersonal == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                if (_context.Personals == null)
                {
                    return Problem("Entity set 'BomberoContext.Personals'  is null.");
                }
                var personal = await _context.Personals.FindAsync(id);
                if (personal != null)
                {
                    _context.Personals.Remove(personal);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { data = "Error al eliminar Miembro de Personal!!", data2 = "Este campo esta siendo utilizado" });

            }
        }

        private bool PersonalExists(string id)
        {
          return _context.Personals.Any(e => e.IdPersonal == id);
        }
    }
}
