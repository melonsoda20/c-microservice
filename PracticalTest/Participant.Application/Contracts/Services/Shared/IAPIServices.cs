using Participant.Application.Models.Services.Shared;

namespace Participant.Application.Contracts.Services.Shared
{
    public interface IAPIServices
    {
        Task<HttpResponseMessage> GetAPI(GetAPIParams getParams);
    }
}
