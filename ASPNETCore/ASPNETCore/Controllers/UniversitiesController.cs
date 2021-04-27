using ASPNETCore.Context;
using ASPNETCore.Models;
using ASPNETCore.Repositories;
using ASPNETCore.Repositories.Data;
using ASPNETCore.Repositories.Interface;
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
    public class UniversitiesController : ControllerBase
    {
        private UniversityRepository repository;
        public UniversitiesController(UniversityRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var get = repository.GetAllUni();
            return Ok(get);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var get = repository.GetById(id);
            if(get == null)
            {
                return NotFound("Data tidak ditemukan");
            }
            else
            {
                return Ok(get);
            }
        }

        [HttpPost]
        public IActionResult Post(University university)
        {
            try
            {
                repository.Insert(university);
            }
            catch (Exception)
            {
                return BadRequest("Insert data gagal");
            }
            return Ok("Data berhasil diinputkan");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, University university)
        {
            try
            {
                repository.UpdateUni(id, university);
            }
            catch (Exception)
            {
                return BadRequest("Update data gagal");
            }
            return Ok("Data berhasil diperbarui");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
    }
}
