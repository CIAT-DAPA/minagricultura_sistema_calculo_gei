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
        public double valor { get; set; }
        [Column("mes")]
        [Display(Name = "Mes")]
        public string mes { get; set; }
        [Column("año")]
        [Display(Name = "Año")]
        public int ano { get; set; }
        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }

        [Column("idconfiguracion")]
        [Display(Name = "Configuracion")]
        public int idConfiguracion { get; set; }
        [ForeignKey("idConfiguracion")]
        [Display(Name = "Configuracion")]
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
    }
}
