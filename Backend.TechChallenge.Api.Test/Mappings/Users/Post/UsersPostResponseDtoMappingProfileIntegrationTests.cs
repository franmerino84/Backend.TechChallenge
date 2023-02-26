using AutoMapper;
using Backend.TechChallenge.Api.Dtos.Users.Post;
using Backend.TechChallenge.Application.Users.Command.CreateUser;
using Backend.TechChallenge.Common.Test;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Backend.TechChallenge.Api.Test.Mappings.Users.Post
{
    public class UsersPostResponseDtoMappingProfileIntegrationTests
    {
        [Fact]
        public void CreateUserCommandResponse_Map_ExpectedUserPostResponseDto()
        {
            CreateUserCommandResponse response = GetValidCreateUserCommandResponse();
            UsersPostResponseDto expected = GetValidUserPostResponseDto();

            var mapper = ServiceProviderBuilder.Build().GetService<IMapper>();

            var result = mapper.Map<UsersPostResponseDto>(response);

            var serializedExpected = JsonConvert.SerializeObject(expected);
            var serializedResult = JsonConvert.SerializeObject(result);

            Assert.Equal(serializedExpected, serializedResult);
        }

        private static CreateUserCommandResponse GetValidCreateUserCommandResponse()
        {
            return new CreateUserCommandResponse
            {
                Address = "address",
                Email = "email",
                Money = 123,
                Name = "name",
                Phone = "456",
                UserType = Application.Users.UserType.Normal
            };
        }

        private static UsersPostResponseDto GetValidUserPostResponseDto()
        {
            return new UsersPostResponseDto
            {
                Address = "address",
                Email = "email",
                Money = "123",
                Name = "name",
                Phone = "456",
                UserType = "Normal"
            };
        }
    }
}
