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
    public class AlcancesController : AccesController
    {
        private readonly Context _context;

        public AlcancesController(Context context) : base(context)
        {
            _context = context;
        }

        // GET: Alcances
        public async Task<IActionResult> Index()
        {
            ViewData["numAlcances"] = _context.Alcance.Where(a => a.enabled == true).Count();
            var context = _context.Alcance.Where(a => a.enabled == true).Include(a => a.usuario).OrderBy(a => a.nombreAlcance);
            return View(await context.ToListAsync());
        }

        // GET: Alcances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alcances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAlcance,nombreAlcance,isBiocombustible")] Alcance alcance)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            alcance.idUsuario = user.idUsuario;
            alcance.enabled = true;
            if (ModelState.IsValid)
            {
                _context.Add(alcance);
                await _context.SaveChangesAsync();

                Log log = new Log
                {
                    accion = 1,
                    contenido = alcance.ToString(),
                    idUsuario = user.idUsuario,
                    fechaAccion = DateTime.UtcNow                    
                };
                _context.Log.Add(log);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alcance);
        }

        // GET: Alcances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alcance == null)
            {
                return NotFound();
            }

            var alcance = await _context.Alcance.FindAsync(id);
            if (alcance == null)
            {
                return NotFound();
            }
            return View(alcance);
        }

        // POST: Alcances/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAlcance,nombreAlcance,isBiocombustible")] Alcance alcance)
        {
            if (id != alcance.idAlcance)
            {
                return NotFound();
            }

            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            alcance.idUsuario = user.idUsuario;
            alcance.enabled = true;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alcance);
                    await _context.SaveChangesAsync();

                    Log log = new Log
                    {
                        accion = 2,
                        contenido = alcance.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlcanceExists(alcance.idAlcance))
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
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email", alcance.idUsuario);
            return View(alcance);
        }

        // GET: Alcances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alcance == null)
            {
                return NotFound();
            }

            var alcance = await _context.Alcance
                .Include(a => a.usuario)
                .FirstOrDefaultAsync(m => m.idAlcance == id);
            if (alcance == null)
            {
                return NotFound();
            }

            return View(alcance);
        }

        // POST: Alcances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            if (_context.Alcance == null)
            {
                return Problem("Entity set 'Context.Alcance'  is null.");
            }
            var alcance = await _context.Alcance.FindAsync(id);
            if (alcance != null)
            {
                alcance.enabled = false;
                _context.Alcance.Update(alcance);

                Log log = new Log
                {
                    accion = 3,
                    contenido = alcance.ToString(),
                    idUsuario = user.idUsuario,
                    fechaAccion = DateTime.UtcNow
                };
                _context.Log.Add(log);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlcanceExists(int id)
        {
          return _context.Alcance.Any(e => e.idAlcance == id);
        }
    }
}
