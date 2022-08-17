﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Participant.Application.Behaviours;
using Participant.Application.Contracts.Services;
using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Services;
using Participant.Application.Services.Shared;
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
            return services;
        }
    }
}
