using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("registroactividad")]
    public class RegistroActividad
    {
        [Key]
        [Column("idregistroactividad")]
        [Display(Name = "id")]
        public int idRegistroActividad { get; set; }
        [Column("valor")]
        [Display(Name = "Valor")]
        [RegularExpression(@"^\d+(\.\d{1,3)?$")]
        [Range(0, 9999999.999)]
        public double? valor { get; set; }
        [Column("mes")]
        [Display(Name = "Mes")]
        public int mes { get; set; }
        [Column("año")]
        [Display(Name = "Año")]
        public int año { get; set; }
        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }

        [Column("idconfiguracion")]
        [Display(Name = "Configuración")]
        public int idConfiguracion { get; set; }
        [ForeignKey("idConfiguracion")]
        [Display(Name = "Configuración")]
        public ConfiguracionActividad? configuracion { get; set; }
        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        [Display(Name = "Usuario")]
        public Usuario? usuario { get; set; }
        [Column("idsede")]
        [Display(Name = "Sede")]
        public int idSede { get; set; }
        [ForeignKey("idSede")]
        [Display(Name = "Sede")]
        public Sede? sede { get; set; }

        public override string ToString()
        {
            return idRegistroActividad.ToString() + "|" + valor.ToString() + "|" + mes.ToString() + "|" + año.ToString() + "|" + enabled.ToString() + "|" + idConfiguracion.ToString() + "|" + idUsuario.ToString() + "|" + idSede.ToString();
        }
    }
}
