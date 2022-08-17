using MediatR;
using Participant.Application.Contracts.Services;
using Participant.Application.Contracts.Services.Shared;
using Participant.Domain.Services;

namespace Participant.Application.Features.SportEvents.Queries.GetEvent
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, GetEventResult>
    {
        private readonly ISportEventServices _sportEventServices;
        private readonly IMapperServices _mapperServices;
        private readonly ILoggerServices<GetEventQueryHandler> _loggerServices;

        public GetEventQueryHandler(ISportEventServices sportEventServices, IMapperServices mapperServices, ILoggerServices<GetEventQueryHandler> loggerServices)
        {
            _sportEventServices = sportEventServices ?? throw new ArgumentNullException(nameof(sportEventServices));
            _mapperServices = mapperServices ?? throw new ArgumentNullException(nameof(mapperServices));
            _loggerServices = loggerServices ?? throw new ArgumentNullException(nameof(loggerServices));
        }

        public async Task<GetEventResult> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            _loggerServices.LogInformation("Mapping request params");
            GetSportEventsParams requestParams = _mapperServices.MapObjects<GetEventQuery, GetSportEventsParams>(request);
            _loggerServices.LogInformation("Retrieving event data");
            var eventData = await _sportEventServices.GetEvent(requestParams);
            _loggerServices.LogInformation("Mapping event response data");
            GetEventResult result = _mapperServices.MapObjects<GetSportEventResults, GetEventResult>(eventData);
            return result;
        }
    }
}
