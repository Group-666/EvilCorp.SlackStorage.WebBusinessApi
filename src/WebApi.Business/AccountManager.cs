using System;
using EvilCorp.AccountService;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebApi.Domain.Contracts;
using WebApi.Domain.Contracts.Validators;
using WebApi.Domain.Entities;

namespace WebApi.Business
{
    public class AccountManager : IAccountManager
    {
        private const string MethodLogging = "Call to method: ";
        private const LogLevel MethodLogLevel = LogLevel.Trace;
        private readonly ILogger _logger;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IValidator _validator;
        private readonly IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository, IValidator validator, IExceptionHandler exceptionHandler,
            ILogger logger)
        {
            _accountRepository = accountRepository;
            _validator = validator;
            _exceptionHandler = exceptionHandler;
            _logger = logger;
        }

        public async Task<Account> Create(Account account)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidCreateAccount(account), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _accountRepository.Create(account));
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            return await _exceptionHandler.RunAsync(() => _accountRepository.GetAll());
        }

        public async Task<Account> Get(string userId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _accountRepository.Get(Guid.Parse(userId)));
        }

        public async Task Update(Account account)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidAccount(account), _validator.ValidatorLogLevel);

            await _accountRepository.Update(account);
        }

        public async Task Delete(string userId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            await _accountRepository.Delete(Guid.Parse(userId));
        }
    }
}