using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WSCrud.Models;
using WSCrud.Models.Common;
using WSCrud.Models.Request;
using WSCrud.Models.Response;
using WSCrud.Tools;

namespace WSCrud.Service
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public UserResponse Auht(AuthRequest entity)
        {
            var userResponse = new UserResponse();

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    // Encriptamos contraseña en Algoritmo SHA256
                    string password = Encrypt.GetSHA256(entity.Password);

                    // Buscamos usuario en bd
                    var user = db.TbUsuarios.Where(u => u.Email == entity.Email && u.Password == password).FirstOrDefault();

                    if (user == null)
                        return null;

                    userResponse.IdUser = user.IdUsuario;
                    userResponse.Email = user.Email;
                    userResponse.Token = GenerateToken(user);
                }

                return userResponse;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al iniciar sessión.");
            }
        }


        public UserResponse SignUp(UserRequest entity)
        {
            var userResponse = new UserResponse();

            try
            {
                using(var db =new DB_CRUDContext())
                {
                    string password = Encrypt.GetSHA256(entity.Password);

                    var user = new TbUsuario
                    {
                        Email = entity.Email,
                        Password = password
                    };

                    db.TbUsuarios.Add(user);
                    db.SaveChanges();

                    userResponse.IdUser = user.IdUsuario;
                    userResponse.Email = entity.Email;
                    userResponse.Token = GenerateToken(user);
                }

                return userResponse;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al registrar los datos.");
            }
        }

        // Metodo para generar token
        private string GenerateToken(TbUsuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                //Agregamos los identificadores para el token
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                // Experiracion de token en 40 dias
                Expires = DateTime.UtcNow.AddDays(40),
                // Agregamos la firma, y el algoritmo
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

    }
}
