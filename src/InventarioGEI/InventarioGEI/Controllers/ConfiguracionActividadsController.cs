using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;

namespace InventarioGEI.Controllers
{
    public class ConfiguracionActividadsController : AccesController
    {
        private readonly Context _context;

        public ConfiguracionActividadsController(Context context) : base(context)
        {
            _context = context;
        }

        // GET: ConfiguracionActividads
        public async Task<IActionResult> Index()
        {
            var context = _context.ConfiguracionActividad.Where(c => c.enabled == true).Include(c => c.combustible).Include(c => c.fuenteEmision).Include(c => c.subcategoria);
            return View(await context.ToListAsync());
        }

        // GET: ConfiguracionActividads/Create
        public IActionResult Create()
        {
            List<Combustible> combustible = _context.Combustible.Where(c => c.enabled == true).ToList();
            var listaCombustibles = new List<SelectListItem>();
            foreach (var item in combustible)
            {
                listaCombustibles.Add(new SelectListItem { Text = item.nombreCombustible, Value = item.idCombustible.ToString() });
            }
            ViewData["idCombustible"] = listaCombustibles;

            List<FuenteEmision> fuenteEmision = _context.FuenteEmision.Where(f => f.enabled == true).ToList();
            var listafuenteEmision = new List<SelectListItem>();
            foreach (var item in fuenteEmision)
            {
                listafuenteEmision.Add(new SelectListItem { Text = item.nombreFuenteEmision, Value = item.idFuenteEmision.ToString() });
            }
            ViewData["idFuenteEmision"] = listafuenteEmision;

            List<Subcategoria> subcategoria = _context.Subcategoria.Where(s => s.enabled == true).ToList();
            var listaSubcategorias = new List<SelectListItem>();
            foreach (var item in subcategoria)
            {
                listaSubcategorias.Add(new SelectListItem { Text = item.nombreSubcategoria, Value = item.idSubcategoria.ToString() });
            }
            ViewData["idSubcategoria"] = listaSubcategorias;
            return View();
        }

