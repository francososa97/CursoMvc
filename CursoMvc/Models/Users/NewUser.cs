using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMvc.Models
{
    public class NewUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        [StringLength(100,ErrorMessage ="El {0} debe tener menos de {1} caracteres",MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password",ErrorMessage ="las contraseñas no son iguales")]
        public string ConfirmPassword { get; set;}

        [Required]
        public int Edad { get; set; }
    }
}