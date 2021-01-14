using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSCrud.Models.Request
{
    public class AuthRequest
    {
        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage = "Ingrese un email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Ingrese su contraseña.")]
        public string Password { get; set; }
    }
}
