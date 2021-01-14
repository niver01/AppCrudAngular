using System;
using System.Collections.Generic;

#nullable disable

namespace WSCrud.Models
{
    public partial class TbEntidad
    {
        public int IdEntidad { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public int IdTipoContribuyente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool? Estato { get; set; }

        public virtual TbTipoContribuyente IdTipoContribuyenteNavigation { get; set; }
        public virtual TbTipoDocumento IdTipoDocumentoNavigation { get; set; }
    }
}
