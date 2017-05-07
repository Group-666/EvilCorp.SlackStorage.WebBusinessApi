using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IAccountManager
    {
        Task<JObject> Create(JObject body);

        Task<JObject> GetAll();

        Task<JObject> Get(string userId);

        Task Update(JObject body);

        Task Delete(string userId);
    }
}