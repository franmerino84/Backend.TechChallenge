using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation
{
    public interface INewUsersFactory
    {
        User CreateNewUser(string name, string email, string address, string phone, UserType userType, decimal money);
    }
}