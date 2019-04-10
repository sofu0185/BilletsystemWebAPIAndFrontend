using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilletsystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OeresundController : ControllerBase
    {
        // GET: api/Oeresund
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Oeresund/5
        [HttpGet("pris/{type}", Name = "GetPris")]
        public ActionResult<decimal> Get(string type)
        {
            if (String.IsNullOrWhiteSpace(type))
                return this.BadRequest();

            switch (type.ToLower())
            {
                case "bil":
                    return Ok(new OeresundBilletLibrary.Bil().Pris());
                case "mc":
                    return Ok(new OeresundBilletLibrary.MC().Pris());
                default:
                    return NoContent();
            }
        }

        // POST: api/Oeresund
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Oeresund/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
