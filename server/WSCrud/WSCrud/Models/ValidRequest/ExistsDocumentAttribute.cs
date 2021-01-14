using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSCrud.Models.ValidRequest
{
    public class ExistsDocumentAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int id = (int)value;

            using (var db = new DB_CRUDContext())
            {
                if (db.TbTipoDocumentos.Find(id) == null)
                    return false;
            }

            return true;
        }
    }
}
