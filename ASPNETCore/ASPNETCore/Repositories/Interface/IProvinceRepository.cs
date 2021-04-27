using ASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Interface
{
    public interface IProvinceRepository
    {
        IEnumerable<Province> GetAll();
        Province GetById(int Id);
        void Post(Province province);
        void Update(Province province);
        void Delete(int Id);
        void Save();
    }
}
