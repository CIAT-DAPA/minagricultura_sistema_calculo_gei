using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;
using System.Numerics;
using SmartBreadcrumbs.Attributes;

namespace InventarioGEI.Controllers
{
    public class FuenteEmisionsController : AccesController
    {
        private readonly Context _context;

        public FuenteEmisionsController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("Fuentes de emisión")]
        // GET: FuenteEmisions
        public async Task<IActionResult> Index()
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavFue = true;
                var context = _context.FuenteEmision.Where(f => f.enabled == true).Include(f => f.usuario);
                return View(await context.ToListAsync());
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Crear")]
        // GET: FuenteEmisions/Create
        public IActionResult Create()
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavFue = true;
                return View();
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: FuenteEmisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idFuenteEmision,nombreFuenteEmision")] FuenteEmision fuenteEmision)
        {
            if (GetAccesRol("Conf"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                fuenteEmision.idUsuario = user.idUsuario;
                fuenteEmision.enabled = true;
                if (ModelState.IsValid)
                {
                    _context.Add(fuenteEmision);
                    Log log = new Log
                    {
                        accion = 1,
                        contenido = fuenteEmision.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(fuenteEmision);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Editar")]
        // GET: FuenteEmisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavFue = true;
                if (id == null || _context.FuenteEmision == null)
                {
                    return NotFound();
                }

                var fuenteEmision = await _context.FuenteEmision.FindAsync(id);
                if (fuenteEmision == null)
                {
                    return NotFound();
                }
                return View(fuenteEmision);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: FuenteEmisions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idFuenteEmision,nombreFuenteEmision")] FuenteEmision fuenteEmision)
        {
            if (GetAccesRol("Conf"))
            {
                if (id != fuenteEmision.idFuenteEmision)
                {
                    return NotFound();
                }

                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                fuenteEmision.idUsuario = user.idUsuario;
                fuenteEmision.enabled = true;

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(fuenteEmision);
                        await _context.SaveChangesAsync();
                        Log log = new Log
                        {
                            accion = 2,
                            contenido = fuenteEmision.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FuenteEmisionExists(fuenteEmision.idFuenteEmision))
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
                return View(fuenteEmision);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Eliminar")]
        // GET: FuenteEmisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavFue = true;
                if (id == null || _context.FuenteEmision == null)
                {
                    return NotFound();
                }

                var fuenteEmision = await _context.FuenteEmision
                    .Include(f => f.usuario)
                    .FirstOrDefaultAsync(m => m.idFuenteEmision == id);
                if (fuenteEmision == null)
                {
                    return NotFound();
                }

                return View(fuenteEmision);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: FuenteEmisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (GetAccesRol("Conf"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (_context.FuenteEmision == null)
                {
                    return Problem("Entity set 'Context.FuenteEmision'  is null.");
                }
                var fuenteEmision = await _context.FuenteEmision.FindAsync(id);
                if (fuenteEmision != null)
                {
                    fuenteEmision.enabled = false;
                    _context.FuenteEmision.Update(fuenteEmision);
                    Log log = new Log
                    {
                        accion = 3,
                        contenido = fuenteEmision.ToString(),
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

        private bool FuenteEmisionExists(int id)
        {
            return _context.FuenteEmision.Any(e => e.idFuenteEmision == id);
        }
    }
}
