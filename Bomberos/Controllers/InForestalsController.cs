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

    public class InForestalsController : Controller
    {
        private readonly BomberoContext _context;

        public InForestalsController(BomberoContext context)
        {
            _context = context;
        }

        // GET: InForestals
        public async Task<IActionResult> Index()
        {
            var bomberoContext = _context.InForestals.Include(i => i.IdCfNavigation).Include(i => i.IdPropNavigation).Include(i => i.IfBomberoReportaNavigation).Include(i => i.IfEstacionNavigation).Include(i => i.IfFirmaBomberoNavigation).Include(i => i.IfJefeServicioNavigation).Include(i => i.IfPilotoNavigation).Include(i => i.IfTelefonistaTurnoNavigation).Include(i => i.IfTurnoNavigation).Include(i => i.IfVoBoJefeServicioNavigation);
            return View(await bomberoContext.ToListAsync());
        }

        // GET: InForestals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.InForestals == null)
            {
                return NotFound();
            }

            var inForestal = await _context.InForestals
                .Include(i => i.CodigoNavigation)
                .Include(i => i.IdCfNavigation)
                .Include(i => i.IdPropNavigation)
                .Include(i => i.IfBomberoReportaNavigation)
                .Include(i => i.IfEstacionNavigation)
                .Include(i => i.IfFirmaBomberoNavigation)
                .Include(i => i.IfJefeServicioNavigation)
                .Include(i => i.IfPilotoNavigation)
                .Include(i => i.IfTelefonistaTurnoNavigation)
                .Include(i => i.IfTurnoNavigation)
                .Include(i => i.IfVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdIf == id);
            if (inForestal == null)
            {
                return NotFound();
            }

            return View(inForestal);
        }

        // GET: InForestals/Create
        public IActionResult Create()
        {
            var empleado = _context.Personals.Select(a => new { Id_Personal = a.IdPersonal, Nombre = a.Nombres + " " + a.Apellidos });
            var users = _context.Usuarios.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.Nombres + " " + a.Apellidos });

            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1");
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "CfClasefuego");
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "PTipoProp");
            ViewData["IfBomberoReporta"] = new SelectList(users, "IdUsuario", "Nombre");
            ViewData["IfEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "Nombre");
            ViewData["IfFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "Nombre");
            ViewData["IfJefeServicio"] = new SelectList(empleado, "Id_Personal", "Nombre");
            ViewData["IfPiloto"] = new SelectList(empleado, "Id_Personal", "Nombre");
            ViewData["IfTelefonistaTurno"] = new SelectList(empleado, "Id_Personal", "Nombre");
            ViewData["IfTurno"] = new SelectList(_context.Turnos, "IdTurno", "Nombre");
            ViewData["IfVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "Nombre");
            return View();
        }

        // POST: InForestals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIf,Codigo,IfEstacion,IfTurno,IfUbiSiniestro,IfAreaAfectada,IfTipoTerreno,IdProp,IdCf,IfHoraSalida,IfHoraServicio,IfHoraEntrada,IfJefeServicio,IfTelefonistaTurno,IfBomberoReporta,IfPiloto,IfUnidad,IfUniAsisEstacion,IfUniAsisOtraEstacion,IfUniPoliciacas,IfUniOtrasInstiBomberiles,IfPersonalAsisEstacion,IfPersonalAsisOtraEstacion,IfObservacion,IfFecha,IfKmEntrada,IfKmSalida,IfKmRecorrido,IfFirmaBombero,IfNoBombero,IfVoBoJefeServicio")] InForestal inForestal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inForestal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", inForestal.Codigo);
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "IdCf", inForestal.IdCf);
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "IdProp", inForestal.IdProp);
            ViewData["IfBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inForestal.IfBomberoReporta);
            ViewData["IfEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", inForestal.IfEstacion);
            ViewData["IfFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inForestal.IfFirmaBombero);
            ViewData["IfJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inForestal.IfJefeServicio);
            ViewData["IfPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inForestal.IfPiloto);
            ViewData["IfTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inForestal.IfTelefonistaTurno);
            ViewData["IfTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", inForestal.IfTurno);
            ViewData["IfVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inForestal.IfVoBoJefeServicio);
            return View(inForestal);
        }

        // GET: InForestals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.InForestals == null)
            {
                return NotFound();
            }

            var inForestal = await _context.InForestals.FindAsync(id);
            if (inForestal == null)
            {
                return NotFound();
            }
            var empleado = _context.Personals.Select(a => new { Id_Personal = a.IdPersonal, Nombre = a.Nombres + " " + a.Apellidos });
            var users = _context.Usuarios.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.Nombres + " " + a.Apellidos });

            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", inForestal.Codigo);
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "CfClasefuego", inForestal.IdCf);
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "PTipoProp", inForestal.IdProp);
            ViewData["IfBomberoReporta"] = new SelectList(users, "IdUsuario", "Nombre", inForestal.IfBomberoReporta);
            ViewData["IfEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "Nombre", inForestal.IfEstacion);
            ViewData["IfFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "Nombre", inForestal.IfFirmaBombero);
            ViewData["IfJefeServicio"] = new SelectList(empleado, "Id_Personal", "Nombre", inForestal.IfJefeServicio);
            ViewData["IfPiloto"] = new SelectList(empleado, "Id_Personal", "Nombre", inForestal.IfPiloto);
            ViewData["IfTelefonistaTurno"] = new SelectList(empleado, "Id_Personal", "Nombre", inForestal.IfTelefonistaTurno);
            ViewData["IfTurno"] = new SelectList(_context.Turnos, "IdTurno", "Nombre", inForestal.IfTurno);
            ViewData["IfVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "Nombre", inForestal.IfVoBoJefeServicio);
            return View(inForestal);
        }

        // POST: InForestals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdIf,Codigo,IfEstacion,IfTurno,IfUbiSiniestro,IfAreaAfectada,IfTipoTerreno,IdProp,IdCf,IfHoraSalida,IfHoraServicio,IfHoraEntrada,IfJefeServicio,IfTelefonistaTurno,IfBomberoReporta,IfPiloto,IfUnidad,IfUniAsisEstacion,IfUniAsisOtraEstacion,IfUniPoliciacas,IfUniOtrasInstiBomberiles,IfPersonalAsisEstacion,IfPersonalAsisOtraEstacion,IfObservacion,IfFecha,IfKmEntrada,IfKmSalida,IfKmRecorrido,IfFirmaBombero,IfNoBombero,IfVoBoJefeServicio")] InForestal inForestal)
        {
            if (id != inForestal.IdIf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inForestal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InForestalExists(inForestal.IdIf))
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
            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", inForestal.Codigo);
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "IdCf", inForestal.IdCf);
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "IdProp", inForestal.IdProp);
            ViewData["IfBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inForestal.IfBomberoReporta);
            ViewData["IfEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", inForestal.IfEstacion);
            ViewData["IfFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inForestal.IfFirmaBombero);
            ViewData["IfJefeServicio"] = new SelectList(_context.Personals, "Id_Personal", "IdPersonal", inForestal.IfJefeServicio);
            ViewData["IfPiloto"] = new SelectList(_context.Personals, "Id_Personal", "IdPersonal", inForestal.IfPiloto);
            ViewData["IfTelefonistaTurno"] = new SelectList(_context.Personals, "Id_Personal", "IdPersonal", inForestal.IfTelefonistaTurno);
            ViewData["IfTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", inForestal.IfTurno);
            ViewData["IfVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inForestal.IfVoBoJefeServicio);
            return View(inForestal);
        }

        // GET: InForestals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.InForestals == null)
            {
                return NotFound();
            }

            var inForestal = await _context.InForestals
                .Include(i => i.CodigoNavigation)
                .Include(i => i.IdCfNavigation)
                .Include(i => i.IdPropNavigation)
                .Include(i => i.IfBomberoReportaNavigation)
                .Include(i => i.IfEstacionNavigation)
                .Include(i => i.IfFirmaBomberoNavigation)
                .Include(i => i.IfJefeServicioNavigation)
                .Include(i => i.IfPilotoNavigation)
                .Include(i => i.IfTelefonistaTurnoNavigation)
                .Include(i => i.IfTurnoNavigation)
                .Include(i => i.IfVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdIf == id);
            if (inForestal == null)
            {
                return NotFound();
            }

            return View(inForestal);
        }

        // POST: InForestals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.InForestals == null)
            {
                return Problem("Entity set 'BomberoContext.InForestals'  is null.");
            }
            var inForestal = await _context.InForestals.FindAsync(id);
            if (inForestal != null)
            {
                _context.InForestals.Remove(inForestal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InForestalExists(string id)
        {
          return _context.InForestals.Any(e => e.IdIf == id);
        }
    }
}
