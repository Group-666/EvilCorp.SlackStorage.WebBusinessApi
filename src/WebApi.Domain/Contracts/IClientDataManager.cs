using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IClientDataManager
    {
        Task<string> Create(string userId, JObject dataStoreName);

        Task<string> Post(string userId, string dataStoreId, JObject data);

        Task<string> GetAll(string id);

        Task<string> GetOne(string userId, string dataStoreId);

        Task<string> GetElementAll(string userId, string dataStoreId);

        Task<string> GetElementOne(string userId, string dataStoreId, string elementId);

        Task<string> DeleteAll(string userId);

        Task<string> DeleteOne(string userId, string dataStoreId);

        Task<string> DeleteElementAll(string userId, string dataStoreId);

        Task<string> DeleteElementOne(string userId, string dataStoreId, string elementId);
    }
}