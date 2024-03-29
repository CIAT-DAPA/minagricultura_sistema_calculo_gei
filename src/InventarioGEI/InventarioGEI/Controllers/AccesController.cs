﻿using InventarioGEI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioGEI.Controllers
{
    public abstract class AccesController : Controller
    {

        private readonly Context _context;

        public AccesController(Context context)
        {
            _context = context;
        }
        public bool GetAccesRol(String moduloPermiso)
        {            
            Usuario user = _context.Usuario.Where(u => u.enabled == true).FirstOrDefault(u => u.email == User.Identity.Name);
            Rol rolAsig = _context.Rol.AsNoTracking().FirstOrDefault(r => r.idRol == user.idRol);
            switch (moduloPermiso)
            {
                case "Rol":
                    if (rolAsig.permisoRol)
                        return true;
                    else
                        return false;
                case "Sede":
                    if (rolAsig.permisoSede)
                        return true;
                    else
                        return false;
                case "Conf":
                    if (rolAsig.permisoConfiguracion)
                        return true;
                    else
                        return false;
                case "Reg":
                    if (rolAsig.permisoRegistro)
                        return true;
                    else
                        return false;
                case "Visualizacion":
                    if (rolAsig.permisoVisualizacion)
                        return true;
                    else
                        return false;
                default:
                    return false;

            }
            
        }
    }
}
