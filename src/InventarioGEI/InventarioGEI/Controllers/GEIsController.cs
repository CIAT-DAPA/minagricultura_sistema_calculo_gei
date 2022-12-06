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
    public class GEIsController : AccesController
    {
        private readonly Context _context;

        public GEIsController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("GEI")]
        // GET: GEIs
        public async Task<IActionResult> Index()
        {
            ViewBag.NavGei = true;
            if (GetAccesRol("Conf"))
            {
                var context = _context.Gei.Where(g => g.enabled == true).Include(g => g.usuario);
                return View(await context.ToListAsync());
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Crear")]
        // GET: GEIs/Create
        public IActionResult Create()
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavGei = true;
                return View();
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: GEIs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idGei,nombreGei")] GEI gEI)
        {
            if (GetAccesRol("Conf"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                gEI.idUsuario = user.idUsuario;
                gEI.enabled = true;
                if (ModelState.IsValid)
                {
                    _context.Add(gEI);
                    Log log = new Log
                    {
                        accion = 1,
                        contenido = gEI.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(gEI);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Editar")]
        // GET: GEIs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavGei = true;
                if (id == null || _context.Gei == null)
                {
                    return NotFound();
                }

                var gEI = await _context.Gei.FindAsync(id);
                if (gEI == null)
                {
                    return NotFound();
                }
                return View(gEI);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: GEIs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idGei,nombreGei")] GEI gEI)
        {
            if (GetAccesRol("Conf"))
            {
                if (id != gEI.idGei)
                {
                    return NotFound();
                }

                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                gEI.idUsuario = user.idUsuario;
                gEI.enabled = true;

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(gEI);
                        await _context.SaveChangesAsync();
                        Log log = new Log
                        {
                            accion = 2,
                            contenido = gEI.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GEIExists(gEI.idGei))
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
                return View(gEI);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Eliminar")]
        // GET: GEIs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavGei = true;
                if (id == null || _context.Gei == null)
                {
                    return NotFound();
                }

                var gEI = await _context.Gei
                    .Include(g => g.usuario)
                    .FirstOrDefaultAsync(m => m.idGei == id);
                if (gEI == null)
                {
                    return NotFound();
                }

                return View(gEI);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: GEIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (GetAccesRol("Conf"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (_context.Gei == null)
                {
                    return Problem("Entity set 'Context.Gei'  is null.");
                }
                var gEI = await _context.Gei.FindAsync(id);
                if (gEI != null)
                {
                    gEI.enabled = false;
                    _context.Gei.Update(gEI);
                    Log log = new Log
                    {
                        accion = 3,
                        contenido = gEI.ToString(),
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

        private bool GEIExists(int id)
        {
            return _context.Gei.Any(e => e.idGei == id);
        }
    }
}
