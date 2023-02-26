namespace Backend.TechChallenge.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IUsersRepository UsersRepository { get; }

        Task SaveChanges();

        Task Rollback();
    }
}
