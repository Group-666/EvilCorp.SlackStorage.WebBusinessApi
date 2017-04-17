using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using System;

namespace EvilCorp.SlackStorage.WebBusinessApi.Application
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        public TResult Run<TResult>(Func<TResult> unsafeFunction)
        {
            if (unsafeFunction != null)
            {
                try
                {
                    return unsafeFunction.Invoke();
                }
                catch (Exception ex)
                {
                    //ToDo implement logger
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
                    //ToDo implement logger
                }
            }
        }
    }
}