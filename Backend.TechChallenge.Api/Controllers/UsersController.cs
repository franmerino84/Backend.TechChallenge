using AutoMapper;
using Backend.TechChallenge.Api.Domain.Users;
using Backend.TechChallenge.Api.Dtos.Users;
using Backend.TechChallenge.Api.Exceptions;
using Backend.TechChallenge.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.TechChallenge.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IMapper _mapper;

        public UsersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsersPostRequestDto userDto)
        {
            var errors = ValidateErrors(userDto);

            if (errors.Any())
                return UnprocessableEntity(new UsersPostResponseDto()
                {
                    Errors = errors
                });

            var newUser = _mapper.Map<User>(userDto);

            try
            {
                //TODO UserService has to be injected by IOC
                new UsersService().Create(newUser);

                //TODO userDTO for the response has to be updated with the id
            }
            catch (UserDuplicatedException)
            {
                var message = "The user is duplicated";

                Debug.WriteLine(message);

                return Conflict(new UsersPostResponseDto()
                {
                    Errors = new string[] { message }
                });
            }

            return Created(string.Empty, userDto);
        }


        private IEnumerable<string> ValidateErrors(UsersPostRequestDto userDto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(userDto.Name))
                errors.Add("The name is required");

            if (string.IsNullOrWhiteSpace(userDto.Email))
                errors.Add("The email is required");

            if (string.IsNullOrWhiteSpace(userDto.Address))
                errors.Add("The address is required");

            if (string.IsNullOrWhiteSpace(userDto.Phone))
                errors.Add("The phone is required");

            return errors;
        }


    }
}
