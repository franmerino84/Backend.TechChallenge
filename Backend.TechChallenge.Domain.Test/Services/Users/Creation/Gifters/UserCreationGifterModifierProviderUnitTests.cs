using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters;
using Backend.TechChallenge.Domain.Services.Users.Creation.Gifters;
using Xunit;

namespace Backend.TechChallenge.Domain.Test.Services.Users.Creation.Gifters
{
    public class UserCreationGifterModifierProviderUnitTests
    {
        private readonly UserCreationGifterModifierProvider _provider;

        public UserCreationGifterModifierProviderUnitTests() => 
            _provider = new UserCreationGifterModifierProvider(new List<IUserCreationGifter> { NormalUserCreationGifter, SuperUserCreationGifter, PremiumUserCreationGifter });

        public static IEnumerable<object[]> UserTypesAndCreationGifters =>
            new List<object[]> {
                new object[] { UserType.Normal, NormalUserCreationGifter } ,
                new object[] { UserType.Premium, PremiumUserCreationGifter },
                new object[] { UserType.SuperUser, SuperUserCreationGifter } };

        public static NormalUserCreationGifter NormalUserCreationGifter { get; set; } = new();
        public static SuperUserCreationGifter SuperUserCreationGifter { get; set; } = new();
        public static PremiumUserCreationGifter PremiumUserCreationGifter { get; set; } = new();

        [Theory]
        [MemberData(nameof(UserTypesAndCreationGifters))]
        public void GetUserModifier_DifferentUserTypes_CorrespondingCreationGifter(UserType userType, IUserCreationGifter expected)
        {
            var result = _provider.GetUserModifier(userType);

            Assert.Same(expected, result);
        }
    }
}
