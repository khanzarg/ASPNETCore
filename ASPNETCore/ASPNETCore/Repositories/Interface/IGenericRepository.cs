using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        void Post(T obj);
        void Put(T obj);
        void Delete(object Id);
        //void Save();
    }
}
