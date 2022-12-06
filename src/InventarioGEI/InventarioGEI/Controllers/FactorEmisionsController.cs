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
    public class FactorEmisionsController : AccesController
    {
        private readonly Context _context;

        public FactorEmisionsController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("Factores de emisión")]
        // GET: FactorEmisions
        public async Task<IActionResult> Index()
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavFac = true;
                var context = _context.FactorEmision.Where(f => f.enabled == true).Include(f => f.configuracion).Include(f => f.configuracion.combustible).Include(f => f.configuracion.fuenteEmision).Include(f => f.configuracion.subcategoria).Include(f => f.gei).Include(f => f.usuario).Include(f => f.configuracion.combustible.unidad).OrderBy(f => f.configuracion.subcategoria.nombreSubcategoria);
                return View(await context.ToListAsync());
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Crear")]
        // GET: FactorEmisions/Create
        public IActionResult Create()
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavFac = true;
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
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: FactorEmisions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idFE,factorEmision,PCG,incertidumbreMas,incertidumbreMenos,idGei,idConfiguracion")] FactorEmision factor)
        {
            if (GetAccesRol("Conf"))
            {
                factor.enabled = true;
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                factor.idUsuario = user.idUsuario;
                if (ModelState.IsValid)
                {
                    _context.Add(factor);
                    Log log = new Log
                    {
                        accion = 1,
                        contenido = factor.ToString(),
                        idUsuario = user.idUsuario,
                        fechaAccion = DateTime.UtcNow
                    };
                    _context.Log.Add(log);
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
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Editar")]
        // GET: FactorEmisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavFac = true;
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
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: FactorEmisions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idFE,factorEmision,PCG,incertidumbreMas,incertidumbreMenos,idGei,idConfiguracion")] FactorEmision factor)
        {
            if (GetAccesRol("Conf"))
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
                        Log log = new Log
                        {
                            accion = 2,
                            contenido = factor.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
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
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Eliminar")]
        // GET: FactorEmisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (GetAccesRol("Conf"))
            {
                ViewBag.NavFac = true;
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
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: FactorEmisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (GetAccesRol("Conf"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (_context.FactorEmision == null)
                {
                    return Problem("Entity set 'Context.FactorEmision'  is null.");
                }
                var factorEmision = await _context.FactorEmision.FindAsync(id);
                if (factorEmision != null)
                {
                    factorEmision.enabled = false;
                    _context.FactorEmision.Update(factorEmision);
                    Log log = new Log
                    {
                        accion = 3,
                        contenido = factorEmision.ToString(),
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

        private bool FactorEmisionExists(int id)
        {
            return _context.FactorEmision.Any(e => e.idFE == id);
        }

        [HttpGet]
        public ActionResult GetUnidad(int id)
        {
            if (id > 0)
            {
                var unidad = _context.ConfiguracionActividad.Where(c => c.idConfiguracion == id).Include(c => c.combustible).Include(c => c.combustible.unidad);
                Console.WriteLine(unidad);
                return Json(unidad);
            }
            return null;
        }
    }
}
