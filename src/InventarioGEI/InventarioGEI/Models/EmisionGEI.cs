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
        [RegularExpression(@"^\d+(\.\d{1,3)?$")]
        [Range(0, 9999999.999)]
        public double emisionGEI { get; set; }
        [Column("emisiongeiequivalente")]
        [Display(Name = "Emisión GEI equivalente")]
        [RegularExpression(@"^\d+(\.\d{1,3)?$")]
        [Range(0, 9999999.999)]
        public double emisionGEIEqui { get; set; }
        [Column("factorEmision")]
        [Display(Name = "Factor de emisión")]
        [RegularExpression(@"^\d+(\.\d{1,3)?$")]
        [Range(0, 9999999.999)]
        public double factorEmision { get; set; }
        [Column("potencialcalentamientoglobal")]
        [Display(Name = "Potencial de calentamiento global")]
        [RegularExpression(@"^\d+(\.\d{1,3)?$")]
        [Range(0, 9999999.999)]
        public double PCG { get; set; }


        [Column("idfe")]
        [Display(Name = "Factor de emisión modelo")]
        public int idFE { get; set; }
        [ForeignKey("idFE")]
        [Display(Name = "Factor de emisión modelo")]
        public FactorEmision? factorEmisionModel { get; set; }
        [Column("idregistroanual")]
        [Display(Name = "Registro anual")]
        public int idRegistroAnual { get; set; }
        [ForeignKey("idRegistroAnual")]
        [Display(Name = "Registro anual")]
        public RegistroAnual? registroAnual { get; set; }
    }
}
