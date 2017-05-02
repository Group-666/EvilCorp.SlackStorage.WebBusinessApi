using EvilCorp.AccountService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAll();

        Task<Account> Create(Account account);

        Task Delete(Guid id);

        Task<Account> Get(Guid id);

        Task Update(Account account);
    }
}