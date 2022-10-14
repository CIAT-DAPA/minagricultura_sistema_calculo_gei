using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;
using Newtonsoft.Json.Linq;

namespace InventarioGEI.Controllers
{
    public class RegistroActividadsController : AccesController
    {
        private readonly Context _context;

        public RegistroActividadsController(Context context) : base(context)
        {
            _context = context;
        }

        // GET: RegistroActividads
        public async Task<IActionResult> Index()
        {
            var context = _context.RegistroActividad.Where(r => r.enabled == true).Include(r => r.configuracion.combustible).Include(r => r.configuracion.combustible.unidad).Include(r => r.sede).Include(r => r.usuario);

            List<Alcance> alcances = _context.Alcance.Where(a => a.enabled == true).ToList();
            var listaAlcances = new List<SelectListItem>();
            foreach (var item in alcances)
            {
                listaAlcances.Add(new SelectListItem { Text = item.nombreAlcance, Value = item.idAlcance.ToString() });
            }
            ViewData["alcance"] = listaAlcances;

            List<Sede> sede = _context.Sede.Where(s => s.enabled == true).ToList();
            var listaSedes = new List<SelectListItem>();
            foreach (var item in sede)
            {
                listaSedes.Add(new SelectListItem { Text = item.nombreSede, Value = item.idSede.ToString() });
            }
            ViewData["sede"] = listaSedes;

        

            return View(await context.ToListAsync());
        }

        // GET: RegistroActividads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroActividad == null)
            {
                return NotFound();
            }

            var registroActividad = await _context.RegistroActividad
                .Include(r => r.configuracion)
                .Include(r => r.sede)
                .Include(r => r.usuario)
                .FirstOrDefaultAsync(m => m.idRegistroActividad == id);
            if (registroActividad == null)
            {
                return NotFound();
            }

            return View(registroActividad);
        }

        // GET: RegistroActividads/Create
        public IActionResult Create()
        {
            ViewData["idConfiguracion"] = new SelectList(_context.ConfiguracionActividad, "idConfiguracion", "idConfiguracion");
            ViewData["idSede"] = new SelectList(_context.Sede, "idSede", "idSede");
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email");
            return View();
        }

        // POST: RegistroActividads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idRegistroActividad,valor,mes,ano,enabled,idConfiguracion,idUsuario,idSede")] RegistroActividad registroActividad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroActividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idConfiguracion"] = new SelectList(_context.ConfiguracionActividad, "idConfiguracion", "idConfiguracion", registroActividad.idConfiguracion);
            ViewData["idSede"] = new SelectList(_context.Sede, "idSede", "idSede", registroActividad.idSede);
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email", registroActividad.idUsuario);
            return View(registroActividad);
        }

        // GET: RegistroActividads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroActividad == null)
            {
                return NotFound();
            }

            var registroActividad = await _context.RegistroActividad.FindAsync(id);
            if (registroActividad == null)
            {
                return NotFound();
            }
            ViewData["idConfiguracion"] = new SelectList(_context.ConfiguracionActividad, "idConfiguracion", "idConfiguracion", registroActividad.idConfiguracion);
            ViewData["idSede"] = new SelectList(_context.Sede, "idSede", "idSede", registroActividad.idSede);
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email", registroActividad.idUsuario);
            return View(registroActividad);
        }

        // POST: RegistroActividads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idRegistroActividad,valor,mes,ano,enabled,idConfiguracion,idUsuario,idSede")] RegistroActividad registroActividad)
        {
            if (id != registroActividad.idRegistroActividad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroActividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroActividadExists(registroActividad.idRegistroActividad))
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
            ViewData["idConfiguracion"] = new SelectList(_context.ConfiguracionActividad, "idConfiguracion", "idConfiguracion", registroActividad.idConfiguracion);
            ViewData["idSede"] = new SelectList(_context.Sede, "idSede", "idSede", registroActividad.idSede);
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "idUsuario", "email", registroActividad.idUsuario);
            return View(registroActividad);
        }

        // GET: RegistroActividads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroActividad == null)
            {
                return NotFound();
            }

            var registroActividad = await _context.RegistroActividad
                .Include(r => r.configuracion)
                .Include(r => r.sede)
                .Include(r => r.usuario)
                .FirstOrDefaultAsync(m => m.idRegistroActividad == id);
            if (registroActividad == null)
            {
                return NotFound();
            }

            return View(registroActividad);
        }

        // POST: RegistroActividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroActividad == null)
            {
                return Problem("Entity set 'Context.RegistroActividad'  is null.");
            }
            var registroActividad = await _context.RegistroActividad.FindAsync(id);
            if (registroActividad != null)
            {
                _context.RegistroActividad.Remove(registroActividad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroActividadExists(int id)
        {
          return _context.RegistroActividad.Any(e => e.idRegistroActividad == id);
        }

        [HttpGet]
        public ActionResult GetCategorias(int id)
        {
            if (id > 0)
            {
                Console.WriteLine("entro metodo if");

                List<Categoria> categorias = _context.Categoria.Where(c => c.enabled == true).Where(c => c.idAlcance == id).ToList();
                var listaCategorias = new List<SelectListItem>();
                foreach (var item in categorias)
                {
                    listaCategorias.Add(new SelectListItem { Text = item.nombreCategoria, Value = item.idCategoria.ToString() });
                }

                Console.WriteLine(listaCategorias);
                return Json(listaCategorias);
            }
            return null;
        }
    }
}
