using Backend.TechChallenge.Application.Users.Command.CreateUser;
using Backend.TechChallenge.Domain.Ioc;
using Backend.TechChallenge.Persistence.File.Ioc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Backend.TechChallenge.Api.Ioc
{
    public static class DependenciesRegistrar
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)            
        {
            services.AddApiDependencies();
            services.AddDomainDependencies();
            services.AddPersistenceFileDependencies();
            services.AddMappings();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));
            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog(new NLogProviderOptions
                {
                    CaptureMessageProperties = true,
                    CaptureMessageTemplates = true
                });
            });
            return services;
        }
    }
}
