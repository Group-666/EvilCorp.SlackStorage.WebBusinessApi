using System;
using System.Threading.Tasks;
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
            if (unsafeAsyncFunction != null)
            {
                try
                {
                    return await unsafeAsyncFunction.Invoke();
                }
                catch (Exception ex)
                {
                    _logger.Log(ex.Message, logLevel);
                    throw;
                }
            }
            return await Task.FromResult(default(TResult));
        }

        public TResult Run<TResult>(Func<TResult> unsafeFunction, LogLevel logLevel = LogLevel.Critical)
        {
            if (unsafeFunction != null)
            {
                try
                {
                    return unsafeFunction.Invoke();
                }
                catch (Exception ex)
                {
                    _logger.Log(ex.Message, logLevel);
                    throw;
                }
            }
            return default(TResult);
        }

        public void Execute(Action unsafeAction)
        {
            if (unsafeAction != null)
            {
                try
                {
                    unsafeAction.Invoke();
                }
                catch (Exception ex)
                {
                    _logger.Log(ex.Message, LogLevel.Critical);
                }
            }
        }
    }
}