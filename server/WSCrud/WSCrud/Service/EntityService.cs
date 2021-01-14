using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCrud.Models;
using WSCrud.Models.Request;

namespace WSCrud.Service
{
    public class EntityService : IEntityService
    {
        public IEnumerable<EntityRequest> Select()
        {
            List<EntityRequest> lstEntitys = null;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    lstEntitys = (from e in db.TbEntidads
                                  join d in db.TbTipoDocumentos
                                  on e.IdTipoDocumento equals d.IdTipoDocumento
                                  join c in db.TbTipoContribuyentes
                                  on e.IdTipoContribuyente equals c.IdTipoContribuyente
                                  where e.Estato == true
                                  select new EntityRequest
                                  {
                                      IdEntidad = e.IdEntidad,
                                      IdTipoDoc = d.IdTipoDocumento,
                                      codigoDoc = d.Codigo,
                                      NumDocumento = e.NroDocumento,
                                      RazonSocial = e.RazonSocial,
                                      NombreComercial = e.NombreComercial,
                                      IdContribuyente = c.IdTipoContribuyente,
                                      NombreContribuyente = c.Nombre,
                                      Direccion = e.Direccion,
                                      Telefono = e.Telefono,
                                      estado = e.Estato
                                  }).ToList();
                }

                return lstEntitys;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al obtener los datos.");
            }
        }

        public EntityRequest Select(int id)
        {
            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var entity = db.TbEntidads.Where(d => d.IdEntidad == id && d.Estato == true).FirstOrDefault();

                    if (entity == null)
                        return null;

                    return new EntityRequest
                    {
                        IdEntidad = entity.IdEntidad,
                        IdTipoDoc = entity.IdTipoDocumento,
                        NumDocumento = entity.NroDocumento,
                        RazonSocial = entity.RazonSocial,
                        NombreComercial = entity.NombreComercial,
                        IdContribuyente = entity.IdTipoContribuyente,
                        Direccion = entity.Direccion,
                        Telefono = entity.Telefono,
                        estado = entity.Estato
                    };
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al obtener el dato.");
            }
        }

        public bool Add(EntityRequest entity)
        {
            bool result = false;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var oentity = new TbEntidad
                    {
                        IdTipoDocumento = entity.IdTipoDoc,
                        NroDocumento = entity.NumDocumento,
                        RazonSocial = entity.RazonSocial,
                        NombreComercial =entity.NombreComercial,
                        IdTipoContribuyente = entity.IdContribuyente,
                        Direccion = entity.Direccion,
                        Telefono = entity.Telefono
                    };

                    db.TbEntidads.Add(oentity);
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

        public bool Update(EntityRequest entity)
        {
            bool result = false;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var oentity = db.TbEntidads.Where(d => d.IdEntidad == entity.IdEntidad).FirstOrDefault();

                    if(oentity != null)
                    {

                        oentity.IdTipoDocumento = entity.IdTipoDoc;
                        oentity.NroDocumento = entity.NumDocumento;
                        oentity.RazonSocial = entity.RazonSocial;
                        oentity.NombreComercial = entity.NombreComercial;
                        oentity.IdTipoContribuyente = entity.IdContribuyente;
                        oentity.Direccion = entity.Direccion;
                        oentity.Telefono = entity.Telefono;
                        
                        db.Entry<TbEntidad>(oentity).State = EntityState.Modified;

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
                throw new Exception("Ocurrio un error al insertar los datos.");
            }
        }

        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var entity = db.TbEntidads.Where(d => d.IdEntidad == id).FirstOrDefault();

                    if (entity != null)
                    {
                        entity.Estato = false;

                        db.Entry<TbEntidad>(entity).State = EntityState.Modified;

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
