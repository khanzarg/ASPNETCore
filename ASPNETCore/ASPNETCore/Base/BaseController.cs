using ASPNETCore.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, TId> : ControllerBase
        where Entity : class
        where Repository : IGenericRepository<Entity, TId>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var model = repository.GetAll();
            return Ok(model);
        }

        [HttpGet]
        public ActionResult Get(TId id)
        {
            var model = repository.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            repository.Post(entity);
            return Ok("Data has been successfully inserted.");
        }
        [HttpDelete]
        public ActionResult Delete(TId id)
        {
            repository.Delete(id);
            return Ok("Data has been successfully deleted.");
        }
        [HttpPut]
        public ActionResult Put(Entity entity)
        {
            repository.Put(entity);
            return Ok("Data has been successfully updated.");
        }
    }
}
