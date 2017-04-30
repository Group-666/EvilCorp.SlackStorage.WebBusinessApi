using EvilCorp.SlackStorage.WebApi.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace EvilCorp.SlackStorage.WebApi.Domain.Contracts
{
    public interface IValidator
    {
        LogLevel ValidatorLogLevel { get; }

        bool IsValidUserId(string userId);

        bool IsValidElementId(string elementId);

        bool IsValidDataStoreId(string dataStoreId);

        bool IsValidDataStoreName(JObject dataStoreNameJson);

        bool IsValidJson(JObject json);
    }
}