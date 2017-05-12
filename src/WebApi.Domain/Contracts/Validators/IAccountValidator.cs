using System.Threading.Tasks;

namespace WebApi.Domain.Contracts.Validators
{
    public interface IAccountValidator
    {
        Task<bool> DoesAccountExist(string userId);
    }
}