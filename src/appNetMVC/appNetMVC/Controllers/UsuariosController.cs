﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appNetMVC.Models;

namespace appNetMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var context = _context.Usuario.Include(u => u.rolUsuario);
            return View(await context.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.rolUsuario)
                .FirstOrDefaultAsync(m => m.idUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["idRol"] = new SelectList(_context.Rol, "idRol", "idRol");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUsuario,email,idRol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idRol"] = new SelectList(_context.Rol, "idRol", "idRol", usuario.idRol);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["idRol"] = new SelectList(_context.Rol, "idRol", "idRol", usuario.idRol);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUsuario,email,idRol")] Usuario usuario)
        {
            if (id != usuario.idUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.idUsuario))
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
            ViewData["idRol"] = new SelectList(_context.Rol, "idRol", "idRol", usuario.idRol);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.rolUsuario)
                .FirstOrDefaultAsync(m => m.idUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'Context.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return _context.Usuario.Any(e => e.idUsuario == id);
        }

        // GET: Usuarios/Authentication
        public IActionResult Authentication()
        {
            return View();
        }

        // POST: Usuarios/Authentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authentication([Bind("email")] Usuario usuario)
        {
            var usuarioBd = await _context.Usuario.FirstOrDefaultAsync(m => m.email == usuario.email);

            var rol = await _context.Rol.FirstOrDefaultAsync(m => m.idRol == usuarioBd.idRol);

            return rol.nombreRol.Equals("AdmiRoles") ? RedirectToAction("Index", "Rols") : RedirectToAction("Index", "Usuarios");
        }
    }
}
