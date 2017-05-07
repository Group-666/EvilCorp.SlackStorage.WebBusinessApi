using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using WebApi.Domain.Contracts;

namespace WebApi.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]JObject body)
        {
            try
            {
                var result = await Program.Container.GetInstance<IAccountManager>().Create(body);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await Program.Container.GetInstance<IAccountManager>().GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IAccountManager>().Get(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update([FromBody]JObject body)
        {
            try
            {
                await Program.Container.GetInstance<IAccountManager>().Update(body);

                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            try
            {
                await Program.Container.GetInstance<IAccountManager>().Delete(userId);

                return Ok();
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