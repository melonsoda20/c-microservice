using Microsoft.EntityFrameworkCore;
using Participant.Application.Contracts.Repositories;
using Participant.Domain.Entities;
using Participant.Infrastructure.Context;
using static Participant.Application.Constants.Constants;

namespace Participant.Infrastructure.Repositories
{
    public class ParticipantsRepository : BaseRepository<Participants>, IParticipantsRepository
    {
        public ParticipantsRepository(ParticipantsContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Participants>> GetEventsByUserNameAndNIK(string name, string NIK, ENUM_ORDER order)
        {
            return order switch
            {
                ENUM_ORDER.ASC => await _dbContext.Participants
                                                .Where(p => p.Name == name && p.NIK == NIK)
                                                .OrderBy(n => n.Name)
                                                .OrderBy(n => n.NIK)
                                                .ToListAsync(),
                ENUM_ORDER.DESC => await _dbContext.Participants
                                                .Where(p => p.Name == name && p.NIK == NIK)
                                                .OrderByDescending(n => n.Name)
                                                .OrderByDescending(n => n.NIK)
                                                .ToListAsync(),
                _ => await _dbContext.Participants
                                                .Where(p => p.Name == name && p.NIK == NIK)
                                                .ToListAsync(),
            };
        }
    }
}
