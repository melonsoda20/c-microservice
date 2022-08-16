using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Participant.Application.Contracts.Services;
using Participant.Domain.Services;

namespace Participant.Application.Features.SportEvents.Queries.GetEvent
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, GetEventResult>
    {
        private readonly ISportEventServices _sportEventServices;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEventQueryHandler> _logger;

        public GetEventQueryHandler(ISportEventServices sportEventServices, IMapper mapper, ILogger<GetEventQueryHandler> logger)
        {
            _sportEventServices = sportEventServices ?? throw new ArgumentNullException(nameof(sportEventServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetEventResult> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            GetSportEventsParams requestParams = new();
            _logger.LogInformation("Mapping request params");
            _mapper.Map(request, requestParams, typeof(GetEventQuery), typeof(GetSportEventsParams));
            _logger.LogInformation("Retrieving event data");
            var eventData = await _sportEventServices.GetEvent(requestParams);
            GetEventResult result = new();
            _logger.LogInformation("Mapping event response data");
            _mapper.Map(eventData, result, typeof(GetSportEventResults), typeof(GetEventResult));
            return result;
        }
    }
}
