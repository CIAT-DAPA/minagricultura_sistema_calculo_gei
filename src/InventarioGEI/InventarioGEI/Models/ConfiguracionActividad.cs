using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("configuracionactividad")]
    public class ConfiguracionActividad
    {
        [Key]
        [Column("idconfiguracion")]
        [Display(Name = "Id de la configuración")]
        public int idConfiguracion { get; set; }
        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }
        [Column("biocombustible")]
        [Display(Name = "Biocombustible")]
        public bool biocombustible { get; set; }
        [Column("porcentaje")]
        [Display(Name = "Porcentaje destinado al biocombustible")]
        [RegularExpression(@"^\d+(\.\d{1,4})?$")]
        [Range(0, 999999.9999)]
        public double? porcentaje { get; set; }


        [Column("idcombustible")]
        [Display(Name = "Combustible")]
        public int idCombustible { get; set; }
        [ForeignKey("idCombustible")]
        [Display(Name = "Combustible")]
        public Combustible? combustible { get; set; }
        [Column("idsubcategoria")]
        [Display(Name = "Subcategoría")]
        public int idSubcategoria { get; set; }
        [ForeignKey("idSubcategoria")]
        [Display(Name = "Subcategoría")]
        public Subcategoria? subcategoria { get; set; }
        [Column("idfuenteemision")]
        [Display(Name = "Fuente de Emisión")]
        public int idFuenteEmision { get; set; }
        [ForeignKey("idFuenteEmision")]
        [Display(Name = "Fuente de Emisión")]
        public FuenteEmision? fuenteEmision { get; set; }
        [Column("idconfdependiente")]
        [Display(Name = "Configuración dependiente")]
        public int? idConfDependiente { get; set; }
        [ForeignKey("idConfDependiente")]
        [Display(Name = "Configuración dependiente")]
        public ConfiguracionActividad? configuracion { get; set; }

        public override string ToString()
        {
            return idConfiguracion.ToString() + "|" + enabled.ToString() + "|" + idCombustible.ToString() + "|" + idSubcategoria.ToString() + "|" + idFuenteEmision.ToString();
        }
    }
}
