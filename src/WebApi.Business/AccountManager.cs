using Newtonsoft.Json.Linq;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using WebApi.Domain.Contracts;
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
        private readonly IConverter _converter;

        public AccountManager(IAccountRepository accountRepository, IValidator validator, IExceptionHandler exceptionHandler,
            ILogger logger, IConverter converter)
        {
            _accountRepository = accountRepository;
            _validator = validator;
            _exceptionHandler = exceptionHandler;
            _logger = logger;
            _converter = converter;
        }

        public async Task<JObject> Create(JObject accountJson)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidJson(accountJson), _validator.ValidatorLogLevel);

            var xml = _converter.JsonToAccount(accountJson);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Create(xml));

            return _converter.AccountToJson(response);
        }

        public async Task<JObject> GetAll()
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.GetAll());

            return _converter.ConvertXmlToString(response);
        }

        public async Task<JObject> Get(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Get(userId));

            return _converter.ConvertXmlToString(response);
        }

        public async Task<JObject> Update(JObject accountJson)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Update(userId));
            return _converter.ConvertXmlToString(response);
        }

        public async Task<JObject> Delete(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Delete(userId));
            return _converter.ConvertXmlToString(response);
        }

        private static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}