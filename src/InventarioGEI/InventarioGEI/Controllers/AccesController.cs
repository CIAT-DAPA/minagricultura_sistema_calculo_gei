using InventarioGEI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventarioGEI.Controllers
{
    public abstract class AccesController : Controller
    {

        private readonly Context _context;

        public AccesController(Context context)
        {
            _context = context;
        }
        public bool GetAccesRol()
        {
            Usuario user = _context.Usuario.FirstOrDefault(u => u.email == User.Identity.Name);
            Rol rolAsig = _context.Rol.FirstOrDefault(r => r.idRol == user.idRol);
            if (rolAsig.permisoRol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
