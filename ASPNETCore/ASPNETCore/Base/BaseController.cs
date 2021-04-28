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
            var get = repository.GetAll();
            return Ok(get);
        }

        [HttpGet]
        public ActionResult Get(TId id)
        {
            var getById = repository.GetById(id);
            if (getById == null)
            {
                return NotFound("Data not found");
            }
            else
            {
                return Ok(getById);
            }
        }

        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            try
            { 
                var result = repository.Post(entity) > 0 ? (ActionResult)Ok("Data has been successfully inserted.") : BadRequest("Data can't be inserted");
                return result;
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete]
        public ActionResult Delete(TId id)
        {
            try
            {
                var result = repository.Delete(id) > 0 ? (ActionResult)Ok("Data has been successfully deleted.") : BadRequest("Data can't be deleted.");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
            
        }
        [HttpPut]
        public ActionResult Put(Entity entity)
        {
            try
            {
                var result = repository.Put(entity) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
