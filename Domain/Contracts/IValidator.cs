using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface IValidator
    {
        LogLevel ValidatorLogLevel { get; }

        bool IsValidUserId(string id);

        bool IsValidDataStoreId(string id);

        bool IsValidDataStoreName(string dataStoreName);

        bool IsValidJson(string json);
    }
}