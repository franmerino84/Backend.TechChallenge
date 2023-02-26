using Microsoft.Extensions.DependencyInjection;

namespace Backend.TechChallenge.Api.Ioc
{
    public static class ApiDependenciesRegistrar
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
