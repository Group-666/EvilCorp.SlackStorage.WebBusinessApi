using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EvilCorp.AccountService;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAll();

        Task<Account> Create(Account account);

        Task<Account> Get(Guid id);

        Task Update(Account account);

        Task Delete(Guid id);
    }
}