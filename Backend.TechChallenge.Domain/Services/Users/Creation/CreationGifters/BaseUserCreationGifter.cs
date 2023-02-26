using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public abstract class BaseUserCreationGifter<T> : IUserCreationGifter<T> where T : User
    {
        public abstract void ApplyGift(T user);
    }
}
