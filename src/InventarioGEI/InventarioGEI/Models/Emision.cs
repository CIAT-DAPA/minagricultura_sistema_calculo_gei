using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("emision")]
    public class Emision
    {
        [Key]
        [Column("idemision")]
        [Display(Name = "Id de la emisión")]
        public int idEmision { get; set; }
        [Column("mes1")]
        [Display(Name = "Enero")]
        public double? mes1 { get; set; }
        [Column("mes2")]
        [Display(Name = "Febrero")]
        public double? mes2 { get; set; }
        [Column("mes3")]
        [Display(Name = "Marzo")]
        public double? mes3 { get; set; }
        [Column("mes4")]
        [Display(Name = "Abril")]
        public double? mes4 { get; set; }
        [Column("mes5")]
        [Display(Name = "Mayo")]
        public double? mes5 { get; set; }
        [Column("mes6")]
        [Display(Name = "Junio")]
        public double? mes6 { get; set; }
        [Column("mes7")]
        [Display(Name = "Julio")]
        public double? mes7 { get; set; }
        [Column("mes8")]
        [Display(Name = "Agosto")]
        public double? mes8 { get; set; }
        [Column("mes9")]
        [Display(Name = "Septiembre")]
        public double? mes9 { get; set; }
        [Column("mes10")]
        [Display(Name = "Octubre")]
        public double? mes10 { get; set; }
        [Column("mes11")]
        [Display(Name = "Noviembre")]
        public double? mes11 { get; set; }
        [Column("mes12")]
        [Display(Name = "Diciembre")]
        public double? mes12 { get; set; }
        [Column("valoranual")]
        [Display(Name = "Valor anual")]
        public double valorAnual { get; set; }
        [Column("nodatos")]
        [Display(Name = "Número de datos")]
        public int noDatos { get; set; }
        [Column("promedio")]
        [Display(Name = "Promedio")]
        public double promedio { get; set; }
        [Column("desviacionestandar")]
        [Display(Name = "Desviación estándar")]
        public double desviacionEstandar { get; set; }
        [Column("coeficientevariacion")]
        [Display(Name = "Coeficiente de variación")]
        public double coeficienteVariacion { get; set; }
        [Column("factort")]
        [Display(Name = "Factor T")]
        public double factorT { get; set; }
        [Column("incertidumbre")]
        [Display(Name = "Incertidumbre")]
        public double incertidumbre { get; set; }
        [Column("emisiontotal")]
        [Display(Name = "Emisión total")]
        public double emisionTotal { get; set; }


        [Column("idregistroanual")]
        [Display(Name = "Registro Anual")]
        public int idRegistroAnual { get; set; }
        [ForeignKey("idRegistroAnual")]
        [Display(Name = "Registro Anual")]
        public RegistroAnual? registroAnual { get; set; }
        [Column("idconfiguracion")]
        [Display(Name = "Configuración")]
        public int idConfiguracion { get; set; }
        [ForeignKey("idConfiguracion")]
        [Display(Name = "Configuración")]
        public RegistroAnual? configuracion { get; set; }
    }
}
