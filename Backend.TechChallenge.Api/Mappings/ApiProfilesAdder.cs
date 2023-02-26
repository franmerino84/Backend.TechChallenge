using AutoMapper;
using Backend.TechChallenge.Api.Mappings.Users.Post;

namespace Backend.TechChallenge.Api.Mappings
{
    public static class ApiProfilesAdder
    {
        public static void AddApiProfiles(this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddProfile(new UsersPostRequestDtoMappingProfile());
            mapperConfigurationExpression.AddProfile(new UsersPostResponseDtoMappingProfile());
        }
    }
}
