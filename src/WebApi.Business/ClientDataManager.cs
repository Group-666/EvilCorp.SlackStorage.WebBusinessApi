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

        private const string MethodLogging = "Call to method: ";
        private const LogLevel MethodLogLevel = LogLevel.Trace;

        public ClientDataManager(IClientDataRepository clientDataRepository, IValidator validator, IExceptionHandler exceptionHandler,
            ILogger logger)
        {
            _clientDataRepository = clientDataRepository;
            _validator = validator;
            _exceptionHandler = exceptionHandler;
            _logger = logger;
        }

        public async Task<string> Create(string userId, JObject dataStoreName)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreName(dataStoreName), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.Create(userId, dataStoreName));
            return result;
        }

        public async Task<string> Post(string userId, string dataStoreId, JObject data)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.Post(userId, dataStoreId, data));
            return result;
        }

        public async Task<string> GetAll(string userId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetAll(userId));
            return result;
        }

        public async Task<string> Get(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.Get(userId, dataStoreId));
            return result;
        }

        public async Task<string> GetAllElement(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetAllElement(userId, dataStoreId));
            return result;
        }

        public async Task<string> GetElement(string userId, string dataStoreId, string elementId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetElement(userId, dataStoreId, elementId));
            return result;
        }

        public async Task<string> UpdateElement(string userId, string dataStoreId, string elementId, JObject body)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.UpdateElement(userId, dataStoreId, elementId, body));
            return result;
        }

        public async Task<string> DeleteAll(string userId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteAll(userId));
            return result;
        }

        public async Task<string> Delete(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.Delete(userId, dataStoreId));
            return result;
        }

        public async Task<string> DeleteAllElement(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteAllElement(userId, dataStoreId));
            return result;
        }

        public async Task<string> DeleteElement(string userId, string dataStoreId, string elementId)
        {
            _logger.Log(MethodLogging + _logger.GetCurrentMethodName(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            var result = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteElement(userId, dataStoreId, elementId));
            return result;
        }
    }
}