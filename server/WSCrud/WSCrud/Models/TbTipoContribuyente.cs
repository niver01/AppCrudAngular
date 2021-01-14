using System;
using System.Collections.Generic;

#nullable disable

namespace WSCrud.Models
{
    public partial class TbTipoContribuyente
    {
        public TbTipoContribuyente()
        {
            TbEntidads = new HashSet<TbEntidad>();
        }

        public int IdTipoContribuyente { get; set; }
        public string Nombre { get; set; }
        public bool? Estato { get; set; }

        public virtual ICollection<TbEntidad> TbEntidads { get; set; }
    }
}
