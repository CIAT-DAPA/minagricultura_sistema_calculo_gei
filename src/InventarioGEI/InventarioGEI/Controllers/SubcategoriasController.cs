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
    public class SubcategoriasController : AccesController
    {
        private readonly Context _context;

        public SubcategoriasController(Context context) : base(context)
        {
            _context = context;
        }

        // GET: Subcategorias
        public async Task<IActionResult> Index()
        {
            var context = _context.Subcategoria.Where(s => s.enabled == true).Include(s => s.categoria).Include(s => s.usuario).OrderBy(s => s.categoria.nombreCategoria);
            return View(await context.ToListAsync());
        }

        // GET: Subcategorias/Create
        public IActionResult Create()
        {
            List<Categoria> categorias = _context.Categoria.Where(c => c.enabled == true).Include(c => c.alcance).ToList();
            var listaCategorias = new List<SelectListItem>();
            foreach (var item in categorias)
            {
                listaCategorias.Add(new SelectListItem { Text = item.alcance.nombreAlcance + " - " + item.nombreCategoria, Value = item.idCategoria.ToString() });
            }

            ViewData["idCategoria"] = listaCategorias;
            return View();
        }

        // POST: Subcategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idSubcategoria,nombreSubcategoria,idCategoria")] Subcategoria subcategoria)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            subcategoria.idUsuario = user.idUsuario;
            subcategoria.enabled = true;
            if (ModelState.IsValid)
            {
                _context.Add(subcategoria);
                Log log = new Log
                {
                    accion = 1,
                    contenido = subcategoria.ToString(),
                    idUsuario = user.idUsuario,
                    fechaAccion = DateTime.UtcNow
                };
                _context.Log.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<Categoria> categorias = _context.Categoria.Where(c => c.enabled == true).Include(c => c.alcance).ToList();
            var listaCategorias = new List<SelectListItem>();
            foreach (var item in categorias)
            {
                listaCategorias.Add(new SelectListItem { Text = item.alcance.nombreAlcance + " - " + item.nombreCategoria, Value = item.idCategoria.ToString() });
            }

            ViewData["idCategoria"] = listaCategorias;
            return View(subcategoria);
        }

        // GET: Subcategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subcategoria == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategoria.FindAsync(id);
            if (subcategoria == null)
            {
                return NotFound();
            }
            List<Categoria> categorias = _context.Categoria.Where(c => c.enabled == true).Include(c => c.alcance).ToList();
            var listaCategorias = new List<SelectListItem>();
            foreach (var item in categorias)
            {
                listaCategorias.Add(new SelectListItem { Text = item.alcance.nombreAlcance + " - " + item.nombreCategoria, Value = item.idCategoria.ToString() });
            }

            ViewData["idCategoria"] = listaCategorias;
            return View(subcategoria);
        }

        // POST: Subcategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idSubcategoria,nombreSubcategoria,idCategoria")] Subcategoria subcategoria)
        {
            if (id != subcategoria.idSubcategoria)
            {
                return NotFound();
            }

            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            subcategoria.idUsuario = user.idUsuario;
            subcategoria.enabled = true;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategoria);
                    await _context.SaveChangesAsync();
                    Log log = new Log
                    {
                        accion = 2,
                        contenido = subcategoria.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoriaExists(subcategoria.idSubcategoria))
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
            List<Categoria> categorias = _context.Categoria.Where(c => c.enabled == true).Include(c => c.alcance).ToList();
            var listaCategorias = new List<SelectListItem>();
            foreach (var item in categorias)
            {
                listaCategorias.Add(new SelectListItem { Text = item.alcance.nombreAlcance + " - " + item.nombreCategoria, Value = item.idCategoria.ToString() });
            }

            ViewData["idCategoria"] = listaCategorias;
            return View(subcategoria);
        }

        // GET: Subcategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subcategoria == null)
            {
                return NotFound();
            }

            var subcategoria = await _context.Subcategoria
                .Include(s => s.categoria)
                .Include(s => s.usuario)
                .FirstOrDefaultAsync(m => m.idSubcategoria == id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        // POST: Subcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            if (_context.Subcategoria == null)
            {
                return Problem("Entity set 'Context.Subcategoria'  is null.");
            }
            var subcategoria = await _context.Subcategoria.FindAsync(id);
            if (subcategoria != null)
            {
                subcategoria.enabled = false;
                _context.Subcategoria.Update(subcategoria);
                Log log = new Log
                {
                    accion = 3,
                    contenido = subcategoria.ToString(),
                    idUsuario = user.idUsuario,
                    fechaAccion = DateTime.UtcNow
                };
                _context.Log.Add(log);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcategoriaExists(int id)
        {
          return _context.Subcategoria.Any(e => e.idSubcategoria == id);
        }
    }
}