        // POST: ConfiguracionActividads/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idConfiguracion,idCombustible,idSubcategoria,idFuenteEmision")] ConfiguracionActividad configuracionActividad)
        {
            configuracionActividad.enabled = true;
            if (ModelState.IsValid)
            {
                _context.Add(configuracionActividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<Combustible> combustible = _context.Combustible.Where(c => c.enabled == true).ToList();
            var listaCombustibles = new List<SelectListItem>();
            foreach (var item in combustible)
            {
                listaCombustibles.Add(new SelectListItem { Text = item.nombreCombustible, Value = item.idCombustible.ToString() });
            }
            ViewData["idCombustible"] = listaCombustibles;

            List<FuenteEmision> fuenteEmision = _context.FuenteEmision.Where(f => f.enabled == true).ToList();
            var listafuenteEmision = new List<SelectListItem>();
            foreach (var item in fuenteEmision)
            {
                listafuenteEmision.Add(new SelectListItem { Text = item.nombreFuenteEmision, Value = item.idFuenteEmision.ToString() });
            }
            ViewData["idFuenteEmision"] = listafuenteEmision;

            List<Subcategoria> subcategoria = _context.Subcategoria.Where(s => s.enabled == true).ToList();
            var listaSubcategorias = new List<SelectListItem>();
            foreach (var item in subcategoria)
            {
                listaSubcategorias.Add(new SelectListItem { Text = item.nombreSubcategoria, Value = item.idSubcategoria.ToString() });
            }
            ViewData["idSubcategoria"] = listaSubcategorias;
            return View(configuracionActividad);
        }

        // GET: ConfiguracionActividads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ConfiguracionActividad == null)
            {
                return NotFound();
            }

            var configuracionActividad = await _context.ConfiguracionActividad.FindAsync(id);
            if (configuracionActividad == null)
            {
                return NotFound();
            }
            List<Combustible> combustible = _context.Combustible.Where(c => c.enabled == true).ToList();
            var listaCombustibles = new List<SelectListItem>();
            foreach (var item in combustible)
            {
                listaCombustibles.Add(new SelectListItem { Text = item.nombreCombustible, Value = item.idCombustible.ToString() });
            }
            ViewData["idCombustible"] = listaCombustibles;

            List<FuenteEmision> fuenteEmision = _context.FuenteEmision.Where(f => f.enabled == true).ToList();
            var listafuenteEmision = new List<SelectListItem>();
            foreach (var item in fuenteEmision)
            {
                listafuenteEmision.Add(new SelectListItem { Text = item.nombreFuenteEmision, Value = item.idFuenteEmision.ToString() });
            }
            ViewData["idFuenteEmision"] = listafuenteEmision;

            List<Subcategoria> subcategoria = _context.Subcategoria.Where(s => s.enabled == true).ToList();
            var listaSubcategorias = new List<SelectListItem>();
            foreach (var item in subcategoria)
            {
                listaSubcategorias.Add(new SelectListItem { Text = item.nombreSubcategoria, Value = item.idSubcategoria.ToString() });
            }
            ViewData["idSubcategoria"] = listaSubcategorias;
            return View(configuracionActividad);
        }

        // POST: ConfiguracionActividads/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idConfiguracion,idCombustible,idSubcategoria,idFuenteEmision")] ConfiguracionActividad configuracionActividad)
        {
            if (id != configuracionActividad.idConfiguracion)
            {
                return NotFound();
            }

            configuracionActividad.enabled = true;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracionActividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracionActividadExists(configuracionActividad.idConfiguracion))
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
            List<Combustible> combustible = _context.Combustible.Where(c => c.enabled == true).ToList();
            var listaCombustibles = new List<SelectListItem>();
            foreach (var item in combustible)
            {
                listaCombustibles.Add(new SelectListItem { Text = item.nombreCombustible, Value = item.idCombustible.ToString() });
            }
            ViewData["idCombustible"] = listaCombustibles;

            List<FuenteEmision> fuenteEmision = _context.FuenteEmision.Where(f => f.enabled == true).ToList();
            var listafuenteEmision = new List<SelectListItem>();
            foreach (var item in fuenteEmision)
            {
                listafuenteEmision.Add(new SelectListItem { Text = item.nombreFuenteEmision, Value = item.idFuenteEmision.ToString() });
            }
            ViewData["idFuenteEmision"] = listafuenteEmision;

            List<Subcategoria> subcategoria = _context.Subcategoria.Where(s => s.enabled == true).ToList();
            var listaSubcategorias = new List<SelectListItem>();
            foreach (var item in subcategoria)
            {
                listaSubcategorias.Add(new SelectListItem { Text = item.nombreSubcategoria, Value = item.idSubcategoria.ToString() });
            }
            ViewData["idSubcategoria"] = listaSubcategorias;
            return View(configuracionActividad);
        }

        // GET: ConfiguracionActividads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConfiguracionActividad == null)
            {
                return NotFound();
            }

            var configuracionActividad = await _context.ConfiguracionActividad
                .Include(c => c.combustible)
                .Include(c => c.fuenteEmision)
                .Include(c => c.subcategoria)
                .FirstOrDefaultAsync(m => m.idConfiguracion == id);
            if (configuracionActividad == null)
            {
                return NotFound();
            }

            return View(configuracionActividad);
        }

        // POST: ConfiguracionActividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ConfiguracionActividad == null)
            {
                return Problem("Entity set 'Context.ConfiguracionActividad'  is null.");
            }
            var configuracionActividad = await _context.ConfiguracionActividad.FindAsync(id);
            if (configuracionActividad != null)
            {
                configuracionActividad.enabled = false;
                _context.ConfiguracionActividad.Update(configuracionActividad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracionActividadExists(int id)
        {
          return _context.ConfiguracionActividad.Any(e => e.idConfiguracion == id);
        }
    }
}
