using AutoMapper;

namespace Backend.TechChallenge.Application.Mappings
{
    public static class ApplicationProfilesAdder
    {
        public static void AddApplicationProfiles(this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddProfile(new UserTypeMappingProfile());
            mapperConfigurationExpression.AddProfile(new CreateUserCommandResponseMappingProfile());
        }
    }
}
