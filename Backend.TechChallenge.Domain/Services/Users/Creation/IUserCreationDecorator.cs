using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation
{
    public interface IUserCreationDecorator
    {
        void ApplyCreationChanges(User user);
    }
}
