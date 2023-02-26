using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users
{
    public interface IUsersFactory
    {
        User BuildUser(string name, string email, string address, string phone, UserType userType, decimal money);
    }
}
