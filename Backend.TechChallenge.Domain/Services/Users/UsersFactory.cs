using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users
{
    public class UsersFactory : IUsersFactory
    {
        public User BuildUser(string name, string email, string address, string phone, UserType userType, decimal money)
        {
            User user = userType switch
            {
                UserType.Normal => new NormalUser(name, email, address, phone, money),
                UserType.SuperUser => new SuperUser(name, email, address, phone, money),
                UserType.Premium => new PremiumUser(name, email, address, phone, money),
                _ => throw new NotImplementedException(),
            };
            return user;
        }
    }
}
