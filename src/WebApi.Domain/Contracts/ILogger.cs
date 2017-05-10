using System.Runtime.CompilerServices;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Contracts
{
    public interface ILogger
    {
        void Log(string message, LogLevel logLevel);

        string GetCurrentMethodName([CallerMemberName] string caller = null);
    }
}