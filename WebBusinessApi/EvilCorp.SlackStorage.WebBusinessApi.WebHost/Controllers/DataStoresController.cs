using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class DataStoresController : Controller
    {
        // GET api/datastores
        [HttpGet]
        public IEnumerable<string> Get([FromHeader]int token)
        {
            // Authenticatiete token
            //Send id(token) to storage
            // Depending on the response, send a response back.
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            return await Program.Container.GetInstance<IDataStoreManager>().GetAll(id) ?? StatusCode(StatusCodes.Status500InternalServerError).ToString();

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