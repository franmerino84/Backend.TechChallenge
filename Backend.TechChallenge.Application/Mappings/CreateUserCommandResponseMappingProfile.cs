using AutoMapper;
using Backend.TechChallenge.Application.Users.Command.CreateUser;
using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Application.Mappings
{
    public class CreateUserCommandResponseMappingProfile : Profile
    {
        public CreateUserCommandResponseMappingProfile()
        {
            CreateMap<User, CreateUserCommandResponse>()
                .ForMember(response=>response.UserType, options => options.MapFrom(user=> user.GetUserType()))
                ;
        }
    }
}
