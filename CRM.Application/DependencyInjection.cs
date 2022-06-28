using System.Reflection;
using CRM.Application.Common.FluidValidation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Application
{
        public static class DependencyInjection
        {
            public static IServiceCollection AddApplication(
                this IServiceCollection services)
            {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services
                 .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            return services;
            }
        }
}
