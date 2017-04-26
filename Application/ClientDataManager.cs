using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
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

        public async Task<string> GetAllElement(string userId, string dataStoreId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetAllElements(userId, dataStoreId));

            return response;
        }

        public async Task<string> GetOneElement(string userId, string dataStoreId, string elementId)
        {
            _exceptionHandler.Run(() => _validator.IsValidUserId(userId), _validator.ValidatorLogLevel);
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(dataStoreId), _validator.ValidatorLogLevel);
            //TODO: What is an elementID?
            _exceptionHandler.Run(() => _validator.IsValidDataStoreId(elementId), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.GetOneElement(userId, dataStoreId, elementId));

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
            _exceptionHandler.Run(() => _validator.IsValidDataStoreName(data), _validator.ValidatorLogLevel);

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.Post(userId, dataStoreId, data));

            return response;
        }

        public async Task<HttpStatusCode> DeleteAll(string userId)
        {
            //if (!_validator.IsValidId(userId))
            //    //return string.Empty;

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteAll(userId));

            return response;
        }

        public async Task<HttpStatusCode> DeleteOne(string userId, string dataStoreId)
        {
            //if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId))
            //    return string.Empty;

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteOne(userId, dataStoreId));

            return response;
        }

        public async Task<HttpStatusCode> DeleteAllElements(string userId, string dataStoreId)
        {
            //if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId))
            //    return string.Empty;

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteAllElements(userId, dataStoreId));

            return response;
        }

        public async Task<HttpStatusCode> DeleteOneElement(string userId, string dataStoreId, string elementId)
        {
            //TODO: Return error messages for invalid Id's
            //if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId) || !_validator.IsValidId(elementId))
            //    return string.Empty;

            var response = await _exceptionHandler.RunAsync(() => _clientDataRepository.DeleteOneElement(userId, dataStoreId, elementId));

            return response;
        }
    }
}