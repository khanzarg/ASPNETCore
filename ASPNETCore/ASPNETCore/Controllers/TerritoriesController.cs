using ASPNETCore.Base;
using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoriesController : BaseController<Territory, TerritoryRepository, int>
    {
        private readonly TerritoryRepository territoryRepository;
        public TerritoriesController(TerritoryRepository territoryRepository) : base(territoryRepository)
        {
            this.territoryRepository = territoryRepository;
        }
    }
}
