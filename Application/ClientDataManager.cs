using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business
{
    public class DataStoreManager : IDataStoreManager
    {
        private readonly IClientDataRespository _clientDataRepository;
        private readonly IValidator _validator;
        private readonly IExceptionHandler _exceptionHandler;

        public DataStoreManager(IClientDataRespository clientDataRepository, IValidator validator, IExceptionHandler exceptionHandler)
        {
            _clientDataRepository = clientDataRepository;
            _validator = validator;
            _exceptionHandler = exceptionHandler;
        }

        public async Task<string> GetAll(string userId)
        {
            if (!_validator.IsValidId(userId))
                return string.Empty;

            return await _exceptionHandler.Run(() => _clientDataRepository.GetAll(userId));
        }

        public async Task<string> GetOne(string userId, string dataStoreId)
        {
            if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId))
                return string.Empty;

            var response = await _exceptionHandler.Run(() => _clientDataRepository.GetOne(userId, dataStoreId));

            //response = "kaj";

            int y = 0;

            if (string.IsNullOrEmpty(response))
                response = null;
            return response;
        }

        public async Task<string> GetAllElement(string userId, string dataStoreId)
        {
            if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId))
                return string.Empty;

            var response = await _exceptionHandler.Run(() => _clientDataRepository.GetAllElements(userId, dataStoreId));

            return response;
        }

        public async Task<string> GetOneElement(string userId, string dataStoreId, string elementId)
        {
            if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId) || !_validator.IsValidId(elementId))
                return string.Empty;

            var response = await _exceptionHandler.Run(() => _clientDataRepository.GetOneElement(userId, dataStoreId, elementId));

            return response;
        }

        public async Task<string> Create(string userId, string dataStoreName)
        {
            if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreName))
                return string.Empty;

            var response = await _exceptionHandler.Run(() => _clientDataRepository.Create(userId, dataStoreName));

            return response;
        }

        public async Task<string> Post(string userId, string dataStoreId, string data)
        {
            if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId) || !_validator.IsValidId(data))
                return string.Empty;

            var response = await _exceptionHandler.Run(() => _clientDataRepository.Post(userId, dataStoreId, data));

            return response;
        }

        public async Task<string> DeleteAll(string userId)
        {
            if (!_validator.IsValidId(userId))
                return string.Empty;

            var response = await _exceptionHandler.Run(() => _clientDataRepository.DeleteAll(userId));

            return response;
        }

        public async Task<string> DeleteOne(string userId, string dataStoreId)
        {
            if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId))
                return string.Empty;

            var response = await _exceptionHandler.Run(() => _clientDataRepository.DeleteOne(userId, dataStoreId));

            return response;
        }

        public async Task<string> DeleteAllElements(string userId, string dataStoreId)
        {
            if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId))
                return string.Empty;

            var response = await _exceptionHandler.Run(() => _clientDataRepository.DeleteAllElements(userId, dataStoreId));

            return response;
        }

        public async Task<string> DeleteOneElements(string userId, string dataStoreId, string elementId)
        {
            if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId) || !_validator.IsValidId(dataStoreId))
                return string.Empty;

            var response = await _exceptionHandler.Run(() => _clientDataRepository.DeleteOneElement(userId, dataStoreId, elementId));

            return response;
        }
    }
}