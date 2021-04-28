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
                return NotFound("Data tidak ditemukan");
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
                repository.Post(entity);
            }
            catch (Exception)
            {
                return BadRequest("Insert data gagal");
            }
            return Ok("Data berhasil diinputkan");
        }
        [HttpDelete]
        public ActionResult Delete(TId id)
        {
            try
            {
                repository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest("Hapus data gagal");
            }
            return Ok("Data berhasil dihapus");
        }
        [HttpPut]
        public ActionResult Put(Entity entity)
        {
            try
            {
                repository.Put(entity);
            }
            catch (Exception)
            {
                return BadRequest("Update data gagal");
            }
            return Ok("Data berhasil diperbarui");
        }
    }
}
