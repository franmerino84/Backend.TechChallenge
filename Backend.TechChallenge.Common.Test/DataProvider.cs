using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Test.Common
{
    public static class DataProvider
    {
        public static NormalUser GetValidNormalUser() =>
            new("name", "email@email.email", "address", "123456789", 0);

        public static PremiumUser GetValidPremiumUser() =>
            new("name", "email@email.email", "address", "123456789", 0);

        public static SuperUser GetValidSuperUser() =>
            new("name", "email@email.email", "address", "123456789", 0);

        public static string GetRandomPhone() =>
            $"+123 {new Random().Next(999999999):000000000}";

        public static string GetNewGuidStringWithoutHyphen() =>
            Guid.NewGuid().ToString().Replace("-", "");

        public static string GetRandomEmail() =>
            $"{GetNewGuidStringWithoutHyphen()}@{GetNewGuidStringWithoutHyphen()}.{GetNewGuidStringWithoutHyphen()}";
    }
}
