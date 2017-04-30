using System.Threading.Tasks;

namespace WebApi.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<string> Login(string userId, string passwordHash);
    }
}