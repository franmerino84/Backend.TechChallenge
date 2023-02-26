using AutoMapper;
using Backend.TechChallenge.Api.Dtos.Users.Post;
using Backend.TechChallenge.Application.Users.Command.CreateUser;
using Backend.TechChallenge.Common.Test;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Backend.TechChallenge.Api.Test.Mappings.Users.Post
{
    public class UserPostRequestDtoMappingProfileIntegrationTests
    {
        
        [Fact]
        public void UserPostRequestDtoNormal_Map_ExpectedCreateUserCommand()
        {
            UsersPostRequestDto dto = GetValidUserPostRequestDto();
            CreateUserCommand expected = GetValidCreateUserCommand();

            var mapper = ServiceProviderBuilder.Build().GetService<IMapper>();

            var result = mapper.Map<CreateUserCommand>(dto);

            var serializedExpected = JsonConvert.SerializeObject(expected);
            var serializedResult = JsonConvert.SerializeObject(result);

            Assert.Equal(serializedExpected, serializedResult);
        }

        [Fact]
        public void UserPostRequestDtoSuperUser_Map_ExpectedCreateUserCommand()
        {
            UsersPostRequestDto dto = GetValidUserPostRequestDto();
            dto.UserType = "SuperUser";
            CreateUserCommand expected = GetValidCreateUserCommand();
            expected.UserType = Application.Users.UserType.SuperUser;

            var mapper = ServiceProviderBuilder.Build().GetService<IMapper>();

            var result = mapper.Map<CreateUserCommand>(dto);

            var serializedExpected = JsonConvert.SerializeObject(expected);
            var serializedResult = JsonConvert.SerializeObject(result);

            Assert.Equal(serializedExpected, serializedResult);
        }

        [Fact]
        public void UserPostRequestDtoPremiumUser_Map_ExpectedCreateUserCommand()
        {
            UsersPostRequestDto dto = GetValidUserPostRequestDto();
            dto.UserType = "Premium";
            CreateUserCommand expected = GetValidCreateUserCommand();
            expected.UserType = Application.Users.UserType.Premium;

            var mapper = ServiceProviderBuilder.Build().GetService<IMapper>();

            var result = mapper.Map<CreateUserCommand>(dto);

            var serializedExpected = JsonConvert.SerializeObject(expected);
            var serializedResult = JsonConvert.SerializeObject(result);

            Assert.Equal(serializedExpected, serializedResult);
        }

        private static CreateUserCommand GetValidCreateUserCommand()
        {
            return new CreateUserCommand
            {
                Address = "address",
                Email = "email",
                Money = 123,
                Name = "name",
                Phone = "456",
                UserType = Application.Users.UserType.Normal
            };
        }

        private static UsersPostRequestDto GetValidUserPostRequestDto()
        {
            return new UsersPostRequestDto
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
