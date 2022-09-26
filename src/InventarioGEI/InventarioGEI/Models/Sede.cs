using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventarioGEI.Models
{
    [Table("sede")]
    public class Sede
    {
        [Key]
        [Column("idsede")]
        [Display(Name = "Id")]
        public int idSede { get; set; }
        [Column("nombresede")]
        [Display(Name = "Nombre")]
        public string nombreSede { get; set; }

        [Column("direccion")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }

    }
}
