using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface ILogRepository
    {
        Task<string> Log(LogEntry logEntry);
    }
}