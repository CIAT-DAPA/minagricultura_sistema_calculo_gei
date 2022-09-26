using InventarioGEI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace InventarioGEI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            var rolAsig = _context.Rol.FirstOrDefault(r => r.idRol == user.idRol);
            ViewData["Rol"] = rolAsig.nombreRol;
            //roleManager.AddClaimAsync((IdentityRole)User.Identity, new Claim("Rol", rolAsig.nombreRol));
            //var claims = User.Claims.ToList();
            //User.IsInRole(rolAsig.nombreRol);
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}