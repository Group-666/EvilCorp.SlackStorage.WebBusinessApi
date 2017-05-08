using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EvilCorp.AccountService;
using Newtonsoft.Json.Linq;

namespace WebApi.Domain.Contracts
{
    public interface IAccountManager
    {
        Task<Account> Create(Account account);

        Task<IEnumerable<Account>> GetAll();

        Task<Account> Get(string userId);

        Task Update(Account account);

        Task Delete(string userId);
    }
}