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
    [Authorize] // solo pasa si tiene un token
    public class TaxpayerController : ControllerBase, IGeneric<TaxpayerRequest>
    {
        private readonly ITaxpayerService _taxpayerService;

        public TaxpayerController(ITaxpayerService taxpayerService)
        {
            _taxpayerService = taxpayerService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var response = new Response<IEnumerable<TaxpayerRequest>>();

            try
            {
                var taxpayers = _taxpayerService.Select();

                if (taxpayers != null)
                {
                    response.Result = 1;
                    response.Message = new { Count = taxpayers.Count() };
                    response.Data = taxpayers;
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
            var response = new Response<TaxpayerRequest>();

            try
            {
                var taxpayers = _taxpayerService.Select(id);

                if (taxpayers != null)
                {
                    response.Result = 1;
                    response.Data = taxpayers;
                }
                else
                {
                    response.Message = "No se contro el registro.";
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
        public ActionResult Add([FromBody] TaxpayerRequest entity)
        {
            var response = new Response<object>();

            try
            {
                if (_taxpayerService.Add(entity))
                {
                    response.Result = 1;
                    response.Message = "Contribuyente registrado correctamente.";
                }
                else
                {
                    response.Message = "No se pudo registrado el Contribuyente.";
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
        public ActionResult Update([FromBody] TaxpayerRequest entity)
        {
            var response = new Response<object>();

            try
            {
                if (_taxpayerService.Update(entity))
                {
                    response.Result = 1;
                    response.Message = "Contribuyente actualizado correctamente.";
                }
                else
                {
                    response.Message = "No se pudo actualizar el Contribuyente.";
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
                if (_taxpayerService.Delete(id))
                {
                    response.Result = 1;
                    response.Message = "Contribuyente eliminado correctamente.";
                }
                else
                {
                    response.Message = "No se pudo eliminar el Contribuyente.";
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
