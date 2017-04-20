using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface ILogRepository
    {
        Task<string> Log(JObject logEntry);
    }
}