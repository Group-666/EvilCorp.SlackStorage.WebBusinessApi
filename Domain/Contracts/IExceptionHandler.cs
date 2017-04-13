using System;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface IExceptionHandler
    {
        TResult Run<TResult>(Func<TResult> unsafeFunction);
        void Execute(Action unsafeAction);
    }
}