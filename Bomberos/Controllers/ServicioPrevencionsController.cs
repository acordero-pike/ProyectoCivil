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

    public class ServicioPrevencionsController : Controller
    {
        private readonly BomberoContext _context;

        public ServicioPrevencionsController(BomberoContext context)
        {
            _context = context;
        }

        // GET: ServicioPrevencions
        public async Task<IActionResult> Index()
        {
            var bomberoContext = _context.ServicioPrevencions.Include(s => s.SpBomberoReportaNavigation).Include(s => s.SpCompañiaNavigation).Include(s => s.SpEstacionNavigation).Include(s => s.SpOficialServicioNavigation).Include(s => s.SpPilotoNavigation).Include(s => s.SpTelefonistaNavigation).Include(s => s.SpTurnoNavigation).Include(s => s.SpVoBoJefeServicioNavigation);
            return View(await bomberoContext.ToListAsync());
        }

        // GET: ServicioPrevencions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ServicioPrevencions == null)
            {
                return NotFound();
            }

            var servicioPrevencion = await _context.ServicioPrevencions
                .Include(s => s.SpBomberoReportaNavigation)
                .Include(s => s.SpCompañiaNavigation)
                .Include(s => s.SpEstacionNavigation)
                .Include(s => s.SpOficialServicioNavigation)
                .Include(s => s.SpPilotoNavigation)
                .Include(s => s.SpTelefonistaNavigation)
                .Include(s => s.SpTurnoNavigation)
                .Include(s => s.SpVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdSp == id);
            if (servicioPrevencion == null)
            {
                return NotFound();
            }

            return View(servicioPrevencion);
        }

        // GET: ServicioPrevencions/Create
        public IActionResult Create()
        {
            ViewData["SpBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["SpCompañia"] = new SelectList(_context.Compañia, "IdCompañia", "IdCompañia");
            ViewData["SpEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion");
            ViewData["SpOficialServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal");
            ViewData["SpPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal");
            ViewData["SpTelefonista"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal");
            ViewData["SpTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno");
            ViewData["SpVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma");
            return View();
        }

        // POST: ServicioPrevencions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSp,SpDireccion,SpNombreRazonsocial,SpGeneralesServPrestado,SpEstablecimiento,SpHoraSalida,SpHoraEntrada,SpUnidad,SpPiloto,SpFormaAviso,SpTelefonista,SpOficialServicio,SpEstacion,SpCompañia,SpTurno,SpObservacion,SpKmSalida,SpKmEntrada,SpKmTotal,SpBomberoReporta,SpFecha,SpVoBoJefeServicio")] ServicioPrevencion servicioPrevencion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioPrevencion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", servicioPrevencion.SpBomberoReporta);
            ViewData["SpCompañia"] = new SelectList(_context.Compañia, "IdCompañia", "IdCompañia", servicioPrevencion.SpCompañia);
            ViewData["SpEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", servicioPrevencion.SpEstacion);
            ViewData["SpOficialServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioPrevencion.SpOficialServicio);
            ViewData["SpPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioPrevencion.SpPiloto);
            ViewData["SpTelefonista"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioPrevencion.SpTelefonista);
            ViewData["SpTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", servicioPrevencion.SpTurno);
            ViewData["SpVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", servicioPrevencion.SpVoBoJefeServicio);
            return View(servicioPrevencion);
        }

        // GET: ServicioPrevencions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ServicioPrevencions == null)
            {
                return NotFound();
            }

            var servicioPrevencion = await _context.ServicioPrevencions.FindAsync(id);
            if (servicioPrevencion == null)
            {
                return NotFound();
            }
            ViewData["SpBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", servicioPrevencion.SpBomberoReporta);
            ViewData["SpCompañia"] = new SelectList(_context.Compañia, "IdCompañia", "IdCompañia", servicioPrevencion.SpCompañia);
            ViewData["SpEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", servicioPrevencion.SpEstacion);
            ViewData["SpOficialServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioPrevencion.SpOficialServicio);
            ViewData["SpPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioPrevencion.SpPiloto);
            ViewData["SpTelefonista"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioPrevencion.SpTelefonista);
            ViewData["SpTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", servicioPrevencion.SpTurno);
            ViewData["SpVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", servicioPrevencion.SpVoBoJefeServicio);
            return View(servicioPrevencion);
        }

        // POST: ServicioPrevencions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSp,SpDireccion,SpNombreRazonsocial,SpGeneralesServPrestado,SpEstablecimiento,SpHoraSalida,SpHoraEntrada,SpUnidad,SpPiloto,SpFormaAviso,SpTelefonista,SpOficialServicio,SpEstacion,SpCompañia,SpTurno,SpObservacion,SpKmSalida,SpKmEntrada,SpKmTotal,SpBomberoReporta,SpFecha,SpVoBoJefeServicio")] ServicioPrevencion servicioPrevencion)
        {
            if (id != servicioPrevencion.IdSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioPrevencion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioPrevencionExists(servicioPrevencion.IdSp))
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
            ViewData["SpBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", servicioPrevencion.SpBomberoReporta);
            ViewData["SpCompañia"] = new SelectList(_context.Compañia, "IdCompañia", "IdCompañia", servicioPrevencion.SpCompañia);
            ViewData["SpEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", servicioPrevencion.SpEstacion);
            ViewData["SpOficialServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioPrevencion.SpOficialServicio);
            ViewData["SpPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioPrevencion.SpPiloto);
            ViewData["SpTelefonista"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioPrevencion.SpTelefonista);
            ViewData["SpTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", servicioPrevencion.SpTurno);
            ViewData["SpVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", servicioPrevencion.SpVoBoJefeServicio);
            return View(servicioPrevencion);
        }

        // GET: ServicioPrevencions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ServicioPrevencions == null)
            {
                return NotFound();
            }

            var servicioPrevencion = await _context.ServicioPrevencions
                .Include(s => s.SpBomberoReportaNavigation)
                .Include(s => s.SpCompañiaNavigation)
                .Include(s => s.SpEstacionNavigation)
                .Include(s => s.SpOficialServicioNavigation)
                .Include(s => s.SpPilotoNavigation)
                .Include(s => s.SpTelefonistaNavigation)
                .Include(s => s.SpTurnoNavigation)
                .Include(s => s.SpVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdSp == id);
            if (servicioPrevencion == null)
            {
                return NotFound();
            }

            return View(servicioPrevencion);
        }

        // POST: ServicioPrevencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ServicioPrevencions == null)
            {
                return Problem("Entity set 'BomberoContext.ServicioPrevencions'  is null.");
            }
            var servicioPrevencion = await _context.ServicioPrevencions.FindAsync(id);
            if (servicioPrevencion != null)
            {
                _context.ServicioPrevencions.Remove(servicioPrevencion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioPrevencionExists(string id)
        {
          return _context.ServicioPrevencions.Any(e => e.IdSp == id);
        }
    }
}
