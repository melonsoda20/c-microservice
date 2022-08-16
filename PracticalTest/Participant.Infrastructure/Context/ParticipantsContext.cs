using Microsoft.EntityFrameworkCore;
using Participant.Domain.Entities;
using Participant.Domain.Entities.Common;

namespace Participant.Infrastructure.Context
{
    public class ParticipantsContext : DbContext
    {
        public ParticipantsContext(DbContextOptions<ParticipantsContext> options) : base(options)
        {
        }
        public DbSet<Participants> Participants { get; set; }

        public Task<int> SaveChangesAsync(string name, CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = name;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = name;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
