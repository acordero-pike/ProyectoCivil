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

    public class InVehiculoesController : Controller
    {
        private readonly BomberoContext _context;

        public InVehiculoesController(BomberoContext context)
        {
            _context = context;
        }

        // GET: InVehiculoes
        public async Task<IActionResult> Index()
        {
            var bomberoContext = _context.InVehiculos.Include(i => i.IdCfNavigation).Include(i => i.IdPropNavigation).Include(i => i.IvBomberoReportaNavigation).Include(i => i.IvEstacionNavigation).Include(i => i.IvFirmaBomberoNavigation).Include(i => i.IvJefeServicioNavigation).Include(i => i.IvPilotoNavigation).Include(i => i.IvTelefonistaTurnoNavigation).Include(i => i.IvTurnoNavigation).Include(i => i.IvVoBoJefeServicioNavigation);
            return View(await bomberoContext.ToListAsync());
        }

        // GET: InVehiculoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.InVehiculos == null)
            {
                return NotFound();
            }

            var inVehiculo = await _context.InVehiculos
                .Include(i => i.IdCfNavigation)
                .Include(i => i.IdPropNavigation)
                .Include(i => i.IvBomberoReportaNavigation)
                .Include(i => i.IvEstacionNavigation)
                .Include(i => i.IvFirmaBomberoNavigation)
                .Include(i => i.IvJefeServicioNavigation)
                .Include(i => i.IvPilotoNavigation)
                .Include(i => i.IvTelefonistaTurnoNavigation)
                .Include(i => i.IvTurnoNavigation)
                .Include(i => i.IvVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdIv == id);
            if (inVehiculo == null)
            {
                return NotFound();
            }

            return View(inVehiculo);
        }

        // GET: InVehiculoes/Create
        public IActionResult Create()
        {
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "IdCf");
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "IdProp");
            ViewData["IvBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["IvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion");
            ViewData["IvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma");
            ViewData["IvJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal");
            ViewData["IvPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal");
            ViewData["IvTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal");
            ViewData["IvTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno");
            ViewData["IvVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma");
            return View();
        }

        // POST: InVehiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIv,IvEstacion,IvTurno,IvUbiSiniestro,IvTipoVehiculo,IvPlaca,IvColor,IvMarca,IvValor,IvPerdida,IdProp,IdCf,IvHoraSalida,IvHoraServicio,IvHoraEntrada,IvJefeServicio,IvTelefonistaTurno,IvBomberoReporta,IvPiloto,IvUnidad,IvUniAsisEstacion,IvUniAsisOtraEstacion,IvUniPoliciacas,IvUniOtrasInstiBomberiles,IvPersonalAsisEstacion,IvPersonalAsisOtraEstacion,IvObservacion,IvFecha,IvKmEntrada,IvKmSalida,IvKmRecorrido,IvFirmaBombero,IvNoBombero,IvVoBoJefeServicio")] InVehiculo inVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "IdCf", inVehiculo.IdCf);
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "IdProp", inVehiculo.IdProp);
            ViewData["IvBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inVehiculo.IvBomberoReporta);
            ViewData["IvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", inVehiculo.IvEstacion);
            ViewData["IvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inVehiculo.IvFirmaBombero);
            ViewData["IvJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inVehiculo.IvJefeServicio);
            ViewData["IvPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inVehiculo.IvPiloto);
            ViewData["IvTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inVehiculo.IvTelefonistaTurno);
            ViewData["IvTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", inVehiculo.IvTurno);
            ViewData["IvVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inVehiculo.IvVoBoJefeServicio);
            return View(inVehiculo);
        }

        // GET: InVehiculoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.InVehiculos == null)
            {
                return NotFound();
            }

            var inVehiculo = await _context.InVehiculos.FindAsync(id);
            if (inVehiculo == null)
            {
                return NotFound();
            }
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "IdCf", inVehiculo.IdCf);
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "IdProp", inVehiculo.IdProp);
            ViewData["IvBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inVehiculo.IvBomberoReporta);
            ViewData["IvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", inVehiculo.IvEstacion);
            ViewData["IvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inVehiculo.IvFirmaBombero);
            ViewData["IvJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inVehiculo.IvJefeServicio);
            ViewData["IvPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inVehiculo.IvPiloto);
            ViewData["IvTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inVehiculo.IvTelefonistaTurno);
            ViewData["IvTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", inVehiculo.IvTurno);
            ViewData["IvVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inVehiculo.IvVoBoJefeServicio);
            return View(inVehiculo);
        }

        // POST: InVehiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdIv,IvEstacion,IvTurno,IvUbiSiniestro,IvTipoVehiculo,IvPlaca,IvColor,IvMarca,IvValor,IvPerdida,IdProp,IdCf,IvHoraSalida,IvHoraServicio,IvHoraEntrada,IvJefeServicio,IvTelefonistaTurno,IvBomberoReporta,IvPiloto,IvUnidad,IvUniAsisEstacion,IvUniAsisOtraEstacion,IvUniPoliciacas,IvUniOtrasInstiBomberiles,IvPersonalAsisEstacion,IvPersonalAsisOtraEstacion,IvObservacion,IvFecha,IvKmEntrada,IvKmSalida,IvKmRecorrido,IvFirmaBombero,IvNoBombero,IvVoBoJefeServicio")] InVehiculo inVehiculo)
        {
            if (id != inVehiculo.IdIv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InVehiculoExists(inVehiculo.IdIv))
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
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "IdCf", inVehiculo.IdCf);
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "IdProp", inVehiculo.IdProp);
            ViewData["IvBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", inVehiculo.IvBomberoReporta);
            ViewData["IvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", inVehiculo.IvEstacion);
            ViewData["IvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inVehiculo.IvFirmaBombero);
            ViewData["IvJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inVehiculo.IvJefeServicio);
            ViewData["IvPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inVehiculo.IvPiloto);
            ViewData["IvTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", inVehiculo.IvTelefonistaTurno);
            ViewData["IvTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", inVehiculo.IvTurno);
            ViewData["IvVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", inVehiculo.IvVoBoJefeServicio);
            return View(inVehiculo);
        }

        // GET: InVehiculoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.InVehiculos == null)
            {
                return NotFound();
            }

            var inVehiculo = await _context.InVehiculos
                .Include(i => i.IdCfNavigation)
                .Include(i => i.IdPropNavigation)
                .Include(i => i.IvBomberoReportaNavigation)
                .Include(i => i.IvEstacionNavigation)
                .Include(i => i.IvFirmaBomberoNavigation)
                .Include(i => i.IvJefeServicioNavigation)
                .Include(i => i.IvPilotoNavigation)
                .Include(i => i.IvTelefonistaTurnoNavigation)
                .Include(i => i.IvTurnoNavigation)
                .Include(i => i.IvVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdIv == id);
            if (inVehiculo == null)
            {
                return NotFound();
            }

            return View(inVehiculo);
        }

        // POST: InVehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.InVehiculos == null)
            {
                return Problem("Entity set 'BomberoContext.InVehiculos'  is null.");
            }
            var inVehiculo = await _context.InVehiculos.FindAsync(id);
            if (inVehiculo != null)
            {
                _context.InVehiculos.Remove(inVehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InVehiculoExists(string id)
        {
          return _context.InVehiculos.Any(e => e.IdIv == id);
        }
    }
}
