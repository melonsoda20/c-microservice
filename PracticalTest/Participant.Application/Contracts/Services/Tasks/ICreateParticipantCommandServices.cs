using Participant.Application.Models.Tasks;

namespace Participant.Application.Contracts.Services.Tasks
{
    public interface ICreateParticipantCommandServices
    {
        Task<CreateParticipantCommandResponse> CreateParticipant(CreateParticipantCommandRequest request, CancellationToken cancellationToken);
    }
}
