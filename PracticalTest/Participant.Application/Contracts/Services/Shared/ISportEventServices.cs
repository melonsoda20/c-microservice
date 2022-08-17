using Participant.Domain.Services;

namespace Participant.Application.Contracts.Services.Shared
{
    public interface ISportEventServices
    {
        Task<GetSportEventResults> GetEvent(GetSportEventsParams eventsParams);
    }
}
