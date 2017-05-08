using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Business
{
    public class ClientDataManager : IClientDataManager
    {
        private readonly IClientDataRepository _clientDataRepository;
        private readonly IValidator _validator;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ILogger _logger;
        private readonly IConverter _converter;

        private const string MethodLogging = "Call to method: ";
        private const LogLevel MethodLogLevel = LogLevel.Trace;

        public ClientDataManager(IClientDataRepository clientDataRepository, IValidator validator, IExceptionHandler exceptionHandler,
            ILogger logger, IConverter converter)
        {
            _clientDataRepository = clientDataRepository;
            _validator = validator;
            _exceptionHandler = exceptionHandler;
            _logger = logger;
            _converter = converter;
        }

        public async Task<JObject> Create(string userId, JObject dataStoreName)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreName(dataStoreName), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.Create(userId, dataStoreName));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> Post(string userId, string dataStoreId, JObject data)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.Post(userId, dataStoreId, data));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> GetAll(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetAll(userId));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> Get(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.Get(userId, dataStoreId));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> GetElementAll(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetAllElement(userId, dataStoreId));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> GetElement(string userId, string dataStoreId, string elementId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetElement(userId, dataStoreId, elementId));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> UpdateElement(string userId, string dataStoreId, string elementId, JObject body)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.UpdateElement(userId, dataStoreId, elementId, body));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> DeleteAll(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteAll(userId));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> Delete(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.Delete(userId, dataStoreId));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> DeleteElementAll(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteAllElement(userId, dataStoreId));
            return _converter.StringToJson(result);
        }

        public async Task<JObject> DeleteElement(string userId, string dataStoreId, string elementId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteElement(userId, dataStoreId, elementId));
            return _converter.StringToJson(result);
        }

        private static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}