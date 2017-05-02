using EvilCorp.AccountService;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class AccountClient : ClientBase<IAccountService>, IAccountService
    {
        public async Task<IEnumerable<Account>> GetAll()
        {
            return await Channel.GetAll();
        }
    }
}