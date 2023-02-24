using System.Collections.Generic;
using System.Linq;

namespace Backend.TechChallenge.Api.Dtos.Users
{
    public class UsersPostResponseDto
    {
        public bool IsSuccess { get { return !Errors.Any(); } }

        public IEnumerable<string> Errors { get; set; }
    }
}
