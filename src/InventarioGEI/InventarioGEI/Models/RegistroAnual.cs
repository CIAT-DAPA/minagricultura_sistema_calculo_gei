using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioGEI.Models
{
    [Table("registroanual")]
    public class RegistroAnual
    {
        [Key]
        [Column("idregistroanual")]
        [Display(Name = "Id")]
        public int idRegistroAnual { get; set; }
        [Column("fecharegistro")]
        [Display(Name = "Fecha del cierre")]
        public DateTime fechaRegistro { get; set; }
        [Column("año")]
        [Display(Name = "Año")]
        [Range(minimum: 2005,maximum:2100,ErrorMessage = "El año debe ser entre 2005 y 2100")]
        public int año { get; set; }
        [Column("estado")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [Column("idsede")]
        [Display(Name = "Sede")]
        public int idSede { get; set; }
        [ForeignKey("idSede")]
        [Display(Name = "Sede")]
        public Sede? sede { get; set; }
        [Column("idusuario")]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        [Display(Name = "Usuario")]
        public Usuario? user { get; set; }

        public override string ToString()
        {
            return idRegistroAnual.ToString() + "|" + fechaRegistro.ToString() + "|" + año.ToString() + "|" + estado.ToString() + "|" + idSede.ToString() + "|" + idUsuario.ToString();
        }
    }
}
