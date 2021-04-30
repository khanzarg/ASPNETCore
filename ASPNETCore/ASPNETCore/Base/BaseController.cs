using ASPNETCore.Handlers;
using ASPNETCore.Repositories.Interface;
using ASPNETCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        //private IConfiguration _config;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
                try
                {
                    //var jwt = new JwtService(_config);
                    //var token = jwt.GenerateSecurityToken("fake@email.com");
                    //return token;
                    var get = repository.GetAll();
                    return Ok(get);
                }
                catch (Exception e)
                {
                    return NotFound(e.InnerException);
                }
            return Forbid("Failed to auth");
        }

        [HttpGet("{id}")]
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

        [HttpDelete("{id}")]
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
        [HttpPut("{id}")]
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
