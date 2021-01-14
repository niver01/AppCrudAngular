using System;
using System.Collections.Generic;

#nullable disable

namespace WSCrud.Models
{
    public partial class TbTipoDocumento
    {
        public TbTipoDocumento()
        {
            TbEntidads = new HashSet<TbEntidad>();
        }

        public int IdTipoDocumento { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estato { get; set; }

        public virtual ICollection<TbEntidad> TbEntidads { get; set; }
    }
}
