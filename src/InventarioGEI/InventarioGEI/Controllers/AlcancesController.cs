﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;

namespace InventarioGEI.Controllers
{
    public class AlcancesController : Controller
    {
        private readonly Context _context;

        public AlcancesController(Context context)
        {
            _context = context;
        }

        // GET: Alcances
        public async Task<IActionResult> Index()
        {
            var context = _context.Alcance.Include(a => a.usuario);
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
        public async Task<IActionResult> Create([Bind("idAlcance,nombreAlcance")] Alcance alcance)
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            alcance.idUsuario = user.idUsuario;
            alcance.enabled = true;
            if (ModelState.IsValid)
            {
                _context.Add(alcance);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAlcance,nombreAlcance")] Alcance alcance)
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
            if (_context.Alcance == null)
            {
                return Problem("Entity set 'Context.Alcance'  is null.");
            }
            var alcance = await _context.Alcance.FindAsync(id);
            if (alcance != null)
            {
                _context.Alcance.Remove(alcance);
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