using Backend.TechChallenge.Api.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.TechChallenge.Common.Test
{
    public static class ServiceProviderBuilder
    {
        public static IServiceProvider Build()
        {
            ServiceCollection services = new();
            services.AddDependencies();
            return services.BuildServiceProvider();
        }
    }
}
