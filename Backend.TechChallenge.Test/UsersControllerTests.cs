using System;
using System.Dynamic;
using System.Linq;
using AutoMapper;
using Backend.TechChallenge.Api.Controllers;
using Backend.TechChallenge.Api.Dtos.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Backend.TechChallenge.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerTests
    {
        private readonly Mock<IMapper> _mapper;

        public UsersControllerTests()
        {
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public void Post_CorrectUser_Success()
        {
            var userController = new UsersController(_mapper.Object);

            var result = userController.Post(new UsersPostRequestDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            }).Result;
            
            Assert.IsAssignableFrom<CreatedResult>(result);
        }

        [Fact]
        public void Post_UserWithDuplicatedAddressAndPhone_IdentifiedAsDuplicate()
        {
            var userController = new UsersController(_mapper.Object);

            var result = userController.Post(new UsersPostRequestDto
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            }).Result;

            Assert.IsAssignableFrom<ConflictObjectResult>(result);

            var conflictObjectResult = (ConflictObjectResult)result;

            var responseDto = (UsersPostResponseDto)conflictObjectResult.Value;

            Assert.Contains("The user is duplicated", responseDto.Errors);
        }
    }
}
