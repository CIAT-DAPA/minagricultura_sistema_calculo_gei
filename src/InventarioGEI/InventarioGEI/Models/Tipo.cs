using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("tipo")]
    public class Tipo
    {
        [Key]
        [Column("idtipo")]
        [Display(Name = "Id del tipo")]
        public int idTipo { get; set; }
        [Column("tipo")]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }
    }
}
