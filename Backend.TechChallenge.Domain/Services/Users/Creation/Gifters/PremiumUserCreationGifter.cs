using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.Gifters
{
    public class PremiumUserCreationGifter : IUserCreationGifter
    {
        public void ApplyCreationChanges(User user) =>
            ApplyGift(user);

        public void ApplyGift(User user)
        {
            if (user.Money > 100)
                user.Money += user.Money * 2;
        }

        public UserType GetUserType() =>
            UserType.Premium;
    }
}
