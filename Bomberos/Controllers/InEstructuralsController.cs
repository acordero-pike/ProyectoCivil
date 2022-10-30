using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bomberos.Models;
using Microsoft.AspNetCore.Authorization;
using Rotativa.AspNetCore;

namespace Bomberos.Controllers
{
    [Authorize]

    public class InEstructuralsController : Controller
    {
        private readonly BomberoContext _context;

        public InEstructuralsController(BomberoContext context)
        {
            _context = context;
        }

        // GET: InEstructurals
        public async Task<IActionResult> Index()
        {
            var bomberoContext = _context.InEstructurals.Include(i => i.IdPropNavigation).Include(i => i.IeBomberoReportaNavigation).Include(i => i.IeEstacionNavigation).Include(i => i.IeFirmaBomberoNavigation).Include(i => i.IeIdCfNavigation).Include(i => i.IeJefeServicioNavigation).Include(i => i.IePilotoNavigation).Include(i => i.IeTelefonistaTurnoNavigation).Include(i => i.IeTurnoNavigation).Include(i => i.IeVoBoJefeServicioNavigation);
            return View(await bomberoContext.ToListAsync());
        }

        // GET: InEstructurals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.InEstructurals == null)
            {
                return NotFound();
            }

            var inEstructural = await _context.InEstructurals
                .Include(i => i.CodigoNavigation)
                .Include(i => i.IdPropNavigation)
                .Include(i => i.IeBomberoReportaNavigation)
                .Include(i => i.IeEstacionNavigation)
                .Include(i => i.IeFirmaBomberoNavigation)
                .Include(i => i.IeIdCfNavigation)
                .Include(i => i.IeJefeServicioNavigation)
                .Include(i => i.IePilotoNavigation)
                .Include(i => i.IeTelefonistaTurnoNavigation)
                .Include(i => i.IeTurnoNavigation)
                .Include(i => i.IeVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdIe == id);
            if (inEstructural == null)
            {
                return NotFound();
            }
            return new ViewAsPdf("Details", inEstructural);

           
        }

