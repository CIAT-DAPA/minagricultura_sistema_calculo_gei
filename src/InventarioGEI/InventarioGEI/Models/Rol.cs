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
        [StringLength(50, ErrorMessage = "Debe tener como maximo {1} caracteres")]
        public string nombreRol { get; set; }

        [Column("moduloRol")]
        [Display(Name = "Permiso de roles")]
        public bool permisoRol { get; set; }

        [Column("moduloSede")]
        [Display(Name = "Permiso de sedes")]
        public bool permisoSede { get; set; }

        [Column("moduloConfiguracion")]
        [Display(Name = "Permiso de configuración")]
        public bool permisoConfiguracion { get; set; }

        [Column("moduloRegistro")]
        [Display(Name = "Permiso de registros")]
        public bool permisoRegistro { get; set; }

        [Column("moduloVisualizacion")]
        [Display(Name = "Permisos de creador de reportes")]
        public bool permisoVisualizacion { get; set; }

        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }

        public virtual ICollection<Usuario>? Usuarios { get; set; }

        public override string ToString()
        {
            return idRol.ToString() + "|" + nombreRol.ToString() + "|" + permisoRol.ToString() + "|" + permisoSede.ToString() + "|" + permisoConfiguracion.ToString() + "|" + permisoRegistro.ToString() + "|" + permisoVisualizacion.ToString() + "|" + enabled.ToString();
        }
    }
}
