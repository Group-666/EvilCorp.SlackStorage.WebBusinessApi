﻿using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Business
{
    public class Validator : IValidator
    {
        private const int DataStoreIdMaxLength = 105;
        private static readonly int DataStoreNameMaxLength = DataStoreIdMaxLength - new Guid().ToString().Length - 1;
        private static readonly int DataStoreIdMinLength = new Guid().ToString().Length + 2;

        private const string FieldNullOrEmptyError = "The field cannot be null or empty.";
        private const string InvalidLengthError = "Length cannot be more than {0}. Value: {1}.";

        private const string InvalidGuidError = "Invalid GUID. Value: {0}";
        private const string InvalidObjectIdError = "Invalid Object ID. Value: {0}";
        private const string InvalidDataStoreIdError = "Invalid ID. Value: {0}";

        public LogLevel ValidatorLogLevel { get; } = LogLevel.Warning;

        public bool IsValidGuid(string userId)
        {
            if (!Guid.TryParse(userId, out _))
                throw new ArgumentException(string.Format(InvalidGuidError, userId), nameof(userId));

            return true;
        }

        public bool IsValidElementId(string elementId)
        {
            if (string.IsNullOrEmpty(elementId) || !Regex.IsMatch(elementId, "^[0-9a-fA-F]{24}$"))
                throw new ArgumentException(string.Format(InvalidObjectIdError, elementId), nameof(elementId));

            return true;
        }

        public bool IsValidDataStoreId(string dataStoreId)
        {
            if (string.IsNullOrEmpty(dataStoreId) || dataStoreId.Length < DataStoreIdMinLength || dataStoreId.Length > DataStoreIdMaxLength)
                throw new ArgumentException(string.Format(InvalidDataStoreIdError, dataStoreId), nameof(dataStoreId));

            return true;
        }

        public bool IsValidHash(string passwordHash)
        {
            throw new NotImplementedException();
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