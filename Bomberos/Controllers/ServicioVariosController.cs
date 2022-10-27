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

    public class ServicioVariosController : Controller
    {
        private readonly BomberoContext _context;

        public ServicioVariosController(BomberoContext context)
        {
            _context = context;
        }

        // GET: ServicioVarios
        public async Task<IActionResult> Index()
        {
            var bomberoContext = _context.ServicioVarios.Include(s => s.SvBomberoReportaNavigation).Include(s => s.SvFirmaBomberoNavigation).Include(s => s.SvJefeServicioNavigation).Include(s => s.SvPersonalAsistenteNavigation).Include(s => s.SvPilotoNavigation).Include(s => s.SvServicioAutPorNavigation).Include(s => s.SvTelefonistaTurnoNavigation).Include(s => s.SvTurnoNavigation).Include(s => s.SvEstacionNavigation);
            return View(await bomberoContext.ToListAsync());
        }

        // GET: ServicioVarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ServicioVarios == null)
            {
                return NotFound();
            }

            var servicioVario = await _context.ServicioVarios
                .Include(s => s.CodigoNavigation)
                .Include(s => s.SvBomberoReportaNavigation)
                .Include(s => s.SvEstacionNavigation)
                .Include(s => s.SvFirmaBomberoNavigation)
                .Include(s => s.SvJefeServicioNavigation)
                .Include(s => s.SvPersonalAsistenteNavigation)
                .Include(s => s.SvPilotoNavigation)
                .Include(s => s.SvTurnoNavigation)
                .Include(s => s.SvServicioAutPorNavigation)
                .Include(s => s.SvTelefonistaTurnoNavigation)
                .FirstOrDefaultAsync(m => m.IdSv == id);
            if (servicioVario == null)
            {
                return NotFound();
            }

            return View(servicioVario);
        }

        // GET: ServicioVarios/Create
        public IActionResult Create()
        {
            var empleado = _context.Personals.Select(a => new { Id_Personal = a.IdPersonal, Nombre = a.Nombres + " " + a.Apellidos });

            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1");
            ViewData["SvBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombres");
            ViewData["SvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "Nombre");
            ViewData["SvTurno"] = new SelectList(_context.Turnos, "IdTurno", "Nombre");
            ViewData["SvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "Nombre");
            ViewData["SvJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "Nombres");
            ViewData["SvPersonalAsistente"] = new SelectList(_context.Personals, "IdPersonal", "Nombres");
            ViewData["SvPiloto"] = new SelectList(_context.Personals, "IdPersonal", "Nombres");
            ViewData["SvServicioAutPor"] = new SelectList(_context.Personals, "IdPersonal", "Nombres");
            ViewData["SvTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "Nombres");
            return View();
        }

        // POST: ServicioVarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSv,Codigo,SvEstacion,SvTurno,SvFecha,SvDireccion,SvServicio,SvHoraSalida,SvHoraEntrada,SvJefeServicio,SvTelefonistaTurno,SvBomberoReporta,SvUnidad,SvPiloto,SvServicioAutPor,SvPersonalAsistente,SvObservacion,SvKmEntrada,SvKmSalida,SvKmRecorrido,SvFirmaBombero,SvNoBombero")] ServicioVario servicioVario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioVario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", servicioVario.Codigo);
            ViewData["SvBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", servicioVario.SvBomberoReporta);
            ViewData["SvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "IdEstacion", servicioVario.SvEstacion);
            ViewData["SvTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", servicioVario.SvTurno);
            ViewData["SvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", servicioVario.SvFirmaBombero);
            ViewData["SvJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvJefeServicio);
            ViewData["SvPersonalAsistente"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvPersonalAsistente);
            ViewData["SvPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvPiloto);
            ViewData["SvServicioAutPor"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvServicioAutPor);
            ViewData["SvTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvTelefonistaTurno);
            return View(servicioVario);
        }

        // GET: ServicioVarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ServicioVarios == null)
            {
                return NotFound();
            }

            var servicioVario = await _context.ServicioVarios.FindAsync(id);
            if (servicioVario == null)
            {
                return NotFound();
            }
            var empleado = _context.Personals.Select(a => new { Id_Personal = a.IdPersonal, Nombre = a.Nombres + " " + a.Apellidos });
            var users = _context.Usuarios.Select(a => new { IdUsuario = a.IdUsuario, Nombre = a.Nombres + " " + a.Apellidos });
            
            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", servicioVario.Codigo);
            ViewData["SvBomberoReporta"] = new SelectList(users, "IdUsuario", "Nombre", servicioVario.SvBomberoReporta);
            ViewData["SvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "Nombre", servicioVario.SvEstacion);
            ViewData["SvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", servicioVario.SvFirmaBombero);
            ViewData["SvJefeServicio"] = new SelectList(empleado, "Id_Personal", "Nombre", servicioVario.SvJefeServicio);
            ViewData["SvPersonalAsistente"] = new SelectList(empleado, "Id_Personal", "Nombre", servicioVario.SvPersonalAsistente);
            ViewData["SvPiloto"] = new SelectList(empleado, "Id_Personal", "Nombre", servicioVario.SvPiloto);
            ViewData["SvServicioAutPor"] = new SelectList(empleado, "Id_Personal", "Nombre", servicioVario.SvServicioAutPor);
            ViewData["SvTurno"] = new SelectList(_context.Turnos, "IdTurno", "Nombre", servicioVario.SvTurno);
            ViewData["SvTelefonistaTurno"] = new SelectList(empleado, "Id_Personal", "Nombre", servicioVario.SvTelefonistaTurno);
            return View(servicioVario);
        }

        // POST: ServicioVarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSv,Codigo,SvEstacion,SvTurno,SvFecha,SvDireccion,SvServicio,SvHoraSalida,SvHoraEntrada,SvJefeServicio,SvTelefonistaTurno,SvBomberoReporta,SvUnidad,SvPiloto,SvServicioAutPor,SvPersonalAsistente,SvObservacion,SvKmEntrada,SvKmSalida,SvKmRecorrido,SvFirmaBombero,SvNoBombero")] ServicioVario servicioVario)
        {
            
            if (id != servicioVario.IdSv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioVario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioVarioExists(servicioVario.IdSv))
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
            ViewData["Uuid"] = new SelectList(_context.Codigos, "Uuid", "Codigo1", servicioVario.Codigo);
            ViewData["SvBomberoReporta"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", servicioVario.SvBomberoReporta);
            ViewData["SvEstacion"] = new SelectList(_context.Estacions, "IdEstacion", "Nombre", servicioVario.SvEstacion);
            ViewData["SvFirmaBombero"] = new SelectList(_context.Firmas, "IdFirma", "IdFirma", servicioVario.SvFirmaBombero);
            ViewData["SvJefeServicio"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvJefeServicio);
            ViewData["SvPersonalAsistente"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvPersonalAsistente);
            ViewData["SvPiloto"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvPiloto);
            ViewData["SvServicioAutPor"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvServicioAutPor);
            ViewData["SvTelefonistaTurno"] = new SelectList(_context.Personals, "IdPersonal", "IdPersonal", servicioVario.SvTelefonistaTurno);
            return View(servicioVario);
        }

        // GET: ServicioVarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ServicioVarios == null)
            {
                return NotFound();
            }

            var servicioVario = await _context.ServicioVarios
                .Include(s => s.CodigoNavigation)
                .Include(s => s.SvBomberoReportaNavigation)
                .Include(s => s.SvFirmaBomberoNavigation)
                .Include(s => s.SvEstacionNavigation)
                .Include(s => s.SvJefeServicioNavigation)
                .Include(s => s.SvPersonalAsistenteNavigation)
                .Include(s => s.SvPilotoNavigation)
                .Include(s => s.SvTurnoNavigation)
                .Include(s => s.SvServicioAutPorNavigation)
                .Include(s => s.SvTelefonistaTurnoNavigation)
                .FirstOrDefaultAsync(m => m.IdSv == id);
            if (servicioVario == null)
            {
                return NotFound();
            }

            return View(servicioVario);
        }

        // POST: ServicioVarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
           try
            {
                if (_context.ServicioVarios == null)
                {
                    return Problem("Entity set 'BomberoContext.ServicioVarios'  is null.");
                }
                var servicioVario = await _context.ServicioVarios.FindAsync(id);
                if (servicioVario != null)
                {
                    _context.ServicioVarios.Remove(servicioVario);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { data = "Error al eliminar!!", data2 = "Este campo esta siendo utilizado" });
            }
        }

        private bool ServicioVarioExists(string id)
        {
            return _context.ServicioVarios.Any(e => e.IdSv == id);
        }
    }
}
