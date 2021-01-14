using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCrud.Models;
using WSCrud.Models.Request;

namespace WSCrud.Service
{
    public class DocumentService : IDocumentService
    {
        public IEnumerable<DocumentRequest> Select()
        {
             List<DocumentRequest> lstDocuments = null;
            
            try
            {
                using(var db = new DB_CRUDContext())
                {
                    lstDocuments = (from d in db.TbTipoDocumentos
                                    where d.Estato == true
                                   select new DocumentRequest
                                   {
                                       IdTipoDoc = d.IdTipoDocumento,
                                       Codigo = d.Codigo,
                                       Nombre = d.Nombre,
                                       Descripcion = d.Descripcion,
                                       estado = d.Estato
                                   }).ToList();
                }

                return lstDocuments;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al obtener los datos.");
            }
        }

        public DocumentRequest Select(int id)
        {
            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var document = db.TbTipoDocumentos.Where(d => d.IdTipoDocumento == id && d.Estato == true).FirstOrDefault();

                    if (document == null)
                        return null;

                    return new DocumentRequest
                    {
                        IdTipoDoc = document.IdTipoDocumento,
                        Codigo = document.Codigo,
                        Nombre = document.Nombre,
                        Descripcion = document.Descripcion,
                        estado = document.Estato
                    };
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al obtener el dato.");
            }
        }

        public bool Add(DocumentRequest entity)
        {
            bool result = false;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var document = new TbTipoDocumento
                    {
                        Codigo = entity.Codigo,
                        Nombre = entity.Nombre,
                        Descripcion = entity.Descripcion
                    };

                    db.TbTipoDocumentos.Add(document);
                    if (db.SaveChanges() > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al insertar los datos.");
            }
        }

        public bool Update(DocumentRequest entity)
        {
            bool result = false;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var document = db.TbTipoDocumentos.Where(d => d.IdTipoDocumento == entity.IdTipoDoc).FirstOrDefault();

                    if (document != null)
                    {
                        document.Codigo = entity.Codigo;
                        document.Nombre = entity.Nombre;
                        document.Descripcion = entity.Descripcion;

                        db.Entry<TbTipoDocumento>(document).State = EntityState.Modified;

                        if (db.SaveChanges() > 0)
                        {
                            result = true;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al actualizar los datos.");
            }
        }

        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var document = db.TbTipoDocumentos.Where(d => d.IdTipoDocumento == id).FirstOrDefault();

                    if (document != null)
                    {
                        document.Estato = false;

                        db.Entry<TbTipoDocumento>(document).State = EntityState.Modified;

                        if (db.SaveChanges() > 0)
                        {
                            result = true;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al eliminar los datos.");
            }
        }
    }
}
