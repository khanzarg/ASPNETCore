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
    [Route("api/{controller}")]
    [ApiController]
    public class TerritoriesController : ControllerBase
    {
        TerritoryRepository territoryRepository = new TerritoryRepository();
        private readonly Territory territory = new Territory();
        [HttpGet]
        [Route("api/{controller}")]
        public ActionResult Get() 
        {
            var model = territoryRepository.GetTerritories();
            return Ok(model);
        }

        [HttpGet]
        [Route("api/{controller}/id")]
        public ActionResult Get(int id) 
        {
            Territory model = territoryRepository.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        [Route("api/{controller}")]
        public ActionResult Post() 
        {
            territoryRepository.AddTerritory(territory);
            return Ok("Data has been successfully inserted.");
        }
        [HttpDelete]
        [Route("api/{controller}/id")]
        public ActionResult Delete(int id) 
        {
            territoryRepository.DeleteTerritory(id);
            return Ok("Data has been successfully deleted.");
        }
        [HttpPut]
        [Route("api/{controller}/id")]
        public ActionResult Put(int id) 
        {
            territoryRepository.GetById(id);
            territoryRepository.UpdateTerritory(territory);
            return Ok("Data has been successfully updated.");
        }
    }
}
