using WebApi.Domain.Entities;

namespace WebApi.Domain.Contracts
{
    public interface ILogger
    {
        void Log(string message, LogLevel logLevel);
    }
}