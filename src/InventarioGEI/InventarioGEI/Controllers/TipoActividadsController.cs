using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;
using SmartBreadcrumbs.Attributes;

namespace InventarioGEI.Controllers
{
    public class TipoActividadsController : AccesController
    {
        private readonly Context _context;

        public TipoActividadsController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("Tipos de actividad")]
        // GET: TipoActividads
        public async Task<IActionResult> Index()
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavTip = true;
                var context = _context.TipoActividad.Where(t => t.enabled == true).Include(t => t.usuario);
                return View(await context.ToListAsync());
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Crear")]
        // GET: TipoActividads/Create
        public IActionResult Create()
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavTip = true;
                return View();
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: TipoActividads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTipoActividad,nombreTipoActividad")] TipoActividad tipoActividad)
        {
            if (GetAccesRol("Conf"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                tipoActividad.enabled = true;
                tipoActividad.idUsuario = user.idUsuario;
                if (ModelState.IsValid)
                {
                    _context.Add(tipoActividad);
                    Log log = new Log
                    {
                        accion = 1,
                        contenido = tipoActividad.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email", tipoActividad.idUsuario);
                return View(tipoActividad);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Editar")]
        // GET: TipoActividads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavTip = true;
                if (id == null || _context.TipoActividad == null)
                {
                    return NotFound();
                }

                var tipoActividad = await _context.TipoActividad.FindAsync(id);
                if (tipoActividad == null)
                {
                    return NotFound();
                }
                return View(tipoActividad);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: TipoActividads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTipoActividad,nombreTipoActividad")] TipoActividad tipoActividad)
        {
            if (GetAccesRol("Conf"))
            {
                if (id != tipoActividad.idTipoActividad)
                {
                    return NotFound();
                }
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                tipoActividad.enabled = true;
                tipoActividad.idUsuario = user.idUsuario;
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(tipoActividad);
                        await _context.SaveChangesAsync();
                        Log log = new Log
                        {
                            accion = 2,
                            contenido = tipoActividad.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TipoActividadExists(tipoActividad.idTipoActividad))
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
                ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email", tipoActividad.idUsuario);
                return View(tipoActividad);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Eliminar")]
        // GET: TipoActividads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavTip = true;
                if (id == null || _context.TipoActividad == null)
                {
                    return NotFound();
                }

                var tipoActividad = await _context.TipoActividad
                    .Include(t => t.usuario)
                    .FirstOrDefaultAsync(m => m.idTipoActividad == id);
                if (tipoActividad == null)
                {
                    return NotFound();
                }

                return View(tipoActividad);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: TipoActividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (GetAccesRol("Conf"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (_context.TipoActividad == null)
                {
                    return Problem("Entity set 'Context.TipoActividad'  is null.");
                }
                var tipoActividad = await _context.TipoActividad.FindAsync(id);
                if (tipoActividad != null)
                {
                    tipoActividad.enabled = false;
                    _context.TipoActividad.Update(tipoActividad);
                    Log log = new Log
                    {
                        accion = 3,
                        contenido = tipoActividad.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        private bool TipoActividadExists(int id)
        {
            return _context.TipoActividad.Any(e => e.idTipoActividad == id);
        }
    }
}
