using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business
{
    public class Validator : IValidator
    {
        private const int DataStoreIdMaxLength = 105;
        private const int UserIdMaxLength = 12;
        private const int JsonMaxLength = 2000;
        private const int ObjectIdMaxLength = 24;
        private static readonly int DataStoreNameMaxLength = DataStoreIdMaxLength - UserIdMaxLength - 1;

        private const string FieldNullOrEmptyError = "The field cannot be null or empty.";
        private const string InvalidGuidError = "Invalid GUID.";
        private const string InvalidJsonError = "Invalid JSON.";
        private const string InvalidLengthError = "Length cannot be more than {0}.";

        public LogLevel ValidatorLogLevel { get; } = LogLevel.Warning;

        public bool IsValidUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(userId));
            if (!Guid.TryParse(userId, out Guid _))
                throw new ArgumentException(InvalidGuidError, nameof(userId));

            return true;
        }

        public bool IsValidElementId(string elementId)
        {
            if (string.IsNullOrEmpty(elementId))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(elementId));
            if (elementId.Length != ObjectIdMaxLength)
                throw new ArgumentException(string.Format(InvalidLengthError, ObjectIdMaxLength), nameof(elementId));

            return true;
        }

        public bool IsValidDataStoreId(string dataStoreId)
        {
            if (string.IsNullOrEmpty(dataStoreId))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(dataStoreId));
            if (dataStoreId.Length > DataStoreIdMaxLength)
                throw new ArgumentException(string.Format(InvalidLengthError, DataStoreIdMaxLength), nameof(dataStoreId));

            return true;
        }

        public bool IsValidDataStoreName(JObject dataStoreName)
        {
            //if (string.IsNullOrEmpty(dataStoreName))
            //    throw new ArgumentException(FieldNullOrEmptyError, nameof(dataStoreName));

            //var json = JObject.Parse(dataStoreName);
            //dataStoreName = dataStoreName.ToLower();
            if (dataStoreName == null)
                throw new ArgumentException(InvalidJsonError, nameof(dataStoreName));
            var dataStoreNameValue = (string)dataStoreName["dataStoreName"];

            if (string.IsNullOrEmpty(dataStoreNameValue))
                throw new ArgumentException(FieldNullOrEmptyError, nameof(dataStoreNameValue));
            if (dataStoreNameValue.Length > DataStoreNameMaxLength)
                throw new ArgumentException(string.Format(InvalidLengthError, DataStoreNameMaxLength), nameof(dataStoreNameValue));

            return true;
        }

        public bool IsValidJson(JObject jsonData)
        {
            if (null == jsonData)
                throw new ArgumentException(InvalidJsonError, nameof(jsonData));
            if (jsonData.Count > 2000)
                throw new ArgumentException(string.Format(InvalidLengthError, JsonMaxLength), nameof(jsonData));

            return true;
        }
    }
}