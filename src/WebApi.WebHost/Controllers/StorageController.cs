using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
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
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().Create(userId, dataStoreNameJson);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/datastores/5/5
        [HttpPost("{userId}/{dataStoreId}")]
        public async Task<IActionResult> Post(string userId, string dataStoreId, [FromBody]JObject dataJson)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().Post(userId, dataStoreId, dataJson);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/datastores/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(string userId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().GetAll(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/datastores/5/5
        [HttpGet("{userId}/{dataStoreId}")]
        public async Task<IActionResult> Get(string userId, string dataStoreId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().Get(userId, dataStoreId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}/{dataStoreId}/data")]
        public async Task<IActionResult> GetElementAll(string userId, string dataStoreId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().GetElementAll(userId, dataStoreId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}/{dataStoreId}/data/{elementId}")]
        public async Task<IActionResult> GetElement(string userId, string dataStoreId, string elementId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().GetElement(userId, dataStoreId, elementId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{userId}/{dataStoreId}/data/{elementId}")]
        public async Task<IActionResult> UpdateElement(string userId, string dataStoreId, string elementId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().UpdateElement(userId, dataStoreId, elementId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAll(string userId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().DeleteAll(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userId}/{dataStoreId}")]
        public async Task<IActionResult> Delete(string userId, string dataStoreId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().Delete(userId, dataStoreId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userId}/{dataStoreId}/data/")]
        public async Task<IActionResult> DeleteElementAll(string userId, string dataStoreId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().DeleteElementAll(userId, dataStoreId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userId}/{dataStoreId}/data/{elementId}")]
        public async Task<IActionResult> DeleteElement(string userId, string dataStoreId, string elementId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IClientDataManager>().DeleteElement(userId, dataStoreId, elementId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}