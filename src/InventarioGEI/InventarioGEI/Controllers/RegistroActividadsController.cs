using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;
using Newtonsoft.Json.Linq;
using static Azure.Core.HttpHeader;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using SmartBreadcrumbs.Attributes;

namespace InventarioGEI.Controllers
{
    public class RegistroActividadsController : AccesController
    {
        private readonly Context _context;

        public RegistroActividadsController(Context context) : base(context)
        {
            _context = context;
        }

        [Breadcrumb("Registros")]
        // GET: RegistroActividads
        public async Task<IActionResult> Index()
        {
            if (GetAccesRol("Reg"))
            {
                ViewBag.NavRegAct = true;
                var context = _context.RegistroActividad.Where(r => r.enabled == true)
                                                    .Include(r => r.configuracion.combustible)
                                                    .Include(r => r.configuracion.combustible.unidad)
                                                    .Include(r => r.sede)
                                                    .Include(r => r.configuracion.fuenteEmision)
                                                    .Include(r => r.usuario);

                List<Alcance> alcances = _context.Alcance.Where(a => a.enabled == true && a.isBiocombustible == false).ToList();
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
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [HttpGet]
        public ActionResult GetCategorias(int id)
        {
            if (GetAccesRol("Reg"))
            {
                if (id > 0)
                {
                    List<Categoria> categorias = _context.Categoria.Where(c => c.enabled == true).Where(c => c.idAlcance == id).ToList();
                    var listaCategorias = new List<SelectListItem>();
                    foreach (var item in categorias)
                    {
                        listaCategorias.Add(new SelectListItem { Text = item.nombreCategoria, Value = item.idCategoria.ToString() });
                    }
                    return Json(listaCategorias);
                }
                return null;
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCombustibles(int id)
        {
            if (GetAccesRol("Reg"))
            {
                if (id > 0)
                {
                    List<Subcategoria> subcategorias = await _context.Subcategoria.Where(s => s.enabled == true).Where(s => s.idCategoria == id).ToListAsync();
                    List<ConfiguracionActividad> configuraciones = new List<ConfiguracionActividad>();
                    foreach (var item in subcategorias)
                    {
                        var configuracion = _context.ConfiguracionActividad
                            .Where(c => c.enabled)
                            .Where(c => c.idSubcategoria == item.idSubcategoria)
                            .Include(c => c.combustible)
                            .Include(c => c.combustible.unidad)
                            .Include(c => c.fuenteEmision)
                            .ToList();
                        configuracion.ForEach(delegate (ConfiguracionActividad conf)
                        {
                            configuraciones.Add(conf);
                        });
                    }

                    return Json(configuraciones);
                }
                return null;
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetValorDeRegistros(int idConfiguracion, int mes, int año, int sede)
        {
            if (GetAccesRol("Reg"))
            {
                var query = _context.RegistroActividad
                    .Where(r => r.idConfiguracion == idConfiguracion)
                    .Where(r => r.idSede == sede)
                    .Where(r => r.mes == mes)
                    .Where(r => r.año == año)
                    .Any();
                ;
                if (query)
                {
                    var queryExist = await _context.RegistroActividad
                        .Where(r => r.idConfiguracion == idConfiguracion)
                        .Where(r => r.idSede == sede)
                        .Where(r => r.mes == mes)
                        .Where(r => r.año == año)
                        .FirstAsync();

                    return Json(queryExist);
                }
                return NotFound();
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostRegistros(List<RegistroActividad> registros)
        {
            if (GetAccesRol("Reg"))
            {
                Usuario user = await _context.Usuario.FirstOrDefaultAsync(u => u.email == User.Identity.Name);

                var regWithBioRem = await _context.RegistroActividad
                        .Where(r => r.configuracion.subcategoria.categoria.alcance.isBiocombustible)
                        .ToListAsync();
                foreach (var r in regWithBioRem)
                {
                    _context.RegistroActividad.Remove(r);
                    await _context.SaveChangesAsync();
                }
                foreach (var registro in registros)
                {
                    registro.idUsuario = user.idUsuario;
                    var query = await _context.RegistroActividad
                        .Where(r => r.idConfiguracion == registro.idConfiguracion)
                        .Where(r => r.idSede == registro.idSede)
                        .Where(r => r.mes == registro.mes)
                        .Where(r => r.año == registro.año)
                        .AnyAsync();

                    var conf = await _context.ConfiguracionActividad.Include(c => c.configuracion).FirstAsync(c => c.idConfiguracion == registro.idConfiguracion);
                    bool hasBio = conf.biocombustible;

                    if (!query && registro.valor.HasValue)
                    {
                        _context.Add(registro);
                        await _context.SaveChangesAsync();

                        Log log = new Log
                        {
                            accion = 1,
                            contenido = registro.ToString(),
                            idUsuario = user.idUsuario,
                            fechaAccion = DateTime.UtcNow
                        };
                        _context.Log.Add(log);
                        await _context.SaveChangesAsync();


                    }
                    else if (query)
                    {
                        var queryExist = await _context.RegistroActividad
                        .Where(r => r.idConfiguracion == registro.idConfiguracion)
                        .Where(r => r.idSede == registro.idSede)
                        .Where(r => r.mes == registro.mes)
                        .Where(r => r.año == registro.año)
                        .FirstAsync();

                        if (!registro.valor.HasValue)
                        {
                            registro.idRegistroActividad = queryExist.idRegistroActividad;
                            _context.ChangeTracker.Clear();
                            _context.Remove(registro);
                            await _context.SaveChangesAsync();
                            Log log = new Log
                            {
                                accion = 3,
                                contenido = registro.ToString(),
                                idUsuario = user.idUsuario,
                                fechaAccion = DateTime.UtcNow
                            };
                            _context.Log.Add(log);
                            await _context.SaveChangesAsync();


                        }
                        else
                        {
                            registro.idRegistroActividad = queryExist.idRegistroActividad;
                            _context.ChangeTracker.Clear();
                            _context.Update(registro);
                            await _context.SaveChangesAsync();
                            Log log = new Log
                            {
                                accion = 2,
                                contenido = registro.ToString(),
                                idUsuario = user.idUsuario,
                                fechaAccion = DateTime.UtcNow
                            };
                            _context.Log.Add(log);
                            await _context.SaveChangesAsync();
                        }

                    }
                }

                var regWithBio = await _context.RegistroActividad
                        .Where(r => r.configuracion.biocombustible)
                        .Include(r => r.configuracion.combustible.unidad)
                        .Include(r => r.configuracion.configuracion)
                        .ToListAsync();
                var regWithBioGroupConf = regWithBio.GroupBy(r => r.configuracion.idConfDependiente);
                foreach (var group in regWithBioGroupConf)
                {
                    var regWithBioGroupSede = group.GroupBy(r => r.idSede);
                    foreach (var groupSede in regWithBioGroupSede)
                    {
                        var regWithBioGroupAño = groupSede.GroupBy(r => r.año);
                        foreach (var groupAño in regWithBioGroupAño)
                        {
                            var regWithBioGroupMes = groupAño.GroupBy(r => r.mes);
                            foreach (var groupMes in regWithBioGroupMes)
                            {
                                double valor = 0;
                                RegistroActividad regBio = new RegistroActividad
                                {
                                    idConfiguracion = (int)groupMes.First().configuracion.idConfDependiente,
                                    idUsuario = groupMes.First().idUsuario,
                                    idSede = groupMes.First().idSede,
                                    valor = valor,
                                    mes = groupMes.First().mes,
                                    año = groupMes.First().año,
                                    enabled = true
                                };
                                foreach (var reg in groupMes)
                                {
                                    if (reg.configuracion.combustible.unidad.unidad == "Km")
                                    {
                                        if (reg.configuracion.combustible.nombreCombustible.StartsWith("Diesel") || reg.configuracion.combustible.nombreCombustible.StartsWith("Diésel"))
                                        {
                                            regBio.valor += ((reg.valor * (reg.configuracion.porcentaje / 100)) / 39);
                                        }
                                        else
                                        {
                                            regBio.valor += ((reg.valor * (reg.configuracion.porcentaje / 100)) / 29);
                                        }

                                    }
                                    else
                                    {
                                        regBio.valor += (reg.valor * (reg.configuracion.porcentaje / 100));
                                    }
                                }
                                _context.RegistroActividad.Add(regBio);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
                return Ok(true);
            }
            else
            {
                return RedirectToAction("AccesDenied", "Home");
            }

        }
    }
}
