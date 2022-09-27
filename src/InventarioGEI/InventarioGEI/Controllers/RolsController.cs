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
    public class RolsController : Controller
    {
        private readonly Context _context;

        public RolsController(Context context)
        {
            _context = context;
        }

        public bool GetAccesRol()
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            Rol rolAsig = _context.Rol.FirstOrDefault(r => r.idRol == user.idRol);
            if(rolAsig.permisoRol)
            {
                return true;
            }
            else
            {
                return false;
            }    
        }

        // GET: Rols
        public async Task<IActionResult> Index()
        {
            if (GetAccesRol())
            {
                return View(await _context.Rol.ToListAsync());
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
            
        }

        // GET: Rols/Create
        public IActionResult Create()
        {
            if (GetAccesRol())
            {
                return View();
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Rols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idRol,nombreRol,permisoRol,permisoSede,permisoConfiguracion,permisoRegistro,permisoVisualizacion")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        // GET: Rols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (GetAccesRol())
            {
                if (id == null || _context.Rol == null)
                {
                    return NotFound();
                }

                var rol = await _context.Rol.FindAsync(id);
                if (rol == null)
                {
                    return NotFound();
                }
                return View(rol);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Rols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idRol,nombreRol,permisoRol,permisoSede,permisoConfiguracion,permisoRegistro,permisoVisualizacion")] Rol rol)
        {
            if (id != rol.idRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolExists(rol.idRol))
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
            return View(rol);
        }

        // GET: Rols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }

            var rol = await _context.Rol
                .FirstOrDefaultAsync(m => m.idRol == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: Rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rol == null)
            {
                return Problem("Entity set 'Context.Rol'  is null.");
            }
            var rol = await _context.Rol.FindAsync(id);
            if (rol != null)
            {
                _context.Rol.Remove(rol);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolExists(int id)
        {
          return _context.Rol.Any(e => e.idRol == id);
        }
    }
}
