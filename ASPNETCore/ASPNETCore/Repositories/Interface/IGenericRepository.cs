using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Interface
{
    public interface IGenericRepository<Entity, TId> where Entity : class
    {
        IEnumerable<Entity> GetAll();
        Entity GetById(TId Id);
        int Post(Entity obj);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
        int Put(Entity obj, TId Id);
=======
        int Put(TId Id, Entity obj);
>>>>>>> main
=======
        int Put(Entity obj, TId Id);
>>>>>>> Stashed changes
=======
        int Put(Entity obj, TId Id);
>>>>>>> Stashed changes
        int Delete(TId Id);
        //void Save();
    }
}
