using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appNetMVC.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("idusuario")]
        [Display(Name = "Id")]
        public int idUsuario { get; set; }
        [Column("email")]
        [Display(Name ="Email")]
        public string email { get; set; }
        //foreign key
        [Column("idrol")]
        [Display(Name = "Rol")]
        public int idRol { get; set; }
        [ForeignKey("idRol")]
        public virtual Rol? rolUsuario { get; set; }
        
    }
}
