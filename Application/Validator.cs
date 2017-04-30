using Newtonsoft.Json.Linq;
using System;
using EvilCorp.SlackStorage.WebApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebApi.Domain.Entities;

namespace EvilCorp.SlackStorage.WebApi.Business
{
    public class Validator : IValidator
    {
        private const int DataStoreIdMaxLength = 105;
        private const int ObjectIdMaxLength = 24;
        private static readonly int DataStoreNameMaxLength = DataStoreIdMaxLength - new Guid().ToString().Length - 1;

        private const string FieldNullOrEmptyError = "The field cannot be null or empty.";
        private const string InvalidLengthError = "Length cannot be more than {0}. Value: {1}.";

        private const string InvalidGuidError = "Invalid GUID. Value: {0}";
        private const string InvalidObjectIdError = "Invalid Object ID. Value: {0}";

        public LogLevel ValidatorLogLevel { get; } = LogLevel.Warning;

        public bool IsValidUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(userId));
            if (!Guid.TryParse(userId, out Guid _))
                throw new ArgumentException(string.Format(InvalidGuidError, userId), nameof(userId));

            return true;
        }

        public bool IsValidElementId(string elementId)
        {
            if (string.IsNullOrEmpty(elementId))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(elementId));
            if (elementId.Length != ObjectIdMaxLength)
                throw new ArgumentException(string.Format(InvalidObjectIdError, elementId), nameof(elementId));

            return true;
        }

        public bool IsValidDataStoreId(string dataStoreId)
        {
            if (string.IsNullOrEmpty(dataStoreId))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(dataStoreId));
            if (dataStoreId.Length > DataStoreIdMaxLength)
                throw new ArgumentException(string.Format(InvalidLengthError, DataStoreIdMaxLength, dataStoreId), nameof(dataStoreId));

            return true;
        }

        public bool IsValidDataStoreName(JObject dataStoreNameJson)
        {
            if (dataStoreNameJson == null)
                throw new ArgumentException(FieldNullOrEmptyError, nameof(dataStoreNameJson));

            var dataStoreName = (string)dataStoreNameJson["dataStoreName"];

            if (string.IsNullOrEmpty(dataStoreName))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(dataStoreName));
            if (dataStoreName.Length > DataStoreNameMaxLength)
                throw new ArgumentException(string.Format(InvalidLengthError, DataStoreNameMaxLength, dataStoreName), nameof(dataStoreName));

            return true;
        }

        public bool IsValidJson(JObject json)
        {
            if (null == json)
                throw new ArgumentException(FieldNullOrEmptyError, nameof(json));

            return true;
        }
    }
}