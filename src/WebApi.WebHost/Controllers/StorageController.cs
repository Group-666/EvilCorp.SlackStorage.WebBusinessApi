using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using WebApi.Domain.Contracts;

namespace WebApi.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class StorageController : Controller
    {
        // POST api/datastores/5
        // [Route("login")]
        [HttpPost("{userId}")]
        public async Task<IActionResult> Create(string userId, [FromBody]JObject dataStoreNameJson)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().Create(userId, dataStoreNameJson));
        }

        // POST api/datastores/5/5
        [HttpPost("{userId}/{dataStoreId}")]
        public async Task<IActionResult> Post(string userId, string dataStoreId, [FromBody]JObject dataJson)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().Post(userId, dataStoreId, dataJson));
        }

        // GET api/datastores/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(string userId)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().GetAll(userId));
        }

        // GET api/datastores/5/5
        [HttpGet("{userId}/{dataStoreId}")]
        public async Task<IActionResult> Get(string userId, string dataStoreId)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().Get(userId, dataStoreId));
        }

        [HttpGet("{userId}/{dataStoreId}/data")]
        public async Task<IActionResult> GetAllElement(string userId, string dataStoreId)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().GetAllElement(userId, dataStoreId));
        }

        [HttpGet("{userId}/{dataStoreId}/data/{elementId}")]
        public async Task<IActionResult> GetElement(string userId, string dataStoreId, string elementId)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().GetElement(userId, dataStoreId, elementId));
        }

        [HttpPut("{userId}/{dataStoreId}/data/{elementId}")]
        public async Task<IActionResult> UpdateElement(string userId, string dataStoreId, string elementId, [FromBody]JObject body)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().UpdateElement(userId, dataStoreId, elementId, body));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAll(string userId)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().DeleteAll(userId));
        }

        [HttpDelete("{userId}/{dataStoreId}")]
        public async Task<IActionResult> Delete(string userId, string dataStoreId)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().Delete(userId, dataStoreId));
        }

        [HttpDelete("{userId}/{dataStoreId}/data/")]
        public async Task<IActionResult> DeleteAllElement(string userId, string dataStoreId)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>().DeleteAllElement(userId, dataStoreId));
        }

        [HttpDelete("{userId}/{dataStoreId}/data/{elementId}")]
        public async Task<IActionResult> DeleteElement(string userId, string dataStoreId, string elementId)
        {
            return await RunHttpAsync(() => Program.Container.GetInstance<IClientDataManager>()
                .DeleteElement(userId, dataStoreId, elementId));
        }

        private async Task<IActionResult> RunHttpAsync<TResult>(Func<Task<TResult>> unsafeAsyncFunction)
        {
            try
            {
                return Ok(await unsafeAsyncFunction.Invoke());
            }
            catch (HttpException ex)
            {
                var errorMessage = new { errorMessage = ex.Message };
                return StatusCode(ex.GetHttpCode(), errorMessage);
            }
            catch (ArgumentException ex)
            {
                var errorMessage = new { errorMessage = ex.Message };
                return BadRequest(errorMessage);
            }
            catch (Exception ex)
            {
                var errorMessage = new { errorMessage = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }
    }
}