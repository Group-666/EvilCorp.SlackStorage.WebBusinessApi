using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using Newtonsoft.Json;
using System;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business
{
    public class Validator : IValidator
    {
        private readonly IExceptionHandler _exceptionHandler;

        private LogLevel validatorLogLevel = LogLevel.Warning;

        public LogLevel ValidatorLogLevel { get => validatorLogLevel; }

        public Validator(IExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public bool IsValidUserId(string id)
        {
            if (id.Length > 12)
                throw new ArgumentException("Length cannot be more than 12.", nameof(id));
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("The ID cannot be null or empty.", nameof(id));

            return true;
        }

        public bool IsValidJson(string json)
        {
            if (string.IsNullOrEmpty(json))
                return false;
            if (json.Length > 2000 || json.Length < 2)
                return false;
            var result = _exceptionHandler.Run(() => JsonConvert.DeserializeObject(json));
            return result != null;
        }
    }
}