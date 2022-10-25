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
    public class RegistroAnualsController : AccesController
    {
        private readonly Context _context;

        public RegistroAnualsController(Context context) : base(context)
        {
            _context = context;
        }

        // GET: RegistroAnuals
        public async Task<IActionResult> Index()
        {
            var context = _context.RegistroAnual.Include(r => r.sede).Include(r => r.user);
            return View(await context.ToListAsync());
        }

        // GET: RegistroAnuals/Create
        public IActionResult Create()
        {
            List<Sede> sedes = _context.Sede.Where(s => s.enabled == true).ToList();
            var listaSedes = new List<SelectListItem>();
            foreach (var item in sedes)
            {
                listaSedes.Add(new SelectListItem { Text = item.nombreSede, Value = item.idSede.ToString() });
            }
            ViewData["idSede"] = listaSedes;
            return View();
        }

        // POST: RegistroAnuals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idRegistroAnual,año,idSede")] RegistroAnual registroAnual)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            registroAnual.idUsuario = user.idUsuario;
            registroAnual.estado = true;
            registroAnual.fechaRegistro = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                _context.Add(registroAnual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<Sede> sedes = _context.Sede.Where(s => s.enabled == true).ToList();
            var listaSedes = new List<SelectListItem>();
            foreach (var item in sedes)
            {
                listaSedes.Add(new SelectListItem { Text = item.nombreSede, Value = item.idSede.ToString() });
            }
            ViewData["idSede"] = listaSedes; 
            return View(registroAnual);
        }

        // GET: RegistroAnuals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroAnual == null)
            {
                return NotFound();
            }

            var registroAnual = await _context.RegistroAnual
                .Include(r => r.sede)
                .Include(r => r.user)
                .FirstOrDefaultAsync(m => m.idRegistroAnual == id);
            if (registroAnual == null)
            {
                return NotFound();
            }

            return View(registroAnual);
        }

        // POST: RegistroAnuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroAnual == null)
            {
                return Problem("Entity set 'Context.RegistroAnual'  is null.");
            }
            var registroAnual = await _context.RegistroAnual.FindAsync(id);
            if (registroAnual != null)
            {
                registroAnual.estado = false;
                _context.RegistroAnual.Update(registroAnual);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroAnualExists(int id)
        {
          return _context.RegistroAnual.Any(e => e.idRegistroAnual == id);
        }
    }
}
