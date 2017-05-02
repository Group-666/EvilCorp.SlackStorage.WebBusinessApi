using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Business
{
    public class ClientDataManager : IClientDataManager
    {
        private readonly IClientDataRespository _clientDataRepository;
        private readonly IValidator _validator;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ILogger _logger;

        private const string MethodLogging = "Call to method: ";
        private const LogLevel MethodLogLevel = LogLevel.Trace;

        public ClientDataManager(IClientDataRespository clientDataRepository, IValidator validator, IExceptionHandler exceptionHandler,
            ILogger logger)
        {
            _clientDataRepository = clientDataRepository;
            _validator = validator;
            _exceptionHandler = exceptionHandler;
            _logger = logger;
        }

        public async Task<string> GetAll(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.GetAll(userId));
        }

        public async Task<string> GetOne(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.GetOne(userId, dataStoreId));
        }

        public async Task<string> GetElementAll(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.GetElementAll(userId, dataStoreId));
        }

        public async Task<string> GetElementOne(string userId, string dataStoreId, string elementId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.GetElementOne(userId, dataStoreId, elementId));
        }

        public async Task<string> Create(string userId, JObject dataStoreName)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreName(dataStoreName), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.Create(userId, dataStoreName));
        }

        public async Task<string> Post(string userId, string dataStoreId, JObject data)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidJson(data), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.Post(userId, dataStoreId, data));
        }

        public async Task<string> DeleteAll(string userId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteAll(userId));
        }

        public async Task<string> DeleteOne(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteOne(userId, dataStoreId));
        }

        public async Task<string> DeleteElementAll(string userId, string dataStoreId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteElementAll(userId, dataStoreId));
        }

        public async Task<string> DeleteElementOne(string userId, string dataStoreId, string elementId)
        {
            _logger.Log(MethodLogging + GetCaller(), MethodLogLevel);

            _exceptionHandler.Run(() => _validator.IsValidGuid(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteElementOne(userId, dataStoreId, elementId));
        }

        private static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}