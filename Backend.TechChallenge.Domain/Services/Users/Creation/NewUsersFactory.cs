using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation
{
    public class NewUsersFactory : INewUsersFactory
    {
        private readonly IUsersFactory _usersFactory;
        private readonly List<IUserCreationModifierFactory> _userCreationModifierFactories;

        public NewUsersFactory(IUsersFactory usersFactory, IEnumerable<IUserCreationModifierFactory> userCreationModifierFactories)
        {
            _usersFactory = usersFactory;
            _userCreationModifierFactories = userCreationModifierFactories.ToList();
        }

        public User CreateNewUser(string name, string email, string address, string phone, UserType userType, decimal money)
        {
            var user = _usersFactory.BuildUser(name, email, address, phone, userType, money);
            _userCreationModifierFactories.ForEach(x => x.CreateUserModifier(userType).ApplyCreationChanges(user));
            return user;
        }
    }
}
