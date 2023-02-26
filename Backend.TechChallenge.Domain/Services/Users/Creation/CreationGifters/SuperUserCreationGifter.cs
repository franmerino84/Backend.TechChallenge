using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public class SuperUserCreationGifter : BaseUserCreationGifter<SuperUser>
    {
        public override void ApplyGift(SuperUser user)
        {
            if (user.Money > 100)
                user.Money += user.Money * 0.2m;
        }
    }
}
