using Newtonsoft.Json.Linq;
using System;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Business
{
    public class Logger : ILogger
    {
        private readonly ILogRepository _logRepository;
        private readonly string _componentName = "WebAPI";

        public Logger(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Log(string message, LogLevel logLevel)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("The message cannot be null or empty.", nameof(message));

            var logEntry = CreateContent(message, logLevel);

            _logRepository.Log(logEntry);

            Console.WriteLine(message);
        }

        private JObject CreateContent(string message, LogLevel level)
        {
            var json = new JObject
            {
                ["component"] = _componentName,
                ["message"] = message,
                ["level"] = (int)level
            };

            return json;
        }
    }
}