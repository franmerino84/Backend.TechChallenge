using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.Email
{
    public class EmailNormalizerUserCreationModifierProvider : IUserCreationModifierProvider
    {
        private readonly IEmailNormalizerUserCreationModifier _modifier;

        public EmailNormalizerUserCreationModifierProvider(IEmailNormalizerUserCreationModifier modifier)
        {
            _modifier = modifier;
        }

        public IUserCreationModifier GetUserModifier(UserType userType) =>
            _modifier;
    }
}
