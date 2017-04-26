using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using System.Net;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business
{
    public class ClientDataManager : IClientDataManager
    {
        private readonly IClientDataRespository _clientDataRepository;
        private readonly IValidator _validator;
        private readonly IExceptionHandler _exceptionHandler;

        public ClientDataManager(IClientDataRespository clientDataRepository, IValidator validator, IExceptionHandler exceptionHandler)
        {
            _clientDataRepository = clientDataRepository;
            _validator = validator;
            _exceptionHandler = exceptionHandler;
        }

        public async Task<string> GetAll(string userId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.GetAll(userId));
        }

        public async Task<string> GetOne(string userId, string dataStoreId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetOne(userId, dataStoreId));

            return response;
        }

        public async Task<string> GetElementAll(string userId, string dataStoreId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetElementAll(userId, dataStoreId));

            return response;
        }

        public async Task<string> GetElementOne(string userId, string dataStoreId, string elementId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetElementOne(userId, dataStoreId, elementId));

            return response;
        }

        public async Task<HttpStatusCode> Create(string userId, string dataStoreName)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreName(dataStoreName), _validator.ValidatorLogLevel);

            return await _exceptionHandler.RunAsync(() => _clientDataRepository.Create(userId, dataStoreName));
        }

        public async Task<HttpStatusCode> Post(string userId, string dataStoreId, string data)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidJson(data), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.Post(userId, dataStoreId, data));

            return response;
        }

        public async Task<HttpStatusCode> DeleteAll(string userId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteAll(userId));

            return response;
        }

        public async Task<HttpStatusCode> DeleteOne(string userId, string dataStoreId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteOne(userId, dataStoreId));

            return response;
        }

        public async Task<HttpStatusCode> DeleteElementAll(string userId, string dataStoreId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteElementAll(userId, dataStoreId));

            return response;
        }

        public async Task<HttpStatusCode> DeleteElementOne(string userId, string dataStoreId, string elementId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidElementId(elementId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteElementOne(userId, dataStoreId, elementId));

            return response;
        }
    }
}