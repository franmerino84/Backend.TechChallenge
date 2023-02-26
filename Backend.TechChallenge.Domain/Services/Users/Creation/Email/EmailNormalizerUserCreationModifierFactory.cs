using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.Email
{
    public class EmailNormalizerUserCreationModifierFactory : IUserCreationModifierFactory
    {
        private readonly IEmailNormalizerUserCreationModifier _modifier;

        public EmailNormalizerUserCreationModifierFactory(IEmailNormalizerUserCreationModifier modifier)
        {
            _modifier = modifier;
        }

        public IUserCreationModifier CreateUserModifier(UserType userType) =>
            _modifier;
    }
}
