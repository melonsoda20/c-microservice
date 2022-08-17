using MediatR;
using Participant.Application.Contracts.Repositories;
using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Features.SportEvents.Queries.GetEvent;

namespace Participant.Application.Features.Participants.Commands.CreateParticipant
{
    public class CreateParticipantCommandHandler : IRequestHandler<CreateParticipantCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IParticipantsRepository _participantsRepository;
        private readonly IMapperServices _mapperServices;
        private readonly ILoggerServices<CreateParticipantCommandHandler> _loggerServices;

        public CreateParticipantCommandHandler(
            IMediator mediator,
            IParticipantsRepository participantsRepository,
            IMapperServices mapperServices,
            ILoggerServices<CreateParticipantCommandHandler> loggerServices
           )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _participantsRepository = participantsRepository ?? throw new ArgumentNullException(nameof(participantsRepository));
            _mapperServices = mapperServices ?? throw new ArgumentNullException(nameof(mapperServices));
            _loggerServices = loggerServices ?? throw new ArgumentNullException(nameof(loggerServices));
        }

        public async Task<bool> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            _loggerServices.LogInformation("Mapping get event params");
            var getEventQuery = _mapperServices.MapObjects<CreateParticipantCommand, GetEventQuery>(request);

            var eventResponse = await _mediator.Send(getEventQuery, cancellationToken);
            if (eventResponse.IsError)
            {
                _loggerServices.LogError($"Error: {eventResponse.ErrorMessage}");
                return false;
            }
            var participantsEntity = _mapperServices.MapObjects<CreateParticipantCommand, Domain.Entities.Participants>(request);
            participantsEntity = _mapperServices.MapObjects(eventResponse, participantsEntity);
            participantsEntity.CreatedBy = participantsEntity.Name;
            await _participantsRepository.AddAsync(participantsEntity);

            return true;
        }
    }
}
