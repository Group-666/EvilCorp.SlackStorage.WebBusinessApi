using EvilCorp.SlackStorage.WebApi.Domain.Entities;

namespace EvilCorp.SlackStorage.WebApi.Domain.Contracts
{
    public interface ILogger
    {
        void Log(string message, LogLevel logLevel);
    }
}