using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface ILogRepository
    {
        Task<string> Log(JObject logEntry);
    }
}