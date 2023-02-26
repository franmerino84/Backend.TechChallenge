using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters;

namespace Backend.TechChallenge.Domain.Services.Users.Factories
{
    public class UsersFactory : IUsersFactory
    {
        public User BuildNewUser(string name, string email, string address, string phone, UserType userType, decimal money)
        {
            throw new NotImplementedException();
        }

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

        public IUserCreationGifter BuildUserCreationGifter(UserType userType)
        {
            return userType switch
            {
                UserType.Normal => new NormalUserCreationGifter(),
                UserType.SuperUser => new SuperUserCreationGifter(),
                UserType.Premium => new PremiumUserCreationGifter(),
                _ => throw new NotImplementedException(),
            };
        }

    }
}
