using AutoMapper;

namespace Backend.TechChallenge.Application.Mappings
{
    public class UserTypeMappingProfile : Profile
    {
        public UserTypeMappingProfile()
        {
            CreateMap<Users.UserType, Domain.Entities.Users.UserType>();                
        }
    }
}
