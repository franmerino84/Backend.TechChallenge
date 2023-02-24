using AutoMapper;
using Backend.TechChallenge.Api.Domain.Users;
using Backend.TechChallenge.Api.Dtos.Users;
using System;

namespace Backend.TechChallenge.Api.Mappings.Profiles
{
    public class UsersPostRequestDtoMapperProfile : Profile
    {
        public UsersPostRequestDtoMapperProfile()
        {
            CreateMap<UsersPostRequestDto, User>(MemberList.Source)
                .ConstructUsing((userDto,_) =>
                {
                    //TODO think about this switch
                    return userDto.UserType switch
                    {
                        "Normal" => new NormalUser(),
                        "SuperUser" => new SuperUser(),
                        "Premium" => new PremiumUser(),
                        _ => throw new NotImplementedException(),
                    };
                })
                .ForMember(user => user.Money, options => options.MapFrom(dto => decimal.Parse(dto.Money)));

        }
    }
}