        // GET: InEstructurals/Create
        public IActionResult Create()
        {
            var empleado = _context.Personals.Select(a => new { Id_Personal = a.IdPersonal, Nombre = a.Nombres + " " + a.Apellidos });
            var users = _context.Usuarios.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.Nombres + " " + a.Apellidos });

            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1");
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "PTipoProp");
            ViewData["IeBomberoReporta"] = new SelectList(users, "IdUsuario", "Nombre");
            ViewData["IeEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "Nombre");
            ViewData["IeFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "Nombre");
            ViewData["IeIdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "CfClasefuego");
            ViewData["IeJefeServicio"] = new SelectList(empleado, "Id_Personal", "Nombre");
            ViewData["IePiloto"] = new SelectList(empleado, "Id_Personal", "Nombre");
            ViewData["IeTelefonistaTurno"] = new SelectList(empleado, "Id_Personal", "Nombre");
            ViewData["IeTurno"] = new SelectList(_context.Turnos, "IdTurno", "Nombre");
            ViewData["IeVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "Nombre");
            return View();
        }

        // POST: InEstructurals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIe,Codigo,IeEstacion,IeTurno,IeUbiSiniestro,IeInmueble,IeValor,IePerdida,IdProp,IeIdCf,IeHoraSalida,IeHoraServicio,IeHoraEntrada,IeJefeServicio,IeTelefonistaTurno,IeBomberoReporta,IePiloto,IeUnidad,IeUniAsisEstacion,IeUniAsisOtraEstacion,IeUniPoliciacas,IeUniOtrasInstiBomberiles,IePersonalAsisEstacion,IePersonalAsisOtraEstacion,IeObservacion,IeFecha,IeKmEntrada,IeKmSalida,IeKmRecorrido,IeFirmaBombero,IeNoBombero,IeVoBoJefeServicio")] InEstructural inEstructural)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inEstructural);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", inEstructural.Codigo );
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "IdProp", inEstructural.IdProp);
            ViewData["IeBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inEstructural.IeBomberoReporta);
            ViewData["IeEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", inEstructural.IeEstacion);
            ViewData["IeFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inEstructural.IeFirmaBombero);
            ViewData["IeIdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "IdCf", inEstructural.IeIdCf);
            ViewData["IeJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inEstructural.IeJefeServicio);
            ViewData["IePiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inEstructural.IePiloto);
            ViewData["IeTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inEstructural.IeTelefonistaTurno);
            ViewData["IeTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", inEstructural.IeTurno);
            ViewData["IeVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inEstructural.IeVoBoJefeServicio);
            return View(inEstructural);
        }

        // GET: InEstructurals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.InEstructurals == null)
            {
                return NotFound();
            }

            var inEstructural = await _context.InEstructurals.FindAsync(id);
            if (inEstructural == null)
            {
                return NotFound();
            }

            var empleado = _context.Personals.Select(a => new { Id_Personal = a.IdPersonal, Nombre = a.Nombres + " " + a.Apellidos });
            var users = _context.Usuarios.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.Nombres + " " + a.Apellidos });

            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", inEstructural.Codigo);
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "PTipoProp", inEstructural.IdProp);
            ViewData["IeBomberoReporta"] = new SelectList(users, "IdUsuario", "Nombre", inEstructural.IeBomberoReporta);
            ViewData["IeEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "Nombre", inEstructural.IeEstacion);
            ViewData["IeFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "Nombre", inEstructural.IeFirmaBombero);
            ViewData["IeIdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "CfClasefuego", inEstructural.IeIdCf);
            ViewData["IeJefeServicio"] = new SelectList(empleado, "Id_Personal", "Nombre", inEstructural.IeJefeServicio);
            ViewData["IePiloto"] = new SelectList(empleado, "Id_Personal", "Nombre", inEstructural.IePiloto);
            ViewData["IeTelefonistaTurno"] = new SelectList(empleado, "Id_Personal", "Nombre", inEstructural.IeTelefonistaTurno);
            ViewData["IeTurno"] = new SelectList(_context.Turnos, "IdTurno", "Nombre", inEstructural.IeTurno);
            ViewData["IeVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "Nombre", inEstructural.IeVoBoJefeServicio);
            return View(inEstructural);
        }

        // POST: InEstructurals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdIe,Codigo,IeEstacion,IeTurno,IeUbiSiniestro,IeInmueble,IeValor,IePerdida,IdProp,IeIdCf,IeHoraSalida,IeHoraServicio,IeHoraEntrada,IeJefeServicio,IeTelefonistaTurno,IeBomberoReporta,IePiloto,IeUnidad,IeUniAsisEstacion,IeUniAsisOtraEstacion,IeUniPoliciacas,IeUniOtrasInstiBomberiles,IePersonalAsisEstacion,IePersonalAsisOtraEstacion,IeObservacion,IeFecha,IeKmEntrada,IeKmSalida,IeKmRecorrido,IeFirmaBombero,IeNoBombero,IeVoBoJefeServicio")] InEstructural inEstructural)
        {
            if (id != inEstructural.IdIe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inEstructural);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InEstructuralExists(inEstructural.IdIe))
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
            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", inEstructural.Codigo);
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "IdProp", inEstructural.IdProp);
            ViewData["IeBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inEstructural.IeBomberoReporta);
            ViewData["IeEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", inEstructural.IeEstacion);
            ViewData["IeFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inEstructural.IeFirmaBombero);
            ViewData["IeIdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "IdCf", inEstructural.IeIdCf);
            ViewData["IeJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inEstructural.IeJefeServicio);
            ViewData["IePiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inEstructural.IePiloto);
            ViewData["IeTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inEstructural.IeTelefonistaTurno);
            ViewData["IeTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", inEstructural.IeTurno);
            ViewData["IeVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inEstructural.IeVoBoJefeServicio);
            return View(inEstructural);
        }

        // GET: InEstructurals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.InEstructurals == null)
            {
                return NotFound();
            }

            var inEstructural = await _context.InEstructurals
                .Include(i => i.CodigoNavigation)
                .Include(i => i.IdPropNavigation)
                .Include(i => i.IeBomberoReportaNavigation)
                .Include(i => i.IeEstacionNavigation)
                .Include(i => i.IeFirmaBomberoNavigation)
                .Include(i => i.IeIdCfNavigation)
                .Include(i => i.IeJefeServicioNavigation)
                .Include(i => i.IePilotoNavigation)
                .Include(i => i.IeTelefonistaTurnoNavigation)
                .Include(i => i.IeTurnoNavigation)
                .Include(i => i.IeVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdIe == id);
            if (inEstructural == null)
            {
                return NotFound();
            }

            return View(inEstructural);
        }

        // POST: InEstructurals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.InEstructurals == null)
            {
                return Problem("Entity set 'BomberoContext.InEstructurals'  is null.");
            }
            var inEstructural = await _context.InEstructurals.FindAsync(id);
            if (inEstructural != null)
            {
                _context.InEstructurals.Remove(inEstructural);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InEstructuralExists(string id)
        {
          return _context.InEstructurals.Any(e => e.IdIe == id);
        }
    }
}
