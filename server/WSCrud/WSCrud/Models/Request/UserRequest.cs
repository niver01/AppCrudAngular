﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSCrud.Models.Request
{
    public class UserRequest
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
