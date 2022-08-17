namespace Participant.Application.Contracts.Services.Shared
{
    public interface ILoggerServices<T>
    {
        void LogInformation(string message);
        void LogError(string message);
    }
}
