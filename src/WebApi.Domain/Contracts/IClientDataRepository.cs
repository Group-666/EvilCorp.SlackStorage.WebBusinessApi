using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IClientDataRepository
    {
        Task<string> GetAll(string id);

        Task<string> Get(string userId, string dataStoreId);

        Task<string> GetElement(string userId, string dataStoreId, string elementId);

        Task<string> GetAllElement(string userId, string dataStoreId);

        Task<string> Create(string userId, JObject dataStoreName);

        Task<string> Post(string userId, string dataStoreId, JObject data);

        Task<string> DeleteAll(string userId);

        Task<string> Delete(string userId, string dataStoreId);

        Task<string> DeleteAllElement(string userId, string dataStoreId);

        Task<string> DeleteElement(string userId, string dataStoreId, string elementId);

        Task<string> UpdateElement(string userId, string dataStoreId, string elementId, JObject body);
    }
}