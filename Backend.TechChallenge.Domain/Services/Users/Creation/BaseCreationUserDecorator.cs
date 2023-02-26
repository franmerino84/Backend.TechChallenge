using Backend.TechChallenge.Domain.Entities.Users;

namespace Backend.TechChallenge.Domain.Services.Users.Creation
{
    public abstract class BaseCreationUserDecorator : ICreationUserDecorator
    {
        private readonly ICreationUserDecorator _decorator;

        protected BaseCreationUserDecorator(ICreationUserDecorator decorator)
        {
            _decorator = decorator;
        }

        public virtual void ApplyCreationChanges(User user)
        {
            _decorator.ApplyCreationChanges(user);
        }
    }
}
