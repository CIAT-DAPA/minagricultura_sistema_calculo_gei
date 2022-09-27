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
    public class SedesController : Controller
    {
        private readonly Context _context;

        public SedesController(Context context)
        {
            _context = context;
        }

        // GET: Sedes
        //[Authorize("rol-only")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sede.Include("municipio").Include("municipio.departamento").ToListAsync());
        }

    }
}