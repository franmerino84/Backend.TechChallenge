using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Domain.Services.Users.Creation.Email;
using Moq;
using Xunit;

namespace Backend.TechChallenge.Domain.Test.Services.Users.Creation.Email
{
    public class EmailNormalizerUserCreationModifierProviderUnitTests
    {
        private readonly Mock<IEmailNormalizerUserCreationModifier> _modifier;
        private readonly EmailNormalizerUserCreationModifierProvider _provider;

        public EmailNormalizerUserCreationModifierProviderUnitTests()
        {
            _modifier = new Mock<IEmailNormalizerUserCreationModifier>();
            _provider = new EmailNormalizerUserCreationModifierProvider(_modifier.Object);
        }

        [Theory]
        [InlineData(UserType.Premium)]
        [InlineData(UserType.SuperUser)]
        [InlineData(UserType.Normal)]
        public void GetUserModifier_AnyInput_SameModifierAsPassedByConstructor(UserType input)
        {
            var result = _provider.GetUserModifier(input);

            Assert.Same(_modifier.Object, result);
        }
    }
}
