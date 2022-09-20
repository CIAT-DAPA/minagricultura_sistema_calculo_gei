using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appNetMVC.Models
{
    [Table("rol")]
    public class Rol
    {
        [Key]
        [Column("idrol")]
        [Display(Name = "Id")]
        public int idRol { get; set; }
        [Column("rol")]
        [Display(Name = "Rol")]
        public string nombreRol { get; set; }
        
        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
