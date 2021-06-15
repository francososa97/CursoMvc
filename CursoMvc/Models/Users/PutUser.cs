using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMvc.Models.Users
{
    public class PutUser
    {

        public int Id { get; set; }
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        [StringLength(100, ErrorMessage = "El {0} debe tener menos de {1} caracteres", MinimumLength = 1)]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }
}