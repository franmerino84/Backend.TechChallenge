using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public class UserCreationGifterFactory : IUserCreationDecoratorFactory
    {

        public IUserCreationDecorator CreateUserDecorator(UserType userType)
        {
            return userType switch
            {
                UserType.Normal => new NormalUserCreationGifter(),
                UserType.SuperUser => new SuperUserCreationGifter(),
                UserType.Premium => new PremiumUserCreationGifter(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
