using Backend.TechChallenge.Domain.Services.Users.Creation.Gifters;
using Backend.TechChallenge.Domain.Test.Common;
using Xunit;

namespace Backend.TechChallenge.Domain.Test.Services.Users.Creation.Gifters
{
    public class NormalUserCreationGifterUnitTests
    {
        private readonly NormalUserCreationGifter _normalUserCreationGifter;

        public NormalUserCreationGifterUnitTests()
        {
            _normalUserCreationGifter = new NormalUserCreationGifter();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(20, 36)]
        [InlineData(40, 72)]
        [InlineData(100, 180)] 
        [InlineData(200, 224)]
        [InlineData(400, 448)]
        public void ApplyGift_UserWithMoneyX_UserWithMoneyY(decimal money, decimal expected)
        {
            var user = DataProvider.GetValidNormalUser();
            user.Money = money;
            
            _normalUserCreationGifter.ApplyGift(user);

            Assert.Equal(expected, user.Money);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(40)]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(400)]
        public void ApplyGift_ApplyGiftAndApplyCreationChanges_SameMoney(decimal money)
        {
            var user = DataProvider.GetValidNormalUser();
            user.Money = money;

            var user2 = DataProvider.GetValidNormalUser();
            user2.Money = money;

            _normalUserCreationGifter.ApplyGift(user);
            _normalUserCreationGifter.ApplyCreationChanges(user2);

            Assert.Equal(user2.Money, user.Money);
        }
    }
}
