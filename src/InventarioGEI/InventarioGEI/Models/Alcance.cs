using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("alcance")]
    public class Alcance
    {
        [Key]
        [Column("idalcance")]
        [Display(Name = "id")]
        public int idAlcance { get; set; }
        [Column("nombrealcance")]
        [Display(Name ="Alcance")]
        public string nombreAlcance { get; set; }
        [Column("enabled")]
        [Display(Name = "Habilitiado")]
        public bool? enabled { get; set; }
        //foreign key
        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        [Display(Name = "Usuario")]
        public Usuario? usuario { get; set; }
        

        public virtual ICollection<Categoria>? Categorias { get; set; }

    }
}
