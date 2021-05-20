using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    public class TerritoriesController : BaseController<Territory, TerritoryRepository, int>
    {
        private readonly TerritoryRepository territoryRepository;
        public TerritoriesController(TerritoryRepository territoryRepository) : base(territoryRepository)
        {
            this.territoryRepository = territoryRepository;
        }
    }
}
