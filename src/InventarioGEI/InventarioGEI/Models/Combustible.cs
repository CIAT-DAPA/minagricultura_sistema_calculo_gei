using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("combustible")]
    public class Combustible
    {
        [Key]
        [Column("idcombustible")]
        [Display(Name = "Id del combustible")]
        public int idCombustible { get; set; }

        [Column("nombrecombustible")]
        [Display(Name = "Combustible")]
        [Required(ErrorMessage = "Es necesario que el combustible tenga un nombre")]
        public string nombreCombustible { get; set; }

        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }



        [Column("idunidad")]
        [Display(Name = "Unidad")]
        public int idUnidad { get; set; }
        [ForeignKey("idUnidad")]
        [Display(Name = "Unidad")]
        public Unidad? unidad { get; set; }

        [Column("idtipo")]
        [Display(Name = "Tipo")]
        public int idTipo { get; set; }
        [ForeignKey("idTipo")]
        [Display(Name = "Tipo")]
        public Tipo? tipo { get; set; }

        [Column("idactividad")]
        [Display(Name = "Actividad")]
        public int idActividad { get; set; }
        [ForeignKey("idActividad")]
        [Display(Name = "Actividad")]
        public TipoActividad? actividad { get; set; }

        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        [Display(Name = "Usuario")]
        public Usuario? usuario { get; set; }
    }
}
