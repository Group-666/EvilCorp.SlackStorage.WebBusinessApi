using Newtonsoft.Json.Linq;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Contracts
{
    public interface IValidator
    {
        LogLevel ValidatorLogLevel { get; }

        bool IsValidGuid(string userId);

        bool IsValidElementId(string elementId);

        bool IsValidDataStoreId(string dataStoreId);

        bool IsValidHash(string passwordHash);

        bool IsValidDataStoreName(JObject dataStoreNameJson);

        bool IsValidJson(JObject body);

        bool IsValidAccountJson(JObject body);
    }
}