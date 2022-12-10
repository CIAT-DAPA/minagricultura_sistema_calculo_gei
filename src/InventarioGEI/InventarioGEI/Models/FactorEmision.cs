using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("factoremision")]
    public class FactorEmision
    {
        [Key]
        [Column("idfe")]
        [Display(Name ="Id del factor de emisión")]
        public int idFE { get; set; }
        [Column("factoremision")]
        [Display(Name = "Factor de emisión")]
        [Required(ErrorMessage = "Es necesario el factor de emisión")]
        [Precision(14,8)]
        public double factorEmision { get; set; }
        [Column("potencialcalentamientoglobal")]
        [Display(Name = "PCG")]
        [Required(ErrorMessage = "Es necesario el PCG")]
        [Precision(14, 8)]
        public double PCG { get; set; }
        [Column("incertidumbremas")]
        [Display(Name = "Incertidumbre + (%)")]
        [Required(ErrorMessage = "Es necesario la incertidumbre +")]
        [Precision(7, 3)]
        public double incertidumbreMas { get; set; }
        [Column("incertidumbremenos")]
        [Display(Name = "Incertidumbre - (%)")]
        [Required(ErrorMessage = "Es necesario la incertidumbre -")]
        [Precision(7, 3)]
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
        [Display(Name = "Última modificación hecha por")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        [Display(Name = "Última modificación hecha por")]
        public Usuario? usuario { get; set; }
        [Column("idconfiguracion")]
        [Display(Name = "Configuración")]
        public int idConfiguracion { get; set; }
        [ForeignKey("idConfiguracion")]
        [Display(Name = "Configuración")]
        public ConfiguracionActividad? configuracion { get; set; }
        public override string ToString()
        {
            return idFE.ToString() + "|" + factorEmision.ToString() + "|" + PCG.ToString() + "|" + incertidumbreMas.ToString() + "|" + incertidumbreMenos.ToString() + "|" + enabled.ToString()
                + "|" + idGei.ToString() + "|" + idUsuario.ToString() + "|" + idConfiguracion.ToString();
        }
    }
}
