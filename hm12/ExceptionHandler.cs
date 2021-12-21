using System;
using Microsoft.Extensions.Logging;

namespace hm11
{

    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger) =>
            _logger = logger;

        private void Handle(LogLevel logLevel, Exception exception) =>
            _logger.Log(logLevel, exception.Message);

        private void Handle(LogLevel logLevel, NullReferenceException exception) =>
            _logger.Log(logLevel, $"нул референсе");

        private void Handle(LogLevel logLevel, DivideByZeroException exception) =>
            _logger.Log(logLevel, $"деление на 0");

        public void DoHandle(LogLevel logLevel, Exception exception) =>
            Handle(logLevel, (dynamic) exception);
    }
}