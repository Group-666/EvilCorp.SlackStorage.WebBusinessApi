using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface IClientDataRespository
    {
        Task<string> Test();
    }
}