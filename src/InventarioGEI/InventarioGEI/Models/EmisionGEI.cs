using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("emisiongei")]
    public class EmisionGEI
    {
        [Key]
        [Column("idemisiongei")]
        [Display(Name = "Id de emisión GEI")]
        public int idEmisionGEI { get; set; }
        [Column("emisiongei")]
        [Display(Name = "Emisión GEI")]
        public double emisionGEI { get; set; }
        [Column("emisiongeiequivalente")]
        [Display(Name = "Emisión GEI equivalente")]
        public double emisionGEIEqui { get; set; }
        [Column("factorEmision")]
        [Display(Name = "Factor de Emisión")]
        public double factorEmision { get; set; }
        [Column("potencialcalentamientoglobal")]
        [Display(Name = "Potencial de Calentamiento Global")]
        public double PCG { get; set; }


        [Column("idfe")]
        [Display(Name = "Factor de Emisión Modelo")]
        public int idFE { get; set; }
        [ForeignKey("idFE")]
        [Display(Name = "Factor de Emisión Modelo")]
        public FactorEmision? factorEmisionModel { get; set; }
        [Column("idregistroanual")]
        [Display(Name = "Registro Anual")]
        public int idRegistroAnual { get; set; }
        [ForeignKey("idRegistroAnual")]
        [Display(Name = "Registro Anual")]
        public RegistroAnual? registroAnual { get; set; }
    }
}
