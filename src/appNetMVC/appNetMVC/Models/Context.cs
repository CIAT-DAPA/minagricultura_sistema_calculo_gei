using Microsoft.EntityFrameworkCore;
using appNetMVC.Models;

namespace appNetMVC.Models
{
    public class Context : DbContext
    { 
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<appNetMVC.Models.Rol> Rol { get; set; }
        public DbSet<appNetMVC.Models.Usuario> Usuario { get; set; }

    }
}
