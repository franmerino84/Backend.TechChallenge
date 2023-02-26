using Backend.TechChallenge.Domain.Services.Users.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.TechChallenge.Domain.Ioc
{
    public static class DomainDependenciesRegistrar
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IUsersFactory, UsersFactory>();

            return services;
        }
    }
}
