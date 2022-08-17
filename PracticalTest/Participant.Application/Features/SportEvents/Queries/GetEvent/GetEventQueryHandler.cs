using MediatR;
using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Contracts.Services.Tasks;
using Participant.Application.Models.Tasks;

namespace Participant.Application.Features.SportEvents.Queries.GetEvent
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, GetEventResult>
    {
        private readonly IGetEventQueryServices _getEventQueryServices;
        private readonly IMapperServices _mapperServices;
        private readonly ILoggerServices<GetEventQueryHandler> _loggerServices;

        public GetEventQueryHandler(IGetEventQueryServices getEventQueryServices, IMapperServices mapperServices, ILoggerServices<GetEventQueryHandler> loggerServices)
        {
            _getEventQueryServices = getEventQueryServices ?? throw new ArgumentNullException(nameof(getEventQueryServices));
            _mapperServices = mapperServices ?? throw new ArgumentNullException(nameof(mapperServices));
            _loggerServices = loggerServices ?? throw new ArgumentNullException(nameof(loggerServices));
        }

        public async Task<GetEventResult> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            _loggerServices.LogInformation("Mapping request params");
            GetEventQueryParams requestParams = _mapperServices.MapObjects<GetEventQuery, GetEventQueryParams>(request);
            _loggerServices.LogInformation("Retrieving event data");
            var eventData = await _getEventQueryServices.GetEvent(requestParams, cancellationToken);
            _loggerServices.LogInformation("Mapping event response data");
            GetEventResult result = _mapperServices.MapObjects<GetEventQueryResponse, GetEventResult>(eventData);
            return result;
        }
    }
}
