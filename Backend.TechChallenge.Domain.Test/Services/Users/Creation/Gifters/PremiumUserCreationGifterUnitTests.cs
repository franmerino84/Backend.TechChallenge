using Backend.TechChallenge.Domain.Services.Users.Creation.Gifters;
using Backend.TechChallenge.Domain.Test.Common;
using Xunit;

namespace Backend.TechChallenge.Domain.Test.Services.Users.Creation.Gifters
{
    public class PremiumUserCreationGifterUnitTests
    {
        private readonly PremiumUserCreationGifter _premiumUserCreationGifter;

        public PremiumUserCreationGifterUnitTests()
        {
            _premiumUserCreationGifter = new PremiumUserCreationGifter();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(40, 40)]
        [InlineData(100, 100)]
        [InlineData(200, 600)]
        [InlineData(400, 1200)]
        [InlineData(600, 1800)]
        public void ApplyGift_UserWithMoneyX_UserWithMoneyY(decimal money, decimal expected)
        {
            var user = DataProvider.GetValidPremiumUser();
            user.Money = money;

            _premiumUserCreationGifter.ApplyGift(user);

            Assert.Equal(expected, user.Money);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(40)]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(400)]
        [InlineData(600)]
        public void ApplyGift_ApplyGiftAndApplyCreationChanges_SameMoney(decimal money)
        {
            var user = DataProvider.GetValidPremiumUser();
            user.Money = money;

            var user2 = DataProvider.GetValidPremiumUser();
            user2.Money = money;

            _premiumUserCreationGifter.ApplyGift(user);
            _premiumUserCreationGifter.ApplyCreationChanges(user2);

            Assert.Equal(user2.Money, user.Money);
        }
    }
}
