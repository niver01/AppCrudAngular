using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WSCrud.Models.ValidRequest;

namespace WSCrud.Models.Request
{
    public class EntityRequest
    {
        [RegularExpression("^[0-9]+$", ErrorMessage = "Ingrese un valor numérico.")]
        public int IdEntidad { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Ingrese un valor numérico.")]
        [ExistsDocument(ErrorMessage ="El documento no existe.")]
        public int IdTipoDoc { get; set; }
        public string codigoDoc { get; set; }

        [Required(ErrorMessage = "El numéro de documento es requerido.")]
        [StringLength(30, ErrorMessage = "Solo se permiten 30 caracteres.")]
        public string NumDocumento { get; set; }

        [Required(ErrorMessage = "La razon social es requerido.")]
        [StringLength(200, ErrorMessage = "Solo se permiten 200 caracteres.")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "Nombre comercial es requerido.")]
        [StringLength(200, ErrorMessage = "Solo se permiten 200 caracteres.")]
        public string NombreComercial { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Ingrese un valor numérico.")]
        [ExistsTaxpayer(ErrorMessage = "El contribuyente no existe.")]
        public int IdContribuyente { get; set; }
        public string NombreContribuyente { get; set; }

        [StringLength(200, ErrorMessage = "Solo se permiten 200 caracteres.")]
        public string Direccion { get; set; }

        [StringLength(50, ErrorMessage = "Solo se permiten 50 caracteres.")]
        public string Telefono { get; set; }
        public bool? estado { get; set; }
    }
}
