using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCrud.Models.Request;
using WSCrud.Models.Response;

namespace WSCrud.Service
{
    public interface IUserService 
    {
        UserResponse Auht(AuthRequest entity);
        UserResponse SignUp(UserRequest entity);
    }
}
