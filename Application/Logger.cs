using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business
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
            //TODO: If response is not valid, then what?
            _logRepository.Log(logEntry);
            Console.WriteLine(message);
        }

        private JObject CreateContent(string message, LogLevel level)
        {
            var json = new JObject
            {
                ["componet"] = _componentName,
                ["message"] = message,
                ["level"] = (int)level
            };

            //var content = new StringContent(json.ToString());
            //content.Headers.Clear();
            //content.Headers.Add("content-type", "application/json");

            return json;
        }
    }
}