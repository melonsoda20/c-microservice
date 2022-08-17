using MediatR;
using Participant.Application.Contracts.Repositories;
using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Contracts.Services.Tasks;
using Participant.Application.Features.SportEvents.Queries.GetEvent;
using Participant.Application.Models.Tasks;

namespace Participant.Application.Services.Tasks
{
    public class CreateParticipantCommandServices : ICreateParticipantCommandServices
    {
        private readonly IMediator _mediator;
        private readonly IParticipantsRepository _participantsRepository;
        private readonly IMapperServices _mapperServices;
        private readonly ILoggerServices<CreateParticipantCommandServices> _loggerServices;

        public CreateParticipantCommandServices(IMediator mediator, IParticipantsRepository participantsRepository, IMapperServices mapperServices, ILoggerServices<CreateParticipantCommandServices> loggerServices)
        {
            _mediator = mediator;
            _participantsRepository = participantsRepository;
            _mapperServices = mapperServices;
            _loggerServices = loggerServices;
        }

        public async Task<CreateParticipantCommandResponse> CreateParticipant(CreateParticipantCommandRequest request, CancellationToken cancellationToken)
        {
            _loggerServices.LogInformation("Mapping get event params");
            var getEventQuery = _mapperServices.MapObjects<CreateParticipantCommandRequest, GetEventQuery>(request);

            var eventResponse = await _mediator.Send(getEventQuery, cancellationToken);
            if (eventResponse.IsError)
            {
                _loggerServices.LogError($"Error: {eventResponse.ErrorMessage}");
                return new CreateParticipantCommandResponse
                {
                    IsValid = false,
                };
            }
            var participantsEntity = _mapperServices.MapObjects<CreateParticipantCommandRequest, Domain.Entities.Participants>(request);
            participantsEntity = _mapperServices.MapObjects(eventResponse, participantsEntity);
            participantsEntity.CreatedBy = participantsEntity.Name;
            await _participantsRepository.AddAsync(participantsEntity);

            return new CreateParticipantCommandResponse
            {
                IsValid = true
            };
        }
    }
}
