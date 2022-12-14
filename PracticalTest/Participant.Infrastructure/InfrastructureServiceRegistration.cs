using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Participant.Application.Contracts.Repositories;
using Participant.Infrastructure.Context;
using Participant.Infrastructure.Repositories;

namespace Participant.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ParticipantsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ParticipantsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IParticipantsRepository, ParticipantsRepository>();

            return services;
        }
    }
}