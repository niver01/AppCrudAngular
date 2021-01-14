using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSCrud.Models;
using WSCrud.Models.Request;

namespace WSCrud.Service
{
    public class TaxpayerService : ITaxpayerService
    {
        public IEnumerable<TaxpayerRequest> Select()
        {
            List<TaxpayerRequest> lstTaxpayers = null;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    lstTaxpayers = (from d in db.TbTipoContribuyentes
                                    where d.Estato == true
                                    select new TaxpayerRequest
                                    {
                                        IdContribuyente = d.IdTipoContribuyente,
                                        Nombre = d.Nombre,
                                        Estado = d.Estato
                                    }
                                    ).ToList();

                    return lstTaxpayers;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al obtener los datos.");
            }
        }

        public TaxpayerRequest Select(int id)
        {
            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var taxpayer = db.TbTipoContribuyentes.Where(d => d.IdTipoContribuyente == id && d.Estato == true).FirstOrDefault();

                    if (taxpayer == null)
                        return null;

                    return new TaxpayerRequest
                    {
                        IdContribuyente = taxpayer.IdTipoContribuyente,
                        Nombre = taxpayer.Nombre,
                        Estado = taxpayer.Estato
                    };
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al obtener el dato.");
            }
        }

        public bool Add(TaxpayerRequest entity)
        {
            bool result = false;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var taxpayer = new TbTipoContribuyente
                    {
                        Nombre = entity.Nombre,
                    };

                    db.TbTipoContribuyentes.Add(taxpayer);
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

        public bool Update(TaxpayerRequest entity)
        {
            bool result = false;

            try
            {
                using (var db = new DB_CRUDContext())
                {
                    var taxpayer = db.TbTipoContribuyentes.Where(d => d.IdTipoContribuyente == entity.IdContribuyente).FirstOrDefault();

                    if (taxpayer != null)
                    {
                        taxpayer.Nombre = entity.Nombre;

                        db.Entry<TbTipoContribuyente>(taxpayer).State = EntityState.Modified;

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
                    var taxpayer = db.TbTipoContribuyentes.Where(d => d.IdTipoContribuyente == id).FirstOrDefault();

                    if (taxpayer != null)
                    {
                        taxpayer.Estato = false;

                        db.Entry<TbTipoContribuyente>(taxpayer).State = EntityState.Modified;

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
