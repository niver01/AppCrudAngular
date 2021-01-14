using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSCrud.Controllers
{
    public interface IGeneric<Entity> where Entity : class
    {
        ActionResult Get();

        ActionResult Get(int id);

        ActionResult Add([FromBody]  Entity entity);

        ActionResult Update([FromBody] Entity entity);

        ActionResult Delete(int id);
    }
}
