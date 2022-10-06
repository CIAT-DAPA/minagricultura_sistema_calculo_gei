using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [Column("idcategoria")]
        [Display(Name = "id")]
        public int idCategoria { get; set; }
        [Column("nombrecategoria")]
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Es necesario que la categoría tenga un nombre")]
        public string nombreCategoria { get; set; }
        [Column("enabled")]
        [Display(Name = "habilitado")]
        public bool enabled { get; set; }


        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        [Display(Name = "Usuario")]
        public Usuario? usuarios { get; set; }
        [Column("idalcance")]
        [Display(Name = "Alcance")]
        public int idAlcance { get; set; }
        [ForeignKey("idAlcance")]
        [Display(Name = "Alcance")]
        public Alcance? alcance { get; set; }


        public virtual ICollection<Subcategoria>? Subcategorias { get; set; }
    }
}