using AutoMapper;

namespace Backend.TechChallenge.Persistence.File.Mappings
{
    public static class PersistenceFileProfilesAdder
    {
        public static void AddPersistenceFileProfiles(this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddProfile(new FileUserMappingProfile());
        }
    }
}
