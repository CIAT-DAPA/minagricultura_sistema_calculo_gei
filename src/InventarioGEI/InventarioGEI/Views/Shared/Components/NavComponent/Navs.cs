using InventarioGEI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioGEI.Components.NavComponent
{
    [ViewComponent(Name = "NavComponent")]
    public class Navs : ViewComponent
    {
        private readonly Context _context;

        public Navs(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Usuario user = await _context.Usuario.FirstOrDefaultAsync(u => u.email == User.Identity.Name);
            if (user != null)
            {
                Rol rolAsig = await _context.Rol.FirstOrDefaultAsync(r => r.idRol == user.idRol);
                if (rolAsig != null)
                {
                    if (rolAsig.permisoRol)
                        ViewData["Rol"] = "Si";
                    if (rolAsig.permisoSede)
                        ViewData["Sedes"] = "Si";
                    if (rolAsig.permisoConfiguracion)
                        ViewData["Conf"] = "Si";
                    if (rolAsig.permisoRegistro)
                        ViewData["Reg"] = "Si";
                    if (rolAsig.permisoVisualizacion)
                        ViewData["Visualizacion"] = "Si";
                }
            }
                
            

            return View();
        }
    }
}
