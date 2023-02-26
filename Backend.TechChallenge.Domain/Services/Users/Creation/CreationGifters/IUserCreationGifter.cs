using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public interface IUserCreationGifter
    {
        void ApplyGift(User user);
    }

}
