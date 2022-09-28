using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventarioGEI.Models
{
    [Table("rol")]
    public class Rol
    {
        [Key]
        [Column("idrol")]
        [Display(Name = "Id")]
        public int idRol { get; set; }
        [Column("rol")]
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Es necesario que el rol tenga un nombre")]
        public string nombreRol { get; set; }

        [Column("moduloRol")]
        [Display(Name = "Permiso de roles")]
        public bool permisoRol { get; set; }

        [Column("moduloSede")]
        [Display(Name = "Permiso de sedes")]
        public bool permisoSede { get; set; }

        [Column("moduloConfiguracion")]
        [Display(Name = "Permiso de configuracion")]
        public bool permisoConfiguracion { get; set; }

        [Column("moduloRegistro")]
        [Display(Name = "Permiso de registros")]
        public bool permisoRegistro { get; set; }

        [Column("moduloVisualizacion")]
        [Display(Name = "Permiso de visualizacion")]
        public bool permisoVisualizacion { get; set; }

        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
