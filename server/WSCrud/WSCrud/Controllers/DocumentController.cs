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
    public class DocumentController : ControllerBase, IGeneric<DocumentRequest>
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            var response = new Response<IEnumerable<DocumentRequest>>();
            
            try
            {
                var documents = _documentService.Select();

                if (documents != null)
                {
                    response.Result = 1;
                    response.Message = new { Count = documents.Count() };
                    response.Data = documents;
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
            var response = new Response<DocumentRequest>();

            try
            {
                var document = _documentService.Select(id);

                if (document != null)
                {
                    response.Result = 1;
                    response.Data = document;
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
        public ActionResult Add([FromBody] DocumentRequest entity)
        {
            var response = new Response<object>();

            try
            {
                if (_documentService.Add(entity))
                {
                    response.Result = 1;
                    response.Message = "Documento registrado correctamente.";
                }
                else
                {
                    response.Message = "No se pudo registrado el documento.";
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
        public ActionResult Update([FromBody] DocumentRequest entity)
        {
            var response = new Response<object>();

            try
            {
                if (_documentService.Update(entity))
                {
                    response.Result = 1;
                    response.Message = "Documento actualizado correctamente.";
                }
                else
                {
                    response.Message = "No se pudo actualizar el documento.";
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
                if (_documentService.Delete(id))
                {
                    response.Result = 1;
                    response.Message = "Documento eliminado correctamente.";
                }
                else
                {
                    response.Message = "No se pudo eliminar el documento.";
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
