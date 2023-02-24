using AutoMapper;
using Backend.TechChallenge.Api.Mappings.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.TechChallenge.Api.Middleware
{
    public static class MapperManager
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            IMapper mapper = CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

        private static IMapper CreateMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UsersPostRequestDtoMapperProfile());
                
            });

            return mappingConfig.CreateMapper();
        }



    }
}