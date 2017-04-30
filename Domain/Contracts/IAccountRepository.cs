using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebApi.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<string> Login(string userId, string passwordHash);
    }
}