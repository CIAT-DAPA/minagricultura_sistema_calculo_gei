using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Authorization;
using SmartBreadcrumbs.Attributes;

namespace InventarioGEI.Controllers
{
    public class UsuariosController : AccesController
    {
        private readonly Context _context;

        public UsuariosController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("Usuarios")]
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            if (GetAccesRol("Rol"))
            {
                ViewBag.NavUsu = true;
                var context = _context.Usuario.Where(u => u.enabled == true).Include(u => u.rolUsuario);
                return View(await context.ToListAsync());
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Crear")]
        // GET: Usuarios/Create
        public IActionResult Create()
        {
            if (GetAccesRol("Rol"))
            {
                ViewBag.NavUsu = true;
                List<Rol> roles = _context.Rol.Where(r => r.enabled == true).ToList();
                var listaRoles = new List<SelectListItem>();
                foreach (var item in roles)
                {
                    listaRoles.Add(new SelectListItem { Text = item.nombreRol, Value = item.idRol.ToString() });
                }
                ViewData["idRol"] = listaRoles;
                return View();
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUsuario,email,idRol")] Usuario usuario)
        {
            if (GetAccesRol("Rol"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                usuario.enabled = true;
                if (ModelState.IsValid)
                {
                    _context.Add(usuario);
                    Log log = new Log
                    {
                        accion = 1,
                        contenido = usuario.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["idRol"] = new SelectList(_context.Rol, "idRol", "idRol", usuario.idRol);
                return View(usuario);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Editar")]
        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (GetAccesRol("Rol"))
            {
                ViewBag.NavUsu = true;
                if (id == null || _context.Usuario == null)
                {
                    return NotFound();
                }

                var usuario = await _context.Usuario.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                List<Rol> roles = _context.Rol.Where(r => r.enabled == true).ToList();
                var listaRoles = new List<SelectListItem>();
                foreach (var item in roles)
                {
                    listaRoles.Add(new SelectListItem { Text = item.nombreRol, Value = item.idRol.ToString() });
                }
                ViewData["idRol"] = listaRoles;
                return View(usuario);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUsuario,email,idRol")] Usuario usuario)
        {
            if (GetAccesRol("Rol"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (id != usuario.idUsuario)
                {
                    return NotFound();
                }
                usuario.enabled = true;
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(usuario);
                        await _context.SaveChangesAsync();
                        Log log = new Log
                        {
                            accion = 2,
                            contenido = usuario.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
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
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Eliminar")]
        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (GetAccesRol("Rol"))
            {
                ViewBag.NavUsu = true;
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
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (GetAccesRol("Rol"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (_context.Usuario == null)
                {
                    return Problem("Entity set 'Context.Usuario'  is null.");
                }
                var usuario = await _context.Usuario.FindAsync(id);
                if (usuario != null)
                {
                    usuario.enabled = false;
                    _context.Usuario.Update(usuario);
                    Log log = new Log
                    {
                        accion = 3,
                        contenido = usuario.ToString(),
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

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.idUsuario == id);
        }
    }
}
