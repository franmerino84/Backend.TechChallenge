using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation.CreationGifters
{
    public class CreationGifterDecorator<T> : BaseCreationUserDecorator where T : User
    {
        private readonly IUserCreationGifter<T> _gifter;

        public CreationGifterDecorator(ICreationUserDecorator decorator, IUserCreationGifter<T> gifter) : base(decorator)
        {
            _gifter = gifter;
        }

        public override void ApplyCreationChanges(User user)
        {
            base.ApplyCreationChanges(user);

            _gifter.ApplyGift((T)user);
        }
    }
}
