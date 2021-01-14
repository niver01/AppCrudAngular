using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSCrud.Service
{
    public interface IGeneric<Entity> where Entity : class
    {
        IEnumerable<Entity> Select();
        Entity Select(int id);
        bool Add(Entity entity);
        bool Update(Entity entity);
        bool Delete(int id);
    }
}
