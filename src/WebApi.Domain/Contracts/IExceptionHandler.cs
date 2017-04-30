using System;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Contracts
{
    public interface IExceptionHandler
    {
        Task<TResult> RunAsync<TResult>(Func<Task<TResult>> unsafeAsyncFunction, LogLevel logLevel = LogLevel.Critical);

        TResult Run<TResult>(Func<TResult> unsafeFunction, LogLevel logLevel = LogLevel.Critical);

        void Execute(Action unsafeAction);
    }
}