using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("unidad")]
    public class Unidad
    {
        [Key]
        [Column("idunidad")]
        [Display(Name = "Id de la unidad")]
        public int idUnidad { get; set; }
        [Column("unidad")]
        [Display(Name = "Unidad")]
        public string unidad { get; set; }
    }
}
