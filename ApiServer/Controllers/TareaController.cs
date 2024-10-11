﻿using Api_Capacitacion.Model;
using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.Tarea;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        ITareaServices _tareaServices;
        public TareaController (ITareaServices tareaServices) => _tareaServices = tareaServices;
        // GET: api/<TareaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TareaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TareaController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTareaDTO createTareaDTO) 
        {
            TareaModel? task = await _tareaServices.Create(createTareaDTO);
            if(task == null) return NotFound();

            return Ok(task);
        }

        // PUT api/<TareaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TareaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
