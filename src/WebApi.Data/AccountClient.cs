using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WebApi.Domain.Contracts;
using EvilCorp.AccountService;

namespace WebApi.Data
{
    public class AccountClient : ClientBase<IAccountService>, IAccountService
    {
        public async Task<IEnumerable<Account>> GetAll()
        {
            return await Channel.GetAll();
        }

        public async Task<Account> Create(Account account)
        {
            return await Channel.Create(account);
        }

        public async Task<Account> Get(Guid id)
        {
            return await Channel.Get(id);
        }

        public async Task Update(Account account)
        {
            await Channel.Update(account);
        }

        public async Task Delete(Guid id)
        {
            await Channel.Delete(id);
        }
    }
}