using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Contracts.Services.Tasks;
using Participant.Application.Models.Tasks;
using Participant.Domain.Services;

namespace Participant.Application.Services.Tasks
{
    public class GetEventQueryServices : IGetEventQueryServices
    {
        private readonly ISportEventServices _sportEventServices;
        private readonly IMapperServices _mapperServices;

        public GetEventQueryServices(ISportEventServices sportEventServices, IMapperServices mapperServices)
        {
            _sportEventServices = sportEventServices;
            _mapperServices = mapperServices;
        }

        public async Task<GetEventQueryResponse> GetEvent(GetEventQueryParams request, CancellationToken cancellationToken)
        {
            GetSportEventsParams requestParams = _mapperServices.MapObjects<GetEventQueryParams, GetSportEventsParams>(request);
            var eventData = await _sportEventServices.GetEvent(requestParams);
            GetEventQueryResponse result = _mapperServices.MapObjects<GetSportEventResults, GetEventQueryResponse>(eventData);
            return result;
        }
    }
}
