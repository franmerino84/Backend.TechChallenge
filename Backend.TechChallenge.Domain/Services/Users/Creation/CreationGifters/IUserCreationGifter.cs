using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public interface IUserCreationGifter<in T> : IUserCreationGifter where T : User
    {
        void ApplyGift(T user);
    }

    public interface IUserCreationGifter
    {

    }
}
