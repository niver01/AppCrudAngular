using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSCrud.Models.Response
{
    public class Response<T>
    {
        public int Result { get; set; }
        public object Message { get; set; }
        public T Data { get; set; }

        public Response() => Result = 0;
    }
}
