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
            try
            {
                var get = repository.GetAll();
                return Ok(get);
            }
            catch(Exception e)
            {
                return NotFound(e.InnerException);
            }
        }

<<<<<<< HEAD
        [HttpGet("Get/{id}")]
=======
        [HttpGet("{id}")]
>>>>>>> main
        public ActionResult Get(TId id)
        {
            try
            {
                var getById = repository.GetById(id);
                return Ok(getById);
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException);
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
<<<<<<< HEAD
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        [HttpDelete]
=======

        [HttpDelete("{id}")]
>>>>>>> Stashed changes
=======

        [HttpDelete("{id}")]
>>>>>>> Stashed changes
=======

        [HttpDelete("{id}")]
>>>>>>> main
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
<<<<<<< HEAD
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
=======
        [HttpPut("{id}")]
        public ActionResult Put(TId Id, Entity entity)
        {
            try
            {
                var result = repository.Put(Id, entity) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
>>>>>>> main
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
<<<<<<< HEAD
>>>>>>> Stashed changes
=======
>>>>>>> main
        }
    }
}
