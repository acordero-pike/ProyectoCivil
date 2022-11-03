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
                .Include(i => i.CodigoNavigation)
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

            return new ViewAsPdf("Details",inVehiculo)
            {
                FileName = "Servicio de Rescate" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf",
                ContentDisposition=
                PageWidth = 250,
                PageHeight= 800
            }; 
        }

        // GET: InVehiculoes/Create
        public IActionResult Create()
        {
            var empleado = _context.Personals.Select(a => new { Id_Personal = a.IdPersonal, Nombre = a.Nombres + " " + a.Apellidos });
            var users = _context.Usuarios.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.Nombres + " " + a.Apellidos });

            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1");
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "CfClasefuego");
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "PTipoProp");
            ViewData["IvBomberoReporta"] = new SelectList(users, "IdUsuario", "Nombre");
            ViewData["IvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "Nombre");
            ViewData["IvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "Nombre");
            ViewData["IvJefeServicio"] = new SelectList(empleado, "Id_Personal", "Nombre");
            ViewData["IvPiloto"] = new SelectList(empleado, "Id_Personal", "Nombre");
            ViewData["IvTelefonistaTurno"] = new SelectList(empleado, "Id_Personal", "Nombre");
            ViewData["IvTurno"] = new SelectList(_context.Turnos, "IdTurno", "Nombre");
            ViewData["IvVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "Nombre");
            return View();
        }

        // POST: InVehiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIv,Codigo,IvEstacion,IvTurno,IvUbiSiniestro,IvTipoVehiculo,IvPlaca,IvColor,IvMarca,IvValor,IvPerdida,IdProp,IdCf,IvHoraSalida,IvHoraServicio,IvHoraEntrada,IvJefeServicio,IvTelefonistaTurno,IvBomberoReporta,IvPiloto,IvUnidad,IvUniAsisEstacion,IvUniAsisOtraEstacion,IvUniPoliciacas,IvUniOtrasInstiBomberiles,IvPersonalAsisEstacion,IvPersonalAsisOtraEstacion,IvObservacion,IvFecha,IvKmEntrada,IvKmSalida,IvKmRecorrido,IvFirmaBombero,IvNoBombero,IvVoBoJefeServicio")] InVehiculo inVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", inVehiculo.Codigo);
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
            var empleado = _context.Personals.Select(a => new { Id_Personal = a.IdPersonal, Nombre = a.Nombres + " " + a.Apellidos });
            var users = _context.Usuarios.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.Nombres + " " + a.Apellidos });

            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", inVehiculo.Codigo);
            ViewData["IdCf"] = new SelectList(_context.ClaseFuegos, "IdCf", "CfClasefuego", inVehiculo.IdCf);
            ViewData["IdProp"] = new SelectList(_context.Proporcions, "IdProp", "PTipoProp", inVehiculo.IdProp);
            ViewData["IvBomberoReporta"] = new SelectList(users, "IdUsuario", "Nombre", inVehiculo.IvBomberoReporta);
            ViewData["IvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "Nombre", inVehiculo.IvEstacion);
            ViewData["IvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "Nombre", inVehiculo.IvFirmaBombero);
            ViewData["IvJefeServicio"] = new SelectList(empleado, "Id_Personal", "Nombre", inVehiculo.IvJefeServicio);
            ViewData["IvPiloto"] = new SelectList(empleado, "Id_Personal", "Nombre", inVehiculo.IvPiloto);
            ViewData["IvTelefonistaTurno"] = new SelectList(empleado, "Id_Personal", "Nombre", inVehiculo.IvTelefonistaTurno);
            ViewData["IvTurno"] = new SelectList(_context.Turnos, "IdTurno", "Nombre", inVehiculo.IvTurno);
            ViewData["IvVoBoJefeServicio"] = new SelectList(_context.Firmas, "IdFirma", "Nombre", inVehiculo.IvVoBoJefeServicio);
            return View(inVehiculo);
        }

        // POST: InVehiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdIv,Codigo,IvEstacion,IvTurno,IvUbiSiniestro,IvTipoVehiculo,IvPlaca,IvColor,IvMarca,IvValor,IvPerdida,IdProp,IdCf,IvHoraSalida,IvHoraServicio,IvHoraEntrada,IvJefeServicio,IvTelefonistaTurno,IvBomberoReporta,IvPiloto,IvUnidad,IvUniAsisEstacion,IvUniAsisOtraEstacion,IvUniPoliciacas,IvUniOtrasInstiBomberiles,IvPersonalAsisEstacion,IvPersonalAsisOtraEstacion,IvObservacion,IvFecha,IvKmEntrada,IvKmSalida,IvKmRecorrido,IvFirmaBombero,IvNoBombero,IvVoBoJefeServicio")] InVehiculo inVehiculo)
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
            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", inVehiculo.Codigo);
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
                .Include(i => i.CodigoNavigation)
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
