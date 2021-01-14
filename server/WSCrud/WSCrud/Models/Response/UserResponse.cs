using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSCrud.Models.Response
{
    public class UserResponse
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
