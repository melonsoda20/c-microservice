using Participant.Application.Models.Tasks;

namespace Participant.Application.Contracts.Services.Tasks
{
    public interface IGetEventQueryServices
    {
        Task<GetEventQueryResponse> GetEvent(GetEventQueryParams request);
    }
}
