using AutoMapper;
using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Persistence.File.Models;

namespace Backend.TechChallenge.Persistence.File.Mappings
{
    public class FileUserMappingProfile : Profile
    {
        public FileUserMappingProfile()
        {
            CreateMap<User, FileUser>()
                .ForMember(fileUser => fileUser.UserType, options=>options.MapFrom(user=> user.GetUserTypeAsString()));
        }
    }
}
