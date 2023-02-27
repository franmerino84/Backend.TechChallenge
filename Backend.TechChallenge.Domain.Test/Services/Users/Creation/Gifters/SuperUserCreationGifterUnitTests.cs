using Backend.TechChallenge.Domain.Services.Users.Creation.Gifters;
using Backend.TechChallenge.Domain.Test.Common;
using Xunit;

namespace Backend.TechChallenge.Domain.Test.Services.Users.Creation.Gifters
{
    public class SuperUserCreationGifterUnitTests
    {
        private readonly SuperUserCreationGifter _superUserCreationGifter;

        public SuperUserCreationGifterUnitTests()
        {
            _superUserCreationGifter = new SuperUserCreationGifter();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(40, 40)]
        [InlineData(100, 100)]
        [InlineData(200, 240)]
        [InlineData(400, 480)]
        [InlineData(600, 720)]
        public void ApplyGift_UserWithMoneyX_UserWithMoneyY(decimal money, decimal expected)
        {
            var user = DataProvider.GetValidSuperUser();
            user.Money = money;

            _superUserCreationGifter.ApplyGift(user);

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
            var user = DataProvider.GetValidSuperUser();
            user.Money = money;

            var user2 = DataProvider.GetValidSuperUser();
            user2.Money = money;

            _superUserCreationGifter.ApplyGift(user);
            _superUserCreationGifter.ApplyCreationChanges(user2);

            Assert.Equal(user2.Money, user.Money);
        }
    }
}
