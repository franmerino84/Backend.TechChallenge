using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Domain.Services.Email;
using Backend.TechChallenge.Domain.Services.Users.Creation.Email;
using Backend.TechChallenge.Domain.Test.Common;
using Moq;
using Xunit;

namespace Backend.TechChallenge.Domain.Test.Services.Users.Creation.Email
{
    public class EmailNormalizerUserCreationModifierUnitTests
    {
        private readonly Mock<IEmailNormalizer> _normalizer;
        private readonly EmailNormalizerUserCreationModifier _modifier;
        public EmailNormalizerUserCreationModifierUnitTests()
        {
            _normalizer = new Mock<IEmailNormalizer>();            
            _modifier = new EmailNormalizerUserCreationModifier(_normalizer.Object);
        }
        
        public static IEnumerable<object[]> DifferentUserTypes =>
            new List<object[]> { 
                new object[] { DataProvider.GetValidNormalUser() } , 
                new object[] { DataProvider.GetValidSuperUser() }, 
                new object[] { DataProvider.GetValidPremiumUser() } };
        
        [Theory]
        [MemberData(nameof(DifferentUserTypes))]
        public void ApplyCreationChanges_AnyUserType_OverwritesEmailWithNormalizedOverEmail(User user)
        {
            var email = DataProvider.GetRandomEmail();
            _normalizer.Setup(x => x.Normalize(user.Email)).Returns(email);

            _modifier.ApplyCreationChanges(user);

            Assert.Equal(email, user.Email);
        }
    }
}
