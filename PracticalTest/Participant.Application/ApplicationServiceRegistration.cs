using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Participant.Application.Behaviours;
using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Contracts.Services.Tasks;
using Participant.Application.Services.Shared;
using Participant.Application.Services.Tasks;
using System.Reflection;

namespace Participant.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddScoped<ISportEventServices, SportEventServices>();
            services.AddScoped<IAPIServices, APIServices>();
            services.AddScoped<IMapperServices, MapperServices>();
            services.AddScoped(typeof(ILoggerServices<>), typeof(LoggerServices<>));
            services.AddScoped<IGetEventQueryServices, GetEventQueryServices>();
            services.AddScoped<ICreateParticipantCommandServices, CreateParticipantCommandServices>();
            return services;
        }
    }
}
