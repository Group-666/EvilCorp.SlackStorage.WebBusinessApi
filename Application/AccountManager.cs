using Newtonsoft.Json.Linq;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EvilCorp.SlackStorage.WebApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebApi.Domain.Entities;

namespace EvilCorp.SlackStorage.WebApi.Business
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

        public async Task<string> Create(JObject json)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidJson(json), _validator.ValidatorLogLevel);
            throw new NotImplementedException();
        }

        public async Task<string> Login(string userId, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetOne(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Disable(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Enable(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Delete(string userId)
        {
            throw new NotImplementedException();
        }

        private static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}