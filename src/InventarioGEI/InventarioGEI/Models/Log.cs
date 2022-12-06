using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("log")]
    public class Log
    {
        [Key]
        [Column("idlog")]
        [Display(Name = "id")]
        public int idLog { get; set; }
        [Column("accion")]
        [Display(Name = "Acción")]
        public int accion { get; set; }
        [Column("contenido")]
        [Display(Name = "Contenido")]
        public string contenido { get; set; }
        [Column("fechaaccion")]
        [Display(Name = "Fecha de la acción")]
        public DateTime fechaAccion { get; set; }


        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        [Display(Name = "Usuario")]
        public Usuario? usuario { get; set; }
    }
}
