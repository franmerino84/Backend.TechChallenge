using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation
{
    public interface IUserCreationDecoratorFactory
    {
        IUserCreationDecorator CreateUserDecorator(UserType userType);
    }
}