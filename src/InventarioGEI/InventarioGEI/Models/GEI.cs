using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("gei")]
    public class GEI
    {
        [Key]
        [Column("idgei")]
        [Display(Name = "Id del GEI")]
        public int idGei { get; set; }
        [Column("nombregei")]
        [Display(Name = "GEI")]
        [Required(ErrorMessage = "Es necesario que el GEI tenga un nombre")]
        public string nombreGei { get; set; }
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
            return idGei.ToString() + "|" + nombreGei.ToString() + "|" + enabled.ToString() + "|" + idUsuario.ToString();
        }
    }
}
