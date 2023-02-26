using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Domain.Services.Users.Creation.Gifters;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public class UserCreationGifterModifierProvider : IUserCreationModifierProvider
    {
        private readonly NormalUserCreationGifter _normalUserCreationGifter;
        private readonly SuperUserCreationGifter _superUserCreationGifter;
        private readonly PremiumUserCreationGifter _premiumUserCreationGifter;

        public UserCreationGifterModifierProvider(NormalUserCreationGifter normalUserCreationGifter, SuperUserCreationGifter superUserCreationGifter, 
            PremiumUserCreationGifter premiumUserCreationGifter)
        {
            _normalUserCreationGifter = normalUserCreationGifter;
            _superUserCreationGifter = superUserCreationGifter;
            _premiumUserCreationGifter = premiumUserCreationGifter;
        }

        public IUserCreationModifier GetUserModifier(UserType userType)
        {
            return userType switch
            {
                UserType.Normal => _normalUserCreationGifter,
                UserType.SuperUser => _superUserCreationGifter,
                UserType.Premium => _premiumUserCreationGifter,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
