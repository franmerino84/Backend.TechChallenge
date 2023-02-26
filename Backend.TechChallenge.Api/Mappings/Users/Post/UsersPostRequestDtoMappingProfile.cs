using AutoMapper;
using Backend.TechChallenge.Api.Dtos.Users.Post;
using Backend.TechChallenge.Application.Users.Command.CreateUser;

namespace Backend.TechChallenge.Api.Mappings.Users.Post
{
    public class UsersPostRequestDtoMappingProfile : Profile
    {
        public UsersPostRequestDtoMappingProfile()
        {
            CreateMap<UsersPostRequestDto, CreateUserCommand>()
                .ForMember(user => user.Money, options => options.MapFrom(dto => decimal.Parse(dto.Money)));
        }
    }
}
