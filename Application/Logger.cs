using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business
{
    public class Logger : ILogger
    {
        private readonly ILogRepository _logRepository;

        public Logger(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Log(string message, LogLevel logLevel)
        {
            var logEntry = new LogEntry("WebAPI", message, logLevel);
            //TODO: If response is not valid, then what?
            _logRepository.Log(logEntry);
            Console.WriteLine(message);
        }
    }
}