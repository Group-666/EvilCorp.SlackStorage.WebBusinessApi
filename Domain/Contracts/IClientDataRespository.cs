using System.Net;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface IClientDataRespository
    {
        Task<string> GetAll(string id);

        Task<string> GetOne(string userId, string dataStoreId);

        Task<string> GetOneElement(string userId, string dataStoreId, string elementId);

        Task<string> GetAllElements(string userId, string dataStoreId);

        Task<HttpStatusCode> Create(string userId, string dataStoreName);

        Task<HttpStatusCode> Post(string userId, string dataStoreId, string data);

        Task<HttpStatusCode> DeleteAll(string userId);

        Task<HttpStatusCode> DeleteOne(string userId, string dataStoreId);

        Task<HttpStatusCode> DeleteAllElements(string userId, string dataStoreId);

        Task<HttpStatusCode> DeleteOneElement(string userId, string dataStoreId, string elementId);
    }
}