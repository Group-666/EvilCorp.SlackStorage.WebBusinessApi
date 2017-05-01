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

        public async Task<string> Create(JObject json)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidJson(json), _validator.ValidatorLogLevel);

            var xml = _converter.ConvertCreateJsonToXml(json);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Create(xml));

            return _converter.ConvertXmlToString(response);
        }

        public async Task<string> Login(string userId, string passwordHash)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidHash(passwordHash), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Login(userId, passwordHash));

            return _converter.ConvertXmlToString(response);
        }

        public async Task<string> GetAll()
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.GetAll());

            return _converter.ConvertXmlToString(response);
        }

        public async Task<string> GetOne(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.GetOne(userId));

            return _converter.ConvertXmlToString(response);
        }

        public async Task<string> Disable(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Disable(userId));
            return _converter.ConvertXmlToString(response);
        }

        public async Task<string> Enable(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Enable(userId));
            return _converter.ConvertXmlToString(response);
        }

        public async Task<string> Delete(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Delete(userId));
            return _converter.ConvertXmlToString(response);
        }

        private static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}