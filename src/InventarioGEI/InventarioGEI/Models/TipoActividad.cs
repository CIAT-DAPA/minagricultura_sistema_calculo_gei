using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("tipoactividad")]
    public class TipoActividad
    {
        [Key]
        [Column("idtipoactividad")]
        [Display(Name = "Id de tipo de actividad")]
        public int idTipoActividad { get; set; }
        [Column("nombretipoactividad")]
        [Display(Name = "Tipo de actividad")]
        [Required(ErrorMessage = "Es necesario que el tipo de actividad tenga un nombre")]
        public string nombreTipoActividad { get; set; }
        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }

        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        [Display(Name = "Usuario")]
        public Usuario? usuario { get; set; }

        public override string ToString()
        {
            return idTipoActividad.ToString() + "|" + nombreTipoActividad.ToString() + "|" + enabled.ToString() + "|" + idUsuario.ToString();
        }
    }
}
