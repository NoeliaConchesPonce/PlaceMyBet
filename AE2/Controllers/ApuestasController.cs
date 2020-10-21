using AE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AE2.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<Apuestas> Get()
        {
            var reposit = new Apuestas_Repository();
            List<Apuestas> apuestas = reposit.retrieve();
            return apuestas;
        }

        // GET: api/Apuestas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Apuestas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
