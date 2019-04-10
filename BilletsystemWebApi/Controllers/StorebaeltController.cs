using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilletLibrary;
using StoreBaeltBilletLibrary;

namespace BilletsystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorebaeltController : ControllerBase
    {
        // GET: api/Storebaelt
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Storebaelt/5
        [HttpGet("pris/{type}", Name = "GetPris")]
        public ActionResult<decimal> Get(string type)
        {
            if (String.IsNullOrWhiteSpace(type))
                return this.BadRequest();

            switch (type.ToLower())
            {
                case "bil":
                    return Ok(new StoreBaeltBilletLibrary.Bil().Pris());
                case "mc":
                    return Ok(new BilletLibrary.MC().Pris());
                default:
                    return NoContent();
            }
        }

        // POST: api/Storebaelt
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Storebaelt/5
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
