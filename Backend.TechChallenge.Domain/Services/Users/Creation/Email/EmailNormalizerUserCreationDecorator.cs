using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Domain.Services.Email;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.Email
{
    public class EmailNormalizerUserCreationDecorator : IEmailNormalizerUserCreationDecorator
    {
        private readonly IEmailNormalizer _normalizer;

        public EmailNormalizerUserCreationDecorator(IEmailNormalizer normalizer)
        {
            _normalizer = normalizer;
        }

        public void ApplyCreationChanges(User user) =>
            user.Email = _normalizer.Normalize(user.Email);

    }
}
