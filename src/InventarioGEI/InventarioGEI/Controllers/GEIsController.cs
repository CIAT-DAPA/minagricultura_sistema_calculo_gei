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
    public class GEIsController : AccesController
    {
        private readonly Context _context;

        public GEIsController(Context context) : base(context)
        {
            _context = context;
        }

        // GET: GEIs
        public async Task<IActionResult> Index()
        {
            var context = _context.Gei.Where(g => g.enabled == true).Include(g => g.usuario);
            return View(await context.ToListAsync());
        }

        // GET: GEIs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GEIs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idGei,nombreGei")] GEI gEI)
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

        // GET: GEIs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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

        // POST: GEIs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idGei,nombreGei")] GEI gEI)
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

        // GET: GEIs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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

        // POST: GEIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private bool GEIExists(int id)
        {
          return _context.Gei.Any(e => e.idGei == id);
        }
    }
}
