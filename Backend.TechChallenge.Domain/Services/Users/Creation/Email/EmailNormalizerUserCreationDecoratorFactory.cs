using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.Email
{
    public class EmailNormalizerUserCreationDecoratorFactory : IUserCreationDecoratorFactory
    {
        private readonly IEmailNormalizerUserCreationDecorator _decorator;

        public EmailNormalizerUserCreationDecoratorFactory(IEmailNormalizerUserCreationDecorator decorator)
        {
            _decorator = decorator;
        }

        public IUserCreationDecorator CreateUserDecorator(UserType userType) =>
            _decorator;
    }
}
