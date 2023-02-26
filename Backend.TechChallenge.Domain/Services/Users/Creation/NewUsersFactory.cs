using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation
{
    public class NewUsersFactory : INewUsersFactory
    {
        private readonly IUsersFactory _usersFactory;
        private readonly List<IUserCreationDecoratorFactory> _userDecoratorFactories;

        public NewUsersFactory(IUsersFactory usersFactory, IEnumerable<IUserCreationDecoratorFactory> userDecoratorFactories)
        {
            _usersFactory = usersFactory;
            _userDecoratorFactories = userDecoratorFactories.ToList();
        }

        public User CreateNewUser(string name, string email, string address, string phone, UserType userType, decimal money)
        {
            var user = _usersFactory.BuildUser(name, email, address, phone, userType, money);
            _userDecoratorFactories.ForEach(x => x.CreateUserDecorator(userType).ApplyCreationChanges(user));
            return user;
        }
    }
}
