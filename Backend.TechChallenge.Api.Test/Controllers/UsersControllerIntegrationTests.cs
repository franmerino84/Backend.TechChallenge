using AutoMapper;
using Backend.TechChallenge.Api.Controllers;
using Backend.TechChallenge.Api.Dtos.Common;
using Backend.TechChallenge.Api.Dtos.Users.Post;
using Backend.TechChallenge.Common.Test;
using Backend.TechChallenge.Domain.Test.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Backend.TechChallenge.Api.Test.Controllers
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerIntegrationTests
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsersControllerIntegrationTests()
        {
            var serviceProvider = ServiceProviderBuilder.Build();
            _mapper = serviceProvider.GetService<IMapper>();
            _mediator = serviceProvider.GetService<IMediator>();
        }

        [Fact]
        public void Post_CorrectUser_Success()
        {
            UsersController userController = new(_mapper, _mediator);
            
            var result = userController.Post(new UsersPostRequestDto
            {
                Name = DataProvider.GetNewGuidStringWithoutHyphen(),
                Email = DataProvider.GetRandomEmail(),
                Address = DataProvider.GetNewGuidStringWithoutHyphen(),
                Phone = DataProvider.GetRandomPhone(),
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
