using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using APIDB_Insecure.Models;

namespace APIDB_Insecure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {

            var personas = ColeccionPersonas.getInstance().verPersonas();
            return JsonConvert.SerializeObject(personas);

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var personas = ColeccionPersonas.getInstance().verPersona(id);
            return JsonConvert.SerializeObject(personas);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Persona persona)
        {

            ColeccionPersonas.getInstance().agregarPersona(persona);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Persona persona)
        {

            ColeccionPersonas.getInstance().actualizarPersona(persona);

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            ColeccionPersonas.getInstance().eliminarPersona(id);
            //return JsonConvert.SerializeObject(personas);

        }
    }
}
