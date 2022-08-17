using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CreateParticipantCommandHandler> _logger;

        public CreateParticipantCommandHandler(
            IMediator mediator,
            IParticipantsRepository participantsRepository,
            IMapperServices mapperServices, 
            ILogger<CreateParticipantCommandHandler> logger
           )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _participantsRepository = participantsRepository ?? throw new ArgumentNullException(nameof(participantsRepository));
            _mapperServices = mapperServices ?? throw new ArgumentNullException(nameof(mapperServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Mapping get event params");
            var getEventQuery = _mapperServices.MapObjects<CreateParticipantCommand, GetEventQuery>(request);

            var eventResponse = await _mediator.Send(getEventQuery);
            if (eventResponse.IsError)
            {
                _logger.LogError($"Error: {eventResponse.ErrorMessage}");
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
