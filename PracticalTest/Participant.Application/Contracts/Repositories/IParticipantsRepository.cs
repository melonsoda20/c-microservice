using Participant.Domain.Entities;
using static Participant.Application.Constants.Constants;

namespace Participant.Application.Contracts.Repositories
{
    public interface IParticipantsRepository : IAsyncRepository<Participants>
    {
        Task<IEnumerable<Participants>> GetEventsByUserNameAndNIK(string name, string NIK, ENUM_ORDER order);
    }
}
