using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
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
            if (!_validator.IsValidId(userId))
                return string.Empty;

            return await _exceptionHandler.Run(() => _clientDataRepository.GetAll(userId));
        }

        public async Task<string> GetOne(string userId, string dataStoreId)
        {
            
            if (!_validator.IsValidId(userId) || !_validator.IsValidId(dataStoreId))
                return string.Empty;

            return await _exceptionHandler.Run(() => _clientDataRepository.GetOne(userId, dataStoreId));
        }
    }
}