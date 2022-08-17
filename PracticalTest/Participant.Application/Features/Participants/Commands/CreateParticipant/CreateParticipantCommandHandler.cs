using MediatR;
using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Contracts.Services.Tasks;
using Participant.Application.Models.Tasks;

namespace Participant.Application.Features.Participants.Commands.CreateParticipant
{
    public class CreateParticipantCommandHandler : IRequestHandler<CreateParticipantCommand, bool>
    {
        private readonly IMapperServices _mapperServices;
        private readonly ICreateParticipantCommandServices _createParticipantCommandServices;

        public CreateParticipantCommandHandler(
            IMapperServices mapperServices,
            ICreateParticipantCommandServices createParticipantCommandServices
        )
        {
            _mapperServices = mapperServices;
            _createParticipantCommandServices = createParticipantCommandServices;
        }

        public async Task<bool> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            var requestParams = _mapperServices.MapObjects<CreateParticipantCommand, CreateParticipantCommandRequest>(request);
            var results = await _createParticipantCommandServices.CreateParticipant(requestParams, cancellationToken);
            return results.IsValid;
        }
    }
}
