using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Application
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

        public async Task<string> GetValue()
        {
            return await _exceptionHandler.Run(() => _clientDataRepository.Test());
        }

        public async Task<string> GetValue(string id)
        {
            if (!_validator.IsValidId(id))
                return string.Empty;

            return await _exceptionHandler.Run(() => _clientDataRepository.Test());
        }
    }
}