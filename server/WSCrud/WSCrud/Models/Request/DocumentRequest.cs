using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSCrud.Models.Request
{
    public class DocumentRequest
    {
        [RegularExpression("^[0-9]+$", ErrorMessage = "Ingrese un valor numérico.")]
        public int IdTipoDoc { get; set; }

        [Required(ErrorMessage ="Ingrese codigo del documento.")]
        [StringLength(20, ErrorMessage = "Solo se permiten 20 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Ingrese nombre del documento.")]
        [StringLength(100, ErrorMessage = "Solo se permiten 100 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "Solo se permiten 200 caracteres.")]
        public string Descripcion { get; set; }
        public bool? estado { get; set; }
    }
}
