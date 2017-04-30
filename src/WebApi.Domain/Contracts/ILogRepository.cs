using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebApi.Domain.Contracts
{
    public interface ILogRepository
    {
        Task<string> Log(JObject logEntry);
    }
}