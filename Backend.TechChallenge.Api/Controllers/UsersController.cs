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
                new UsersService().Create(newUser);
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


        //Validate errors
        private IEnumerable<string> ValidateErrors(UsersPostRequestDto userDto)
        {
            var errors = new List<string>();

            if (userDto.Name == null)
                errors.Add("The name is required");

            if (userDto.Email == null)
                errors.Add("The email is required");

            if (userDto.Address == null)
                errors.Add("The address is required");

            if (userDto.Phone == null)
                errors.Add("The phone is required");

            return errors;
        }


    }
}
