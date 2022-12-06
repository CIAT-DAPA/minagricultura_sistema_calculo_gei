using System;
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
    public class CategoriasController : AccesController
    {
        private readonly Context _context;

        public CategoriasController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("Categorías")]
        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavCat = true;
                var context = _context.Categoria.Where(c => c.enabled == true).Include(c => c.alcance).Include(c => c.usuarios).OrderBy(c => c.alcance.nombreAlcance);
                return View(await context.ToListAsync());
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Crear")]
        // GET: Categorias/Create
        public IActionResult Create()
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavCat = true;
                List<Alcance> alcances = _context.Alcance.Where(a => a.enabled == true).ToList();
                var listaAlcances = new List<SelectListItem>();
                foreach (var item in alcances)
                {
                    listaAlcances.Add(new SelectListItem { Text = item.nombreAlcance, Value = item.idAlcance.ToString() });
                }
                ViewData["idAlcance"] = listaAlcances;
                return View();
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCategoria,nombreCategoria,idAlcance")] Categoria categoria)
        {
            if (GetAccesRol("Conf"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                categoria.enabled = true;
                categoria.idUsuario = user.idUsuario;
                if (ModelState.IsValid)
                {
                    _context.Add(categoria);

                    Log log = new Log
                    {
                        accion = 1,
                        contenido = categoria.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                List<Alcance> alcances = _context.Alcance.Where(a => a.enabled == true).ToList();
                var listaAlcances = new List<SelectListItem>();
                foreach (var item in alcances)
                {
                    listaAlcances.Add(new SelectListItem { Text = item.nombreAlcance, Value = item.idAlcance.ToString() });
                }
                ViewData["idAlcance"] = listaAlcances;
                return View(categoria);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Editar")]
        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavCat = true;
                if (id == null || _context.Categoria == null)
                {
                    return NotFound();
                }

                var categoria = await _context.Categoria.FindAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                List<Alcance> alcances = _context.Alcance.Where(a => a.enabled == true).ToList();
                var listaAlcances = new List<SelectListItem>();
                foreach (var item in alcances)
                {
                    listaAlcances.Add(new SelectListItem { Text = item.nombreAlcance, Value = item.idAlcance.ToString() });
                }
                ViewData["idAlcance"] = listaAlcances;
                return View(categoria);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCategoria,nombreCategoria,idAlcance")] Categoria categoria)
        {
            if (GetAccesRol("Conf"))
            {
                if (id != categoria.idCategoria)
                {
                    return NotFound();
                }

                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                categoria.idUsuario = user.idUsuario;
                categoria.enabled = true;

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(categoria);
                        await _context.SaveChangesAsync();
                        Log log = new Log
                        {
                            accion = 2,
                            contenido = categoria.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoriaExists(categoria.idCategoria))
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
                List<Alcance> alcances = _context.Alcance.Where(a => a.enabled == true).ToList();
                var listaAlcances = new List<SelectListItem>();
                foreach (var item in alcances)
                {
                    listaAlcances.Add(new SelectListItem { Text = item.nombreAlcance, Value = item.idAlcance.ToString() });
                }
                ViewData["idAlcance"] = listaAlcances;
                return View(categoria);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Eliminar")]
        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavCat = true;
                if (id == null || _context.Categoria == null)
                {
                    return NotFound();
                }

                var categoria = await _context.Categoria
                    .Include(c => c.alcance)
                    .Include(c => c.usuarios)
                    .FirstOrDefaultAsync(m => m.idCategoria == id);
                if (categoria == null)
                {
                    return NotFound();
                }

                return View(categoria);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (GetAccesRol("Conf"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (_context.Categoria == null)
                {
                    return Problem("Entity set 'Context.Categoria'  is null.");
                }
                var categoria = await _context.Categoria.FindAsync(id);
                if (categoria != null)
                {
                    categoria.enabled = false;
                    _context.Categoria.Update(categoria);
                    Log log = new Log
                    {
                        accion = 3,
                        contenido = categoria.ToString(),
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

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.idCategoria == id);
        }
    }
}
