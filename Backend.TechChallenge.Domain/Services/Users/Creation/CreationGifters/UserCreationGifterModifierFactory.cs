using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public class UserCreationGifterModifierFactory : IUserCreationModifierFactory
    {

        public IUserCreationModifier CreateUserModifier(UserType userType)
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
