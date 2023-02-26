using MediatR;

namespace Backend.TechChallenge.Application.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public UserType UserType { get; set; }
        public decimal Money { get; set; }
    }
}
