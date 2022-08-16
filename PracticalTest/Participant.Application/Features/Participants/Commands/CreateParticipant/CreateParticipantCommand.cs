using MediatR;

namespace Participant.Application.Features.Participants.Commands.CreateParticipant
{
    public class CreateParticipantCommand : IRequest<bool>
    {
        public string? Name { get; set; }
        public string? NIK { get; set; }
        public string? Address { get; set; }
        public int EventID { get; set; }
    }
}
