using AutoMapper;
using Backend.TechChallenge.Api.Dtos.Users.Post;
using Backend.TechChallenge.Application.Users.Command.CreateUser;
using Backend.TechChallenge.Common.Test;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Backend.TechChallenge.Application.Test.Mappings
{
    public class UserTypeMappingProfileIntegrationTests
    {
        [Theory]
        [InlineData(Application.Users.UserType.Normal, Domain.Entities.Users.UserType.Normal)]
        [InlineData(Application.Users.UserType.SuperUser, Domain.Entities.Users.UserType.SuperUser)]
        [InlineData(Application.Users.UserType.Premium, Domain.Entities.Users.UserType.Premium)]
        public void ApplicationUserType_Map_ExpectedDomainUserType(Application.Users.UserType input, Domain.Entities.Users.UserType expected)
        {
            var mapper = ServiceProviderBuilder.Build().GetService<IMapper>();

            var result = mapper?.Map<Domain.Entities.Users.UserType>(input);

            Assert.Equal(expected, result);
        }
    }
}
