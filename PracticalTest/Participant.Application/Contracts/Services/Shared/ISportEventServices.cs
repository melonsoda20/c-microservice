using Participant.Application.Models.Services.Shared;

namespace Participant.Application.Contracts.Services.Shared
{
    public interface ISportEventServices
    {
        Task<GetSportEventResults> GetEvent(GetSportEventsParams eventsParams);
    }
}
