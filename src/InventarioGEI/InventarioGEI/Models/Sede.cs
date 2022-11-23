using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventarioGEI.Models
{
    [Table("sede")]
    public class Sede
    {
        [Key]
        [Column("idsede")]
        [Display(Name = "Id")]
        public int idSede { get; set; }
        [Column("nombresede")]
        [Display(Name = "Nombre")]
        public string nombreSede { get; set; }

        [Column("direccion")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Column("enabled")]
        [Display(Name = "Habilitado")]
        public bool enabled { get; set; }

        //foreign key
        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public virtual Usuario? usuCreador { get; set; }

        [Column("codigomunicipio")]
        [Display(Name = "Codigo municipio")]
        public int codMunicipio { get; set; }
        [ForeignKey("codMunicipio")]
        public virtual Municipio? municipio { get; set; }

        public override string ToString()
        {
            return idSede.ToString() + "|" + nombreSede.ToString() + "|" + direccion.ToString() + "|" + enabled.ToString() + "|" + idUsuario.ToString() + "|" + codMunicipio.ToString();
        }
    }
}
