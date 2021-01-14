using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSCrud.Models.Request;
using WSCrud.Models.Response;
using WSCrud.Service;

namespace WSCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody] AuthRequest entity)
        {
            var response = new Response<UserResponse>();

            try
            {
                var user = _userService.Auht(entity);

                if(user == null)
                {
                    response.Message = "Usuario o contraseña incorrecta.";
                    return Ok(response);
                }

                response.Result = 1;
                response.Data = user;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                //return BadRequest(response);
                return Ok(response);
            }
        }
        
        [HttpPost("signUp")]
        public ActionResult SignUp([FromBody] UserRequest entity)
        {
            var response = new Response<UserResponse>();

            try
            {
                var user = _userService.SignUp(entity);

                if (user == null)
                {
                    response.Message = "No se pudo registrar los datos.";
                    return Ok(response);
                }

                response.Result = 1;
                response.Data = user;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return Ok(response);
            }
        }
    }
}
