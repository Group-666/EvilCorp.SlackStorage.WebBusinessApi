using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EvilCorp.SlackStorage.WebApi.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace EvilCorp.SlackStorage.WebApi.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Create(JObject json)
        {
            try
            {
                var result = await Program.Container.GetInstance<IAccountManager>().Create(json);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}/{passwordHash}")]
        public async Task<IActionResult> Login(string userId, string passwordHash)
        {
            try
            {
                var result = await Program.Container.GetInstance<IAccountManager>().Login(userId, passwordHash);

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
        public async Task<IActionResult> GetOne(string userId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IAccountManager>().GetOne(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}/disable/")]
        public async Task<IActionResult> Disable(string userId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IAccountManager>().Disable(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}/enable/")]
        public async Task<IActionResult> Enable(string userId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IAccountManager>().Enable(userId);

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
        public async Task<IActionResult> Delete(string userId)
        {
            try
            {
                var result = await Program.Container.GetInstance<IAccountManager>().Delete(userId);

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