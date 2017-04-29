using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface IValidator
    {
        LogLevel ValidatorLogLevel { get; }

        bool IsValidUserId(string userId);

        bool IsValidElementId(string elementId);

        bool IsValidDataStoreId(string dataStoreId);

        bool IsValidDataStoreName(JObject dataStoreName);

        bool IsValidJson(string jsonData);
    }
}