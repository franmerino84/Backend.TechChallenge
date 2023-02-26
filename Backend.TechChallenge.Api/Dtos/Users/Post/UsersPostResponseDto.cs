using System.Collections.Generic;

namespace Backend.TechChallenge.Api.Dtos.Users.Post
{
    public class UsersPostResponseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string Money { get; set; }
    }
}
