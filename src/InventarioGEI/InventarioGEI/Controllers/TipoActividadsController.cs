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
    public class TipoActividadsController : AccesController
    {
        private readonly Context _context;

        public TipoActividadsController(Context context) : base(context)
        {
            _context = context;
        }

        // GET: TipoActividads
        public async Task<IActionResult> Index()
        {
            var context = _context.TipoActividad.Where(t => t.enabled == true).Include(t => t.usuario);
            return View(await context.ToListAsync());
        }

        // GET: TipoActividads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoActividads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTipoActividad,nombreTipoActividad")] TipoActividad tipoActividad)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            tipoActividad.enabled = true;
            tipoActividad.idUsuario = user.idUsuario;
            if (ModelState.IsValid)
            {
                _context.Add(tipoActividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email", tipoActividad.idUsuario);
            return View(tipoActividad);
        }

        // GET: TipoActividads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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

        // POST: TipoActividads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTipoActividad,nombreTipoActividad")] TipoActividad tipoActividad)
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

        // GET: TipoActividads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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

        // POST: TipoActividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoActividad == null)
            {
                return Problem("Entity set 'Context.TipoActividad'  is null.");
            }
            var tipoActividad = await _context.TipoActividad.FindAsync(id);
            if (tipoActividad != null)
            {
                tipoActividad.enabled = false;
                _context.TipoActividad.Update(tipoActividad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoActividadExists(int id)
        {
          return _context.TipoActividad.Any(e => e.idTipoActividad == id);
        }
    }
}
