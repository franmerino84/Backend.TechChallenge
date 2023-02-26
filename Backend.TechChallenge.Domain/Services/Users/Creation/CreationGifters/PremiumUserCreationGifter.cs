using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public class PremiumUserCreationGifter : BaseUserCreationGifter<PremiumUser>
    {
        public override void ApplyGift(PremiumUser user)
        {
            if (user.Money > 100)
                user.Money += user.Money * 2;
        }
    }
}
