using AutoMapper;
using Backend.TechChallenge.Api.Controllers;
using Backend.TechChallenge.Api.Dtos.Common;
using Backend.TechChallenge.Api.Dtos.Users.Post;
using Backend.TechChallenge.Api.Ioc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Backend.TechChallenge.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]    
    public class UsersControllerIntegrationTests
    {
        private ServiceProvider _serviceProvider;
        private IMapper _mapper;
        private IMediator _mediator;

        public UsersControllerIntegrationTests()
        {
            BuildServiceProvider();
        }

        private void BuildServiceProvider()
        {
            ServiceCollection services = new();
            services.AddDependencies();
            _serviceProvider = services.BuildServiceProvider();
            _mapper = _serviceProvider.GetService<IMapper>();
            _mediator = _serviceProvider.GetService<IMediator>();
        }

        [Fact]
        public void Post_CorrectUser_Success()
        {
            UsersController userController = new(_mapper, _mediator);

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
            UsersController userController = new(_mapper, _mediator);

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

            var responseDto = (ErrorResponseDto)conflictObjectResult.Value;

            Assert.Contains("The user is duplicated", responseDto.Errors);
        }
    }
}
