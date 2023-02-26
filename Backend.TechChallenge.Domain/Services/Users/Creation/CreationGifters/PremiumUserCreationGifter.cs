using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public class PremiumUserCreationGifter : IUserCreationGifter, IUserCreationDecorator
    {
        public void ApplyCreationChanges(User user) =>
            ApplyGift(user);

        public void ApplyGift(User user)
        {
            if (user.Money > 100)
                user.Money += user.Money * 2;
        }
    }
}
