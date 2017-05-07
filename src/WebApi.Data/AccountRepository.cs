using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EvilCorp.AccountService;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ILogger _logger;

        public AccountRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<Account> Create(Account account)
        {
            _logger.Log("Getting all users from account service", LogLevel.Trace);
            var proxy = new AccountClient();

            try
            {
                return await proxy.Create(account);
            }
            catch (Exception e)
            {
                _logger.Log(e.ToString(), LogLevel.Error);
                throw;
            }
            finally
            {
                proxy.Close();
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            _logger.Log("Getting all users from account service", LogLevel.Trace);
            var proxy = new AccountClient();

            try
            {
                return await proxy.GetAll();
            }
            catch (Exception e)
            {
                _logger.Log(e.ToString(), LogLevel.Error);
                throw;
            }
            finally
            {
                proxy.Close();
            }
        }

        public async Task<Account> Get(Guid id)
        {
            _logger.Log("Getting all users from account service", LogLevel.Trace);
            var proxy = new AccountClient();

            try
            {
                return await proxy.Get(id);
            }
            catch (Exception e)
            {
                _logger.Log(e.ToString(), LogLevel.Error);
                throw;
            }
            finally
            {
                proxy.Close();
            }
        }

        public async Task Update(Account account)
        {
            _logger.Log("Getting all users from account service", LogLevel.Trace);
            var proxy = new AccountClient();

            try
            {
                await proxy.Update(account);
            }
            catch (Exception e)
            {
                _logger.Log(e.ToString(), LogLevel.Error);
                throw;
            }
            finally
            {
                proxy.Close();
            }
        }

        public async Task Delete(Guid id)
        {
            _logger.Log("Getting all users from account service", LogLevel.Trace);
            var proxy = new AccountClient();

            try
            {
                await proxy.Delete(id);
            }
            catch (Exception e)
            {
                _logger.Log(e.ToString(), LogLevel.Error);
                throw;
            }
            finally
            {
                proxy.Close();
            }
        }
    }
}