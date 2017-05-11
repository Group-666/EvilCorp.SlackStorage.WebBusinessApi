using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Business
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResult> RunAsync<TResult>(Func<Task<TResult>> unsafeAsyncFunction, LogLevel logLevel = LogLevel.Critical)
        {
            if (unsafeAsyncFunction == null) return await Task.FromResult(default(TResult));
            try
            {
                return await unsafeAsyncFunction.Invoke();
            }
            catch (Exception ex)
            {
                _logger.Log(JObject.FromObject(ex).ToString(), logLevel);
                throw;
            }
        }

        public TResult Run<TResult>(Func<TResult> unsafeFunction, LogLevel logLevel = LogLevel.Critical)
        {
            if (unsafeFunction == null) return default(TResult);
            try
            {
                return unsafeFunction.Invoke();
            }
            catch (Exception ex)
            {
                _logger.Log(JObject.FromObject(ex).ToString(), logLevel);
                throw;
            }
        }

        public void Execute(Action unsafeAction)
        {
            if (unsafeAction == null) return;
            try
            {
                unsafeAction.Invoke();
            }
            catch (Exception ex)
            {
                _logger.Log(JObject.FromObject(ex).ToString(), LogLevel.Critical);
            }
        }
    }
}