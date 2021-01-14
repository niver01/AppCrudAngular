using System;
using System.Collections.Generic;

#nullable disable

namespace WSCrud.Models
{
    public partial class TbUsuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
