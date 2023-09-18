﻿using TrabajoIntegradorSofftek.Entities;
using TrabajoIntegradorSofftek.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajoIntegradorSofftek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajosController : ControllerBase
    {
        // GET: api/<TrabajosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TrabajosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TrabajosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TrabajosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TrabajosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
