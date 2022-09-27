using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventarioGEI.Models
{
    [Table("municipio")]
    public class Municipio
    {
        [Key]
        [Column("codigomunicipio")]
        [Display(Name = "Codigo")]
        public int codigoMunicipio { get; set; }

        [Column("nombremunicipio")]
        [Display(Name = "Municipio")]
        public string nombreMunicipio { get; set; }

        //foreign key
        [Column("codigodepartamento")]
        [Display(Name = "Codigo Departamento")]
        public int codDepartamento { get; set; }
        [ForeignKey("codDepartamento")]
        public virtual Departamento departamento { get; set; }

    }
}
