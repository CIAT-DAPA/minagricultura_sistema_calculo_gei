using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("reporte")]
    public class Reporte
    {
        [Key]
        [Column("idreporte")]
        [Display(Name ="Id")]
        public int idReporte { get; set; }
        [Column("nombrereporte")]
        [Display(Name = "Reporte")]
        [Required(ErrorMessage = "Es necesario que el reporte tenga un nombre")]
        public String nombreReporte { get; set; }
        [Column("link")]
        [Display(Name = "URL")]
        [Required(ErrorMessage = "Es necesario que el reporte tenga un link")]
        public String link { get; set; }
    }
}
