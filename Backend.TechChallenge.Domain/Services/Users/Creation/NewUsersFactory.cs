using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation
{
    public class NewUsersFactory : INewUsersFactory
    {
        private readonly IUsersFactory _usersFactory;
        private readonly List<IUserCreationModifierProvider> _userCreationModifierProviders;

        public NewUsersFactory(IUsersFactory usersFactory, IEnumerable<IUserCreationModifierProvider> userCreationModifierProviders)
        {
            _usersFactory = usersFactory;
            _userCreationModifierProviders = userCreationModifierProviders.ToList();
        }

        public User CreateNewUser(string name, string email, string address, string phone, UserType userType, decimal money)
        {
            var user = _usersFactory.BuildUser(name, email, address, phone, userType, money);
            _userCreationModifierProviders.ForEach(provider => provider.GetUserModifier(userType).ApplyCreationChanges(user));
            return user;
        }
    }
}
