using EvilCorp.AccountService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Domain.Contracts;

namespace WebApi.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Account body)
        {
            return await RunAsync(() => Program.Container.GetInstance<IAccountManager>().Create(body));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await RunAsync(() => Program.Container.GetInstance<IAccountManager>().GetAll());
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            return await RunAsync(() => Program.Container.GetInstance<IAccountManager>().Get(userId));
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update([FromBody]Account body)
        {
            return await ExecuteAsync(() => Program.Container.GetInstance<IAccountManager>().Update(body));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            return await ExecuteAsync(() => Program.Container.GetInstance<IAccountManager>().Delete(userId));
        }

        private async Task<IActionResult> RunAsync<TResult>(Func<Task<TResult>> unsafeAsyncFunction)
        {
            try
            {
                return Ok(await unsafeAsyncFunction.Invoke());
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

        public async Task<IActionResult> ExecuteAsync(Func<Task> unsafeAsyncFunction)
        {
            try
            {
                await unsafeAsyncFunction.Invoke();
                return Ok();
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