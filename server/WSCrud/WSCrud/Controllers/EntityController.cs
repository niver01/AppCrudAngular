using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSCrud.Models.Request;
using WSCrud.Models.Response;
using WSCrud.Service;

namespace WSCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()] // solo pasa si tiene un token
    public class EntityController : ControllerBase, IGeneric<EntityRequest>
    {
        private readonly IEntityService _entityService;

        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var response = new Response<IEnumerable<EntityRequest>>();

            try
            {
                var entitys = _entityService.Select();

                if (entitys != null)
                {
                    response.Result = 1;
                    response.Message = new { Count = entitys.Count() };
                    response.Data = entitys;
                }
                else
                {
                    response.Message = "No se encontraron registros.";
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var response = new Response<EntityRequest>();

            try
            {
                var entity = _entityService.Select(id);

                if (entity != null)
                {
                    response.Result = 1;
                    response.Data = entity;
                }
                else
                {
                    response.Message = "No se encontro el registro.";
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return Ok(response);
            }
        }

        [HttpPost]
        public ActionResult Add([FromBody] EntityRequest entity)
        {
            var response = new Response<object>();

            try
            {
                if (_entityService.Add(entity))
                {
                    response.Result = 1;
                    response.Message = "Entidad registrado correctamente.";
                }
                else
                {
                    response.Message = "No se pudo registrado la entidad.";
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return Ok(response);
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] EntityRequest entity)
        {
            var response = new Response<object>();

            try
            {
                if (_entityService.Update(entity))
                {
                    response.Result = 1;
                    response.Message = "Entidad actualizada correctamente.";
                }
                else
                {
                    response.Message = "No se pudo actualizar la entidad.";
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var response = new Response<object>();

            try
            {
                if (_entityService.Delete(id))
                {
                    response.Result = 1;
                    response.Message = "Entidad eliminada correctamente.";
                }
                else
                {
                    response.Message = "No se pudo eliminar la entidad.";
                }

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
