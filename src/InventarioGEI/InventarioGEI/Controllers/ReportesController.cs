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
    public class ReportesController : AccesController
    {
        private readonly Context _context;

        public ReportesController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("Reportes")]
        // GET: Reportes
        public async Task<IActionResult> Index()
        {
            ViewBag.NavRep = true;
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            Rol rolAsig = _context.Rol.FirstOrDefault(r => r.idRol == user.idRol);
            if (rolAsig.permisoVisualizacion)
            {
                ViewData["Edit"] = "si";
            }
            return View(await _context.Reporte.ToListAsync());
        }

        [Breadcrumb("Crear")]
        // GET: Reportes/Create
        public IActionResult Create()
        {
            if (GetAccesRol("Visualizacion"))
            {
                ViewBag.NavRep = true;
                return View();
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }

        }

        // POST: Reportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idReporte,nombreReporte,link")] Reporte reporte)
        {
            if (GetAccesRol("Visualizacion"))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(reporte);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(reporte);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("ViewData.TitleBread")]
        public async Task<IActionResult> Visualizar(int? id)
        {
            ViewBag.NavRep = true;
            if (id == null || _context.Reporte == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte.FindAsync(id);
            if (reporte == null)
            {
                return NotFound();
            }
            ViewData["TitleBread"] = reporte.nombreReporte;
            return View(reporte);
        }

        [Breadcrumb("Editar")]
        // GET: Reportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (GetAccesRol("Visualizacion"))
            {
                ViewBag.NavRep = true;
                if (id == null || _context.Reporte == null)
                {
                    return NotFound();
                }

                var reporte = await _context.Reporte.FindAsync(id);
                if (reporte == null)
                {
                    return NotFound();
                }
                return View(reporte);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Reportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idReporte,nombreReporte,link")] Reporte reporte)
        {
            if (GetAccesRol("Visualizacion"))
            {
                if (id != reporte.idReporte)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(reporte);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ReporteExists(reporte.idReporte))
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
                return View(reporte);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Eliminar")]
        // GET: Reportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (GetAccesRol("Visualizacion"))
            {
                ViewBag.NavRep = true;
                if (id == null || _context.Reporte == null)
                {
                    return NotFound();
                }

                var reporte = await _context.Reporte
                    .FirstOrDefaultAsync(m => m.idReporte == id);
                if (reporte == null)
                {
                    return NotFound();
                }

                return View(reporte);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reporte == null)
            {
                return Problem("Entity set 'Context.Reporte'  is null.");
            }
            var reporte = await _context.Reporte.FindAsync(id);
            if (reporte != null)
            {
                _context.Reporte.Remove(reporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteExists(int id)
        {
            return _context.Reporte.Any(e => e.idReporte == id);
        }
    }
}
