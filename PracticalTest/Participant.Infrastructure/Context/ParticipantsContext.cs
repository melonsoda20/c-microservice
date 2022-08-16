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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
