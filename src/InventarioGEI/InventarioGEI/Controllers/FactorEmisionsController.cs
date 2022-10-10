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
    public class FactorEmisionsController : AccesController
    {
        private readonly Context _context;

        public FactorEmisionsController(Context context) : base(context)
        {
            _context = context;
        }

        // GET: FactorEmisions
        public async Task<IActionResult> Index()
        {
            var context = _context.FactorEmision.Where(f => f.enabled == true).Include(f => f.configuracion).Include(f=> f.configuracion.combustible).Include(f => f.configuracion.fuenteEmision).Include(f => f.configuracion.subcategoria).Include(f => f.gei).Include(f => f.usuario);
            return View(await context.ToListAsync());
        }

        // GET: FactorEmisions1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FactorEmision == null)
            {
                return NotFound();
            }

            var factorEmision = await _context.FactorEmision
                .Include(f => f.configuracion)
                .Include(f => f.configuracion.subcategoria)
                .Include(f => f.configuracion.fuenteEmision)
                .Include(f => f.configuracion.combustible)
                .Include(f => f.gei)
                .Include(f => f.usuario)
                .FirstOrDefaultAsync(m => m.idFE == id);
            ViewData["configuracion"] = factorEmision.configuracion.subcategoria.nombreSubcategoria + " - " + factorEmision.configuracion.fuenteEmision.nombreFuenteEmision + " - " + factorEmision.configuracion.combustible.nombreCombustible;
            if (factorEmision == null)
            {
                return NotFound();
            }

            return View(factorEmision);
        }

        // GET: FactorEmisions/Create
        public IActionResult Create()
        {
            List<ConfiguracionActividad> configuraciones = _context.ConfiguracionActividad.Where(c => c.enabled == true).Include(c => c.subcategoria).Include(c => c.fuenteEmision).Include(c => c.combustible).ToList();
            var listaConfiguraciones = new List<SelectListItem>();
            foreach (var item in configuraciones)
            {
                listaConfiguraciones.Add(new SelectListItem { Text = item.subcategoria.nombreSubcategoria + " - " + item.fuenteEmision.nombreFuenteEmision + " - " + item.combustible.nombreCombustible, Value = item.idConfiguracion.ToString() });
            }
            ViewData["idConfiguracion"] = listaConfiguraciones;

            List<GEI> geis = _context.Gei.Where(g => g.enabled == true).ToList();
            var listaGeis = new List<SelectListItem>();
            foreach (var item in geis)
            {
                listaGeis.Add(new SelectListItem { Text = item.nombreGei, Value = item.idGei.ToString() });
            }
            ViewData["idGei"] = listaGeis;
            return View();
        }

        // POST: FactorEmisions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idFE,factorEmision,PCG,incertidumbreMas,incertidumbreMenos,idGei,idConfiguracion")] FactorEmision factor)
        {
            factor.enabled = true;
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            factor.idUsuario = user.idUsuario;
            if (ModelState.IsValid)
            {
                _context.Add(factor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<ConfiguracionActividad> configuraciones = _context.ConfiguracionActividad.Where(c => c.enabled == true).Include(c => c.subcategoria).Include(c => c.fuenteEmision).Include(c => c.combustible).ToList();
            var listaConfiguraciones = new List<SelectListItem>();
            foreach (var item in configuraciones)
            {
                listaConfiguraciones.Add(new SelectListItem { Text = item.subcategoria.nombreSubcategoria + " - " + item.fuenteEmision.nombreFuenteEmision + " - " + item.combustible.nombreCombustible, Value = item.idConfiguracion.ToString() });
            }
            ViewData["idConfiguracion"] = listaConfiguraciones;

            List<GEI> geis = _context.Gei.Where(g => g.enabled == true).ToList();
            var listaGeis = new List<SelectListItem>();
            foreach (var item in geis)
            {
                listaGeis.Add(new SelectListItem { Text = item.nombreGei, Value = item.idGei.ToString() });
            }
            ViewData["idGei"] = listaGeis;
            return View(factor);
        }

        // GET: FactorEmisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FactorEmision == null)
            {
                return NotFound();
            }

            var factorEmision = await _context.FactorEmision.FindAsync(id);
            if (factorEmision == null)
            {
                return NotFound();
            }
            List<ConfiguracionActividad> configuraciones = _context.ConfiguracionActividad.Where(c => c.enabled == true).Include(c => c.subcategoria).Include(c => c.fuenteEmision).Include(c => c.combustible).ToList();
            var listaConfiguraciones = new List<SelectListItem>();
            foreach (var item in configuraciones)
            {
                listaConfiguraciones.Add(new SelectListItem { Text = item.subcategoria.nombreSubcategoria + " - " + item.fuenteEmision.nombreFuenteEmision + " - " + item.combustible.nombreCombustible, Value = item.idConfiguracion.ToString() });
            }
            ViewData["idConfiguracion"] = listaConfiguraciones;

            List<GEI> geis = _context.Gei.Where(g => g.enabled == true).ToList();
            var listaGeis = new List<SelectListItem>();
            foreach (var item in geis)
            {
                listaGeis.Add(new SelectListItem { Text = item.nombreGei, Value = item.idGei.ToString() });
            }
            ViewData["idGei"] = listaGeis;
            return View(factorEmision);
        }

        // POST: FactorEmisions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idFE,factorEmision,PCG,incertidumbreMas,incertidumbreMenos,idGei,idConfiguracion")] FactorEmision factor)
        {
            if (id != factor.idFE)
            {
                return NotFound();
            }

            factor.enabled = true;
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            factor.idUsuario = user.idUsuario;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactorEmisionExists(factor.idFE))
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
            List<ConfiguracionActividad> configuraciones = _context.ConfiguracionActividad.Where(c => c.enabled == true).Include(c => c.subcategoria).Include(c => c.fuenteEmision).Include(c => c.combustible).ToList();
            var listaConfiguraciones = new List<SelectListItem>();
            foreach (var item in configuraciones)
            {
                listaConfiguraciones.Add(new SelectListItem { Text = item.subcategoria.nombreSubcategoria + " - " + item.fuenteEmision.nombreFuenteEmision + " - " + item.combustible.nombreCombustible, Value = item.idConfiguracion.ToString() });
            }
            ViewData["idConfiguracion"] = listaConfiguraciones;

            List<GEI> geis = _context.Gei.Where(g => g.enabled == true).ToList();
            var listaGeis = new List<SelectListItem>();
            foreach (var item in geis)
            {
                listaGeis.Add(new SelectListItem { Text = item.nombreGei, Value = item.idGei.ToString() });
            }
            ViewData["idGei"] = listaGeis;
            return View(factor);
        }

        // GET: FactorEmisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FactorEmision == null)
            {
                return NotFound();
            }

            var factorEmision = await _context.FactorEmision
                .Include(f => f.configuracion)
                .Include(f => f.configuracion.subcategoria)
                .Include(f => f.configuracion.fuenteEmision)
                .Include(f => f.configuracion.combustible)
                .Include(f => f.gei)
                .Include(f => f.usuario)
                .FirstOrDefaultAsync(m => m.idFE == id);
            ViewData["configuracion"] = factorEmision.configuracion.subcategoria.nombreSubcategoria + " - " + factorEmision.configuracion.fuenteEmision.nombreFuenteEmision + " - " + factorEmision.configuracion.combustible.nombreCombustible;
            if (factorEmision == null)
            {
                return NotFound();
            }

            return View(factorEmision);
        }

        // POST: FactorEmisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FactorEmision == null)
            {
                return Problem("Entity set 'Context.FactorEmision'  is null.");
            }
            var factorEmision = await _context.FactorEmision.FindAsync(id);
            if (factorEmision != null)
            {
                factorEmision.enabled = false;
                _context.FactorEmision.Update(factorEmision);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactorEmisionExists(int id)
        {
          return _context.FactorEmision.Any(e => e.idFE == id);
        }
    }
}
