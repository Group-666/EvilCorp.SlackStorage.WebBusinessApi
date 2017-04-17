using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface ILogger
    {
        void Log(string message, LogLevel logLevel);
    }
}