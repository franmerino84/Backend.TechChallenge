using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation
{
    public interface ICreationUserDecorator
    {
        void ApplyCreationChanges(User user);
    }
}
