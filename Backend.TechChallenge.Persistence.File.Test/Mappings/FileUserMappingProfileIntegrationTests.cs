using AutoMapper;
using Backend.TechChallenge.Common.Test;
using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Persistence.File.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Backend.TechChallenge.Persistence.File.Test.Mappings
{
    public class FileUserMappingProfileIntegrationTests
    {
        [Fact]
        public void User_Map_FileUser()
        {
            User response = GetValidCreateUser();
            FileUser expected = GetValidFileUser();

            var mapper = ServiceProviderBuilder.Build().GetService<IMapper>();

            var result = mapper?.Map<FileUser>(response);

            var serializedExpected = JsonConvert.SerializeObject(expected);
            var serializedResult = JsonConvert.SerializeObject(result);

            Assert.Equal(serializedExpected, serializedResult);
        }

        private static User GetValidCreateUser() =>
            new NormalUser("name", "email", "address", "456", 123);


        private static FileUser GetValidFileUser()
        {
            return new FileUser
            {
                Address = "address",
                Email = "email",
                Money = 123,
                Name = "name",
                Phone = "456",
                UserType = "Normal"
            };
        }
    }
}
