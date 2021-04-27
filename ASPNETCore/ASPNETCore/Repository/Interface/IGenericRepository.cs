using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repository.Interface
{
    interface IGeneralRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Post(T obj);
        void Put(T obj);
        void Delete(object id);
    }
}
