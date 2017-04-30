using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IAccountManager
    {
        Task<string> Create(JObject json);

        Task<string> Login(string userId, string passwordHash);

        Task<string> GetAll();

        Task<string> GetOne(string userId);

        Task<string> Disable(string userId);

        Task<string> Enable(string userId);

        Task<string> Delete(string userId);
    }
}