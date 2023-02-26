using AutoMapper;
using Backend.TechChallenge.Api.Dtos.Common;
using Backend.TechChallenge.Api.Dtos.Users.Post;
using Backend.TechChallenge.Application.Users;
using Backend.TechChallenge.Application.Users.Command.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Backend.TechChallenge.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsersPostResponseDto),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(UsersPostRequestDto userDto)
        {
            var errors = ValidateErrors(userDto);

            if (errors.Any())
                return UnprocessableEntity(new ErrorResponseDto(errors));
            
            var command = _mapper.Map<CreateUserCommand>(userDto);

            var response = await _mediator.Send(command);

            switch (response.Status)
            {
                case CreateUserCommandResponseResult.Created:
                    {
                        var responseDto = _mapper.Map<UsersPostResponseDto>(response);
                        return Created(string.Empty, responseDto);
                    }
                case CreateUserCommandResponseResult.Duplicated:
                    {
                        var message = "The user is duplicated";

                        Debug.WriteLine(message);

                        return Conflict(new ErrorResponseDto(new string[] { message }));
                    }
                case CreateUserCommandResponseResult.UnhandledError:
                default:
                    {
                        var message = "An unexpected error occurred";

                        Debug.WriteLine(message);

                        ObjectResult errorObjectResult = new(message)
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Value = new ErrorResponseDto(new string[] { message })
                        };
                        return errorObjectResult;
                    }
            }
        }


        private static IEnumerable<string> ValidateErrors(UsersPostRequestDto userDto)
        {
            List<string> errors = new();

            if (string.IsNullOrWhiteSpace(userDto.Name))
                errors.Add("The name is required");

            if (string.IsNullOrWhiteSpace(userDto.Email))
                errors.Add("The email is required");

            if (string.IsNullOrWhiteSpace(userDto.Address))
                errors.Add("The address is required");

            if (string.IsNullOrWhiteSpace(userDto.Phone))
                errors.Add("The phone is required");

            if (!Enum.TryParse(typeof(UserType), userDto.UserType, out _))
                errors.Add("The user type has to be one of these values: 'Normal', 'SuperUser', 'Premium'");

            if (!decimal.TryParse(userDto.Money, out _))
                errors.Add("The money must be a number.");


            return errors;
        }


    }
}
