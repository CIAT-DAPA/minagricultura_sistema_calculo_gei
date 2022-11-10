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
            var context = _context.ConfiguracionActividad
                                                .Where(c => c.enabled == true)
                                                .Include(c => c.combustible)
                                                .Include(c => c.combustible.unidad)
                                                .Include(c => c.fuenteEmision)
                                                .Include(c => c.subcategoria)
                                                .OrderBy(c => c.subcategoria.nombreSubcategoria);
            return View(await context.ToListAsync());
        }

        // GET: ConfiguracionActividads/Create
        public IActionResult Create()
        {
            List<Combustible> combustible = _context.Combustible.Where(c => c.enabled == true).Include(c => c.unidad).ToList();
            var listaCombustibles = new List<SelectListItem>();
            foreach (var item in combustible)
            {
                listaCombustibles.Add(new SelectListItem { Text = item.nombreCombustible + " - " + item.unidad.unidad, Value = item.idCombustible.ToString() });
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

            List<ConfiguracionActividad> configuracionActividads = _context.ConfiguracionActividad.Where(c => c.enabled == true && c.subcategoria.categoria.alcance.isBiocombustible)
                                                                                                .Include(c => c.combustible)
                                                                                                .Include(c => c.combustible.unidad)
                                                                                                .Include(c => c.fuenteEmision)
                                                                                                .Include(c => c.subcategoria)
                                                                                                .ToList();
            var listaConfiguraciones = new List<SelectListItem>();
            foreach (var item in configuracionActividads)
            {
                listaConfiguraciones.Add(new SelectListItem { Text = item.subcategoria.nombreSubcategoria + " - " + item.fuenteEmision.nombreFuenteEmision + " - " + item.combustible.nombreCombustible, Value = item.idConfiguracion.ToString() });
            }
            ViewData["idConfDependiente"] = listaConfiguraciones;
            return View();
        }

        // POST: ConfiguracionActividads/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idConfiguracion,idCombustible,idSubcategoria,idFuenteEmision,biocombustible,idConfDependiente, porcentaje")] ConfiguracionActividad configuracionActividad)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            configuracionActividad.enabled = true;
            if (!configuracionActividad.biocombustible)
            {
                configuracionActividad.idConfDependiente = null;
                configuracionActividad.porcentaje = null;
            }
            if (ModelState.IsValid)
            {
                _context.Add(configuracionActividad);
                Log log = new Log
                {
                    accion = 1,
                    contenido = configuracionActividad.ToString(),
                    idUsuario = user.idUsuario,
                    fechaAccion = DateTime.UtcNow
                };
                _context.Log.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<Combustible> combustible = _context.Combustible.Where(c => c.enabled == true).Include(c => c.unidad).ToList();
            var listaCombustibles = new List<SelectListItem>();
            foreach (var item in combustible)
            {
                listaCombustibles.Add(new SelectListItem { Text = item.nombreCombustible + " - " + item.unidad.unidad, Value = item.idCombustible.ToString() });
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

            List<ConfiguracionActividad> configuracionActividads = _context.ConfiguracionActividad.Where(c => c.enabled == true && c.subcategoria.categoria.alcance.isBiocombustible)
                                                                                                .Include(c => c.combustible)
                                                                                                .Include(c => c.combustible.unidad)
                                                                                                .Include(c => c.fuenteEmision)
                                                                                                .Include(c => c.subcategoria)
                                                                                                .ToList();
            var listaConfiguraciones = new List<SelectListItem>();
            foreach (var item in configuracionActividads)
            {
                listaConfiguraciones.Add(new SelectListItem { Text = item.subcategoria.nombreSubcategoria + " - " + item.fuenteEmision.nombreFuenteEmision + " - " + item.combustible.nombreCombustible, Value = item.idConfiguracion.ToString() });
            }
            ViewData["idConfDependiente"] = listaConfiguraciones;
            return View();
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
            List<Combustible> combustible = _context.Combustible.Where(c => c.enabled == true).Include(c => c.unidad).ToList();
            var listaCombustibles = new List<SelectListItem>();
            foreach (var item in combustible)
            {
                listaCombustibles.Add(new SelectListItem { Text = item.nombreCombustible + " - " + item.unidad.unidad, Value = item.idCombustible.ToString() });
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

            List<ConfiguracionActividad> configuracionActividads = _context.ConfiguracionActividad.Where(c => c.enabled == true && c.subcategoria.categoria.alcance.isBiocombustible)
                                                                                               .Include(c => c.combustible)
                                                                                               .Include(c => c.combustible.unidad)
                                                                                               .Include(c => c.fuenteEmision)
                                                                                               .Include(c => c.subcategoria)
                                                                                               .ToList();
            var listaConfiguraciones = new List<SelectListItem>();
            foreach (var item in configuracionActividads)
            {
                listaConfiguraciones.Add(new SelectListItem { Text = item.subcategoria.nombreSubcategoria + " - " + item.fuenteEmision.nombreFuenteEmision + " - " + item.combustible.nombreCombustible, Value = item.idConfiguracion.ToString() });
            }
            ViewData["idConfDependiente"] = listaConfiguraciones;
            return View(configuracionActividad);
        }

        // POST: ConfiguracionActividads/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idConfiguracion,idCombustible,idSubcategoria,idFuenteEmision,biocombustible,idConfDependiente, porcentaje")] ConfiguracionActividad configuracionActividad)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            if (id != configuracionActividad.idConfiguracion)
            {
                return NotFound();
            }

            configuracionActividad.enabled = true;
            if (!configuracionActividad.biocombustible)
            {
                configuracionActividad.idConfDependiente = null;
                configuracionActividad.porcentaje = null;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracionActividad);
                    await _context.SaveChangesAsync();

                    Log log = new Log
                    {
                        accion = 2,
                        contenido = configuracionActividad.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
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
            List<Combustible> combustible = _context.Combustible.Where(c => c.enabled == true).Include(c => c.unidad).ToList();
            var listaCombustibles = new List<SelectListItem>();
            foreach (var item in combustible)
            {
                listaCombustibles.Add(new SelectListItem { Text = item.nombreCombustible + " - " + item.unidad.unidad, Value = item.idCombustible.ToString() });
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

            List<ConfiguracionActividad> configuracionActividads = _context.ConfiguracionActividad.Where(c => c.enabled == true && c.subcategoria.categoria.alcance.isBiocombustible)
                                                                                               .Include(c => c.combustible)
                                                                                               .Include(c => c.combustible.unidad)
                                                                                               .Include(c => c.fuenteEmision)
                                                                                               .Include(c => c.subcategoria)
                                                                                               .ToList();
            var listaConfiguraciones = new List<SelectListItem>();
            foreach (var item in configuracionActividads)
            {
                listaConfiguraciones.Add(new SelectListItem { Text = item.subcategoria.nombreSubcategoria + " - " + item.fuenteEmision.nombreFuenteEmision + " - " + item.combustible.nombreCombustible, Value = item.idConfiguracion.ToString() });
            }
            ViewData["idConfDependiente"] = listaConfiguraciones;
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
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            if (_context.ConfiguracionActividad == null)
            {
                return Problem("Entity set 'Context.ConfiguracionActividad'  is null.");
            }
            var configuracionActividad = await _context.ConfiguracionActividad.FindAsync(id);
            if (configuracionActividad != null)
            {
                configuracionActividad.enabled = false;
                _context.ConfiguracionActividad.Update(configuracionActividad);
                Log log = new Log
                {
                    accion = 3,
                    contenido = configuracionActividad.ToString(),
                    idUsuario = user.idUsuario,
                    fechaAccion = DateTime.UtcNow
                };
                _context.Log.Add(log);
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
