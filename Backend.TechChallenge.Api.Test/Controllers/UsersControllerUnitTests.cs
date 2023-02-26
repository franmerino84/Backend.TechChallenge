using AutoMapper;
using Backend.TechChallenge.Api.Controllers;
using Backend.TechChallenge.Api.Dtos.Common;
using Backend.TechChallenge.Api.Dtos.Users.Post;
using Backend.TechChallenge.Application.Users.Command.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Backend.TechChallenge.Api.Test.Controllers
{
    public class UsersControllerUnitTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IMapper> _mapper;
        private readonly UsersController _userController;

        public UsersControllerUnitTests()
        {
            _mediator = new Mock<IMediator>();
            _mapper = new Mock<IMapper>();
            _userController = new UsersController(_mapper.Object, _mediator.Object);
        }

        [Fact]
        public async Task Post_ValidArguments_Success()
        {
            var requestDto = GetValidUsersPostRequestDto();
            var createUserCommand = GetValidCreateUserCommand();
            var createUserCommandResponse = GetValidCreateUserCommandResponse();
            var responseDto = GetValidUsersPostResponseDto();

            _mapper.Setup(x => x.Map<CreateUserCommand>(requestDto)).Returns(createUserCommand);

            _mediator.Setup(x => x.Send(createUserCommand, It.IsAny<CancellationToken>())).Returns(Task.FromResult(createUserCommandResponse));

            _mapper.Setup(x => x.Map<UsersPostResponseDto>(createUserCommandResponse)).Returns(responseDto);

            var result = await _userController.Post(requestDto);

            Assert.IsAssignableFrom<CreatedResult>(result);
            Assert.Equal(responseDto, ((CreatedResult)result).Value);
        }

        [Fact]
        public async Task Post_InvalidName_ErrorsContainingName()
        {
            var requestDto = GetValidUsersPostRequestDto();
            requestDto.Name = null;

            var result = await _userController.Post(requestDto);

            Assert.IsAssignableFrom<UnprocessableEntityObjectResult>(result);

            var unprocessableEntityObjectResult = (UnprocessableEntityObjectResult)result;

            Assert.IsAssignableFrom<ErrorResponseDto>(unprocessableEntityObjectResult.Value);

            var errorResponseDto = (ErrorResponseDto)unprocessableEntityObjectResult.Value;

            Assert.Contains(errorResponseDto.Errors, x => x.Contains("name"));
        }

        [Fact]
        public async Task Post_InvalidUserType_ErrorsContainingUserType()
        {
            var requestDto = GetValidUsersPostRequestDto();
            requestDto.UserType = null;

            var result = await _userController.Post(requestDto);

            Assert.IsAssignableFrom<UnprocessableEntityObjectResult>(result);

            var unprocessableEntityObjectResult = (UnprocessableEntityObjectResult)result;

            Assert.IsAssignableFrom<ErrorResponseDto>(unprocessableEntityObjectResult.Value);

            var errorResponseDto = (ErrorResponseDto)unprocessableEntityObjectResult.Value;

            Assert.Contains(errorResponseDto.Errors, x => x.Contains("user type"));
        }

        [Fact]
        public async Task Post_InvalidUserAddress_ErrorsContainingAddress()
        {
            var requestDto = GetValidUsersPostRequestDto();
            requestDto.Address = null;

            var result = await _userController.Post(requestDto);

            Assert.IsAssignableFrom<UnprocessableEntityObjectResult>(result);

            var unprocessableEntityObjectResult = (UnprocessableEntityObjectResult)result;

            Assert.IsAssignableFrom<ErrorResponseDto>(unprocessableEntityObjectResult.Value);

            var errorResponseDto = (ErrorResponseDto)unprocessableEntityObjectResult.Value;

            Assert.Contains(errorResponseDto.Errors, x => x.Contains("address"));
        }

        [Fact]
        public async Task Post_InvalidUserEmail_ErrorsContainingEmail()
        {
            var requestDto = GetValidUsersPostRequestDto();
            requestDto.Email = null;

            var result = await _userController.Post(requestDto);

            Assert.IsAssignableFrom<UnprocessableEntityObjectResult>(result);

            var unprocessableEntityObjectResult = (UnprocessableEntityObjectResult)result;

            Assert.IsAssignableFrom<ErrorResponseDto>(unprocessableEntityObjectResult.Value);

            var errorResponseDto = (ErrorResponseDto)unprocessableEntityObjectResult.Value;

            Assert.Contains(errorResponseDto.Errors, x => x.Contains("email"));
        }

        [Fact]
        public async Task Post_InvalidUserMoney_ErrorsContainingMoney()
        {
            var requestDto = GetValidUsersPostRequestDto();
            requestDto.Money = null;

            var result = await _userController.Post(requestDto);

            Assert.IsAssignableFrom<UnprocessableEntityObjectResult>(result);

            var unprocessableEntityObjectResult = (UnprocessableEntityObjectResult)result;

            Assert.IsAssignableFrom<ErrorResponseDto>(unprocessableEntityObjectResult.Value);

            var errorResponseDto = (ErrorResponseDto)unprocessableEntityObjectResult.Value;

            Assert.Contains(errorResponseDto.Errors, x => x.Contains("money"));
        }

        [Fact]
        public async Task Post_InvalidUserPhone_ErrorsContainingPhone()
        {
            var requestDto = GetValidUsersPostRequestDto();
            requestDto.Phone = null;

            var result = await _userController.Post(requestDto);

            Assert.IsAssignableFrom<UnprocessableEntityObjectResult>(result);

            var unprocessableEntityObjectResult = (UnprocessableEntityObjectResult)result;

            Assert.IsAssignableFrom<ErrorResponseDto>(unprocessableEntityObjectResult.Value);

            var errorResponseDto = (ErrorResponseDto)unprocessableEntityObjectResult.Value;

            Assert.Contains(errorResponseDto.Errors, x => x.Contains("phone"));
        }

        [Fact]
        public async Task Post_DuplicatedUser_ErrorsContainingDuplicated()
        {
            var requestDto = GetValidUsersPostRequestDto();
            var createUserCommand = GetValidCreateUserCommand();
            var createUserCommandResponse = GetDupllicatedCreateUserCommandResponse();

            _mapper.Setup(x => x.Map<CreateUserCommand>(requestDto)).Returns(createUserCommand);

            _mediator.Setup(x => x.Send(createUserCommand, It.IsAny<CancellationToken>())).Returns(Task.FromResult(createUserCommandResponse));

            var result = await _userController.Post(requestDto);

            Assert.IsAssignableFrom<ConflictObjectResult>(result);

            var conflictObjectResult = (ConflictObjectResult)result;

            Assert.IsAssignableFrom<ErrorResponseDto>(conflictObjectResult.Value);

            var errorResponseDto = (ErrorResponseDto)conflictObjectResult.Value;

            Assert.Contains(errorResponseDto.Errors, x => x.Contains("duplicated"));
        }

        [Fact]
        public async Task Post_UnhandledError_ErrorsContainingUnexpected()
        {
            var requestDto = GetValidUsersPostRequestDto();
            var createUserCommand = GetValidCreateUserCommand();
            var createUserCommandResponse = GetUnhandledErrorCreateUserCommandResponse();

            _mapper.Setup(x => x.Map<CreateUserCommand>(requestDto)).Returns(createUserCommand);

            _mediator.Setup(x => x.Send(createUserCommand, It.IsAny<CancellationToken>())).Returns(Task.FromResult(createUserCommandResponse));

            var result = await _userController.Post(requestDto);

            Assert.IsAssignableFrom<ObjectResult>(result);

            var objectResult = (ObjectResult)result;

            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);

            Assert.IsAssignableFrom<ErrorResponseDto>(objectResult.Value);

            var errorResponseDto = (ErrorResponseDto)objectResult.Value;

            Assert.Contains(errorResponseDto.Errors, x => x.Contains("unexpected"));
        }

        private static CreateUserCommandResponse GetUnhandledErrorCreateUserCommandResponse() =>
          new()
          {
              Status = CreateUserCommandResponseResult.UnhandledError
          };

        private static CreateUserCommandResponse GetDupllicatedCreateUserCommandResponse() =>
           new()
           {               
               Status = CreateUserCommandResponseResult.Duplicated
           };

        private static CreateUserCommandResponse GetValidCreateUserCommandResponse() =>
            new()
            {
                Address = "ValidAdress",
                Email = "valid@email.com",
                Money = 123,
                Name = "ValidName",
                Phone = "123456789",
                UserType = Application.Users.UserType.Normal,
                Status = CreateUserCommandResponseResult.Created
            };

        private static UsersPostResponseDto GetValidUsersPostResponseDto() =>
            new()
            {
                Address = "ValidAdress",
                Email = "valid@email.com",
                Money = "1234",
                Name = "ValidName",
                Phone = "123456789",
                UserType = "Normal"
            };

        private static UsersPostRequestDto GetValidUsersPostRequestDto() =>
            new()
            {
                Address = "ValidAdress",
                Email = "valid@email.com",
                Money = "123",
                Name = "ValidName",
                Phone = "123456789",
                UserType = "Normal"
            };

        private static CreateUserCommand GetValidCreateUserCommand() => 
            new()
            {
                Address = "ValidAdress",
                Email = "valid@email.com",
                Money = 123,
                Name = "ValidName",
                Phone = "123456789",
                UserType = Application.Users.UserType.Normal
            };
    }
}
