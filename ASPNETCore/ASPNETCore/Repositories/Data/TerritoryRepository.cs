using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Repositories.Data
{
    public class TerritoryRepository : GeneralRepository<Territory>
    {

        //public TerritoryRepository() 
        //{
        //    repository = new GeneralRepository<Territory>();
        //} 
        //public TerritoryRepository(IGenericRepository<Territory> repository) 
        //{
        //    this.repository = repository;
        //}

        //private IGenericRepository<Territory> repository = null;
        
        //public IEnumerable<Territory> GetTerritories()
        //{
        //    var get = repository.GetAll();
        //    return get;
        //}
        //public Territory GetTerritoryById(int id)
        //{
        //    var getId = repository.GetById(id);
        //    return getId;
        //}
        //public void AddTerritory(Territory territory) 
        //{
        //    repository.Insert(territory);
        //    repository.Save();
        //}
        //public void UpdateTerritory(Territory territory) 
        //{
        //    repository.Update(territory);
        //    repository.Save();
        //}
        //public void DeleteTerritory(int id) 
        //{
        //    repository.Delete(id);
        //    repository.Save();
        //}
    }
}
