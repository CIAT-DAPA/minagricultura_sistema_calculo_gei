using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("subcategoria")]
    public class Subcategoria
    {
        [Key]
        [Column("idsubcategoria")]
        [Display(Name = "Id")]
        public int idSubcategoria { get; set; }
        [Column("nombresubcategoria")]
        [Display(Name = "Subcategoría")]
        public string nombreSubcategoria { get; set; }
        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }

        [Column("idcategoria")]
        [Display(Name = "Categoria")]
        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        [Display(Name = "Categoria")]
        public Categoria? categoria { get; set; }
        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        [Display(Name = "Usuario")]
        public Usuario? usuario { get; set; }
    }
}
