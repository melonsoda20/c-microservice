using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Participant.Application.Contracts.Repositories;
using Participant.Application.Features.SportEvents.Queries.GetEvent;

namespace Participant.Application.Features.Participants.Commands.CreateParticipant
{
    public class CreateParticipantCommandHandler : IRequestHandler<CreateParticipantCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IParticipantsRepository _participantsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateParticipantCommandHandler> _logger;

        public CreateParticipantCommandHandler(IMediator mediator, IParticipantsRepository participantsRepository, IMapper mapper, ILogger<CreateParticipantCommandHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _participantsRepository = participantsRepository ?? throw new ArgumentNullException(nameof(participantsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            var getEventQuery = new GetEventQuery();
            _logger.LogInformation("Mapping get event params");
            _mapper.Map(request, getEventQuery, typeof(CreateParticipantCommand), typeof(GetEventQuery));
            var eventResponse = await _mediator.Send(getEventQuery);
            if (!eventResponse.IsError)
            {
                _logger.LogError($"Error: {eventResponse.ErrorMessage}");
                return false;
            }
            var participantsEntity = new Domain.Entities.Participants();
            _mapper.Map(request, participantsEntity, typeof(CreateParticipantCommand), typeof(Domain.Entities.Participants));
            _mapper.Map(eventResponse, participantsEntity, typeof(GetEventResult), typeof(Domain.Entities.Participants));
            await _participantsRepository.AddAsync(participantsEntity);

            return true;
        }
    }
}
