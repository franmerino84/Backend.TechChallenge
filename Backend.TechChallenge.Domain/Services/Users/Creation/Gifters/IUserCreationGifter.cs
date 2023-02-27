using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.Gifters
{
    public interface IUserCreationGifter : IUserCreationModifier
    {
        UserType GetUserType();
        void ApplyGift(User user);
    }

}
