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

    public class ServicioRescatesController : Controller
    {

        private readonly BomberoContext _context;

        public ServicioRescatesController(BomberoContext context)
        {
            _context = context;
        }

        // GET: ServicioRescates
        public async Task<IActionResult> Index()
        {
            var bomberoContext = _context.ServicioRescates.Include(s => s.SrBomberoReportaNavigation).Include(s => s.SrEstacionNavigation).Include(s => s.SrOficialMandoNavigation).Include(s => s.SrTelefonistaTurnoEstacionNavigation).Include(s => s.SrVoBoJefeServicioNavigation);
            return View(await bomberoContext.ToListAsync());
        }

        // GET: ServicioRescates/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ServicioRescates == null)
            {
                return NotFound();
            }

            var servicioRescate = await _context.ServicioRescates
                .Include(s => s.SrBomberoReportaNavigation)
                .Include(s => s.SrEstacionNavigation)
                .Include(s => s.SrOficialMandoNavigation)
                .Include(s => s.SrTelefonistaTurnoEstacionNavigation)
                .Include(s => s.SrVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdSr == id);
            if (servicioRescate == null)
            {
                return NotFound();
            }

            return View(servicioRescate);
        }

        // GET: ServicioRescates/Create
        public IActionResult Create()
        {
            ViewData["SrBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["SrEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion");
            ViewData["SrOficialMando"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal");
            ViewData["SrTelefonistaTurnoEstacion"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal");
            ViewData["SrVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma");
            return View();
        }

        // POST: ServicioRescates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSr,SrEstacion,SrDireccionRescate,SrLugarLocalizacion,SrEstado,SrNombresPaciente,SrApellidosPaciente,SrCausa,SrDireccionPaciente,SrEdad,SrSexo,SrRopaColor,SrColorZapatos,SrObjetosPortaba,SrColorPelo,SrAproxEstatura,SrPosicionEncontro,SrTraslado,SrUnidad,SrOtrasUniAsis,SrNombreJuez,SrSeñalesPartRescatado,SrFormaAviso,SrNoTelLlamaron,SrSiglasRadioLlamaron,SrRadioOpTurnoCentral,SrTelefonistaTurnoEstacion,SrOficialMando,SrHoraSalida,SrHoraEntrada,SrPatrullasCarSeg,SrPersonalAsistente,SrObservacion,SrKmSalida,SrKmEntrada,SrKmTotal,SrBomberoReporta,SrFecha,SrVoBoJefeServicio")] ServicioRescate servicioRescate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioRescate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SrBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", servicioRescate.SrBomberoReporta);
            ViewData["SrEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", servicioRescate.SrEstacion);
            ViewData["SrOficialMando"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioRescate.SrOficialMando);
            ViewData["SrTelefonistaTurnoEstacion"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioRescate.SrTelefonistaTurnoEstacion);
            ViewData["SrVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", servicioRescate.SrVoBoJefeServicio);
            return View(servicioRescate);
        }

        // GET: ServicioRescates/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ServicioRescates == null)
            {
                return NotFound();
            }

            var servicioRescate = await _context.ServicioRescates.FindAsync(id);
            if (servicioRescate == null)
            {
                return NotFound();
            }
            ViewData["SrBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", servicioRescate.SrBomberoReporta);
            ViewData["SrEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", servicioRescate.SrEstacion);
            ViewData["SrOficialMando"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioRescate.SrOficialMando);
            ViewData["SrTelefonistaTurnoEstacion"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioRescate.SrTelefonistaTurnoEstacion);
            ViewData["SrVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", servicioRescate.SrVoBoJefeServicio);
            return View(servicioRescate);
        }

        // POST: ServicioRescates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSr,SrEstacion,SrDireccionRescate,SrLugarLocalizacion,SrEstado,SrNombresPaciente,SrApellidosPaciente,SrCausa,SrDireccionPaciente,SrEdad,SrSexo,SrRopaColor,SrColorZapatos,SrObjetosPortaba,SrColorPelo,SrAproxEstatura,SrPosicionEncontro,SrTraslado,SrUnidad,SrOtrasUniAsis,SrNombreJuez,SrSeñalesPartRescatado,SrFormaAviso,SrNoTelLlamaron,SrSiglasRadioLlamaron,SrRadioOpTurnoCentral,SrTelefonistaTurnoEstacion,SrOficialMando,SrHoraSalida,SrHoraEntrada,SrPatrullasCarSeg,SrPersonalAsistente,SrObservacion,SrKmSalida,SrKmEntrada,SrKmTotal,SrBomberoReporta,SrFecha,SrVoBoJefeServicio")] ServicioRescate servicioRescate)
        {
            if (id != servicioRescate.IdSr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioRescate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioRescateExists(servicioRescate.IdSr))
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
            ViewData["SrBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", servicioRescate.SrBomberoReporta);
            ViewData["SrEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", servicioRescate.SrEstacion);
            ViewData["SrOficialMando"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioRescate.SrOficialMando);
            ViewData["SrTelefonistaTurnoEstacion"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioRescate.SrTelefonistaTurnoEstacion);
            ViewData["SrVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", servicioRescate.SrVoBoJefeServicio);
            return View(servicioRescate);
        }

        // GET: ServicioRescates/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ServicioRescates == null)
            {
                return NotFound();
            }

            var servicioRescate = await _context.ServicioRescates
                .Include(s => s.SrBomberoReportaNavigation)
                .Include(s => s.SrEstacionNavigation)
                .Include(s => s.SrOficialMandoNavigation)
                .Include(s => s.SrTelefonistaTurnoEstacionNavigation)
                .Include(s => s.SrVoBoJefeServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdSr == id);
            if (servicioRescate == null)
            {
                return NotFound();
            }

            return View(servicioRescate);
        }

        // POST: ServicioRescates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ServicioRescates == null)
            {
                return Problem("Entity set 'BomberoContext.ServicioRescates'  is null.");
            }
            var servicioRescate = await _context.ServicioRescates.FindAsync(id);
            if (servicioRescate != null)
            {
                _context.ServicioRescates.Remove(servicioRescate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioRescateExists(string id)
        {
          return _context.ServicioRescates.Any(e => e.IdSr == id);
        }
    }
}
