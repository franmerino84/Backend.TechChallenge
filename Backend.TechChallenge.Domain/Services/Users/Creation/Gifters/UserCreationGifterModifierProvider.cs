using Backend.TechChallenge.Domain.Entities.Users;
using Backend.TechChallenge.Domain.Services.Users.Creation.Gifters;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public class UserCreationGifterModifierProvider : IUserCreationModifierProvider
    {
        private readonly Dictionary<UserType, IUserCreationGifter> _creationGifterMapper;

        public UserCreationGifterModifierProvider(IEnumerable<IUserCreationGifter> userCreationGifters) => 
            _creationGifterMapper = userCreationGifters.ToDictionary(x => x.GetUserType(), x => x);

        public IUserCreationModifier GetUserModifier(UserType userType)
        {
            if (!_creationGifterMapper.ContainsKey(userType))
                throw new NotImplementedException();

            return _creationGifterMapper[userType];
        }
    }
}
