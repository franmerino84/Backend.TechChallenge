using AutoMapper;
using Backend.TechChallenge.Api.Mappings;
using Backend.TechChallenge.Application.Mappings;
using Backend.TechChallenge.Persistence.File.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.TechChallenge.Api.Ioc
{
    public static class MapperRegistrar
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            IMapper mapper = CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

        private static IMapper CreateMapper()
        {
            MapperConfiguration mappingConfig = new(mc =>
            {
                mc.AddApiProfiles();
                mc.AddApplicationProfiles();
                mc.AddPersistenceFileProfiles();
            });


            return mappingConfig.CreateMapper();
        }



    }
}