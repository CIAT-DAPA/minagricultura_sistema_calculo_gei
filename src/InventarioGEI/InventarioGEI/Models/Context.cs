using Microsoft.EntityFrameworkCore;

namespace InventarioGEI.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<InventarioGEI.Models.Rol> Rol { get; set; }
        public DbSet<InventarioGEI.Models.Usuario> Usuario { get; set; }
        public DbSet<InventarioGEI.Models.Sede> Sede { get; set; }
        public DbSet<InventarioGEI.Models.Departamento> Departamento { get; set; }
        public DbSet<InventarioGEI.Models.Municipio> Municipio { get; set; }
        public DbSet<InventarioGEI.Models.Alcance> Alcance { get; set; }
        public DbSet<InventarioGEI.Models.Categoria> Categoria { get; set; }


    }
}
