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
            var context = _context.RegistroAnual.Include(r => r.sede).Include(r => r.user).OrderByDescending(r => r.estado).ThenBy(r => r.sede.nombreSede);
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
                var regAnualExists = await _context.RegistroAnual.Where(r => r.idSede == registroAnual.idSede && r.año == registroAnual.año).AnyAsync();
                if (regAnualExists)
                {
                    var registrosAnualesAnt = await _context.RegistroAnual.Where(r => r.idSede == registroAnual.idSede && r.año == registroAnual.año && r.estado == true).ToListAsync();
                    foreach (var regAnt in registrosAnualesAnt)
                    {
                        regAnt.estado = false;
                        _context.RegistroAnual.Update(regAnt);
                    }
                }
                _context.Add(registroAnual);
                await _context.SaveChangesAsync();
                await CreateEmision(registroAnual.año, registroAnual.idSede, registroAnual.idRegistroAnual);
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

        [HttpPost]
        public async Task<IActionResult> CreateEmision(int año, int idSede, int idRegAnual)
        {
            var registros = await _context.RegistroActividad
                                                   .Where(r => r.año == año && r.idSede == idSede)
                                                   .ToListAsync();
            var registrosGroup = registros.GroupBy(r => r.idConfiguracion);
            Dictionary<int, double> factoresT = new Dictionary<int, double>()
                                                                        {
                                                                            {0, 0},
                                                                            {1, 12.71},
                                                                            {2, 12.71},
                                                                            {3, 4.3},
                                                                            {4, 3.18},
                                                                            {5, 2.78},
                                                                            {6, 2.57},
                                                                            {7, 2.45},
                                                                            {8, 2.36},
                                                                            {9, 2.31},
                                                                            {10, 2.26},
                                                                            {11, 2.23},
                                                                            {12, 2.2}
                                                                        };
            foreach (var group in registrosGroup)
            {
                Emision emision = new Emision();
                double valAnual = 0;
                int noDatos = 0;
                List<double> valList = new List<double>();
                foreach (var reg in group)
                {
                    switch (reg.mes)
                    {
                        case 1:
                            emision.mes1 = reg.valor;
                            break;
                        case 2:
                            emision.mes2 = reg.valor;
                            break;
                        case 3:
                            emision.mes3 = reg.valor;
                            break;
                        case 4:
                            emision.mes4 = reg.valor;
                            break;
                        case 5:
                            emision.mes5 = reg.valor;
                            break;
                        case 6:
                            emision.mes6 = reg.valor;
                            break;
                        case 7:
                            emision.mes7 = reg.valor;
                            break;
                        case 8:
                            emision.mes8 = reg.valor;
                            break;
                        case 9:
                            emision.mes9 = reg.valor;
                            break;
                        case 10:
                            emision.mes10 = reg.valor;
                            break;
                        case 11:
                            emision.mes11 = reg.valor;
                            break;
                        case 12:
                            emision.mes12 = reg.valor;
                            break;
                    }
                    valList.Add((double)reg.valor);
                    valAnual += (double)reg.valor;
                    
                        noDatos++;
                    
                }
                double promedio = valAnual / noDatos;
                double desviacion = standardDeviation(valList);
                double coeficiente =  desviacion / promedio;
                double factorT = factoresT[noDatos];
                double incertidumbre = 1 - ((promedio - (desviacion * factorT) / Math.Sqrt(noDatos)) / promedio);

                emision.valorAnual = valAnual;
                emision.noDatos = noDatos;
                emision.promedio = promedio;
                emision.desviacionEstandar = desviacion;
                emision.coeficienteVariacion = coeficiente;
                emision.factorT = factorT;
                emision.incertidumbre = incertidumbre;
                emision.idConfiguracion = group.Key;
                emision.idRegistroAnual = idRegAnual;

                var resultEmGEI = await CreateEmisionGEI(group.Key, valAnual, idRegAnual) as OkObjectResult;
                emision.emisionTotal = (double)resultEmGEI.Value;

                _context.Add(emision);
                await _context.SaveChangesAsync();
            }
            return Ok();


        }

        [HttpPost]
        public async Task<IActionResult> CreateEmisionGEI(int idConf, double valAnual, int idRegAnual)
        {
            var factoresEmision = await _context.FactorEmision.Where(f => f.idConfiguracion == idConf).ToListAsync();
            double emTotal = 0;
            foreach (var factor in factoresEmision)
            {
                EmisionGEI emisionGEI = new EmisionGEI();
                double emi = (valAnual * factor.factorEmision) / 1000;
                double emiEq = emi * factor.PCG;
                emTotal += emiEq;

                emisionGEI.idFE = factor.idFE;
                emisionGEI.emisionGEI = emi;
                emisionGEI.emisionGEIEqui = emiEq;
                emisionGEI.factorEmision = factor.factorEmision;
                emisionGEI.PCG = factor.PCG;
                emisionGEI.idRegistroAnual = idRegAnual;

                _context.Add(emisionGEI);
                await _context.SaveChangesAsync();
            }
            return Ok(emTotal);
        }

        static double standardDeviation(IEnumerable<double> sequence)
        {
            double result = 0;

            if (sequence.Any())
            {
                double average = sequence.Average();
                double sum = sequence.Sum(d => Math.Pow(d - average, 2));
                result = Math.Sqrt((sum) / (sequence.Count()-1));
            }
            return result;
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
