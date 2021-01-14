using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSCrud.Models.Request
{
    public class TaxpayerRequest
    {
        public int IdContribuyente { get; set; }

        [Required(ErrorMessage ="El valor es requerida.")]
        [StringLength(50, ErrorMessage = "Solo se permiten 50 caracteres.")]
        public string Nombre { get; set; }

        public bool? Estado { get; set; }
    }
}
