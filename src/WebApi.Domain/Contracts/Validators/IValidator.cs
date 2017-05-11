using EvilCorp.AccountService;
using Newtonsoft.Json.Linq;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Contracts.Validators
{
    public interface IValidator
    {
        LogLevel ValidatorLogLevel { get; }

        bool IsValidGuid(string userId);

        bool IsValidElementId(string elementId);

        bool IsValidDataStoreId(string dataStoreId);

        bool IsValidDataStoreName(JObject dataStoreNameJson);

        bool IsValidAccount(Account account);

        bool IsValidCreateAccount(Account account);
    }
}