using Microsoft.EntityFrameworkCore;
using InventarioGEI.Models;

namespace InventarioGEI.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Sede> Sede { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Alcance> Alcance { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Subcategoria> Subcategoria { get; set; }
        public DbSet<FuenteEmision> FuenteEmision { get; set; }
        public DbSet<TipoActividad> TipoActividad { get; set; }
        public DbSet<ConfiguracionActividad> ConfiguracionActividad { get; set; }
        public DbSet<Combustible> Combustible { get; set; }
        public DbSet<GEI> Gei { get; set; }
        public DbSet<FactorEmision> FactorEmision { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Unidad> Unidad { get; set; }
        public DbSet<RegistroActividad> RegistroActividad { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<RegistroAnual> RegistroAnual { get; set; }
        public DbSet<Emision> Emision { get; set; }
        public DbSet<EmisionGEI> EmisionGEI { get; set; }
        public DbSet<Reporte> Reporte { get; set; }
        
    }
}
