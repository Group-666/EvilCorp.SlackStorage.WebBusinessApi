using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<string> Create(XDocument xml);

        Task<string> Login(string userId, string passwordHash);

        Task<string> GetAll();

        Task<string> GetOne(string userId);

        Task<string> Disable(string userId);

        Task<string> Enable(string userId);

        Task<string> Delete(string userId);
    }
}