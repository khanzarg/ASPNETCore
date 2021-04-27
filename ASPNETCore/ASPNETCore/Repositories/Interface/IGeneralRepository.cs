using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Interface
{
    public interface IGeneralRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        void Post(T obj);
        void Update(T obj);
        void Delete(object Id);
        void Save();

    }
}
