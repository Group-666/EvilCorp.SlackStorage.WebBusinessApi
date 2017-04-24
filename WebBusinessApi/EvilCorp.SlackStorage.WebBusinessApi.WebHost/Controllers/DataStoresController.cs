using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class DataStoresController : Controller
    {
        // GET api/datastores
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().GetAll("id") ?? StatusCode(StatusCodes.Status500InternalServerError).ToString();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            return await Program.Container.GetInstance<IClientDataManager>().GetAll(id) ?? StatusCode(StatusCodes.Status500InternalServerError).ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}