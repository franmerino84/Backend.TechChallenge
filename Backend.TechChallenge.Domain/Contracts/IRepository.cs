namespace Backend.TechChallenge.Domain.Contracts
{
    public interface IRepository<in T> : IRepository
    {
        Task Insert(T entity);
    }

    public interface IRepository
    {
        Task SaveChanges();

        Task Rollback();
    }
}