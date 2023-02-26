using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Domain.Services.Email;

namespace Backend.TechChallenge.Domain.Services.Users.Creation
{
    public class EmailNormalizerCreationUserDecorator : BaseCreationUserDecorator
    {
        private readonly IEmailNormalizer _normalizer;

        public EmailNormalizerCreationUserDecorator(ICreationUserDecorator decorator, IEmailNormalizer normalizer) : base(decorator)
        {
            _normalizer = normalizer;
        }

        public override void ApplyCreationChanges(User user)
        {
            base.ApplyCreationChanges(user);

            user.Email = _normalizer.Normalize(user.Email);
        }
    }
}
