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

        [HttpGet]
        public ActionResult GetCategorias(int id)
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

        [HttpGet]
        public async Task<IActionResult> GetCombustibles(int id)
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
                        .Include(c => c.combustible).Include(c => c.combustible.unidad)
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

        [HttpGet]
        public async Task<IActionResult> GetValorDeRegistros(int idConfiguracion, int mes, int año, int sede)
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


        [HttpPost]
        public async Task<IActionResult> PostRegistros(List<RegistroActividad> registros)
        {
            Usuario user = await _context.Usuario.FirstOrDefaultAsync(u => u.email == User.Identity.Name);
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
                    if (hasBio)
                    {
                        RegistroActividad regBio = new RegistroActividad
                        {
                            idConfiguracion = conf.configuracion.idConfiguracion,
                            idUsuario = registro.idUsuario,
                            idSede = registro.idSede,
                            valor = registro.valor * (conf.porcentaje / 100),
                            mes = registro.mes,
                            año = registro.año,
                            enabled = true
                        };
                        _context.RegistroActividad.Add(regBio);
                        await _context.SaveChangesAsync();
                    }

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

                    var bioExist = await _context.RegistroActividad
                    .Where(r => r.idConfiguracion == conf.configuracion.idConfiguracion)
                    .Where(r => r.idSede == registro.idSede)
                    .Where(r => r.mes == registro.mes)
                    .Where(r => r.año == registro.año)
                    .FirstAsync();

                    if (!registro.valor.HasValue)
                    {
                        if (hasBio)
                        {
                            RegistroActividad regBio = new RegistroActividad
                            {
                                idRegistroActividad = bioExist.idRegistroActividad,
                                idConfiguracion = conf.configuracion.idConfiguracion,
                                idUsuario = registro.idUsuario,
                                idSede = registro.idSede,
                                valor = registro.valor * (conf.porcentaje / 100),
                                mes = registro.mes,
                                año = registro.año,
                                enabled = true
                            };
                            _context.ChangeTracker.Clear();
                            _context.Remove(regBio);
                            await _context.SaveChangesAsync();
                        }

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
                        if (hasBio)
                        {
                            RegistroActividad regBio = new RegistroActividad
                            {
                                idRegistroActividad = bioExist.idRegistroActividad,
                                idConfiguracion = conf.configuracion.idConfiguracion,
                                idUsuario = registro.idUsuario,
                                idSede = registro.idSede,
                                valor = registro.valor * (conf.porcentaje / 100),
                                mes = registro.mes,
                                año = registro.año,
                                enabled = true
                            };
                            _context.ChangeTracker.Clear();
                            _context.Update(regBio);
                            await _context.SaveChangesAsync();
                        }
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
            return Ok(true);

        }
    }
}
