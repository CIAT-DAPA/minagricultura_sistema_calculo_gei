using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventarioGEI.Models
{
    [Table("departamento")]
    public class Departamento
    {
        [Key]
        [Column("codigodepartamento")]
        [Display(Name = "Código")]
        public int codigoDepartamento { get; set; }

        [Column("nombredepartamento")]
        [Display(Name = "Departamento")]
        public string nombreDepartamento { get; set; }

    }
}
