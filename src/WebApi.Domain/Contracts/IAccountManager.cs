using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IAccountManager
    {
        Task<JObject> Create(JObject json);

        Task<JObject> GetAll();

        Task<JObject> Get(string userId);

        Task<JObject> Update(JObject json);

        Task<JObject> Delete(string userId);
    }
}