﻿using System;
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
    public class RolsController : AccesController
    {

        private readonly Context _context;

        public RolsController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("Roles")]
        // GET: Rols
        public async Task<IActionResult> Index()
        {
            if (GetAccesRol("Rol"))
            {
                ViewBag.NavRol = true;
                return View(await _context.Rol.Where(r => r.enabled == true).ToListAsync());
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }

        }

        [Breadcrumb("Crear")]
        // GET: Rols/Create
        public IActionResult Create()
        {
            if (GetAccesRol("Rol"))
            {
                ViewBag.NavRol = true;
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
            if (GetAccesRol("Rol"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                rol.enabled = true;
                if (ModelState.IsValid)
                {
                    _context.Add(rol);
                    Log log = new Log
                    {
                        accion = 1,
                        contenido = rol.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(rol);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Editar")]
        // GET: Rols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (GetAccesRol("Rol"))
            {
                ViewBag.NavRol = true;
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
            if (GetAccesRol("Rol"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (id != rol.idRol)
                {
                    return NotFound();
                }

                rol.enabled = true;
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(rol);
                        await _context.SaveChangesAsync();
                        Log log = new Log
                        {
                            accion = 2,
                            contenido = rol.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
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
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Eliminar")]
        // GET: Rols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (GetAccesRol("Rol"))

            {
                ViewBag.NavRol = true;
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

            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }

        }

        // POST: Rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (GetAccesRol("Rol"))

            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (_context.Rol == null)
                {
                    return Problem("Entity set 'Context.Rol'  is null.");
                }
                var rol = await _context.Rol.FindAsync(id);
                if (rol != null)
                {
                    rol.enabled = false;
                    _context.Rol.Update(rol);
                    Log log = new Log
                    {
                        accion = 3,
                        contenido = rol.ToString(),
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

        private bool RolExists(int id)
        {
            return _context.Rol.Any(e => e.idRol == id);
        }
    }
}
