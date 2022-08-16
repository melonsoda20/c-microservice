using Participant.Domain.Services;

namespace Participant.Application.Contracts.Services
{
    public interface ISportEventServices
    {
        Task<GetSportEventResults> GetEvent(GetSportEventsParams eventsParams);
    }
}
