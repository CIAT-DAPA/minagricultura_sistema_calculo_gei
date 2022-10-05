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
    public class CombustiblesController : Controller
    {
        private readonly Context _context;

        public CombustiblesController(Context context)
        {
            _context = context;
        }

        // GET: Combustibles
        public async Task<IActionResult> Index()
        {
            var context = _context.Combustible.Where(c => c.enabled == true).Include(c => c.actividad).Include(c => c.tipo).Include(c => c.unidad).Include(c => c.usuario);
            return View(await context.ToListAsync());
        }

        // GET: Combustibles/Create
        public IActionResult Create()
        {
            List<TipoActividad> tiposActividad = _context.TipoActividad.Where(t => t.enabled == true).ToList();
            var listaActividades = new List<SelectListItem>();
            foreach (var item in tiposActividad)
            {
                listaActividades.Add(new SelectListItem { Text = item.nombreTipoActividad, Value = item.idTipoActividad.ToString() });
            }
            ViewData["idActividad"] = listaActividades;

            List<Tipo> tipos = _context.Tipo.ToList();
            var listaTipos = new List<SelectListItem>();
            foreach (var item in tipos)
            {
                listaTipos.Add(new SelectListItem { Text = item.tipo, Value = item.idTipo.ToString() });
            }
            ViewData["idTipo"] = listaTipos;

            List<Unidad> unidades = _context.Unidad.ToList();
            var listaUnidades = new List<SelectListItem>();
            foreach (var item in unidades)
            {
                listaUnidades.Add(new SelectListItem { Text = item.unidad, Value = item.idUnidad.ToString() });
            }
            ViewData["idUnidad"] = listaUnidades;
            return View();
        }

        // POST: Combustibles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCombustible,nombreCombustible,idUnidad,idTipo,idActividad")] Combustible combustible)
        {
            combustible.enabled = true;
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            combustible.idUsuario = user.idUsuario;
            if (ModelState.IsValid)
            {
                _context.Add(combustible);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<TipoActividad> tiposActividad = _context.TipoActividad.Where(t => t.enabled == true).ToList();
            var listaActividades = new List<SelectListItem>();
            foreach (var item in tiposActividad)
            {
                listaActividades.Add(new SelectListItem { Text = item.nombreTipoActividad, Value = item.idTipoActividad.ToString() });
            }
            ViewData["idActividad"] = listaActividades;
            List<Tipo> tipos = _context.Tipo.ToList();
            var listaTipos = new List<SelectListItem>();
            foreach (var item in tipos)
            {
                listaTipos.Add(new SelectListItem { Text = item.tipo, Value = item.idTipo.ToString() });
            }
            ViewData["idTipo"] = listaTipos;

            List<Unidad> unidades = _context.Unidad.ToList();
            var listaUnidades = new List<SelectListItem>();
            foreach (var item in unidades)
            {
                listaUnidades.Add(new SelectListItem { Text = item.unidad, Value = item.idUnidad.ToString() });
            }
            ViewData["idUnidad"] = listaUnidades; 
            return View(combustible);
        }

        // GET: Combustibles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Combustible == null)
            {
                return NotFound();
            }

            var combustible = await _context.Combustible.FindAsync(id);
            if (combustible == null)
            {
                return NotFound();
            }

            List<TipoActividad> tiposActividad = _context.TipoActividad.Where(t => t.enabled == true).ToList();
            var listaActividades = new List<SelectListItem>();
            foreach (var item in tiposActividad)
            {
                listaActividades.Add(new SelectListItem { Text = item.nombreTipoActividad, Value = item.idTipoActividad.ToString() });
            }
            ViewData["idActividad"] = listaActividades;
            List<Tipo> tipos = _context.Tipo.ToList();
            var listaTipos = new List<SelectListItem>();
            foreach (var item in tipos)
            {
                listaTipos.Add(new SelectListItem { Text = item.tipo, Value = item.idTipo.ToString() });
            }
            ViewData["idTipo"] = listaTipos;

            List<Unidad> unidades = _context.Unidad.ToList();
            var listaUnidades = new List<SelectListItem>();
            foreach (var item in unidades)
            {
                listaUnidades.Add(new SelectListItem { Text = item.unidad, Value = item.idUnidad.ToString() });
            }
            ViewData["idUnidad"] = listaUnidades; 
            return View(combustible);
        }

        // POST: Combustibles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCombustible,nombreCombustible,idUnidad,idTipo,idActividad")] Combustible combustible)
        {
            if (id != combustible.idCombustible)
            {
                return NotFound();
            }

            combustible.enabled = true;
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            combustible.idUsuario = user.idUsuario;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combustible);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CombustibleExists(combustible.idCombustible))
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

            List<TipoActividad> tiposActividad = _context.TipoActividad.Where(t => t.enabled == true).ToList();
            var listaActividades = new List<SelectListItem>();
            foreach (var item in tiposActividad)
            {
                listaActividades.Add(new SelectListItem { Text = item.nombreTipoActividad, Value = item.idTipoActividad.ToString() });
            }
            ViewData["idActividad"] = listaActividades;
            List<Tipo> tipos = _context.Tipo.ToList();
            var listaTipos = new List<SelectListItem>();
            foreach (var item in tipos)
            {
                listaTipos.Add(new SelectListItem { Text = item.tipo, Value = item.idTipo.ToString() });
            }
            ViewData["idTipo"] = listaTipos;

            List<Unidad> unidades = _context.Unidad.ToList();
            var listaUnidades = new List<SelectListItem>();
            foreach (var item in unidades)
            {
                listaUnidades.Add(new SelectListItem { Text = item.unidad, Value = item.idUnidad.ToString() });
            }
            ViewData["idUnidad"] = listaUnidades; 
            return View(combustible);
        }

        // GET: Combustibles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Combustible == null)
            {
                return NotFound();
            }

            var combustible = await _context.Combustible
                .Include(c => c.actividad)
                .Include(c => c.tipo)
                .Include(c => c.unidad)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.idCombustible == id);
            if (combustible == null)
            {
                return NotFound();
            }

            return View(combustible);
        }

        // POST: Combustibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Combustible == null)
            {
                return Problem("Entity set 'Context.Combustible'  is null.");
            }
            var combustible = await _context.Combustible.FindAsync(id);
            if (combustible != null)
            {
                combustible.enabled = false;
                _context.Combustible.Update(combustible);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CombustibleExists(int id)
        {
          return _context.Combustible.Any(e => e.idCombustible == id);
        }
    }
}
