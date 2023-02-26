using Backend.TechChallenge.Domain.Contracts;
using Backend.TechChallenge.Persistence.File.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.TechChallenge.Persistence.File.Ioc
{
    public static class PersistenceFileDependenciesRegistrar
    {
        public static IServiceCollection AddPersistenceFileDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            return services;
        }
    }
}
