using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventarioGEI.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("idusuario")]
        [Display(Name = "Id")]
        public int idUsuario { get; set; }
        [Column("email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Es obligatorio el correo electronico del usuario")]
        public string email { get; set; }
        //foreign key
        [Column("idrol")]
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Es obligatorio asignar un rol al usuario")]
        public int idRol { get; set; }
        [ForeignKey("idRol")]
        [Display(Name = "Rol")]
        public virtual Rol? rolUsuario { get; set; }

    }
}
