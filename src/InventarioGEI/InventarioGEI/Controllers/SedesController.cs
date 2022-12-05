using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using SmartBreadcrumbs.Attributes;

namespace InventarioGEI.Controllers
{
    public class SedesController : AccesController
    {
        private readonly Context _context;

        public SedesController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("Sedes")]
        // GET: Sedes
        //[Authorize("rol-only")]
        public async Task<IActionResult> Index(string? filter)
        {
            if (GetAccesRol("Sede"))
            {
                ViewBag.NavSede = true;
                ViewBag.filter = new SelectList(_context.Departamento, "codigoDepartamento", "nombreDepartamento");

                var sedes = new Object();

                if (!String.IsNullOrEmpty(filter))
                {
                    sedes = await _context.Sede.Include("municipio").Include("municipio.departamento").Where(s => s.municipio.departamento.codigoDepartamento == Int32.Parse(filter)).Where(s => s.enabled == true).ToListAsync();
                }
                else
                {
                    sedes = await _context.Sede.Include("municipio").Include("municipio.departamento").Where(s => s.enabled == true).ToListAsync();
                }

                return View(sedes);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Crear")]
        // GET: Sedes/Create
        public IActionResult Create()
        {
            if (GetAccesRol("Sede"))
            {
                ViewBag.NavSede = true;
                ViewBag.departamentos = new SelectList(_context.Departamento, "codigoDepartamento", "nombreDepartamento");

                return View();
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [HttpGet]
        public ActionResult GetMunicipios(int id)
        {
            List<Municipio> municipios = _context.Municipio.Where(c => c.codDepartamento == id).ToList();
            var listaMunicipios = new List<SelectListItem>();
            foreach (var item in municipios)
            {
                listaMunicipios.Add(new SelectListItem { Text = item.nombreMunicipio, Value = item.codigoMunicipio.ToString() });
            }
            return Json(listaMunicipios);
        }

        // POST: Sedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idSede,nombreSede,direccion,idUsuario,codMunicipio")] Sede sede)
        {
            if (GetAccesRol("Sede"))
            {
                try
                {
                    Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                    sede.enabled = true;
                    sede.idUsuario = user.idUsuario;
                    if (ModelState.IsValid)
                    {
                        _context.Sede.Add(sede);
                        await _context.SaveChangesAsync();
                        Log log = new Log
                        {
                            accion = 1,
                            contenido = sede.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DataException e)
                {
                    Console.WriteLine("Exception information: {0}", e); ;
                    ModelState.AddModelError("", "No se pueden guardar los cambios. Inténtelo de nuevo y, si el problema persiste, consulte al administrador del sistema.");
                }
                ModelState.AddModelError("", "No se pueden guardar los cambios. Inténtelo de nuevo y, si el problema persiste, consulte al administrador del sistema.");
                ViewBag.departamentos = new SelectList(_context.Departamento, "codigoDepartamento", "nombreDepartamento");
                return View(sede);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Editar")]
        // GET: Sedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (GetAccesRol("Sede"))
            {
                ViewBag.NavSede = true;
                if (id == null || _context.Sede == null)
                {
                    return NotFound();
                }

                var sede = await _context.Sede.Include("municipio").Include("municipio.departamento")
                .FirstOrDefaultAsync(m => m.idSede == id);
                if (sede == null)
                {
                    return NotFound();
                }
                ViewBag.departamentos = new SelectList(_context.Departamento, "codigoDepartamento", "nombreDepartamento");
                ViewBag.municipios = new SelectList(_context.Municipio.Where(m => m.codDepartamento == sede.municipio.codDepartamento), "codigoMunicipio", "nombreMunicipio");
                return View(sede);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idSede,nombreSede,direccion,idUsuario,codMunicipio")] Sede sede)
        {
            if (GetAccesRol("Sede"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                sede.enabled = true;
                sede.idUsuario = user.idUsuario;
                sede.idSede = id;
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(sede);
                        await _context.SaveChangesAsync();
                        Log log = new Log
                        {
                            accion = 2,
                            contenido = sede.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {

                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(sede);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [Breadcrumb("Eliminar")]
        // GET: Sedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (GetAccesRol("Sede"))
            {
                ViewBag.NavSede = true;
                if (id == null || _context.Sede == null)
                {
                    return NotFound();
                }

                var sede = await _context.Sede.Include("municipio").Include("municipio.departamento")
                    .FirstOrDefaultAsync(m => m.idSede == id);
                if (sede == null)
                {
                    return NotFound();
                }

                return View(sede);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (GetAccesRol("Sede"))
            {
                Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
                if (_context.Sede == null)
                {
                    return Problem("Entity set 'Context.Sede'  is null.");
                }
                var sede = await _context.Sede.FindAsync(id);
                if (sede != null)
                {
                    sede.enabled = false;
                    _context.Sede.Update(sede);
                    Log log = new Log
                    {
                        accion = 3,
                        contenido = sede.ToString(),
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

        private bool SedeExists(int id)
        {
            return _context.Sede.Any(e => e.idSede == id);
        }


    }
}