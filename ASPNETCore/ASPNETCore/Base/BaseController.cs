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

        [HttpGet("GetAll/")]
        public ActionResult Get()
        {
            var model = repository.GetAll();
            return Ok(model);
        }

        [HttpGet("Get/{id}")]
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
<<<<<<< Updated upstream
        [HttpDelete]
=======

        [HttpDelete("{id}")]
>>>>>>> Stashed changes
        public ActionResult Delete(TId id)
        {
            repository.Delete(id);
            return Ok("Data has been successfully deleted.");
        }
        [HttpPut("Put/{id}")]
        public ActionResult Put(Entity entity, TId Id)
        {
<<<<<<< Updated upstream
            repository.Put(entity);
            return Ok("Data has been successfully updated.");
=======
            try
            {
                var result = repository.Put(entity, Id) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
>>>>>>> Stashed changes
        }
    }
}
