using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    internal class NormalUserCreationGifter : BaseUserCreationGifter<NormalUser>
    {
        public override void ApplyGift(NormalUser user)
        {
            if (user.Money > 100)
                user.Money += user.Money * 0.12m;
            else if (user.Money < 100 && user.Money > 10)
                user.Money += user.Money * 0.8m;
        }
    }
}
