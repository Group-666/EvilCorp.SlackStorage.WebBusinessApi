using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using Newtonsoft.Json;
using System;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business
{
    public class Validator : IValidator
    {
        private static readonly int DataStoreIdMaxLength = 105;
        private static readonly int UserIdMaxLength = 12;
        private static readonly int DataStoreNameMaxLength = DataStoreIdMaxLength - UserIdMaxLength - 1;

        public LogLevel ValidatorLogLevel { get; } = LogLevel.Warning;

        public bool IsValidUserId(string id)
        {

            return true;
        }

        public bool IsValidDataStoreId(string id)
        {
            if (id.Length > DataStoreIdMaxLength)
                throw new ArgumentException(string.Format("Length cannot be more than {0}.", DataStoreIdMaxLength), nameof(id));
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("The ID cannot be null or empty.", nameof(id));

            return true;
        }

        public bool IsValidElementId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("The ID cannot be null or empty.", nameof(id));
            if (!Guid.TryParse(id, out Guid newGuid))
                throw new ArgumentException("Invalid guid.", nameof(id));

            return true;
        }

        public bool IsValidDataStoreName(string dataStoreName)
        {
            if (dataStoreName.Length > DataStoreNameMaxLength)
                throw new ArgumentException(string.Format("Length cannot be more than {0}.", DataStoreNameMaxLength), nameof(dataStoreName));
            if (string.IsNullOrEmpty(dataStoreName))
                throw new ArgumentException("The name cannot be null or empty.", nameof(dataStoreName));
            if (JsonConvert.DeserializeObject(dataStoreName) == null)
                throw new ArgumentException("Invalid JSON", nameof(dataStoreName));

            return true;
        }

        public bool IsValidJson(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentException("Cannot be empty", nameof(json));
            if (json.Length > 2000 || json.Length < 2)
                throw new ArgumentException("Length cannot be more than 2000 or less than 2.", nameof(json));
            if (JsonConvert.DeserializeObject(json) == null)
                throw new ArgumentException("Invalid JSON", nameof(json));
            return true;
        }
    }
}