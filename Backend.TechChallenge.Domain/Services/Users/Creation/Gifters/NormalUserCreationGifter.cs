using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.Gifters
{
    public class NormalUserCreationGifter : IUserCreationGifter
    {
        public void ApplyCreationChanges(User user) =>
            ApplyGift(user);

        public void ApplyGift(User user)
        {
            if (user.Money > 100)
                user.Money += user.Money * 0.12m;
            else if (user.Money < 100 && user.Money > 10)
                user.Money += user.Money * 0.8m;
        }

        public UserType GetUserType() =>
            UserType.Normal;
    }
}
