using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bomberos.Models;
using Microsoft.AspNetCore.Http;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Bomberos.Controllers
{
    [Authorize]
    public class FirmasController : Controller
    {
        private readonly BomberoContext _context;

        public FirmasController(BomberoContext context)
        {
            _context = context;
        }

        // GET: Firmas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Firmas.ToListAsync());
        }

        // GET: Firmas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Firmas == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmas
                .FirstOrDefaultAsync(m => m.IdFirma == id);
            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // GET: Firmas/Create
        public IActionResult Create()
        {
            return View();
        }
        public ActionResult convert(string id)
        {
            var imgs = _context.Firmas.Where(x => x.IdFirma == id).FirstOrDefault();
            return File(imgs.Firma1, "image/jpeg");
        }
        // POST: Firmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFirma,Tipo,Nombre,Firma1")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                var files = Request.Form.Files.First();
               

                WebImage im = new WebImage(files.OpenReadStream());
                firma.Firma1 = im.GetBytes();

                _context.Add(firma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firma);
        }

        // GET: Firmas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Firmas == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmas.FindAsync(id);
            if (firma == null)
            {
                return NotFound();
            }
            return View(firma);
        }

        // POST: Firmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdFirma,Tipo,Nombre,Firma1")] Firma firma)
        {
            if (id != firma.IdFirma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirmaExists(firma.IdFirma))
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
            return View(firma);
        }

        // GET: Firmas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Firmas == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmas
                .FirstOrDefaultAsync(m => m.IdFirma == id);
            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // POST: Firmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Firmas == null)
            {
                return Problem("Entity set 'BomberoContext.Firmas'  is null.");
            }
            var firma = await _context.Firmas.FindAsync(id);
            if (firma != null)
            {
                _context.Firmas.Remove(firma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirmaExists(string id)
        {
          return _context.Firmas.Any(e => e.IdFirma == id);
        }
    }
}
