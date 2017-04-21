using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface IClientDataRespository
    {
        Task<string> GetAll(string id);

        Task<string> GetOne(string userId, string dataStoreId);

        Task<string> GetOneElement(string userId, string dataStoreId, string elementId);

        Task<string> GetAllElements(string userId, string dataStoreId);

        Task<string> Create(string userId, string dataStoreName);

        Task<string> Post(string userId, string dataStoreId, string data);

        Task<string> DeleteAll(string userId);

        Task<string> DeleteOne(string userId, string dataStoreId);

        Task<string> DeleteAllElements(string userId, string dataStoreId);

        Task<string> DeleteOneElement(string userId, string dataStoreId, string elementId);
    }
}