using System;
using System.Threading.Tasks;
using EvilCorp.SlackStorage.WebApi.Domain.Entities;

namespace EvilCorp.SlackStorage.WebApi.Domain.Contracts
{
    public interface IExceptionHandler
    {
        Task<TResult> RunAsync<TResult>(Func<Task<TResult>> unsafeAsyncFunction, LogLevel logLevel = LogLevel.Critical);

        TResult Run<TResult>(Func<TResult> unsafeFunction, LogLevel logLevel = LogLevel.Critical);

        void Execute(Action unsafeAction);
    }
}