﻿using System.ComponentModel.DataAnnotations.Schema;
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
        [StringLength(50, ErrorMessage = "Debe tener como maximo {1} caracteres")]
        public string email { get; set; }
        [Column("enabled")]
        [Display(Name ="Habilitado")]
        public bool enabled { get; set; }
        //foreign key
        [Column("idrol")]
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Es obligatorio asignar un rol al usuario")]
        public int idRol { get; set; }
        [ForeignKey("idRol")]
        [Display(Name = "Rol")]
        public virtual Rol? rolUsuario { get; set; }

        public override string ToString()
        {
            return idUsuario.ToString() + "|" + email.ToString() + "|" + enabled.ToString() + "|" + idRol.ToString();
        }
    }
}
