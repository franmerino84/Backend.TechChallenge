using AutoMapper;
using Backend.TechChallenge.Api.Dtos.Users.Post;
using Backend.TechChallenge.Application.Users.Command.CreateUser;

namespace Backend.TechChallenge.Api.Mappings.Users.Post
{
    public class UsersPostResponseDtoMappingProfile : Profile
    {
        public UsersPostResponseDtoMappingProfile()
        {
            CreateMap<CreateUserCommandResponse, UsersPostResponseDto>()
                .ForMember(dto => dto.Money, options => options.MapFrom(response => response.Money.ToString()));
        }
    }
}
