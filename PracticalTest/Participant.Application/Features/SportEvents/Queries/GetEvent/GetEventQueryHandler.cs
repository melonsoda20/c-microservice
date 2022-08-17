using MediatR;
using Microsoft.Extensions.Logging;
using Participant.Application.Contracts.Services;
using Participant.Application.Contracts.Services.Shared;
using Participant.Domain.Services;

namespace Participant.Application.Features.SportEvents.Queries.GetEvent
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, GetEventResult>
    {
        private readonly ISportEventServices _sportEventServices;
        private readonly IMapperServices _mapperServices;
        private readonly ILogger<GetEventQueryHandler> _logger;

        public GetEventQueryHandler(ISportEventServices sportEventServices, IMapperServices mapperServices, ILogger<GetEventQueryHandler> logger)
        {
            _sportEventServices = sportEventServices ?? throw new ArgumentNullException(nameof(sportEventServices));
            _mapperServices = mapperServices ?? throw new ArgumentNullException(nameof(mapperServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetEventResult> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Mapping request params");
            GetSportEventsParams requestParams = _mapperServices.MapObjects<GetEventQuery, GetSportEventsParams>(request);
            _logger.LogInformation("Retrieving event data");
            var eventData = await _sportEventServices.GetEvent(requestParams);
            _logger.LogInformation("Mapping event response data");
            GetEventResult result = _mapperServices.MapObjects<GetSportEventResults, GetEventResult>(eventData);
            return result;
        }
    }
}
