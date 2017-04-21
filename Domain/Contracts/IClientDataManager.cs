using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface IDataStoreManager
    {
        Task<string> GetAll(string id);

        Task<string> GetOne(string userId, string dataStoreId);
    }
}