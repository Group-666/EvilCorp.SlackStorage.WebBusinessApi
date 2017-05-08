using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EvilCorp.AccountService;
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

        public async Task<JObject> Create(JObject body)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidAccountJson(body), _validator.ValidatorLogLevel);

            var account = _converter.JsonToObject<Account>(body);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Create(account));

            return _converter.ObjectToJson(response);
        }

        public async Task<JObject> GetAll()
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.GetAll());

            return _converter.ObjectsToJson(response, "Accounts");
        }

        public async Task<JObject> Get(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            var guid = _exceptionHandler.Run(() => _converter.StringToGuid(userId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _accountRepository.Get(guid));

            return _converter.ObjectToJson(response);
        }

        public async Task Update(JObject body)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidAccountJson(body), _validator.ValidatorLogLevel);

            var account = _exceptionHandler.Run(() => _converter.JsonToObject<Account>(body), _validator.ValidatorLogLevel);

            await _accountRepository.Update(account);
        }

        public async Task Delete(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            var guid = _exceptionHandler.Run(() => _converter.StringToGuid(userId), _validator.ValidatorLogLevel);

            await _accountRepository.Delete(guid);
        }

        private static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}