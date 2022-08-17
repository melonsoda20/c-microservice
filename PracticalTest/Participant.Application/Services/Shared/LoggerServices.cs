using Microsoft.Extensions.Logging;
using Participant.Application.Contracts.Services.Shared;

namespace Participant.Application.Services.Shared
{
    public class LoggerServices<T> : ILoggerServices<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerServices(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogError(string message)
        {
            _logger.LogWarning(message);
        }
    }
}
