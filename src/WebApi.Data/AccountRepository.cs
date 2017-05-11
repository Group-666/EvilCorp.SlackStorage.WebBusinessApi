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
            var proxy = new AccountClient();

            try
            {
                var result = await proxy.Create(account);
                var log = $"Method: {_logger.GetCurrentMethodName()}, succesfully completed";
                _logger.Log(log, LogLevel.Trace);
                return result;
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
            var proxy = new AccountClient();

            try
            {
                var result = await proxy.GetAll();
                var log = $"Method: {_logger.GetCurrentMethodName()}, succesfully completed";
                _logger.Log(log, LogLevel.Trace);
                return result;
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
            var proxy = new AccountClient();

            try
            {
                var result = await proxy.Get(id);
                var log = $"Method: {_logger.GetCurrentMethodName()}, succesfully completed";
                _logger.Log(log, LogLevel.Trace);
                return result;
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
            var proxy = new AccountClient();

            try
            {
                await proxy.Update(account);
                var log = $"Method: {_logger.GetCurrentMethodName()}, succesfully completed";
                _logger.Log(log, LogLevel.Trace);
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
            var proxy = new AccountClient();

            try
            {
                await proxy.Delete(id);
                var log = $"Method: {_logger.GetCurrentMethodName()}, succesfully completed";
                _logger.Log(log, LogLevel.Trace);
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