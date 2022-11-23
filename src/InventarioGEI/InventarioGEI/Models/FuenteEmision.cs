using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("fuenteemision")]
    public class FuenteEmision
    {
        [Key]
        [Column("idfuenteemision")]
        [Display(Name = "Id fuente de emisión")]
        public int idFuenteEmision { get; set; }
        [Column("nombrefuenteemision")]
        [Display(Name = "Fuente de emisión")]
        [Required(ErrorMessage = "Es necesario que la fuente de emisión tenga un nombre")]
        public string nombreFuenteEmision { get; set; }
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
            return idFuenteEmision.ToString() + "|" + nombreFuenteEmision.ToString() + "|" + enabled.ToString() + "|" + idUsuario.ToString();
        }
    }
}
