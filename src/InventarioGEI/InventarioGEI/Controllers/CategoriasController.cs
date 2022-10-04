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
    public class CategoriasController : Controller
    {
        private readonly Context _context;

        public CategoriasController(Context context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            var context = _context.Categoria.Where(c => c.enabled == true).Include(c => c.alcance).Include(c => c.usuarios);
            return View(await context.ToListAsync());
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            List<Alcance> alcances = _context.Alcance.Where(a => a.enabled == true).ToList();
            var listaAlcances = new List<SelectListItem>();
            foreach (var item in alcances)
            {
                listaAlcances.Add(new SelectListItem { Text = item.nombreAlcance, Value = item.idAlcance.ToString() });
            }
            ViewData["idAlcance"] = listaAlcances;
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCategoria,nombreCategoria,idAlcance")] Categoria categoria)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            categoria.enabled = true;
            categoria.idUsuario = user.idUsuario;
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idAlcance"] = new SelectList(_context.Alcance, "idAlcance", "idAlcance", categoria.idAlcance);
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email", categoria.idUsuario);
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCategoria,nombreCategoria,idAlcance")] Categoria categoria)
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
            ViewData["idAlcance"] = new SelectList(_context.Alcance, "idAlcance", "idAlcance", categoria.idAlcance);
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email", categoria.idUsuario);
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categoria == null)
            {
                return Problem("Entity set 'Context.Categoria'  is null.");
            }
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria != null)
            {
                categoria.enabled = false;
                _context.Categoria.Update(categoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
          return _context.Categoria.Any(e => e.idCategoria == id);
        }
    }
}
