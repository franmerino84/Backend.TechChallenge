using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.Gifters
{
    public class SuperUserCreationGifter : IUserCreationGifter
    {
        public void ApplyCreationChanges(User user) =>
            ApplyGift(user);


        public void ApplyGift(User user)
        {
            if (user.Money > 100)
                user.Money += user.Money * 0.2m;
        }

        public UserType GetUserType() => 
            UserType.SuperUser;
    }
}
