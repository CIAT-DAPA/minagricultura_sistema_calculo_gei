using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("factoremision")]
    public class FactorEmision
    {
        [Key]
        [Column("idfe")]
        [Display(Name ="Id del Factor de Emisión")]
        public int idFE { get; set; }
        [Column("factoremision")]
        [Display(Name = "Factor de Emisión")]
        public double factorEmision { get; set; }
        [Column("potencialcalentamientoglobal")]
        [Display(Name = "PCG")]
        public double PCG { get; set; }
        [Column("incertidumbremas")]
        [Display(Name = "Incertidumbre +")]
        public double incertidumbreMas { get; set; }
        [Column("incertidumbremenos")]
        [Display(Name = "Incertidumbre -")]
        public double incertidumbreMenos { get; set; }
        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }
        
        [Column("idgei")]
        [Display(Name = "GEI")]
        public int idGei { get; set; }
        [ForeignKey("idGei")]
        [Display(Name = "GEI")]
        public GEI? gei { get; set; }
        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuaro")]
        [Display(Name = "Usuario")]
        public Usuario? usuario { get; set; }
        [Column("idconfiguracion")]
        [Display(Name = "Configuracion")]
        public int idConfiguracion { get; set; }
        [ForeignKey("idConfiguracion")]
        [Display(Name = "Configuracion")]
        public ConfiguracionActividad? configuracion { get; set; }

    }
}
