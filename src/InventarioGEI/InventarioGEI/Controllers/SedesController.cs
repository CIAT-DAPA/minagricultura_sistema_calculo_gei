using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;
using Microsoft.AspNetCore.Authorization;

namespace InventarioGEI.Controllers
{
    public class SedesController : AccesController
    {
        private readonly Context _context;

        public SedesController(Context context) : base(context)
        {
            _context = context;
        }

        // GET: Sedes
        //[Authorize("rol-only")]
        public async Task<IActionResult> Index(string? filter)
        {
            ViewBag.filter = new SelectList(_context.Departamento, "codigoDepartamento", "nombreDepartamento");

            var sedes = new Object();

            if (!String.IsNullOrEmpty(filter))
            {
                sedes = await _context.Sede.Include("municipio").Include("municipio.departamento").Where(s => s.municipio.departamento.codigoDepartamento == Int32.Parse(filter)).ToListAsync(); 
            } else
            {
                sedes = await _context.Sede.Include("municipio").Include("municipio.departamento").ToListAsync();
            }

            return View(sedes);
        }

    }
}