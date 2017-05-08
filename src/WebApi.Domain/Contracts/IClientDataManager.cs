using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IClientDataManager
    {
        Task<JObject> Create(string userId, JObject dataStoreName);

        Task<JObject> Post(string userId, string dataStoreId, JObject data);

        Task<JObject> GetAll(string id);

        Task<JObject> Get(string userId, string dataStoreId);

        Task<JObject> GetElementAll(string userId, string dataStoreId);

        Task<JObject> GetElement(string userId, string dataStoreId, string elementId);

        Task<JObject> DeleteAll(string userId);

        Task<JObject> Delete(string userId, string dataStoreId);

        Task<JObject> DeleteElementAll(string userId, string dataStoreId);

        Task<JObject> DeleteElement(string userId, string dataStoreId, string elementId);

        Task<JObject> UpdateElement(string userId, string dataStoreId, string elementId);
    }
}